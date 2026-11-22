using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserSocial.Areas.Persistence.Extensions;
using UserSocial.Core.Models.Domains;
using UserSocial.Core.Service;
using UserSocial.Core.ViewModels;
using UserSocial.Persistence;

namespace UserSocial.Controllers
{
    public class SocialLinkController : Controller
    {
        private readonly ApplicationDbContext _context;

        private ILinkSocialService _linkSocialService;

        public SocialLinkController(ApplicationDbContext context,ILinkSocialService linkSocialService)
        {
            _context = context;
            _linkSocialService = linkSocialService;
        }

        [Authorize]
        public IActionResult MySocialLink()
        {
            var actualUserId = User.GetUserId();

            var links = _context.LinkSocials.Where(x => x.UserId == actualUserId).ToList();

            var model = new SocialLinkViewModel
            {
                Links = links
            };

            return View("MySocialLink", model);
        }

        public IActionResult MySocialLinks(int id = 0)
        {
            var userId = User.GetUserId();

            var linkSocial = id == 0 ?
                new LinkSocial { Id = 0, UserId = userId, } : _linkSocialService.Get(id, userId);

            var vm = new SocialLinkViewModel
            {
                LinkSocial = linkSocial,
                Heading = id == 0 ? "Dodawanie nowego zadania" : "Edytowanie zadania",
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MySocialLinks(LinkSocial linkSocial)
        {
            var userId = User.GetUserId();
            linkSocial.UserId = userId;


            if (!ModelState.IsValid)
            {
                var vm = new SocialLinkViewModel
                {
                    LinkSocial = linkSocial,
                    Heading = linkSocial.Id == 0 ? "Dodawanie nowego zadania" : "Edytowanie zadania",
                };

                return View("MySocialLinks", vm);
            }

            if (linkSocial.Id == 0)
                _linkSocialService.Add(linkSocial);
            else
                _linkSocialService.Update(linkSocial);


            return RedirectToAction("MySocialLink");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var userId = User.GetUserId();
                _linkSocialService.Delete(id, userId);

            }
            catch (Exception ex)
            {
                //logowanie do pliku
                return Json(new { success = false, message = ex.Message });
            }

            return Json(new { success = true });
        }

    }
}

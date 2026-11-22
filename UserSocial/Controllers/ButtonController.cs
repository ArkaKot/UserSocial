using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserSocial.Areas.Persistence.Extensions;
using UserSocial.Core.Models.Domains;
using UserSocial.Core.Service;
using UserSocial.Core.ViewModels;
using UserSocial.Persistence;

namespace UserSocial.Controllers
{
    public class ButtonController : Controller
    {
        private readonly ApplicationDbContext _context;

        private IButton _button;

        public ButtonController(ApplicationDbContext context, IButton button)
        {
            _context = context;
            _button = button;
        }


        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Button()
        {
            var actualUserId = User.GetUserId();

            var buttons = _context.Buttons.Where(x => x.UserId == actualUserId).ToList();

            var model = new ButtonViewModel
            {
               Buttons = buttons
            };

            return View("Button", model);
        }

        public IActionResult Buttons(int id = 0)
        {
            var userId = User.GetUserId();

            var button = id == 0 ?
                new Button { Id = 0, UserId = userId, } : _button.Get(id, userId);

            var vm = new ButtonViewModel
            {
                Button = button,
                Heading = id == 0 ? "Dodawanie nowego zadania" : "Edytowanie zadania",
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Buttons(Button button)
        {
            var userId = User.GetUserId();
            button.UserId = userId;


            if (!ModelState.IsValid)
            {
                var vm = new ButtonViewModel
                {
                    Button = button,
                    Heading = button.Id == 0 ? "Dodawanie nowego zadania" : "Edytowanie zadania",
                };

                return View("Buttons", vm);
            }

            if (button.Id == 0)
                _button.Add(button);
            else
                _button.Update(button);


            return RedirectToAction("Button");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var userId = User.GetUserId();
                _button.Delete(id, userId);

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
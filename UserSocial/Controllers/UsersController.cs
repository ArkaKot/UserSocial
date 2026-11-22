using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserSocial.Areas.Persistence.Extensions;
using UserSocial.Core.Models;
using UserSocial.Core.Models.Domains;
using UserSocial.Core.Repositories;
using UserSocial.Core.ViewModels;
using static System.Collections.Specialized.BitVector32;

namespace UserSocial.Controllers
{
    

    public class UsersController : Controller
    {
        private UserManager<ApplicationUser> _applicationUser;

        private readonly UserRepository _userRepository;

        public UsersController(UserManager<ApplicationUser> applicationUsers, UserRepository userRepository)
        {
            _applicationUser = applicationUsers;
            _userRepository = userRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            var actualUserId = User.GetUserId();

            var model = new UsersViewModel
            {
                Users = _applicationUser.Users.Where(x => x.Id != actualUserId).OrderByDescending(x => x.Id).Take(5).ToList()
            };

            return View("~/Views/User/Users.cshtml",model);
        }

        [Authorize]
        public async Task<IActionResult> UserCompleteProfileAsync()
        {
            var actualUserId = User.GetUserId();

            var user = await _applicationUser.FindByIdAsync(actualUserId);


            if (user == null)
                return NotFound();


            return View("~/Views/User/UserCompleteProfile.cshtml");
        }

        [HttpGet]
        public async Task<IActionResult> UserCompleteProfile()
        {
            var userId = User.GetUserId();

            var user = await _applicationUser.FindByIdAsync(userId);

            if (user == null)
                return NotFound();

            return View("~/Views/User/UserCompleteProfile.cshtml", user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserCompleteProfile(ApplicationUser model)
        {
            var userId = User.GetUserId();

            var user = await _applicationUser.FindByIdAsync(userId);

            if (user == null)
                return NotFound();

            user.NameAccount = model.NameAccount;
            user.Description = model.Description;
            user.Picture = model.Picture;

            await _applicationUser.UpdateAsync(user);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Users()
        {
            var userId = User.GetUserId();

            var vm = new UsersViewModel
            {
                FilterTasks = new FilterTasks(),
                Users = _userRepository.Get(userId),
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Users(UsersViewModel model)
        {
            var userId = User.GetUserId();

            var users = _userRepository.Get(userId, model.FilterTasks.Email);

            return PartialView("~/Views/User/_UsersTable.cshtml", users);
        }
    }
}

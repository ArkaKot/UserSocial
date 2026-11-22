using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserSocial.Core.Models.Domains;
using UserSocial.Core.Service;
using UserSocial.Persistence;


namespace UserSocial.Controllers
{
    public class MyPageController : Controller
    {
        private UserManager<ApplicationUser> _applicationUser;
        private ApplicationDbContext _context;


        private IButton _button;

        public MyPageController(UserManager<ApplicationUser> applicationUser, IButton button,ApplicationDbContext context)
        {
           _applicationUser = applicationUser;
            _button = button;
            _context = context;

        }
        public  IActionResult MyPage(string Name)
        {
            var user =  _context.Users
                .Include(u => u.LinkSocials)
                .Include(x => x.Buttons)
                .FirstOrDefault(y => y.UserName == Name);
               
           
            return View(user);
        }
    }
}

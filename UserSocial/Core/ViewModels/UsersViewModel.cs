using UserSocial.Core.Models;
using UserSocial.Core.Models.Domains;

namespace UserSocial.Core.ViewModels
{
    public class UsersViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; }

        public FilterTasks FilterTasks { get; set; }
    }
}

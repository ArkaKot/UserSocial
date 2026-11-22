using Microsoft.AspNetCore.Identity;
using UserSocial.Core.Models.Domains;

namespace UserSocial.Core.Repositories
{
    public class UserRepository
    {
        private UserManager<ApplicationUser> _applicationUser;

        public UserRepository(UserManager<ApplicationUser> applicationUser)
        {
            _applicationUser = applicationUser;
        }
        public IEnumerable<ApplicationUser> Get(string id, string email = null)
        {
            var users = _applicationUser.Users.Where(x => x.Id != id);

            if (!string.IsNullOrWhiteSpace(email))
                users = users.Where(x => x.Email.Contains(email));

            return users.OrderBy(x => x.Email).ToList();

        }
    }
}

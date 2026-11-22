using UserSocial.Core.Models.Domains;

namespace UserSocial.Core.Service
{
    public interface IButton
    {
        IEnumerable<Button> Get(string userId, string title = null);

        Button Get(int id, string userId);

        void Add(Button button);

        void Update(Button button);

        void Delete(int id, string userId);
    }
}

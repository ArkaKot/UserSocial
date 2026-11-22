using UserSocial.Core.Models.Domains;

namespace UserSocial.Core.Service
{
    public interface ILinkSocialService
    {
        IEnumerable<LinkSocial> Get(string userId, string title = null);

        LinkSocial Get(int id, string userId);

        void Add(LinkSocial linkSocial);

        void Update(LinkSocial linkSocial);

        void Delete(int id, string userId);
    }
}

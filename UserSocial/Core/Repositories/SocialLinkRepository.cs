using UserSocial.Core.Models.Domains;
using UserSocial.Core.Service;
using UserSocial.Persistence;

namespace UserSocial.Core.Repositories
{
    public class SocialLinkRepository : ILinkSocialService
    {
        private readonly ApplicationDbContext _context;

        public SocialLinkRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<LinkSocial> Get(string userId, string title = null)
        {
            var links = _context.LinkSocials
                .Where(x => x.UserId == userId);


            if (!string.IsNullOrWhiteSpace(title))
                links = links.Where(x => x.Title.Contains(title));

            return links.OrderBy(x => x.Title).ToList();
        }

        public LinkSocial Get(int id, string userId)
        {
            var links = _context.LinkSocials.Single(x => x.Id == id && x.UserId == userId);

            return links;
        }

        public void Add(LinkSocial linkSocial)
        {
            _context.LinkSocials.Add(linkSocial);
            _context.SaveChanges();
        }

        public void Update(LinkSocial linkSocial)
        {
            var linkSocialToUpdate = _context.LinkSocials.Single(x => x.Id == linkSocial.Id);

            linkSocialToUpdate.Link = linkSocial.Link;
            linkSocialToUpdate.Title = linkSocial.Title;

            _context.SaveChanges();
        }

        public void Delete(int id, string userId)
        {

            var linkSocialToDelete = _context.LinkSocials.Single(x => x.Id == id && x.UserId == userId);

            _context.LinkSocials.Remove(linkSocialToDelete);

            _context.SaveChanges();
        }
    }
}

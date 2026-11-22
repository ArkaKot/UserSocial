using UserSocial.Core.Models.Domains;

namespace UserSocial.Core.ViewModels
{
    public class SocialLinkViewModel
    {
        public string Heading { get; set; }

        public LinkSocial LinkSocial { get; set; }
        public IEnumerable<LinkSocial> Links { get; set; }
    }
}

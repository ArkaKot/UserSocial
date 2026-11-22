using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace UserSocial.Core.Models.Domains
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Buttons = new Collection<Button>();
            LinkSocials = new Collection<LinkSocial>();
        }

        [Display(Name = "Nazwa konta")]
        public string? NameAccount { get; set; }

        [Display(Name = "Opis")]
        public string? Description { get; set; }

        [Url]
        public string? Picture { get; set; }
       
        public ICollection<Button> Buttons { get; set; }
        public ICollection<LinkSocial> LinkSocials { get; set; }


    }
}

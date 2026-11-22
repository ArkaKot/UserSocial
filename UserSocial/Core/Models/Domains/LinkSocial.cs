using System.ComponentModel.DataAnnotations;

namespace UserSocial.Core.Models.Domains
{
    public class LinkSocial
    {
     
        public int Id { get; set; }

        public string UserId { get; set; }

        [Required]
        [Display(Name = "Nazwa linku")]
        [MaxLength(6, ErrorMessage ="Nazwa linku może zawierać maksymalnie 6 znaków")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Adres")]
       
        public string Link { get; set; }


        public ApplicationUser? User { get; set; }
    }
}

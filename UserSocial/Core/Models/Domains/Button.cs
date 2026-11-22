using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace UserSocial.Core.Models.Domains
{
    public class Button
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nazwa przycisku")]
        [MaxLength(20, ErrorMessage = "Nazwa przycisku może zawierać maksymalnie 20 znaków")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Adres")]
        public string Url { get; set; }

        [Display(Name = "Kolor")]
        public string? Color { get; set; }

        public string UserId { get; set; }

        public ApplicationUser? User { get; set; }
    }
}

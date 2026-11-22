using UserSocial.Core.Models.Domains;

namespace UserSocial.Core.ViewModels
{
    public class ButtonViewModel
    {
        public string Heading { get; set; }

        public Button Button { get; set; }
        public IEnumerable<Button> Buttons { get; set; }
    }
}

using UserSocial.Core.Models.Domains;
using UserSocial.Core.Service;
using UserSocial.Persistence;

namespace UserSocial.Core.Repositories
{
    public class ButtonRepository : IButton
    {
        private readonly ApplicationDbContext _context;
        public ButtonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Button> Get(string userId, string name = null)
        {
            var buttons = _context.Buttons
                .Where(x => x.UserId == userId);


            if (!string.IsNullOrWhiteSpace(name))
                buttons = buttons.Where(x => x.Name.Contains(name));

            return buttons.OrderBy(x => x.Name).ToList();
        }

        public Button Get(int id, string userId)
        {
            var buttons = _context.Buttons.Single(x => x.Id == id && x.UserId == userId);

            return buttons;
        }

        public void Add(Button button)
        {
            _context.Buttons.Add(button);
            _context.SaveChanges();
        }

        public void Update(Button button)
        {
            var buttonToUpdate = _context.Buttons.Single(x => x.Id == button.Id);

            buttonToUpdate.Name = button.Name;
            buttonToUpdate.Url = button.Url;
            buttonToUpdate.Color = button.Color;

            _context.SaveChanges();
        }

        public void Delete(int id, string userId)
        {

            var buttonToDelete = _context.Buttons.Single(x => x.Id == id && x.UserId == userId);

            _context.Buttons.Remove(buttonToDelete);

            _context.SaveChanges();
        }
    }
}

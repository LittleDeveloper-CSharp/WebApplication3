using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly UserService _userService;

        public EditModel(UserService userService)
        {
            _userService = userService;
        }

        [BindProperty(SupportsGet = true)]
        public UserEditViewModel UserVM { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            var user = await _userService.Get(id);

            if (user == null)
                return RedirectToPage("Index");

            UserVM = new UserEditViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = id,
                Patronymic = user.Patronymic
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userService.Get(UserVM.Id);

            if (user == null)
            {
                return Page();
            }

            user.FirstName = UserVM.FirstName;
            user.LastName = UserVM.LastName;
            user.Patronymic = UserVM.Patronymic;

            await _userService.Update(user);

            return RedirectToPage("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using WebApplication3.Database;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly UserService _userService;

        [BindProperty(SupportsGet = true)]
        public UserCreateViewModel UserVM { get; set; }
        
        public CreateModel(UserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
            UserVM = new UserCreateViewModel();
        }

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var user = new User
            {
                FirstName = UserVM.FirstName,
                LastName = UserVM.LastName,
                Patronymic = UserVM.Patronymic
            };

            await _userService.Create(user);

            return RedirectToPage("Index");
        }
    }
}

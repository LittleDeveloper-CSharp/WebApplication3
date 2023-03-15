using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly UserService _userService;

        public IEnumerable<UserListViewModel> UserList { get; set; }

        public IndexModel(UserService userService)
        {
            _userService = userService;
        }

        public async Task OnGet()
        {
            UserList = await _userService.GetListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _userService.Delete(id);
            return RedirectToAction("OnGet");
        }
    }
}

using LoginApp_Kealit.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace LoginApp_Kealit.Pages
{
    public class LoginModel : PageModel
    {
        private readonly LoginDbContext _context;

        public LoginModel(LoginDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Message { get; set; }

        public IActionResult OnPost()
        {
            var user = _context.Users
                .FirstOrDefault(u =>
                     u.Email == Email &&
                     u.Password == Password);

            if (user != null)
            {
                HttpContext.Session.SetString("User", user.Name);

                return RedirectToPage("/Index");
            }

            Message = "Invalid Email or Password ❌";

            return Page();
        }
    }
}
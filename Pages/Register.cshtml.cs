using LoginApp_Kealit.Data;
using LoginApp_Kealit.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace LoginApp_Kealit.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly LoginDbContext _context;

        public RegisterModel(LoginDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User NewUser { get; set; }

        public string Message { get; set; }

        public IActionResult OnPost()
        {
            var existingUser = _context.Users
                .FirstOrDefault(x =>
                    x.Email == NewUser.Email);

            if (existingUser != null)
            {
                Message = "Email already exists ❌";

                return Page();
            }

            NewUser.Roles = "User";

            _context.Users.Add(NewUser);

            _context.SaveChanges();

            Message = "Register Success ✅";

            return Page();
        }
    }
}
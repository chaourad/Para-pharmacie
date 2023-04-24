using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using paraMvc.Data;
using paraMvc.Data.Services;
using paraMvc.Data.Static;
using paraMvc.Data.ViewModels;
using paraMvc.Models;
using System.Data.Entity;

namespace paraMvc.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;
      

        public AccountController( AppDbContext context)
        {
          
            _context = context;
        }
      
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> User()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }


        public IActionResult Login() => View();

      
        [HttpPost]

        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            //if (!ModelState.IsValid) return View(loginVM);

            var loggedUser = _context.ApplicationUsers.Where(e =>

             e.PasswordHash == loginVM.Password && e.Email == loginVM.EmailAddress
         );
            if (loggedUser != null && loggedUser.Count() > 0)
            {

                if (loggedUser.Where(e => e.Role == UserRoles.User).Count() > 0)
                {
                    return RedirectToAction("Index", "Product");
                }
                else if (loggedUser.Where(e => e.Role == UserRoles.Admin).Count() > 0)
                {
                    return RedirectToAction("Index", "Account");


                }
            }
            else
            {
                //
            }

            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(loginVM);
        }




        public IActionResult Register() => View(new RegisterVM());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);




            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerVM);
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress,
                PasswordHash = registerVM.Password,
                Role = UserRoles.User,
            };


            var newUserResponse = await _context.ApplicationUsers.AddAsync(newUser);


            await _context.SaveChangesAsync();

            return View("RegisterCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Product");
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }
    }
}

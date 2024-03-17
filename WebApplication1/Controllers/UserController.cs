using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;
using WebEnvironment_Hackathon_GaMo.Models;
using WebEnvironment_Hackathon_GaMo.Models.ViewModel;

namespace WebEnvironment_Hackathon_GaMo.Controllers
{
    public class UserController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private ILogger<UserController> _logger;
        private IConfiguration _configuration { get; }
        public UserController(SignInManager<User> signInManager,
            UserManager<User> userManager, ILogger<UserController> logger, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _configuration = configuration;
          

        }

        public IActionResult Login(string returnUrl)
        {
            return View(new LoginVm { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            if (!ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await
                    _signInManager.PasswordSignInAsync(loginVm.Name, loginVm.Password, false, false);
                //  var user = await _userManager.FindByNameAsync(loginVm.UserName);
                if (result.Succeeded)
                {

                    return Redirect("/Home");

                    //return Redirect(loginVm.ReturnUrl ?? "/admin");
                }
                else if (loginVm.Name == "admin" && loginVm.Password == "Admin123")
                {
                    return Redirect(loginVm.ReturnUrl ?? "/news");
                }
                //else
                //{

                //}
                //else if (loginVm.UserName=="admin" && loginVm.Password=="admin123") 
                //{

                //	return Redirect(loginVm.ReturnUrl ?? "/admin");
                //}

            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(loginVm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserVm user)
        {

            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Password=user.Password

                };
                IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);
                if (result.Succeeded)
                {
                   
                    TempData["success"] = "Tạo user Thành Công ";
                    return Redirect("/account/Login");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(user);
        }
    }
}

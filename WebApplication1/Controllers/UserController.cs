﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;
using WebEnvironment_Hackathon_GaMo.Models;
using WebEnvironment_Hackathon_GaMo.Models.ViewModel;
using WebEnvironment_Hackathon_GaMo.Services;

namespace WebEnvironment_Hackathon_GaMo.Controllers
{
    public class UserController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private EmailSender _emailsender;
        private ILogger<UserController> _logger;
        private IConfiguration _configuration { get; }
        public UserController(SignInManager<User> signInManager,
            UserManager<User> userManager, ILogger<UserController> logger, IConfiguration configuration, EmailSender emailSender)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _configuration = configuration;
            _emailsender = emailSender;
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

                    return Redirect("/home");

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
                    Location=user.Location,
                    permission="User",
                    Email=user.Email,
                    //Password=user.Password
                    
                };
                IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                    token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
                    var callbackUrl = Url.Page(
                     "/User/login",
                     pageHandler: null,
                     values: new { area = "Identity", userId = user.Id, token = token, returnUrl = "Clicking me" },
                     protocol: Request.Scheme);
                     _emailsender.SendEmail(user.Email, "Confirm your Email",
                     $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                     _logger.LogInformation("User created a new account with password.");
                     TempData["success"] = "Tạo user Thành Công ";
                     return Redirect("/user/Login");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(user);
        }
        public async Task<IActionResult> LogOut(string ReturnUrl = "/home")
        {
            await _signInManager.SignOutAsync();
            return Redirect(ReturnUrl);
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mvc_WebApp_Level2.Models;
using Mvc_WebApp_Level2.Models.ViewModels;

namespace Mvc_WebApp_Level2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> _UserManager, SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _UserManager;
            signInManager = _signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                //Create Account
                ApplicationUser user = new ApplicationUser();
                user.UserName = userVM.UserName;
                user.PasswordHash = userVM.Password;
                user.Email = userVM.Email;
                user.Branch = userVM.Branch;
                user.Grade = userVM.Grade;
                IdentityResult result = await userManager.CreateAsync(user, userVM.Password);
                if (result.Succeeded)//true
                {
                    //Create Cookie
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("index", "Home");
                }
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(userVM);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)//1st Layer
            {
                //check Existance by Name
                ApplicationUser? user = await userManager.FindByNameAsync(loginModel.UserName);
                if (user != null)//2nd Layer
                {
                    //Check Correction of Password
                    bool found = await userManager.CheckPasswordAsync(user, loginModel.Password);
                    if (found)//3rd Layer
                    {
                        //Successful Login : Sign In the user
                        await signInManager.SignInAsync(user, loginModel.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "Password Isn't Correct!");
                    return View(loginModel);
                }
                ModelState.AddModelError("", "User Name isn't Exist!");
            }
            return View(loginModel);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}

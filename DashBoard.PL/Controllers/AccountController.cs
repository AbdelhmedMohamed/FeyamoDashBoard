using DashBoard.PL.ViewModels;
using Feyamo.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DashBoard.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager ,SignInManager<ApplicationUser> signInManager)
        {
           _userManager = userManager;
           _signInManager = signInManager;

        }

        #region SignUp

        [HttpGet]
        [Authorize]
        public IActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        [Authorize]
        public  async Task<IActionResult> SignUp(SignUpViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    FName = viewModel.FName,
                    LName = viewModel.LName,
                    UserName = viewModel.Email.Split("@")[0] ,
                    Email = viewModel.Email,
                    IsAgree = viewModel.IsAgree,
                };

           var Result  = await _userManager.CreateAsync(user,viewModel.Password);

                if (Result.Succeeded)
                {
                    return RedirectToAction(nameof(SignIn));
                }
                foreach (var Error in Result.Errors)
                {
                    ModelState.AddModelError(string.Empty,Error.Description );
                }

            }
            return View(viewModel);
        }

        #endregion


        #region SignIn

        [HttpGet]

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> SignIn(SignInViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(viewModel.Email);
                if (user is not null)
                {
                    bool flag = await _userManager.CheckPasswordAsync(user, viewModel.Password);
                    if (flag)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction(nameof(HomeController.Index),"Home");
                        }
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid Login");
            } 
            return View(viewModel);
        }
        #endregion



        [Authorize]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }




    }
}

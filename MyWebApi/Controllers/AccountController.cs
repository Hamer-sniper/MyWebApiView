using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyWebApiView.Authentification;
using MyWebApiView.Interfaces;
using System.Xml.Linq;

namespace MyWebApiView.Controllers
{
    public class AccountController : Controller
    {

        //private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _signInManager;
        private readonly IDataBookData dataBookData;

        public AccountController(IDataBookData dBData)
        {
            //_userManager = userManager;
            //_signInManager = signInManager;
            dataBookData = dBData;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            if (string.IsNullOrWhiteSpace(returnUrl)) returnUrl = "/";

            return View(new UserLogin()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogin model)
        {
            if (string.IsNullOrWhiteSpace(model.ReturnUrl)) model.ReturnUrl = "/";

            if (ModelState.IsValid)
            {
                /*var loginResult = await _signInManager.PasswordSignInAsync(model.LoginProp,
                    model.Password,
                    false,
                    lockoutOnFailure: false);

                if (loginResult.Succeeded)
                {
                    if (Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    return RedirectToAction("Index", "DataBook");
                }*/

                HttpContext.Response.Cookies.Append(".AspNetCore.Application.Id",
                    dataBookData.GetTokenString(model.LoginProp, model.Password),
        new CookieOptions
        {
            MaxAge = TimeSpan.FromMinutes(60)
        });

                //dataBookData.GetToken(model.LoginProp, model.Password);
                return RedirectToAction("Index", "DataBook");
            }

            ModelState.AddModelError("", "Пользователь не найден");
            return View(model);
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View(new UserRegistration());
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistration model)
        {
            if (ModelState.IsValid)
            {
                /*var user = new User { UserName = model.LoginProp };
                var createResult = await _userManager.CreateAsync(user, model.Password);

                if (createResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "DataBook");
                }
                else
                {
                    foreach (var identityError in createResult.Errors) 
                    {
                        ModelState.AddModelError("", identityError.Description);
                    }
                }*/

                dataBookData.Register(model.LoginProp, model.Password);
                return RedirectToAction("Index", "DataBook");
            }

            return View(model);
        }


        [HttpPost]
        public IActionResult Logout()
        {
            dataBookData.RemoveTokenFromClient();
            return RedirectToAction("Index", "DataBook");
        }

        [HttpGet]
        public IActionResult AccessDenied(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AccessDenied(UserLogin model)
        {
            return RedirectToAction("Index", "DataBook");
        }
    }
}
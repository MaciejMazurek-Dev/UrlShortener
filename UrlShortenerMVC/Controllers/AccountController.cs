using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using UrlShortenerMVC.Models.ViewModels;

namespace UrlShortenerMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ILogger<AccountController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser { UserName = registerModel.Email, Email = registerModel.Email };
                IdentityResult result = await _userManager.CreateAsync(user, registerModel.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("New user account created.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(registerModel);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result =
                    await _signInManager.PasswordSignInAsync(
                    loginModel.Email,
                    loginModel.Password,
                    isPersistent: false,
                    lockoutOnFailure: false);

                if(result.Succeeded)
                {
                    _logger.LogInformation($"User: {loginModel.Email} logged in.");
                    return RedirectToAction("Index");
                }else
                {
                    ModelState.AddModelError(string.Empty, "Invalid email or password.");
                    return View(loginModel);
                }
            }
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            string? userName = User.Identity?.Name;
            await _signInManager.SignOutAsync();
            _logger.LogInformation($"User: {userName} logged out.");
            return RedirectToAction("Index", "Home");
        }
    }
}

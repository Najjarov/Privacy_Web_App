using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Privacy_Web_App.Models;

namespace Privacy_Web_App.Controllers
{
    [Authorize(Roles = "Admin, Owner")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult UserList()
        {
           

            return View();
        }

        public IActionResult UserAccess()
        {
            




            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {

            
            
            var vm = new RegisterViewModel();

            var allRoles = _roleManager.Roles.ToList();
            vm.RolesList = new SelectList(allRoles, "Id", "Name");
            

            return View(vm);




            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
            public async Task<IActionResult> Register(RegisterViewModel model)
       {
           
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName=model.UserName,
                    
                };
               var result = await _userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    var roleid = model.RoleName;
                    var role = _roleManager.FindByIdAsync(roleid);
                    



                    await _userManager.AddToRoleAsync(user, role.Result.Name);
                    
                    return RedirectToAction("Index", "Home");

                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel loginData)
        {
            if (ModelState.IsValid)
            {
                
               
               
                
                var result = await _signInManager.PasswordSignInAsync(loginData.UserName, loginData.Password, loginData.RememberMe, false);
                if (result.Succeeded)
                {
                   




                    return RedirectToAction("index", "Home");
                     

                }
                ModelState.AddModelError("", "Invalid Login Attempt!");

            }



            return View(loginData);
        }

        [HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");

        }
    }
}

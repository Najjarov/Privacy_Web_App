using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Privacy_Web_App.DataContext;

namespace Privacy_Web_App.Controllers
{
    [Authorize]
    public class ToolsController : Controller
    {
        private readonly dbContext dbContext;
        private readonly IMapper _mapper;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ViewsController _viewsController;


        public ToolsController(IMapper mapper, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, ViewsController viewsController)
        {
            _mapper = mapper;
            dbContext = new dbContext();

            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _viewsController = viewsController;
        }

        public async Task<IActionResult> Mini_Game()
        {
            var viewno = 1;
            var user = await _userManager.GetUserAsync(User);
            var roles = await _userManager.GetRolesAsync(user);
           

            var menu = _viewsController.getmenusaccess();


            foreach (var menuitem in await menu)
            {


                string str = "menu" + menuitem;

                ViewData.Add(str, menuitem.ToString());
            }
            ViewBag.title = "Mini Game";
            return View();
        }

        public async Task<IActionResult> Magic_Generator()
        {
            var viewno = 2;
            var user = await _userManager.GetUserAsync(User);
            var roles = await _userManager.GetRolesAsync(user);


            var menu = _viewsController.getmenusaccess();


            foreach (var menuitem in await menu)
            {


                string str = "menu" + menuitem;

                ViewData.Add(str, menuitem.ToString());
            }

            ViewBag.title = "Magic Generator";
            return View();
        }
        public async Task<IActionResult> Weapon_Simulator()
        {
            var viewno = 3;
            var user = await _userManager.GetUserAsync(User);
            var roles = await _userManager.GetRolesAsync(user);


            var menu = _viewsController.getmenusaccess();


            foreach (var menuitem in await menu)
            {


                string str = "menu" + menuitem;

                ViewData.Add(str, menuitem.ToString());
            }
            ViewBag.title = "Weapon Simulator";
            return View();
        }



       
    }
}

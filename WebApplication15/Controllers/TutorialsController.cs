using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Privacy_Web_App.DataContext;
using Privacy_Web_App.Models;



namespace Privacy_Web_App.Controllers
{
   
        public class TutorialsController : Controller
        {
            private readonly dbContext dbContext;
            private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
         private readonly ViewsController _viewsController;

        public TutorialsController(IMapper mapper, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, ViewsController viewsController)
        {
                _mapper = mapper;
                dbContext = new dbContext();
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _viewsController = viewsController;
        }
        public async Task<IActionResult> did_you_know()
        {
            var menuaccess = _viewsController.getmenusaccess();
            //var menu = _viewsController.getmenus();


            //ViewData["main"] = menu.mains;
            //ViewData["sub"] = menu.subs;
            foreach (var menuitem in await menuaccess)
            {


                string str = "menu" + menuitem;

                ViewData.Add(str, menuitem.ToString());
            }

            //var viewno = 9;
            //var user = await _userManager.GetUserAsync(User);
            //var roles = await _userManager.GetRolesAsync(user);


            //var menu = _homecontroller.getmenusaccess();


            //foreach (var menuitem in menu)
            //{


            //    string str = "menu" + menuitem;

            //    ViewData.Add(str, menuitem.ToString());
            //}

            var didvids = dbContext.did_you_know_vids.ToList();
            var mappeddidvids = _mapper.Map<IEnumerable<did_you_know_vid>, IEnumerable<DidYouKnowViewModel>>(didvids);
            ViewBag.Title = "Did You Know";
            return View(mappeddidvids);


           
        }
        public async Task<IActionResult> tutorial_videos()
        {
            var menuaccess = _viewsController.getmenusaccess();
            //var menu = _viewsController.getmenus();


            //ViewData["main"] = menu.mains;
            //ViewData["sub"] = menu.subs;
            foreach (var menuitem in await menuaccess)
            {


                string str = "menu" + menuitem;

                ViewData.Add(str, menuitem.ToString());
            }

            //var viewno = 10;
            //var user = await _userManager.GetUserAsync(User);
            //var roles = await _userManager.GetRolesAsync(user);


            //var menu = _homecontroller.getmenusaccess(roles.FirstOrDefault());


            //foreach (var menuitem in menu)
            //{


            //    string str = "menu" + menuitem;

            //    ViewData.Add(str, menuitem.ToString());
            //}


            var tutvids = dbContext.tutorial_vids.ToList();
            var mappedtutvids = _mapper.Map<IEnumerable<tutorial_vid>, IEnumerable<TutorialVidsViewModel>>(tutvids);

            ViewBag.Title = "Tutorial Videos";
            return View(mappedtutvids);

           
        }
        public async Task<IActionResult> Visual_tutorials()
        {
            var menuaccess = _viewsController.getmenusaccess();
            //var menu = _viewsController.getmenus();


            //ViewData["main"] = menu.mains;
            //ViewData["sub"] = menu.subs;
            foreach (var menuitem in await menuaccess)
            {


                string str = "menu" + menuitem;

                ViewData.Add(str, menuitem.ToString());
            }

            //var viewno = 11;
            //var user = await _userManager.GetUserAsync(User);
            //var roles = await _userManager.GetRolesAsync(user);


            //var menu = _homecontroller.getmenusaccess(roles.FirstOrDefault());


            //foreach (var menuitem in menu)
            //{


            //    string str = "menu" + menuitem;

            //    ViewData.Add(str, menuitem.ToString());
            //}


            var tuts = dbContext.visual_tuts.ToList();
            var mappedtuts = _mapper.Map<IEnumerable<visual_tut>, IEnumerable<VisualTutsViewModel>>(tuts);

            ViewBag.Title = "Visual Tutorials";
            return View(mappedtuts);


        }
    }
}

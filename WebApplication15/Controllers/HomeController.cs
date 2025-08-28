using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Privacy_Web_App.DataContext;
using Privacy_Web_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Privacy_Web_App.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dbContext _dbContext;
        private readonly IMapper mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ViewsController _viewsController;



        public HomeController(ILogger<HomeController> logger, dbContext dbContext, IMapper _mapper, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ViewsController viewsController)
        {
            _logger = logger;

            _dbContext = dbContext;

            mapper = _mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _viewsController = viewsController;
        }

        public async Task<IActionResult> Index()
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

            return View();
        }

       

        


        public IActionResult Home()
        {

           

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public async Task<List<int>> getmenusaccess()
        {

            var user = await _userManager.GetUserAsync(User);
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.FirstOrDefault() == "Owner" || roles.FirstOrDefault() == "Admin" )
            {
                var viewList2 = new List<int>();
                var list2 = _dbContext.views.ToList();
                foreach (var item in list2)
                {
                    viewList2.Add(item.Id);
                }
                return viewList2;
            }


            var list = _dbContext.viewsaccesses.Where(x => x.role_name == roles.FirstOrDefault()).ToList();
            var viewList = new List<int>();

            foreach (var item in list)
            {
                viewList.Add(item.view_id);
            }
            return viewList;

        }

    }
}

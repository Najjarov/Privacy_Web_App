using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Privacy_Web_App.DataContext;
using Privacy_Web_App.Models;
using System.Collections.Generic;

namespace Privacy_Web_App.Controllers
{
    [Authorize]
    public class ViewsController : Controller
    {
        private readonly ILogger<ViewsController> _logger;
        private readonly dbContext _dbContext;
        private readonly IMapper mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public ViewsController(ILogger<ViewsController> logger, dbContext dbContext, IMapper _mapper, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;

            _dbContext = dbContext;

            mapper = _mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<int>> getmenusaccess()
        {

            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.FirstOrDefault() == "Owner" || roles.FirstOrDefault() == "Admin")
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
        public  MenuViewModel getmenus()
        {
            var viewmodel = new MenuViewModel();
            var main_menu = _dbContext.menu_mains.ToList ();
            var mappedmain_menu = mapper.Map<IEnumerable<MainMenuModel>>(main_menu);
            var sub_menu = _dbContext.menu_subs.ToList();
            var mappedsub_menu = mapper.Map < IEnumerable<SubMenuModel>>(sub_menu);
            viewmodel.mains = mappedmain_menu;
            viewmodel.subs = mappedsub_menu;
            return viewmodel;
        }
        //public async Task<string> getRoles()
        //{

        //    var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        //    var roles = await _userManager.GetRolesAsync(user);
        //    string Role = roles.FirstOrDefault();
        //    return Role;
        //}
        public List<ViewsModel> getMapTabs(int map_id)
        {
            var viewList2 = new List<ViewsModel>();
            var sec = "maps";

            var views = _dbContext.views.Where(x=>x.section==sec);
            var mappedview = mapper.Map<List<ViewsModel>>(views);

            var poisCount = _dbContext.Landing_pois.Where(x=>x.map_id==map_id).Count();
            if (poisCount > 0)
            {
                var item = new ViewsModel();
                item= mappedview.Where(x=>x.id==5).FirstOrDefault();
                item.status = "active";
                viewList2.Add(item);

            }



           
            var spawnCount = _dbContext.map_spawn_rates.Where(x => x.map_id == map_id).Count();

            if (spawnCount > 0)
            {
                var item = new ViewsModel();
                item = mappedview.Where(x => x.id == 6).FirstOrDefault();
                item.status = "active";
                viewList2.Add(item);

            }
            var lootCount = _dbContext.map_loots.Where(x => x.map_id == map_id).Count();

            if (lootCount > 0)
            {
                var item = new ViewsModel();
                item = mappedview.Where(x => x.id == 7).FirstOrDefault();
                item.status = "active";
                viewList2.Add(item);

            }


            var evacsCount = _dbContext.evacs.Where(x => x.map_id == map_id).Count();
            var altersCount = _dbContext.alter_voids.Where(x => x.map_id == map_id).Count();
            var valkCount = _dbContext.Valk_ults.Where(x => x.map_id == map_id).Count();
            var climbsCount = _dbContext.climbs.Where(x => x.map_id == map_id).Count();
            var ratsCount = _dbContext.rat_spots.Where(x => x.map_id == map_id).Count();

            if (evacsCount > 0 || valkCount > 0 || climbsCount > 0 || altersCount > 0 || ratsCount > 0)
            {
                var item = new ViewsModel();
                item = mappedview.Where(x => x.id == 8).FirstOrDefault();
                item.status = "active";
                viewList2.Add(item);

            }

            var towersCount = _dbContext.jump_towers.Where(x => x.map_id == map_id).Count();
            if (towersCount > 0)
            {
                var item = new ViewsModel();
                item = mappedview.Where(x => x.id == 12).FirstOrDefault();
                item.status = "active";
                viewList2.Add(item);

            }
            var uavsCount = _dbContext.uav_ranges.Where(x => x.map_id == map_id).Count();
            if (uavsCount > 0)
            {
                var item = new ViewsModel();
                item = mappedview.Where(x => x.id == 13).FirstOrDefault();
                item.status = "active";
                viewList2.Add(item);

            }

            var spotsCount = _dbContext.playable_spots.Where(x => x.map_id == map_id).Count();
            if (spotsCount > 0)
            {
                var item = new ViewsModel();
                item = mappedview.Where(x => x.id == 14).FirstOrDefault();
                item.status = "active";
                viewList2.Add(item);

            }
            return viewList2;

           

        }

        public IEnumerable<MapModel> getMaps()
        {
            var maps = _dbContext.maps.ToList();

            var mappedMaps = mapper.Map<IEnumerable<MapModel>>(maps);
            
            return mappedMaps;
        }

        }
}

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Privacy_Web_App.DataContext;
using Privacy_Web_App.Models;
using System.Data;
using System.Linq;

namespace Privacy_Web_App.Controllers
{
    [Authorize]
    public class MapController : Controller
    {
        private readonly ILogger<MapController> _logger;
        private readonly dbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ViewsController _viewsController;

        public MapController(ILogger<MapController> logger, IMapper mapper, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, ViewsController viewsController)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = new dbContext();
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _viewsController = viewsController;
           
        }
        public async Task<IActionResult> pois(int id)
        {
           
            var viewModel = new MapsViewModel();
            var mapdata = _dbContext.maps.Find(id);

            var MappedMap = _mapper.Map<MapModel>(mapdata);


            var pois = _dbContext.Landing_pois.Where(x => x.map_id == id).ToList();
            var Mappedpois = _mapper.Map<IEnumerable<LandingPoiModel>>(pois);

            if (pois.Count() == 0)
            {
                return RedirectToAction("spawn_rates",new {id = id});
            }

            var currentAction = "pois";
            var viewno = _dbContext.views.Where(x=>x.action_name== currentAction).FirstOrDefault().Id;

            var menu = _viewsController.getmenusaccess();

           

            foreach (var menuitem in await menu)
            {


                string str = "menu" + menuitem;

                ViewData.Add(str, menuitem.ToString());
            }

            viewModel.views = _viewsController.getMapTabs(id);
          var maps = _viewsController.getMaps();

            foreach (var map in maps)
            {




                int count = mapDataCount(map.Id);






                if (count > 0)
                {
                    string str = "map" + map.Id;


                    ViewData.Add(str, "Yes");
                }
            }

            viewModel.map = MappedMap;
           
            viewModel.pois = Mappedpois;
           viewModel.maps = maps;
            ViewBag.Title = MappedMap.Name + " Pois";
            ViewBag.current = currentAction;
            ViewBag.map_img = MappedMap.img;

            return View(viewModel);
        }


        public async Task<IActionResult> spawn_rates(int id)
        {
            var viewModel = new MapSpawnModel();


            var spawn = _dbContext.map_spawn_rates.Include(x => x.map).Where(x => x.map_id == id).FirstOrDefault();
            var mappedspawn = _mapper.Map<MapSpawnModel>(spawn);

            if (spawn == null)
            {
                return RedirectToAction("loot", new { id = id });
            }
            viewModel = mappedspawn;

            ViewBag.Title = mappedspawn.map_name + " Spawn Rates";


            var currentAction = "spawn_rates";
            var viewno = _dbContext.views.Where(x => x.action_name == currentAction).FirstOrDefault().Id;

            var menu = _viewsController.getmenusaccess();



            foreach (var menuitem in await menu)
            {


                string str = "menu" + menuitem;

                ViewData.Add(str, menuitem.ToString());
            }

            
            var maps = _viewsController.getMaps();

            foreach (var map in maps)
            {

                int count = mapDataCount(map.Id);
                if (count > 0)
                {
                    string str = "map" + map.Id;


                    ViewData.Add(str, "Yes");
                }
            }
            var mapdata = _dbContext.maps.Find(id);
            var MappedMap = _mapper.Map<MapModel>(mapdata);
            viewModel.map = MappedMap;
            viewModel.views = _viewsController.getMapTabs(id);
            viewModel.maps = maps;
            ViewBag.map_img = MappedMap.img;
            ViewBag.current = currentAction;
            return View(viewModel);
        }
        public async Task<IActionResult> playable_spots(int id)
        {
            var viewModel = new playable_spots_Model();


            var spots = _dbContext.playable_spots.Include(x => x.map).Where(x => x.map_id == id).FirstOrDefault();
            var mappedspots = _mapper.Map<playable_spots_Model>(spots);

            if (spots == null)
            {
                return RedirectToAction("loot", new { id = id });
            }
            viewModel = mappedspots;

            ViewBag.Title = mappedspots.Map_Name + " Playable Spots";


            var currentAction = "playable_spots";
            var viewno = _dbContext.views.Where(x => x.action_name == currentAction).FirstOrDefault().Id;

            var menu = _viewsController.getmenusaccess();



            foreach (var menuitem in await menu)
            {


                string str = "menu" + menuitem;

                ViewData.Add(str, menuitem.ToString());
            }


            var maps = _viewsController.getMaps();

            foreach (var map in maps)
            {

                int count = mapDataCount(map.Id);
                if (count > 0)
                {
                    string str = "map" + map.Id;


                    ViewData.Add(str, "Yes");
                }
            }
            var mapdata = _dbContext.maps.Find(id);
            var MappedMap = _mapper.Map<MapModel>(mapdata);
            viewModel.map = MappedMap;
            viewModel.views = _viewsController.getMapTabs(id);
            viewModel.maps = maps;
            ViewBag.map_img = MappedMap.img;
            ViewBag.current = currentAction;
            return View(viewModel);
        }
        public async Task<IActionResult> loot(int id)
        {
            var viewModel = new MapLootModel();


            var loot = _dbContext.map_loots.Include(x => x.map).Where(x => x.map_id == id).FirstOrDefault();
            var mappedloot = _mapper.Map<MapLootModel>(loot);

            if (loot==null)
            {
                return RedirectToAction("evacs", new { id = id });
            }
            viewModel = mappedloot;

            ViewBag.Title = mappedloot.map_name + " Loot";


           
            var currentAction = "loot";
            var viewno = _dbContext.views.Where(x => x.action_name == currentAction).FirstOrDefault().Id;

            var menu = _viewsController.getmenusaccess();



            foreach (var menuitem in await menu)
            {


                string str = "menu" + menuitem;

                ViewData.Add(str, menuitem.ToString());
            }


            var maps = _viewsController.getMaps();

            foreach (var map in maps)
            {

                int count = mapDataCount(map.Id);
                if (count > 0)
                {
                    string str = "map" + map.Id;


                    ViewData.Add(str, "Yes");
                }
            }
            var mapdata = _dbContext.maps.Find(id);
            var MappedMap = _mapper.Map<MapModel>(mapdata);
            viewModel.map = MappedMap;
            ViewBag.current = currentAction;
            viewModel.maps = maps;
            ViewBag.map_img = MappedMap.img;
            viewModel.views = _viewsController.getMapTabs(id);
            return View(viewModel);
        }
        public async Task<IActionResult> poi(int id)
        {
            var viewno = 5;
            var user = await _userManager.GetUserAsync(User);
            var roles = await _userManager.GetRolesAsync(user);


            var menu = _viewsController.getmenusaccess();


            foreach (var menuitem in await menu)
            {


                string str = "menu" + menuitem;

                ViewData.Add(str, menuitem.ToString());
            }
            var viewModel = new poiViewModel();

            var poidata = _dbContext.Landing_pois.Find(id);
            var MappedPoi = _mapper.Map<LandingPoiModel>(poidata);

            var lootInfo = _dbContext.loot_infos.Where(x => x.poi_id == id).FirstOrDefault();
            var Mappedlootinfo = _mapper.Map<lootInfoModel>(lootInfo);

            var lootdetailInfo = _dbContext.loot_detail_infos.Where(x => x.poi_id == id).FirstOrDefault();
            var Mappeddetaillootinfo = _mapper.Map<lootDetailInfoModel>(lootdetailInfo);
            var mapdata = _dbContext.maps.Find(poidata.map_id);

            var MappedMap = _mapper.Map<MapModel>(mapdata);


            viewModel.poiData = MappedPoi;
            viewModel.lootInfol = Mappedlootinfo;
            viewModel.lootDetailInfo = Mappeddetaillootinfo;
           
            ViewBag.Title = MappedPoi.Name +" - " +MappedMap.Name;
            var lastPoiId = _dbContext.Landing_pois.OrderBy(x => x.Id).Last();
            ViewBag.Lastrow = lastPoiId.Id;
            ViewBag.mapid = poidata.map_id;
            ViewBag.map_name = MappedMap.Name;
            ViewBag.map_img = MappedMap.img;
            return View(viewModel);


        }
   
    public async Task<IActionResult>Interactive_Map(int id)
    {
           
            
            var viewModel = new InteractiveMapViewModel();

            var evacs = _dbContext.evacs.Where(x=>x.map_id == id).ToList();
            var mappedEvacs = _mapper.Map<IEnumerable<evacModel>>(evacs);

            var voids = _dbContext.alter_voids.Where(x => x.map_id == id).ToList();
            var mappedvoids = _mapper.Map<IEnumerable<alter_void_Model>>(voids);
                  var rats = _dbContext.rat_spots.Where(x => x.map_id == id).ToList();
            var mappedrats = _mapper.Map<IEnumerable<rats_Model>>(rats);
            var climbs = _dbContext.climbs.Where(p => p.map_id == id);
            var mappedclimbs = _mapper.Map<IEnumerable<climbModel>>(climbs);
            var valks = _dbContext.Valk_ults.Where(p => p.map_id == id);
            var mappedvalks = _mapper.Map<IEnumerable<valkModel>>(valks);

            var currentAction = "Interactive_Map";
            var viewno = _dbContext.views.Where(x => x.action_name == currentAction).FirstOrDefault().Id;

            var menu = _viewsController.getmenusaccess();

            if (evacs.Count() == 0 && climbs.Count() == 0 && valks.Count() == 0)
            {
                return RedirectToAction("jump_towers", new { id = id });
            }

            foreach (var menuitem in await menu)
            {


                string str = "menu" + menuitem;

                ViewData.Add(str, menuitem.ToString());
            }


            var maps = _viewsController.getMaps();

            foreach (var map in maps)
            {

                int count = mapDataCount(map.Id);
                if (count > 0)
                {
                    string str = "map" + map.Id;


                    ViewData.Add(str, "Yes");
                }
            }
            var mapdata = _dbContext.maps.Find(id);
            var MappedMap = _mapper.Map<MapModel>(mapdata);
            viewModel.map = MappedMap;
            viewModel.maps = maps;
            ViewBag.map_img = MappedMap.img;
            ViewBag.Title = MappedMap.Name + " Interactive Map";
            ViewBag.current = currentAction;
            viewModel.evacs=mappedEvacs;
            viewModel.climbs=mappedclimbs;
            viewModel.valks = mappedvalks;
            viewModel.voids = mappedvoids;
            viewModel.rats = mappedrats;
            viewModel.Map_id = id;
            viewModel.views = _viewsController.getMapTabs(id);
            return View(viewModel);

    }
        public async Task<IActionResult> Jump_Towers(int id)
        {
            
            var viewModel = new jumpTowerViewModel();

            var jumpTowers = _dbContext.jump_towers.Where(x => x.map_id == id).ToList();
            var mappedTowers = _mapper.Map<List<jumpTowerModel>>(jumpTowers);

            if (jumpTowers.Count() == 0)
            {
                return RedirectToAction("pois", new { id = id });
            }


            ViewBag.Title = "Jump Towers";

            var currentAction = "Jump_Towers";
            var viewno = _dbContext.views.Where(x => x.action_name == currentAction).FirstOrDefault().Id;

            var menu = _viewsController.getmenusaccess();



            foreach (var menuitem in await menu)
            {


                string str = "menu" + menuitem;

                ViewData.Add(str, menuitem.ToString());
            }


            var maps = _viewsController.getMaps();

            foreach (var map in maps)
            {

                int count = mapDataCount(map.Id);
                if (count > 0)
                {
                    string str = "map" + map.Id;


                    ViewData.Add(str, "Yes");
                }
            }
            ViewBag.current = currentAction;
            viewModel.maps = maps;
            viewModel.towers = mappedTowers;
            ViewBag.mapid= id;
            var mapdata = _dbContext.maps.Find(id);
            var MappedMap = _mapper.Map<MapModel>(mapdata);
            viewModel.map = MappedMap;
            ViewBag.map_img = MappedMap.img;
            viewModel.views = _viewsController.getMapTabs(id);
            return View(viewModel);

        }
        public int mapDataCount(int id)
        {
            var count = _dbContext.Landing_pois.Where(x => x.map_id == id).Count();
            var count2 = _dbContext.map_spawn_rates.Where(x => x.map_id == id).Count();
            var count3 = _dbContext.map_loots.Where(x => x.map_id == id).Count();
            var count4 = _dbContext.evacs.Where(x => x.map_id == id).Count();
            var count5 = _dbContext.Valk_ults.Where(x => x.map_id == id).Count();
            var count6 = _dbContext.climbs.Where(x => x.map_id == id).Count();
            var count7 = _dbContext.jump_towers.Where(x => x.map_id == id).Count();
            var count8 = _dbContext.alter_voids.Where(x => x.map_id == id).Count();
            var count9 = _dbContext.rat_spots.Where(x => x.map_id == id).Count();
            var count10 = _dbContext.playable_spots.Where(x => x.map_id == id).Count();
            var AllCounts = count + count2 + count3 + count4 + count5+count6 + count7+count8 + count9 + count10;

            return AllCounts;
        }
        public async Task<IActionResult> Uav_Ranges(int id)
        {

            var viewModel = new Uav_Range_ViewModel();

            var uav_Ranges = _dbContext.uav_ranges.Where(x => x.map_id == id).ToList();
            var mappeduavs = _mapper.Map<List<Uav_Range_Model>>(uav_Ranges);

            if (uav_Ranges.Count() == 0)
            {
                return RedirectToAction("pois", new { id = id });
            }


            ViewBag.Title = "UAV Ranges";

            var currentAction = "Uav_Ranges";
            var viewno = _dbContext.views.Where(x => x.action_name == currentAction).FirstOrDefault().Id;

            var menu = _viewsController.getmenusaccess();



            foreach (var menuitem in await menu)
            {


                string str = "menu" + menuitem;

                ViewData.Add(str, menuitem.ToString());
            }


            var maps = _viewsController.getMaps();

            foreach (var map in maps)
            {

                int count = mapDataCount(map.Id);
                if (count > 0)
                {
                    string str = "map" + map.Id;


                    ViewData.Add(str, "Yes");
                }
            }
            ViewBag.current = currentAction;
            viewModel.maps = maps;
            viewModel.uavs = mappeduavs;
            ViewBag.mapid = id;
            var mapdata = _dbContext.maps.Find(id);
            var MappedMap = _mapper.Map<MapModel>(mapdata);
            viewModel.map = MappedMap;
            ViewBag.map_img = MappedMap.img;
            viewModel.views = _viewsController.getMapTabs(id);
            return View(viewModel);

        }
       
    }
}
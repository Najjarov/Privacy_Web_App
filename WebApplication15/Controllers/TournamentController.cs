using AutoMapper;
using Elfie.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Privacy_Web_App.DataContext;
using Privacy_Web_App.Models;
using System.Security.Principal;

namespace Privacy_Web_App.Controllers
{
    [Authorize]
    public class TournamentController : Controller
    {
        private readonly dbContext _dbcontext;
        private readonly IMapper _mapper;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ViewsController _viewsController;



        public TournamentController(IMapper mapper, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, ViewsController viewsController)
        {
            _dbcontext = new dbContext();
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _viewsController = viewsController;
        }

        public async Task<IActionResult> List()
        {

            //var viewno = 4;
            //var user = await _userManager.GetUserAsync(User);
            //var roles = await _userManager.GetRolesAsync(user);
            //var menu = _homecontroller.getmenusaccess(roles.FirstOrDefault());
            //foreach (var menuitem in menu)
            //{
            //    string str = "menu" + menuitem;
            //    ViewData.Add(str, menuitem.ToString());
            //} var menu = _viewsController.getmenusaccess();
            var menu = _viewsController.getmenusaccess();


            foreach (var menuitem in await menu)
            {


                string str = "menu" + menuitem;

                ViewData.Add(str, menuitem.ToString());
            }

            var tours = _dbcontext.tournaments.ToList();
            var mappedtour = _mapper.Map<IEnumerable<tournament>, IEnumerable<TournamentModel>>(tours);

            foreach (var tour in mappedtour)
            {
                var rotations = _dbcontext.team_rotations.Where(x=>x.tour_id== tour.Id).Count();

                if(rotations > 0) { 
                string str = "tour" + tour.Id;
                ViewData.Add(str, "yes");
                }
            }








            return View(mappedtour);





        }
        public async Task<IActionResult> TeamStats(int Id,int teamid)
        {
            var menu = _viewsController.getmenusaccess();



            foreach (var menuitem in await menu)
            {


                string str = "menu" + menuitem;

                ViewData.Add(str, menuitem.ToString());
            }
            //var viewno = 4;
            //var user = await _userManager.GetUserAsync(User);
            //var roles = await _userManager.GetRolesAsync(user);
            //var menu = _homecontroller.getmenusaccess(roles.FirstOrDefault());
            //foreach (var menuitem in menu)
            //{
            //    string str = "menu" + menuitem;
            //    ViewData.Add(str, menuitem.ToString());
            //}
            var teamviewmodel = new TeamStatViewModel();

            var teaminfo = _dbcontext.Teams.Include(x=>x.region).FirstOrDefault(x=>x.Id == teamid);

            

            var mappedteam = _mapper.Map<Team, TeamModel>(teaminfo);
            var mappedteaminfo = _mapper.Map<TeamModel, TeamInfoModel>(mappedteam);

           

            var tourplayers = _dbcontext.tour_players.Where(x=>x.team_id == teamid && x.tour_id == Id).Include(x=>x.team).Include(x => x.player).Include(x => x.tour).ToList();
            var mappedtourplayers = _mapper.Map<IEnumerable<tour_player>, IEnumerable<TourPlayerModel>>(tourplayers);

            var tourcoaches = _dbcontext.tour_coaches.Where(x => x.team_id == teamid && x.tour_id == Id).Include(x => x.coach).Include(x => x.team).Include(x => x.tour).ToList();
            var mappedtourcoaches = _mapper.Map<IEnumerable<tour_coach>, IEnumerable<TourCoachModel>>(tourcoaches);

            var tourstats = _dbcontext.tour_stats.Where(x=>x.tour_id == Id && x.team_id == teamid).Include(x => x.team).Include(x => x.tour).Include(x => x.Legend_1).Include(x => x.Legend_2).Include(x => x.Legend_3).ToList();
            var mappedtourstats = _mapper.Map<IEnumerable<tour_stat>, IEnumerable<TournamentStatsModel>>(tourstats);


            var tourteamstats = _dbcontext.tour_team_stats.Where(x => x.team_id == teamid && x.tour_id == Id).Include(x => x.tour).Include(x => x.team).Include(x => x.pois).ToList();
            var mappedtourteamstats = _mapper.Map<IEnumerable<tour_team_stat>, IEnumerable<TourTeamStatsModel>>(tourteamstats);



            var tour = _dbcontext.tournaments.Find(Id);
            ViewBag.tourid = Id;
            ViewBag.tourname = tour.tour_name;
            ViewBag.touryear = tour.year;

            var map1 = _dbcontext.maps.Find(tour.map1_id);
            var map2 = _dbcontext.maps.Find(tour.map2_id);

            var map1id = map1.Id;
            var map2id = map2.Id;

            var tourteammapstats1= _dbcontext.tour_team_map_stats.Where(x => x.team_id == teamid && x.tour_id == Id && x.map_id == map1id).Include(x => x.tour).Include(x => x.team).Include(x => x.pois).Include(x => x.map).ToList();
            var mappedtourteammapstats1 = _mapper.Map<IEnumerable<tour_team_map_stat>, IEnumerable<TourTeamMapStatsModel>>(tourteammapstats1);
            var tourteammapstats2 = _dbcontext.tour_team_map_stats.Where(x => x.team_id == teamid && x.tour_id == Id && x.map_id == map2id).Include(x => x.tour).Include(x => x.team).Include(x => x.pois).Include(x => x.map).ToList();
            var mappedtourteammapstats2 = _mapper.Map<IEnumerable<tour_team_map_stat>, IEnumerable<TourTeamMapStatsModel>>(tourteammapstats2);

            var tourteamovermeta = _dbcontext.tour_team_stats_overall_meta.Where(x => x.team_id == teamid && x.tour_id == Id).Include(x => x.tour).Include(x => x.team).Include(x => x.legend_Id_1Navigation).Include(x => x.legend_Id_2Navigation).Include(x => x.legend_Id_3Navigation).ToList();
            var mappedtourteamovermeta = _mapper.Map<IEnumerable<tour_team_stats_overall_metum>, IEnumerable<TourTeamOverMetaModel>>(tourteamovermeta);

            var tourteammapmeta1 = _dbcontext.tour_team_stats_map_meta.Where(x => x.team_id == teamid && x.tour_id == Id && x.map_id == map1id).Include(x => x.tour).Include(x => x.team).Include(x => x.map).Include(x => x.legend_Id_1Navigation).Include(x => x.legend_Id_2Navigation).Include(x => x.legend_Id_3Navigation).ToList();
            var mappedtourteammapmeta1 = _mapper.Map<IEnumerable<tour_team_stats_map_metum>, IEnumerable<TourTeamMapMetaModel>>(tourteammapmeta1);
            var tourteammapmeta2 = _dbcontext.tour_team_stats_map_meta.Where(x => x.team_id == teamid && x.tour_id == Id && x.map_id == map2id).Include(x => x.tour).Include(x => x.team).Include(x => x.map).Include(x => x.legend_Id_1Navigation).Include(x => x.legend_Id_2Navigation).Include(x => x.legend_Id_3Navigation).ToList();
            var mappedtourteammapmeta2 = _mapper.Map<IEnumerable<tour_team_stats_map_metum>, IEnumerable<TourTeamMapMetaModel>>(tourteammapmeta2);


            var tourteamoverinvmeta = _dbcontext.tour_team_stats_overall_inv_meta.Where(x => x.team_id == teamid && x.tour_id == Id).Include(x => x.tour).Include(x => x.team).Include(x => x.legend).ToList();
            var mappedtourteamoverinvmeta = _mapper.Map<IEnumerable<tour_team_stats_overall_inv_metum>, IEnumerable<TourTeamOverInvMetaModel>>(tourteamoverinvmeta);

            var tourteammapinvmeta1 = _dbcontext.tour_team_stats_map_inv_meta.Where(x => x.team_id == teamid && x.tour_id == Id && x.map_id == map1id).Include(x => x.tour).Include(x => x.team).Include(x => x.legend).Include(x => x.map).ToList();
            var mappedtourteammapinvmeta1 = _mapper.Map<IEnumerable<tour_team_stats_map_inv_metum>, IEnumerable<TourTeamMapInvMetaModel>>(tourteammapinvmeta1);
            var tourteammapinvmeta2 = _dbcontext.tour_team_stats_map_inv_meta.Where(x => x.team_id == teamid && x.tour_id == Id && x.map_id == map2id).Include(x => x.tour).Include(x => x.team).Include(x => x.legend).Include(x => x.map).ToList();
            var mappedtourteammapinvmeta2 = _mapper.Map<IEnumerable<tour_team_stats_map_inv_metum>, IEnumerable<TourTeamMapInvMetaModel>>(tourteammapinvmeta2);



            teamviewmodel.Id = mappedteaminfo.Id;
            teamviewmodel.team_name = mappedteaminfo.team_name;
            teamviewmodel.team_name_shortcut = mappedteaminfo.team_name_shortcut;
            teamviewmodel.region_id = mappedteaminfo.region_id;
            teamviewmodel.region_Name = mappedteaminfo.region_Name;
            teamviewmodel.team_img = mappedteaminfo.team_img;
            teamviewmodel.players = mappedtourplayers;
            teamviewmodel.coaches = mappedtourcoaches;
            teamviewmodel.tourstats = mappedtourstats;
            teamviewmodel.tourTeamStats = mappedtourteamstats;




            teamviewmodel.mapStats1 = mappedtourteammapstats1;
            teamviewmodel.mapStats2 = mappedtourteammapstats2;

            teamviewmodel.overMeta = mappedtourteamovermeta;
            teamviewmodel.overMapMeta1 = mappedtourteammapmeta1;
            teamviewmodel.overMapMeta2 = mappedtourteammapmeta2;

            teamviewmodel.overInvMeta = mappedtourteamoverinvmeta;
            teamviewmodel.overMapInvMeta1 = mappedtourteammapinvmeta1;
            teamviewmodel.overMapInvMeta2 = mappedtourteammapinvmeta2;

            ViewBag.map1_name = map1.map_name;
            ViewBag.map2_name = map2.map_name;



            return View(teamviewmodel);

        }

        public async Task<IActionResult> Stats(int id)
        {
            var menu = _viewsController.getmenusaccess();



            foreach (var menuitem in await menu)
            {


                string str = "menu" + menuitem;

                ViewData.Add(str, menuitem.ToString());
            }
            //var viewno = 4;
            //var user = await _userManager.GetUserAsync(User);
            //var roles = await _userManager.GetRolesAsync(user);
            //var menu = _homecontroller.getmenusaccess(roles.FirstOrDefault());
            //foreach (var menuitem in menu)
            //{
            //    string str = "menu" + menuitem;
            //    ViewData.Add(str, menuitem.ToString());
            //}
            var viewModel = new TournamentStatsViewModel();
            var tour = _dbcontext.tour_stats.Where(x => x.tour_id == id).Include(x => x.tour).Include(x => x.team).Include(x=>x.Legend_1).Include(x => x.Legend_2).Include(x => x.Legend_3).ToList();
            
            var mappedtour= _mapper.Map<IEnumerable<tour_stat>, IEnumerable<TournamentStatsModel>>(tour);
            var tourObj = _dbcontext.tournaments.Find(id);

            var map1id = tourObj.map1_id;
            var map2id = tourObj.map2_id;

            var metastats = _dbcontext.tour_team_meta.Where(x => x.tour_id == id).Include(x=>x.legend_Id_1Navigation).Include(x => x.legend_Id_2Navigation).Include(x => x.legend_Id_3Navigation).ToList().OrderByDescending(x=>x.total);
            var mappedmetastats = _mapper.Map<IEnumerable<tour_team_metum>, IEnumerable< TourOverMetaModel>>(metastats);

            var mapstats1 = _dbcontext.tour_map_stats.Include(x => x.legend1).Include(x => x.legend2).Include(x => x.legend3).Where(x => x.tour_id == id && x.map_id == map1id);
            var mappedmapstats1 = _mapper.Map<IEnumerable<tour_map_stat>, IEnumerable<MapStatsModel>>(mapstats1);

            var mapstats2 = _dbcontext.tour_map_stats.Where(x => x.tour_id == id && x.map_id == map2id);
            var mappedmapstats2 = _mapper.Map<IEnumerable<tour_map_stat>, IEnumerable<MapStatsModel>>(mapstats2);

            viewModel.overallStats = mappedtour;
            viewModel.mapStats1 = mappedmapstats1;
            viewModel.mapStats2 = mappedmapstats2;
            viewModel.metaStats = mappedmetastats;

            var map1_name = _dbcontext.maps.Find(map1id).map_name;
            var map2_name = _dbcontext.maps.Find(map2id).map_name;
            ViewBag.tourname = tourObj.tour_name;
            ViewBag.touryear = tourObj.year;
            ViewBag.map1_name = map1_name;
            ViewBag.map2_name = map2_name;
            return View(viewModel);
        }

        public async Task<IActionResult> team_rotations(int id)
        {
            var menu = _viewsController.getmenusaccess();



            foreach (var menuitem in await menu)
            {


                string str = "menu" + menuitem;

                ViewData.Add(str, menuitem.ToString());
            }
            //var viewno = 4;
            //var user = await _userManager.GetUserAsync(User);
            //var roles = await _userManager.GetRolesAsync(user);
            //var menu = _homecontroller.getmenusaccess(roles.FirstOrDefault());
            //foreach (var menuitem in menu)
            //{
            //    string str = "menu" + menuitem;
            //    ViewData.Add(str, menuitem.ToString());
            //}
            var viewModel = new TournamentTeamRotationsViewModel();

            var rotations = _dbcontext.team_rotations.Where(x => x.tour_id == id).Include(x => x.map).Include(x => x.team).Include(x => x.tour).Include(x => x.landing_poi).Include(x => x.endzone_poi).ToList().DistinctBy(x => x.team_id);
            var mappedrotations = _mapper.Map<IEnumerable<team_rotation>, IEnumerable<TournamentTeamRotationsModel>>(rotations);

            viewModel.TeamRotations= mappedrotations;

            var tourObj = _dbcontext.tournaments.Find(id);

            ViewBag.tourname = tourObj.tour_name;
            ViewBag.touryear = tourObj.year;



            var map1id = tourObj.map1_id;
            var map2id = tourObj.map2_id;

            var map1_name = _dbcontext.maps.Find(map1id).map_name;
            var map2_name = _dbcontext.maps.Find(map2id).map_name;

            ViewBag.map1_name = map1_name;
            ViewBag.map2_name = map2_name;


           



            foreach(var rotation in mappedrotations) {
                var landpoi = _dbcontext.team_rotations.Where(x => x.tour_id == rotation.tour_id && x.team_id == rotation.team_id).Include(x => x.map).Include(x => x.team).Include(x => x.tour).Include(x => x.landing_poi).Include(x => x.endzone_poi).ToList().DistinctBy(x => x.landing_poi_id);
                var mappedlandpoi = _mapper.Map<IEnumerable<team_rotation>, IEnumerable<TournamentTeamRotationsModel>>(landpoi);
                var pois = new List<teamRotationLandingpoi>();
                foreach (var poi in mappedlandpoi)
            {
                    var poimodel = new teamRotationLandingpoi();

                    poimodel.landing_poi_name = poi.landing_poi_name;
                    poimodel.map_name = poi.map_name;

                   pois.Add(poimodel);



                }

                rotation.LandingPois = pois;



            }
            return View(viewModel);

        }

        public async Task<IActionResult> team_rotation_details(int tourid,int teamid,int ?mapid)
        {
            var menu = _viewsController.getmenusaccess();



            foreach (var menuitem in await menu)
            {


                string str = "menu" + menuitem;

                ViewData.Add(str, menuitem.ToString());
            }
            //var viewno = 4;
            //var user = await _userManager.GetUserAsync(User);
            //var roles = await _userManager.GetRolesAsync(user);
            //var menu = _homecontroller.getmenusaccess(roles.FirstOrDefault());
            //foreach (var menuitem in menu)
            //{
            //    string str = "menu" + menuitem;
            //    ViewData.Add(str, menuitem.ToString());
            //}


            var viewModel = new TournamentTeamRotationsViewModel();
            var tourObj = _dbcontext.tournaments.Find(tourid);
            ViewBag.tourid = tourObj.Id;
            ViewBag.tourname = tourObj.tour_name;
            ViewBag.touryear = tourObj.year;

            var teamObj = _dbcontext.Teams.Find(teamid);
            ViewBag.Teamid = teamObj.Id;
            ViewBag.TeamName = teamObj.team_name;

            ViewBag.TeamLogo = teamObj.team_img;


            var map1id = tourObj.map1_id;
            var map2id = tourObj.map2_id;

            var rotations1 = _dbcontext.team_rotations.Where(x => x.tour_id == tourid && x.team_id == teamid && x.map_id == map1id).Include(x => x.map).Include(x => x.team).Include(x => x.tour).Include(x => x.landing_poi).Include(x => x.endzone_poi).ToList();
            var rotations2 = _dbcontext.team_rotations.Where(x => x.tour_id == tourid && x.team_id == teamid && x.map_id == map2id).Include(x => x.map).Include(x => x.team).Include(x => x.tour).Include(x => x.landing_poi).Include(x => x.endzone_poi).ToList();
            if (mapid== null)
            {
                if (rotations1.Count() == 0)
                {
                    mapid = map2id;
                    ViewBag.active2 ="active";
                }
                else {
                    mapid = map1id;
                    ViewBag.active1 = "active";
                }
            }
            if (mapid == map2id)
            {
               
                ViewBag.active2 = "active";
                ViewBag.currentmapid = map2id;
            }
            else
            {
                ViewBag.currentmapid = map1id;
                ViewBag.active1 = "active";
            }



            ViewBag.count1 = rotations1.Count();
            ViewBag.count2 = rotations2.Count();


            var rotations = _dbcontext.team_rotations.Where(x => x.tour_id == tourid && x.team_id == teamid && x.map_id == mapid).Include(x => x.map).Include(x => x.team).Include(x => x.tour).Include(x => x.landing_poi).Include(x => x.endzone_poi).ToList();
            var mappaedrotations = _mapper.Map<IEnumerable<team_rotation>, IEnumerable<TournamentTeamRotationsModel>>(rotations);

            viewModel.TeamRotations = mappaedrotations;

           
            var map1 = _dbcontext.maps.Find(map1id);
            var map2 = _dbcontext.maps.Find(map2id);
            ViewBag.map1_id = map1.Id;
            ViewBag.map1_name = map1.map_name;
            ViewBag.map2_id = map2.Id;
            ViewBag.map2_name = map2.map_name;

             


           var landing_poi = rotations.FirstOrDefault().landing_poi;
            ViewBag.LandingPoi = landing_poi.poi_name;
            ViewBag.mapName = landing_poi.map.map_name;

            return View(viewModel);
        }
                
                      
        }
        
}

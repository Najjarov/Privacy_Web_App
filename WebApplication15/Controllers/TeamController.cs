using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Privacy_Web_App.DataContext;
using Privacy_Web_App.Models;


namespace Privacy_Web_App.Controllers
{
    [Authorize]
    public class TeamController : Controller
    {
        private readonly dbContext dbContext;
        private readonly IMapper _mapper;
        

        public TeamController(IMapper mapper)
        {
            _mapper = mapper;
            dbContext = new dbContext();
            

        }
        public IActionResult TeamList()
        {



            var region = dbContext.regions.ToList();
            var mappedregions = _mapper.Map<IEnumerable<region>, IEnumerable<RegionModel>>(region);

            var team = dbContext.Teams.ToList();
            var mappedteams = _mapper.Map<IEnumerable<Team>, IEnumerable<TeamModel>>(team);

            var player = dbContext.Players.ToList();
            var mappedplayers = _mapper.Map<IEnumerable<Player>, IEnumerable<PlayerModel>>(player);


            var coach = dbContext.coaches.ToList();
            var mappedcoaches = _mapper.Map<IEnumerable<coach>, IEnumerable<CoacheModel>>(coach);





            var TeamListModel = new TeamsListModel();
            TeamListModel.regions = mappedregions;
            TeamListModel.teams = mappedteams;
            TeamListModel.players = mappedplayers;
            TeamListModel.coaches = mappedcoaches;
            


            return View(TeamListModel);
        }

        public IActionResult Info(int Id)
        {

            var viewModel = new TournamentStatsViewModel();



            var regions = dbContext.regions.ToList();
            var team = dbContext.Teams.FirstOrDefault(x=>x.Id == Id);
            var MappedTeam = _mapper.Map<TeamModel>(team);
           
            var Teaminfo = _mapper.Map<TeamInfoModel>(MappedTeam);


            var players = dbContext.Players.Where(x => x.Current_Team_Id == Id);
            var mappedplayers = _mapper.Map<IEnumerable<PlayerModel>>(players);


            var coaches = dbContext.coaches.Where(x => x.Current_Team_Id == Id);
            var mappedcoaches = _mapper.Map<IEnumerable<CoacheModel>>(coaches);
            Teaminfo.players = mappedplayers;

            Teaminfo.coaches = mappedcoaches;

            var legends = dbContext.legends.ToList();
            var tours = dbContext.tournaments.ToList();
            var tour = dbContext.tour_stats.Where(x => x.team_id == Id).ToList();


            var mappedtour_stats = _mapper.Map<IEnumerable<TournamentStatsModel>>(tour);


            // Load the blog related to a given post.
            Teaminfo.tours = mappedtour_stats;





            return View(Teaminfo);
        }
    }
}
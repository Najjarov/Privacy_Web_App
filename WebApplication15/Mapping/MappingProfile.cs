using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Privacy_Web_App.DataContext;
using Privacy_Web_App.Models;
using System.Drawing;




namespace Privacy_Web_App.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Team, TeamModel>()
                .ForMember(dst => dst.region_id, src => src.MapFrom(e => e.region.Id))
                 .ForMember(dst => dst.region_Name, src => src.MapFrom(e => e.region.region_name))
                  .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
                   .ForMember(dst => dst.team_name, src => src.MapFrom(e => e.team_name))
                    .ForMember(dst => dst.team_name_shortcut, src => src.MapFrom(e => e.team_name_shortcut))
                    .ForMember(dst => dst.team_img, src => src.MapFrom(e => e.team_img))
                .ReverseMap();
            CreateMap<Player, PlayerModel>()
                .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
                 .ForMember(dst => dst.Player_Name, src => src.MapFrom(e => e.Player_Name))
                  .ForMember(dst => dst.Cur_Team_Id, src => src.MapFrom(e => e.Current_Team.Id))
                .ReverseMap();
            CreateMap<playable_spot, playable_spots_Model>()
              .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
               .ForMember(dst => dst.Map_id, src => src.MapFrom(e => e.map.Id))
                .ForMember(dst => dst.Map_Name, src => src.MapFrom(e => e.map.map_name))
                .ForMember(dst => dst.img, src => src.MapFrom(e => e.img))
              .ReverseMap();

            CreateMap<coach, CoacheModel>()
                .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
                 .ForMember(dst => dst.coach_Name, src => src.MapFrom(e => e.coach_Name))
                  .ForMember(dst => dst.Cur_Team_Id, src => src.MapFrom(e => e.Current_Team.Id))
                .ReverseMap();

            CreateMap<region, RegionModel>()
               .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
                .ForMember(dst => dst.region_shortcut, src => src.MapFrom(e => e.region_name_shortcut))
                 .ForMember(dst => dst.Name, src => src.MapFrom(e => e.region_name))
               .ReverseMap();

            CreateMap<TeamModel, TeamInfoModel>()
              .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
               .ForMember(dst => dst.team_name, src => src.MapFrom(e => e.team_name))
                .ForMember(dst => dst.team_name_shortcut, src => src.MapFrom(e => e.team_name_shortcut))
                 .ForMember(dst => dst.region_id, src => src.MapFrom(e => e.region_id))
                  .ForMember(dst => dst.region_Name, src => src.MapFrom(e => e.region_Name))
                  .ForMember(dst => dst.team_img, src => src.MapFrom(e => e.team_img)).ReverseMap();


            CreateMap<tour_stat, TournamentStatsModel>()
              .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
               .ForMember(dst => dst.Tour_id, src => src.MapFrom(e => e.tour_id))
                .ForMember(dst => dst.Tour_name, src => src.MapFrom(e => e.tour.tour_name))
                 .ForMember(dst => dst.Team_Id, src => src.MapFrom(e => e.team.Id))
                .ForMember(dst => dst.Team_Name, src => src.MapFrom(e => e.team.team_name))
                .ForMember(dst => dst.tour_stand, src => src.MapFrom(e => e.tour_stand))
                 .ForMember(dst => dst.av_po_per_game, src => src.MapFrom(e => e.av_po_per_game))
                  .ForMember(dst => dst.av_kills_per_game, src => src.MapFrom(e => e.av_kills_per_game))
                  .ForMember(dst => dst.av_place_per_game, src => src.MapFrom(e => e.av_place_per_game))
                   .ForMember(dst => dst.win_rate, src => src.MapFrom(e => e.win_rate))
               .ForMember(dst => dst.top_5_rate, src => src.MapFrom(e => e.top_5_rate))
                .ForMember(dst => dst.top_10_rate, src => src.MapFrom(e => e.top_10_rate))
                .ForMember(dst => dst.no_of_games, src => src.MapFrom(e => e.no_of_games))
                .ForMember(dst => dst.Legend_1_img, src => src.MapFrom(e => e.Legend_1.image))
              .ForMember(dst => dst.Legend_2_img, src => src.MapFrom(e => e.Legend_2.image))
              .ForMember(dst => dst.Legend_3_img, src => src.MapFrom(e => e.Legend_3.image))
              .ForMember(dst => dst.Legend_1_name, src => src.MapFrom(e => e.Legend_1.legend_name))
               .ForMember(dst => dst.Legend_2_name, src => src.MapFrom(e => e.Legend_2.legend_name))
                .ForMember(dst => dst.Legend_3_name, src => src.MapFrom(e => e.Legend_3.legend_name))

                 .ReverseMap();

            CreateMap<tour_map_stat, MapStatsModel>()
              .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
               .ForMember(dst => dst.Tour_id, src => src.MapFrom(e => e.tour_id))
                .ForMember(dst => dst.Tour_name, src => src.MapFrom(e => e.tour.tour_name))

                 .ForMember(dst => dst.map_id, src => src.MapFrom(e => e.map_id))
                  .ForMember(dst => dst.map_name, src => src.MapFrom(e => e.map.map_name))
                 .ForMember(dst => dst.Team_Id, src => src.MapFrom(e => e.team.Id))

                .ForMember(dst => dst.Team_Name, src => src.MapFrom(e => e.team.team_name))
                .ForMember(dst => dst.tour_stand, src => src.MapFrom(e => e.stand))
                 .ForMember(dst => dst.av_po_per_game, src => src.MapFrom(e => e.av_po))
                  .ForMember(dst => dst.av_kills_per_game, src => src.MapFrom(e => e.av_ki))
                  .ForMember(dst => dst.av_place_per_game, src => src.MapFrom(e => e.av_ki))
                   .ForMember(dst => dst.win_rate, src => src.MapFrom(e => e.win_rate))
               .ForMember(dst => dst.top_5_rate, src => src.MapFrom(e => e.top_5_rate))
                .ForMember(dst => dst.top_10_rate, src => src.MapFrom(e => e.top_10_rate))
                .ForMember(dst => dst.no_of_games, src => src.MapFrom(e => e.no_games))

                .ForMember(dst => dst.Legend_1_id, src => src.MapFrom(e => e.legend1.Id))
              .ForMember(dst => dst.Legend_2_id, src => src.MapFrom(e => e.legend2.Id))
              .ForMember(dst => dst.Legend_3_id, src => src.MapFrom(e => e.legend3.Id))


                .ForMember(dst => dst.Legend_1_img, src => src.MapFrom(e => e.legend1.image))
              .ForMember(dst => dst.Legend_2_img, src => src.MapFrom(e => e.legend2.image))
              .ForMember(dst => dst.Legend_3_img, src => src.MapFrom(e => e.legend3.image))
              .ForMember(dst => dst.Legend_1_name, src => src.MapFrom(e => e.legend1.legend_name))
               .ForMember(dst => dst.Legend_2_name, src => src.MapFrom(e => e.legend2.legend_name))
                .ForMember(dst => dst.Legend_3_name, src => src.MapFrom(e => e.legend3.legend_name))

                 .ReverseMap();
            CreateMap<legend, LegendsModel>()
              .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
               .ForMember(dst => dst.Name, src => src.MapFrom(e => e.legend_name))
                .ForMember(dst => dst.short_Name, src => src.MapFrom(e => e.legend_name_shortcut))
                 .ForMember(dst => dst.Img, src => src.MapFrom(e => e.image))
                 .ReverseMap();

            CreateMap<tournament, TournamentModel>()
              .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
               .ForMember(dst => dst.Name, src => src.MapFrom(e => e.tour_name))
                .ForMember(dst => dst.short_name, src => src.MapFrom(e => e.tour_name_shortcut))
                 .ForMember(dst => dst.year, src => src.MapFrom(e => e.year))
                  .ForMember(dst => dst.winner_Id, src => src.MapFrom(e => e.winner_team.Id))
                   .ForMember(dst => dst.winner_Name, src => src.MapFrom(e => e.winner_team.team_name))
                   .ForMember(dst => dst.map1_id, src => src.MapFrom(e => e.map1.Id))
                   .ForMember(dst => dst.map1_Name, src => src.MapFrom(e => e.map1.map_name))
                   .ForMember(dst => dst.map2_id, src => src.MapFrom(e => e.map2.Id))
                    .ForMember(dst => dst.map2_Name, src => src.MapFrom(e => e.map2.map_name)).ReverseMap();

            CreateMap<tour_team_metum, TourOverMetaModel>()
                .ForMember(dst => dst.id, src => src.MapFrom(e => e.Id))
                 .ForMember(dst => dst.tour_id, src => src.MapFrom(e => e.tour.Id))
                  .ForMember(dst => dst.tour_name, src => src.MapFrom(e => e.tour.tour_name))

                  .ForMember(dst => dst.Legend_1_id, src => src.MapFrom(e => e.legend_Id_1Navigation.Id))

                  .ForMember(dst => dst.Legend_2_id, src => src.MapFrom(e => e.legend_Id_2Navigation.Id))
                  .ForMember(dst => dst.Legend_3_id, src => src.MapFrom(e => e.legend_Id_3Navigation.Id))

                   .ForMember(dst => dst.Legend_1_name, src => src.MapFrom(e => e.legend_Id_1Navigation.legend_name))
                   .ForMember(dst => dst.Legend_2_name, src => src.MapFrom(e => e.legend_Id_2Navigation.legend_name))
                   .ForMember(dst => dst.Legend_3_name, src => src.MapFrom(e => e.legend_Id_3Navigation.legend_name))

                   .ForMember(dst => dst.Legend_1_img, src => src.MapFrom(e => e.legend_Id_1Navigation.image))
                   .ForMember(dst => dst.Legend_2_img, src => src.MapFrom(e => e.legend_Id_2Navigation.image))
                   .ForMember(dst => dst.Legend_3_img, src => src.MapFrom(e => e.legend_Id_3Navigation.image))

                   .ForMember(dst => dst.pick_rate, src => src.MapFrom(e => e.pick_rate))
                   .ForMember(dst => dst.total, src => src.MapFrom(e => e.total))

                .ReverseMap();
            CreateMap<tour_player, TourPlayerModel>()
             .ForMember(dst => dst.id, src => src.MapFrom(e => e.Id))
             .ForMember(dst => dst.player_id, src => src.MapFrom(e => e.player.Id))
              .ForMember(dst => dst.player_Name, src => src.MapFrom(e => e.player.Player_Name))
              .ForMember(dst => dst.team_id, src => src.MapFrom(e => e.team.Id))
              .ForMember(dst => dst.team_Name, src => src.MapFrom(e => e.team.team_name))
              .ForMember(dst => dst.tour_id, src => src.MapFrom(e => e.tour.Id))
              .ForMember(dst => dst.tour_Name, src => src.MapFrom(e => e.tour.tour_name))

              .ReverseMap();


            CreateMap<tour_coach, TourCoachModel>()
            .ForMember(dst => dst.id, src => src.MapFrom(e => e.Id))
            .ForMember(dst => dst.coach_id, src => src.MapFrom(e => e.coach.Id))
             .ForMember(dst => dst.coach_Name, src => src.MapFrom(e => e.coach.coach_Name))
             .ForMember(dst => dst.team_id, src => src.MapFrom(e => e.team.Id))
             .ForMember(dst => dst.team_Name, src => src.MapFrom(e => e.team.team_name))
             .ForMember(dst => dst.tour_id, src => src.MapFrom(e => e.tour.Id))
             .ForMember(dst => dst.tour_Name, src => src.MapFrom(e => e.tour.tour_name))

             .ReverseMap();

            CreateMap<tour_team_stat, TourTeamStatsModel>()
            .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
            .ForMember(dst => dst.tour_id, src => src.MapFrom(e => e.tour.Id))
             .ForMember(dst => dst.tour_name, src => src.MapFrom(e => e.tour.tour_name))
             .ForMember(dst => dst.team_id, src => src.MapFrom(e => e.team.Id))
             .ForMember(dst => dst.team_name, src => src.MapFrom(e => e.team.team_name))
             .ForMember(dst => dst.pois_id, src => src.MapFrom(e => e.pois.Id))
              .ForMember(dst => dst.pois_name, src => src.MapFrom(e => e.pois.poi_name))

               .ForMember(dst => dst.av_po_per_game, src => src.MapFrom(e => e.av_po_per_game))
                .ForMember(dst => dst.av_kills_per_game, src => src.MapFrom(e => e.av_kills_per_game))
                 .ForMember(dst => dst.av_place_per_game, src => src.MapFrom(e => e.av_place_per_game))
                  .ForMember(dst => dst.win_rate, src => src.MapFrom(e => e.win_rate))
                   .ForMember(dst => dst.top_5_rate, src => src.MapFrom(e => e.top_5_rate))
                    .ForMember(dst => dst.top_10_rate, src => src.MapFrom(e => e.top_10_rate))
             .ReverseMap();
            CreateMap<tour_team_map_stat, TourTeamMapStatsModel>()
           .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
           .ForMember(dst => dst.tour_id, src => src.MapFrom(e => e.tour.Id))
            .ForMember(dst => dst.tour_name, src => src.MapFrom(e => e.tour.tour_name))
            .ForMember(dst => dst.team_id, src => src.MapFrom(e => e.team.Id))
            .ForMember(dst => dst.team_name, src => src.MapFrom(e => e.team.team_name))
            .ForMember(dst => dst.map_id, src => src.MapFrom(e => e.map.Id))
            .ForMember(dst => dst.map_name, src => src.MapFrom(e => e.map.map_name))
            .ForMember(dst => dst.pois_id, src => src.MapFrom(e => e.pois.Id))
             .ForMember(dst => dst.pois_name, src => src.MapFrom(e => e.pois.poi_name))

              .ForMember(dst => dst.av_po_per_game, src => src.MapFrom(e => e.av_po_per_game))
               .ForMember(dst => dst.av_kills_per_game, src => src.MapFrom(e => e.av_kills_per_game))
                .ForMember(dst => dst.av_place_per_game, src => src.MapFrom(e => e.av_place_per_game))
                 .ForMember(dst => dst.win_rate, src => src.MapFrom(e => e.win_rate))
                  .ForMember(dst => dst.top_5_rate, src => src.MapFrom(e => e.top_5_rate))
                   .ForMember(dst => dst.top_10_rate, src => src.MapFrom(e => e.top_10_rate))
            .ReverseMap();


            CreateMap<tour_team_stats_overall_metum, TourTeamOverMetaModel>()
           .ForMember(dst => dst.id, src => src.MapFrom(e => e.Id))
           .ForMember(dst => dst.tour_id, src => src.MapFrom(e => e.tour.Id))
           .ForMember(dst => dst.tour_name, src => src.MapFrom(e => e.tour.tour_name))
           .ForMember(dst => dst.team_id, src => src.MapFrom(e => e.team.Id))
           .ForMember(dst => dst.team_name, src => src.MapFrom(e => e.team.team_name))
          
           .ForMember(dst => dst.Legend_1_id, src => src.MapFrom(e => e.legend_Id_1Navigation.Id))
           .ForMember(dst => dst.Legend_2_id, src => src.MapFrom(e => e.legend_Id_2Navigation.Id))
           .ForMember(dst => dst.Legend_3_id, src => src.MapFrom(e => e.legend_Id_3Navigation.Id))

                   .ForMember(dst => dst.Legend_1_name, src => src.MapFrom(e => e.legend_Id_1Navigation.legend_name))
                   .ForMember(dst => dst.Legend_2_name, src => src.MapFrom(e => e.legend_Id_2Navigation.legend_name))
                   .ForMember(dst => dst.Legend_3_name, src => src.MapFrom(e => e.legend_Id_3Navigation.legend_name))

                   .ForMember(dst => dst.Legend_1_img, src => src.MapFrom(e => e.legend_Id_1Navigation.image))
                   .ForMember(dst => dst.Legend_2_img, src => src.MapFrom(e => e.legend_Id_2Navigation.image))
                   .ForMember(dst => dst.Legend_3_img, src => src.MapFrom(e => e.legend_Id_3Navigation.image))

                   .ForMember(dst => dst.pick_rate, src => src.MapFrom(e => e.pick_rate))
                   .ForMember(dst => dst.total, src => src.MapFrom(e => e.Total))
            .ReverseMap();


            CreateMap<tour_team_stats_map_metum, TourTeamMapMetaModel>()
          .ForMember(dst => dst.id, src => src.MapFrom(e => e.Id))
          .ForMember(dst => dst.tour_id, src => src.MapFrom(e => e.tour.Id))
          .ForMember(dst => dst.tour_name, src => src.MapFrom(e => e.tour.tour_name))
          .ForMember(dst => dst.team_id, src => src.MapFrom(e => e.team.Id))
          .ForMember(dst => dst.team_name, src => src.MapFrom(e => e.team.team_name))

          .ForMember(dst => dst.map_id, src => src.MapFrom(e => e.map.Id))
          .ForMember(dst => dst.map_name, src => src.MapFrom(e => e.map.map_name))


          .ForMember(dst => dst.Legend_1_id, src => src.MapFrom(e => e.legend_Id_1Navigation.Id))
          .ForMember(dst => dst.Legend_2_id, src => src.MapFrom(e => e.legend_Id_2Navigation.Id))
          .ForMember(dst => dst.Legend_3_id, src => src.MapFrom(e => e.legend_Id_3Navigation.Id))

                  .ForMember(dst => dst.Legend_1_name, src => src.MapFrom(e => e.legend_Id_1Navigation.legend_name))
                  .ForMember(dst => dst.Legend_2_name, src => src.MapFrom(e => e.legend_Id_2Navigation.legend_name))
                  .ForMember(dst => dst.Legend_3_name, src => src.MapFrom(e => e.legend_Id_3Navigation.legend_name))

                  .ForMember(dst => dst.Legend_1_img, src => src.MapFrom(e => e.legend_Id_1Navigation.image))
                  .ForMember(dst => dst.Legend_2_img, src => src.MapFrom(e => e.legend_Id_2Navigation.image))
                  .ForMember(dst => dst.Legend_3_img, src => src.MapFrom(e => e.legend_Id_3Navigation.image))

                  .ForMember(dst => dst.pick_rate, src => src.MapFrom(e => e.pick_rate))
                  .ForMember(dst => dst.total, src => src.MapFrom(e => e.Total))
           .ReverseMap();
            
        
            CreateMap<viewsaccess, UserAccess>()
          .ForMember(dst => dst.id, src => src.MapFrom(e => e.Id))
         .ForMember(dst => dst.view_id, src => src.MapFrom(e => e.view_id))
         .ForMember(dst => dst.role_name, src => src.MapFrom(e => e.role_name))
        
           .ReverseMap();

            CreateMap<view, ViewsModel>()
             .ForMember(dst => dst.id, src => src.MapFrom(e => e.Id))
            .ForMember(dst => dst.view_name, src => src.MapFrom(e => e.viewname))
            .ForMember(dst => dst.section, src => src.MapFrom(e => e.section))
              .ForMember(dst => dst.action_name, src => src.MapFrom(e => e.action_name))
                .ForMember(dst => dst.controller, src => src.MapFrom(e => e.controller))
              .ReverseMap();

            CreateMap<tour_team_stats_overall_inv_metum, TourTeamOverInvMetaModel>()
           .ForMember(dst => dst.id, src => src.MapFrom(e => e.Id))
           .ForMember(dst => dst.tour_id, src => src.MapFrom(e => e.tour.Id))
           .ForMember(dst => dst.tour_name, src => src.MapFrom(e => e.tour.tour_name))
           .ForMember(dst => dst.team_id, src => src.MapFrom(e => e.team.Id))
           .ForMember(dst => dst.team_name, src => src.MapFrom(e => e.team.team_name))

                    .ForMember(dst => dst.Legend_id, src => src.MapFrom(e => e.legend.Id))
                   .ForMember(dst => dst.Legend_name, src => src.MapFrom(e => e.legend.legend_name))
                   .ForMember(dst => dst.Legend_img, src => src.MapFrom(e => e.legend.image))
                   .ForMember(dst => dst.pick_rate, src => src.MapFrom(e => e.pick_rate))
                   .ForMember(dst => dst.total, src => src.MapFrom(e => e.Total))
            .ReverseMap();


            CreateMap<tour_team_stats_map_inv_metum, TourTeamMapInvMetaModel>()
          .ForMember(dst => dst.id, src => src.MapFrom(e => e.Id))
          .ForMember(dst => dst.tour_id, src => src.MapFrom(e => e.tour.Id))
          .ForMember(dst => dst.tour_name, src => src.MapFrom(e => e.tour.tour_name))
          .ForMember(dst => dst.team_id, src => src.MapFrom(e => e.team.Id))
          .ForMember(dst => dst.team_name, src => src.MapFrom(e => e.team.team_name))

          .ForMember(dst => dst.map_id, src => src.MapFrom(e => e.map.Id))
          .ForMember(dst => dst.map_name, src => src.MapFrom(e => e.map.map_name))
           .ForMember(dst => dst.Legend_id, src => src.MapFrom(e => e.legend.Id))
                   .ForMember(dst => dst.Legend_name, src => src.MapFrom(e => e.legend.legend_name))
                   .ForMember(dst => dst.Legend_img, src => src.MapFrom(e => e.legend.image))
                  .ForMember(dst => dst.pick_rate, src => src.MapFrom(e => e.pick_rate))
                  .ForMember(dst => dst.total, src => src.MapFrom(e => e.Total))
           .ReverseMap();

            CreateMap<map, MapModel>()
              .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
               .ForMember(dst => dst.Name, src => src.MapFrom(e => e.map_name))
                .ForMember(dst => dst.img, src => src.MapFrom(e => e.img))
                .ForMember(dst => dst.Logo_img, src => src.MapFrom(e => e.logo_img))
              .ReverseMap();
            CreateMap<map_spawn_rate, MapSpawnModel>()
            .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
             .ForMember(dst => dst.map_id, src => src.MapFrom(e => e.map.Id))
              .ForMember(dst => dst.map_name, src => src.MapFrom(e => e.map.map_name))
                .ForMember(dst => dst.uav_spawn, src => src.MapFrom(e => e.uav_spawn))
              .ForMember(dst => dst.console_spawn, src => src.MapFrom(e => e.console_spawn))
                .ForMember(dst => dst.hotzone_spawn, src => src.MapFrom(e => e.hotzone_spawn))
              .ForMember(dst => dst.ship_spawn, src => src.MapFrom(e => e.ship_spawn))
               .ForMember(dst => dst.assault_bin_spawn_25px, src => src.MapFrom(e => e.assault_bin_spawn_25px))
              .ForMember(dst => dst.assault_bin_spawn_areas, src => src.MapFrom(e => e.assault_bin_spawn_areas))
                .ForMember(dst => dst.assault_bin_spawn_all, src => src.MapFrom(e => e.assault_bin_spawn_all))
              .ForMember(dst => dst.evo_harvester_spawn_25px, src => src.MapFrom(e => e.evo_harvester_spawn_25px))
                .ForMember(dst => dst.evo_harvester_spawn_areas, src => src.MapFrom(e => e.evo_harvester_spawn_areas))
              .ForMember(dst => dst.evo_harvester_spawn_all, src => src.MapFrom(e => e.evo_harvester_spawn_all))
            .ReverseMap();

            CreateMap<map_loot, MapLootModel>()
           .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
            .ForMember(dst => dst.map_id, src => src.MapFrom(e => e.map.Id))
             .ForMember(dst => dst.map_name, src => src.MapFrom(e => e.map.map_name))
               .ForMember(dst => dst.loot_qty, src => src.MapFrom(e => e.loot_qty_map))
             .ForMember(dst => dst.cargobot, src => src.MapFrom(e => e.cargo_bot))
               
           .ReverseMap();

            CreateMap<poi, poiModel>()
            .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
             .ForMember(dst => dst.Name, src => src.MapFrom(e => e.poi_name))
              .ForMember(dst => dst.img, src => src.MapFrom(e => e.img))
               .ForMember(dst => dst.Map_Id, src => src.MapFrom(e => e.map.Id))
                .ForMember(dst => dst.Map_name, src => src.MapFrom(e => e.map.map_name))
                 .ForMember(dst => dst.Map_short, src => src.MapFrom(e => e.map.map_name_shortcut))
                   .ForMember(dst => dst.loot_bins_spawn_img, src => src.MapFrom(e => e.loot_bins_spawn_img))
                     .ForMember(dst => dst.loot_path_img, src => src.MapFrom(e => e.loot_path_img))

                  .ForMember(dst => dst.Map_img, src => src.MapFrom(e => e.map.img))
              .ForMember(dst => dst.Season_Id, src => src.MapFrom(e => e.season.Id))
               .ForMember(dst => dst.Season_Name, src => src.MapFrom(e => e.season.season_name))
              .ForMember(dst => dst.Season_no, src => src.MapFrom(e => e.season.season_number))
            .ReverseMap();

            CreateMap<Landing_poi, LandingPoiModel>()
           .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
            .ForMember(dst => dst.Name, src => src.MapFrom(e => e.poi_name))
             .ForMember(dst => dst.img, src => src.MapFrom(e => e.img))
              .ForMember(dst => dst.Map_Id, src => src.MapFrom(e => e.map.Id))
               .ForMember(dst => dst.Map_name, src => src.MapFrom(e => e.map.map_name))
                .ForMember(dst => dst.Map_short, src => src.MapFrom(e => e.map.map_name_shortcut))
                  .ForMember(dst => dst.over_loot, src => src.MapFrom(e => e.over_loot_img))
                    .ForMember(dst => dst.loot_path_img, src => src.MapFrom(e => e.loot_path_img))
                 .ForMember(dst => dst.Map_img, src => src.MapFrom(e => e.map.img))
             .ForMember(dst => dst.Season_Id, src => src.MapFrom(e => e.season.Id))
              .ForMember(dst => dst.Season_Name, src => src.MapFrom(e => e.season.season_name))
             .ForMember(dst => dst.Season_no, src => src.MapFrom(e => e.season.season_number))
             .ForMember(dst => dst.ext_loot_path_img, src => src.MapFrom(e => e.ext_loot_path_img))
              .ForMember(dst => dst.hover_img, src => src.MapFrom(e => e.hover_img))
             .ForMember(dst => dst.hover_x, src => src.MapFrom(e => e.map_hover_x))
             .ForMember(dst => dst.hover_y, src => src.MapFrom(e => e.map_hover_y))
              
           .ReverseMap();



            CreateMap<loot_info, lootInfoModel>()
             .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
              .ForMember(dst => dst.map_Id, src => src.MapFrom(e => e.map_id))
               .ForMember(dst => dst.poi_Id, src => src.MapFrom(e => e.poi_id))
                .ForMember(dst => dst.total_loots, src => src.MapFrom(e => e.total_loots))
               .ForMember(dst => dst.weapon_ref, src => src.MapFrom(e => e.weapon_ref))
                .ForMember(dst => dst.lootbins, src => src.MapFrom(e => e.lootbins))
               .ForMember(dst => dst.next_zone_beacons, src => src.MapFrom(e => e.next_zone_beacons))
                .ForMember(dst => dst.survey_beacons, src => src.MapFrom(e => e.survey_beacons))
               .ForMember(dst => dst.crafts, src => src.MapFrom(e => e.crafts))
                .ForMember(dst => dst.respawn_beacons, src => src.MapFrom(e => e.respawn_beacons))
               .ForMember(dst => dst.weapon_racks, src => src.MapFrom(e => e.weapon_racks))
               .ReverseMap();

            CreateMap<loot_detail_info, lootDetailInfoModel>()
            .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
             .ForMember(dst => dst.map_Id, src => src.MapFrom(e => e.map_id))
              .ForMember(dst => dst.poi_Id, src => src.MapFrom(e => e.poi_id))
               .ForMember(dst => dst.cell, src => src.MapFrom(e => e.cell))
              .ForMember(dst => dst.syringe, src => src.MapFrom(e => e.syringe))
               .ForMember(dst => dst.bat, src => src.MapFrom(e => e.bat))
              .ForMember(dst => dst.medkit, src => src.MapFrom(e => e.medkit))
               .ForMember(dst => dst.phoenix, src => src.MapFrom(e => e.phoenix))
              .ForMember(dst => dst.ult_acc, src => src.MapFrom(e => e.ult_acc))
			  .ForMember(dst => dst.evac, src => src.MapFrom(e => e.EVAC))
			   .ForMember(dst => dst.leg_back, src => src.MapFrom(e => e.leg_back))
              .ForMember(dst => dst.epic_back, src => src.MapFrom(e => e.epic_back))
              .ForMember(dst => dst.two_x, src => src.MapFrom(e => e._2x))
               .ForMember(dst => dst.three_x, src => src.MapFrom(e => e._3x))
              .ForMember(dst => dst.two_four_x, src => src.MapFrom(e => e._2x_4x))

              
              .ReverseMap();



            CreateMap<evac, evacModel>()
            .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
             .ForMember(dst => dst.map_Id, src => src.MapFrom(e => e.map_id))
              .ForMember(dst => dst.video, src => src.MapFrom(e => e.video))
              .ForMember(dst => dst.x, src => src.MapFrom(e => e.map_x))
              .ForMember(dst => dst.y, src => src.MapFrom(e => e.map_y))
              .ReverseMap();
            CreateMap<alter_void, alter_void_Model>()
           .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
            .ForMember(dst => dst.map_Id, src => src.MapFrom(e => e.map_id))
             .ForMember(dst => dst.video, src => src.MapFrom(e => e.video))
             .ForMember(dst => dst.x, src => src.MapFrom(e => e.map_x))
             .ForMember(dst => dst.y, src => src.MapFrom(e => e.map_y))
             .ReverseMap();

            CreateMap<did_you_know_vid, DidYouKnowViewModel>()
           .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
            .ForMember(dst => dst.Name, src => src.MapFrom(e => e.name))
             .ForMember(dst => dst.img, src => src.MapFrom(e => e.img))
              .ForMember(dst => dst.vid_link, src => src.MapFrom(e => e.video_link))
            
             .ReverseMap();

            CreateMap<tutorial_vid, TutorialVidsViewModel>()
          .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
           .ForMember(dst => dst.Name, src => src.MapFrom(e => e.name))
            .ForMember(dst => dst.img, src => src.MapFrom(e => e.img))
             .ForMember(dst => dst.vid_link, src => src.MapFrom(e => e.video_link))

            .ReverseMap();

            CreateMap<climb, climbModel>()
           .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
            .ForMember(dst => dst.map_Id, src => src.MapFrom(e => e.map_id))
             .ForMember(dst => dst.video, src => src.MapFrom(e => e.video))
             .ForMember(dst => dst.x, src => src.MapFrom(e => e.map_x))
             .ForMember(dst => dst.y, src => src.MapFrom(e => e.map_y))
             .ReverseMap();
            CreateMap<rat_spot, rats_Model>()
          .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
           .ForMember(dst => dst.map_Id, src => src.MapFrom(e => e.map_id))
            .ForMember(dst => dst.video, src => src.MapFrom(e => e.video))
            .ForMember(dst => dst.x, src => src.MapFrom(e => e.map_x))
            .ForMember(dst => dst.y, src => src.MapFrom(e => e.map_y))
            .ReverseMap();
            CreateMap<Valk_ult, valkModel>()
           .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
            .ForMember(dst => dst.map_Id, src => src.MapFrom(e => e.map_id))
             .ForMember(dst => dst.video, src => src.MapFrom(e => e.video))
             .ForMember(dst => dst.x, src => src.MapFrom(e => e.map_x))
             .ForMember(dst => dst.y, src => src.MapFrom(e => e.map_y))
             .ReverseMap();

            CreateMap<jump_tower, jumpTowerModel>()
          .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
          .ForMember(dst => dst.map_id, src => src.MapFrom(e => e.map.Id))
          .ForMember(dst => dst.pos_x, src => src.MapFrom(e => e.pos_x))
          .ForMember(dst => dst.pos_y, src => src.MapFrom(e => e.pos_y))
          .ForMember(dst => dst.hover_x, src => src.MapFrom(e => e.hover_x))
          .ForMember(dst => dst.hover_y, src => src.MapFrom(e => e.hover_y))
          .ForMember(dst => dst.img, src => src.MapFrom(e => e.img))
          .ReverseMap();
            CreateMap<uav_range, Uav_Range_Model>()
        .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
        .ForMember(dst => dst.map_id, src => src.MapFrom(e => e.map.Id))
        .ForMember(dst => dst.pos_x, src => src.MapFrom(e => e.pos_x))
        .ForMember(dst => dst.pos_y, src => src.MapFrom(e => e.pos_y))
        
       
        .ReverseMap();
            CreateMap<visual_tut, VisualTutsViewModel>()
           .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
           
           
             .ForMember(dst => dst.img, src => src.MapFrom(e => e.img))
             .ReverseMap();

            CreateMap<team_rotation, TournamentTeamRotationsModel>()
               .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
                .ForMember(dst => dst.tour_id, src => src.MapFrom(e => e.tour.Id))
                  .ForMember(dst => dst.tour_name, src => src.MapFrom(e => e.tour.tour_name))
                  .ForMember(dst => dst.team_id, src => src.MapFrom(e => e.team.Id))
                  .ForMember(dst => dst.team_name, src => src.MapFrom(e => e.team.team_name))
                   .ForMember(dst => dst.team_logo, src => src.MapFrom(e => e.team.team_img))
                   .ForMember(dst => dst.map_id, src => src.MapFrom(e => e.map.Id))
                  .ForMember(dst => dst.map_name, src => src.MapFrom(e => e.map.map_name))
                   .ForMember(dst => dst.landing_poi_id, src => src.MapFrom(e => e.landing_poi.Id))
                  .ForMember(dst => dst.landing_poi_name, src => src.MapFrom(e => e.landing_poi.poi_name))
                   .ForMember(dst => dst.endzone_poi_id, src => src.MapFrom(e => e.endzone_poi.Id))
                   .ForMember(dst => dst.endzone_poi_name, src => src.MapFrom(e => e.endzone_poi.poi_name))
                    .ForMember(dst => dst.img, src => src.MapFrom(e => e.img))
               .ReverseMap();
            CreateMap<menu_main, MainMenuModel>()
          .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
          .ForMember(dst => dst.text, src => src.MapFrom(e => e.text))
            .ForMember(dst => dst.viewid, src => src.MapFrom(e => e.view))
            .ReverseMap();

            CreateMap<menu_sub, SubMenuModel>()
          .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
           .ForMember(dst => dst.text, src => src.MapFrom(e => e.text))
            .ForMember(dst => dst.main_menu_id, src => src.MapFrom(e => e.main_menu_id))
            .ForMember(dst => dst.controller, src => src.MapFrom(e => e.controller_link))
            .ForMember(dst => dst.action, src => src.MapFrom(e => e.action_link))
            .ForMember(dst => dst.att, src => src.MapFrom(e => e.att))
            .ForMember(dst => dst.viewid, src => src.MapFrom(e => e.view_id))
            .ReverseMap();

        }


    }
}

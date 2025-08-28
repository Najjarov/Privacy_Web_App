using Privacy_Web_App.DataContext;

namespace Privacy_Web_App.Models
{
    public class TournamentStatsModel
    {
        public int Id { get; set; }


        public int Tour_id { get; set; }
        public string Tour_name { get; set; }

        public int Team_Id { get; set; }
        public string Team_Name { get; set; }

        public int tour_stand { get; set; }

        public decimal av_po_per_game { get; set; }

        public decimal av_kills_per_game { get; set; }
        public decimal av_place_per_game { get; set; }
        public decimal win_rate { get; set; }
        public decimal top_5_rate { get; set; }
        public decimal top_10_rate { get; set; }

        public int no_of_games { get; set; }

       

        public int Legend_1_id { get; set; }
        public string Legend_1_name { get; set; }
        public string Legend_1_img { get; set; }


        public int Legend_2_id { get; set; }

        public string Legend_2_name { get; set; }
        public string Legend_2_img { get; set; }
        public int Legend_3_id { get; set; }

        public string Legend_3_name { get; set; }
        public string Legend_3_img { get; set; }

       

       


    }

    public class TourOverMetaModel
    { 
        public int id { get; set; }
        public int tour_id { get; set; }
        public string tour_name { get;set; }

        public int Legend_1_id { get; set; }
        public string Legend_1_name { get; set; }
        public string Legend_1_img { get; set; }


        public int Legend_2_id { get; set; }

        public string Legend_2_name { get; set; }
        public string Legend_2_img { get; set; }
        public int Legend_3_id { get; set; }

        public string Legend_3_name { get; set; }
        public string Legend_3_img { get; set; }

        public decimal pick_rate { get; set; }
        public int total { get; set; }



    }

    public class TourTeamOverMetaModel
    {
        public int id { get; set; }
        public int tour_id { get; set; }
        public string tour_name { get; set; }

        public int team_id { get; set; }
        public string team_name { get; set; }

        public int Legend_1_id { get; set; }
        public string Legend_1_name { get; set; }
        public string Legend_1_img { get; set; }


        public int Legend_2_id { get; set; }

        public string Legend_2_name { get; set; }
        public string Legend_2_img { get; set; }
        public int Legend_3_id { get; set; }

        public string Legend_3_name { get; set; }
        public string Legend_3_img { get; set; }

        public decimal pick_rate { get; set; }
        public int total { get; set; }



    }
    public class TourTeamMapMetaModel
    {
        public int id { get; set; }
        public int tour_id { get; set; }
        public string tour_name { get; set; }

        public int team_id { get; set; }
        public string team_name { get; set; }


        public int map_id { get; set; }
        public string map_name { get; set; }
        public int Legend_1_id { get; set; }
        public string Legend_1_name { get; set; }
        public string Legend_1_img { get; set; }


        public int Legend_2_id { get; set; }

        public string Legend_2_name { get; set; }
        public string Legend_2_img { get; set; }
        public int Legend_3_id { get; set; }

        public string Legend_3_name { get; set; }
        public string Legend_3_img { get; set; }

        public decimal pick_rate { get; set; }
        public int total { get; set; }



    }

    public class TournamentStatsViewModel
    {
        public IEnumerable<TournamentStatsModel> overallStats { get; set; }
        public IEnumerable<MapStatsModel> mapStats1 { get; set; }

        public IEnumerable<MapStatsModel> mapStats2 { get; set; }


        public IEnumerable<TourOverMetaModel> metaStats { get; set; }

    }
    public class TourTeamStatsModel
    {
       public int Id { get; set; }

        public int tour_id { get; set; }
        public string tour_name { get; set; }

        public int team_id { get; set; }
        public string team_name { get; set;}

        public int pois_id { get; set;}

        public string pois_name { get; set; }

        public decimal av_po_per_game { get; set; }

        public decimal av_kills_per_game { get; set; }
        public decimal av_place_per_game { get; set; }
        public decimal win_rate { get; set; }
        public decimal top_5_rate { get; set; }
        public decimal top_10_rate { get; set; }

        public int no_of_games { get; set; }

        
    }
    public class TourTeamMapStatsModel
    {

        public int Id { get; set; }

        public int tour_id { get; set; }
        public string tour_name { get; set; }

        public int team_id { get; set; }
        public string team_name { get; set; }

        public int map_id { get; set; }
        public string map_name { get; set; }

        public int pois_id { get; set; }

        public string pois_name { get; set; }

        public decimal av_po_per_game { get; set; }

        public decimal av_kills_per_game { get; set; }
        public decimal av_place_per_game { get; set; }
        public decimal win_rate { get; set; }
        public decimal top_5_rate { get; set; }
        public decimal top_10_rate { get; set; }

        public int no_of_games { get; set; }
    }

    public class TourTeamOverInvMetaModel
    {
        public int id { get; set; }
        public int tour_id { get; set; }
        public string tour_name { get; set; }

        public int team_id { get; set; }
        public string team_name { get; set; }

        public int Legend_id { get; set; }
        public string Legend_name { get; set; }
        public string Legend_img { get; set; }


       

        public decimal pick_rate { get; set; }
        public int total { get; set; }



    }
    public class TourTeamMapInvMetaModel
    {
        public int id { get; set; }
        public int tour_id { get; set; }
        public string tour_name { get; set; }

        public int team_id { get; set; }
        public string team_name { get; set; }


        public int map_id { get; set; }
        public string map_name { get; set; }
        public int Legend_id { get; set; }
        public string Legend_name { get; set; }
        public string Legend_img { get; set; }


       

        public decimal pick_rate { get; set; }
        public int total { get; set; }



    }
}

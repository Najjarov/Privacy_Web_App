namespace Privacy_Web_App.Models
{
    public class TournamentTeamRotationsModel
    {
        public int Id { get; set; }

        public int tour_id { get; set; }
        public string tour_name { get; set; }

        public int team_id { get; set; }
        public string team_name { get; set; }
        public string team_logo { get; set; }
        public int map_id { get; set; }
        public string map_name { get; set; }
        public int landing_poi_id { get; set; }
        public string landing_poi_name { get; set; }

        public int endzone_poi_id { get; set; }

        public string endzone_poi_name { get; set; }

        public string img { get; set; }

        public IEnumerable<teamRotationLandingpoi> LandingPois { get; set; }
        

    }

    public class TournamentTeamRotationsViewModel
    {
        public IEnumerable<TournamentTeamRotationsModel> TeamRotations { get; set; }
    }

    public class teamRotationLandingpoi
    {

        public string landing_poi_name { get; set; }
        public string map_name { get; set; }
    }
}

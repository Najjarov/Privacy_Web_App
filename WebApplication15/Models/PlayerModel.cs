namespace Privacy_Web_App.Models
{
    public class PlayerModel
    {

        public int Id { get; set; }
        public string Player_Name { get; set; }

        public int Cur_Team_Id { get; set; }
    }

    public class TourPlayerModel
    {

        public int id { get; set; }
        public int player_id { get; set; }
        public string player_Name { get; set; }

        public int team_id { get; set; }
        public string team_Name { get; set; }

        public int tour_id { get; set; }
        public string tour_Name { get; set; }
    }


}

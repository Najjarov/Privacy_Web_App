namespace Privacy_Web_App.Models
{
    public class CoacheModel
    {
        public int Id { get; set; }
        public string coach_Name { get; set; }

        public int Cur_Team_Id { get; set; }
    }

    public class TourCoachModel
    {

        public int id { get; set; }
        public int coach_id { get; set; }
        public string coach_Name { get; set; }

        public int team_id { get; set; }
        public string team_Name { get; set; }

        public int tour_id { get; set; }
        public string tour_Name { get; set; }
    }

}

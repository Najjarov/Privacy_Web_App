namespace Privacy_Web_App.Models
{
    public class TournamentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string short_name { get; set; }
        public int year { get; set; }
        public int? winner_Id {get; set;}

        public string? winner_Name { get; set; }


        public int map1_id { get; set; }
        public int map1_Name { get; set; }

        public int map2_id { get; set; }
        public int map2_Name { get; set; }

    }
}

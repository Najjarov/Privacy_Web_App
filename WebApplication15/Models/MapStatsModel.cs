namespace Privacy_Web_App.Models
{
    public class MapStatsModel
    {
        public int Id { get; set; }


        public int Tour_id { get; set; }
        public string Tour_name { get; set; }

        public int map_id { get; set; }

        public int map_name { get; set; }
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
}

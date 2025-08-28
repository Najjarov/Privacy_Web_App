namespace Privacy_Web_App.Models
{
   
        public class MainMenuModel
        {
            public int Id { get; set; }
            public string text { get; set; }
            public int? viewid { get; set; }

        }
        public class SubMenuModel
        {
            public int Id { get; set; }
            public string text { get; set; }

            public int main_menu_id { get; set; }

            public string controller { get; set; }

            public string action { get; set; }

            public string att { get; set; }

            public int? viewid { get; set; }

        }
        public class MenuViewModel
        {
           
         
            public IEnumerable<MainMenuModel> mains { get; set; }
            public IEnumerable<SubMenuModel> subs { get; set; }

        }


    
}

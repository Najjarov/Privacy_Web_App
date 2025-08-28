namespace Privacy_Web_App.Models
{
    public class MapsViewModel
    {
        public MapModel map { get; set; }

        public IEnumerable<LandingPoiModel> pois { get; set; }
        public IEnumerable<MapModel> maps { get; set; }
        public IEnumerable<ViewsModel> views { get; set; }

    }
    public class MapModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string img { get; set; }
        public string Logo_img { get; set; }
       
    }
    public class playable_spots_Model
    {
        public int Id { get; set; }
        public string Map_id { get; set; }
        public string Map_Name { get; set; }
        public string img { get; set; }
        public MapModel map { get; set; }
        public IEnumerable<MapModel> maps { get; set; }
        public IEnumerable<ViewsModel> views { get; set; }

    }
    public class MapSpawnModel
    {
        public MapModel map { get; set; }
        public int Id { get; set; }
        public int map_id { get; set; }
        public string map_name { get; set; }

        public string uav_spawn { get; set; }

        public string console_spawn { get; set; }

        public string hotzone_spawn { get; set; }

        public string ship_spawn { get; set; }

        public string assault_bin_spawn_25px { get; set; }

        public string assault_bin_spawn_areas { get; set; }

        public string assault_bin_spawn_all { get; set; }



        public string evo_harvester_spawn_25px { get; set; }

        public string evo_harvester_spawn_areas { get; set; }

        public string evo_harvester_spawn_all { get; set; }

        public IEnumerable<MapModel> maps { get; set; }
        public IEnumerable<ViewsModel> views { get; set; }
    }

    public class MapLootModel
    {
        public MapModel map { get; set; }
        public int Id { get; set; }
        public int map_id { get; set; }
        public string map_name { get; set; }

        public string loot_qty { get; set; }

        public string cargobot { get; set; }
        public IEnumerable<MapModel> maps { get; set; }
        public IEnumerable<ViewsModel> views { get; set; }
    }

    public class poiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string img { get; set; }

        public string loot_bins_spawn_img { get; set; }
        public string loot_path_img { get; set; }




        public int Map_Id { get; set; }
        public string Map_name { get; set; }
        public string Map_short { get; set; }
        public string Map_img { get; set; }



        public int Season_Id { get; set; }
        public string Season_Name { get; set; }
        public string Season_no { get; set; }
    }

    public class LandingPoiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string img { get; set; }

        public string over_loot { get; set; }
        public string loot_path_img { get; set; }
        public string ext_loot_path_img { get; set; }


        public int hover_x { get; set; }
        public int hover_y { get; set; }



        public string hover_img { get; set; }
        public int Map_Id { get; set; }
        public string Map_name { get; set; }
        public string Map_short { get; set; }
        public string Map_img { get; set; }



        public int Season_Id { get; set; }
        public string Season_Name { get; set; }
        public string Season_no { get; set; }
    }



    public class lootInfoModel
    {
        public int Id { get; set; }
        public int map_Id { get; set; }
        public int poi_Id { get; set; }

        public int total_loots { get; set; }
        public int weapon_ref { get; set; }
        public int lootbins { get; set; }
        public int next_zone_beacons { get; set; }
        public int survey_beacons { get; set; }
        public int crafts { get; set; }
        public int respawn_beacons { get; set; }
        public int weapon_racks { get; set; }

    }

    public class lootDetailInfoModel
    {
        public int Id { get; set; }
        public int map_Id { get; set; }
        public int poi_Id { get; set; }

        public decimal cell { get; set; }
        public decimal syringe { get; set; }
        public decimal bat { get; set; }
        public decimal medkit { get; set; }
        public decimal phoenix { get; set; }
        public decimal ult_acc { get; set; }
        public decimal evac { get; set; }
        public decimal leg_back { get; set; }
        public decimal epic_back { get; set; }
        public decimal two_x { get; set; }
        public decimal three_x { get; set; }
        public decimal two_four_x { get; set; }
    }


    public class InteractiveMapViewModel
    {
        public MapModel map { get; set; }
        public int Map_id { get; set; }
        public IEnumerable<evacModel> evacs { get; set; }
        public IEnumerable<alter_void_Model> voids { get; set; }
        public IEnumerable<rats_Model> rats { get; set; }
        public IEnumerable<climbModel> climbs { get; set; }
        public IEnumerable<valkModel> valks { get; set; }
        public IEnumerable<MapModel> maps { get; set; }

        public IEnumerable<ViewsModel> views { get; set; }
    }


    public class evacModel
    {
        public int Id { get; set; }
        public int map_Id { get; set; }

        public string video { get; set; }

        public int x { get; set; }
        public int y { get; set; }
    }
    public class alter_void_Model
    {
        public int Id { get; set; }
        public int map_Id { get; set; }

        public string video { get; set; }

        public int x { get; set; }
        public int y { get; set; }
    }
    public class rats_Model
    {
        public int Id { get; set; }
        public int map_Id { get; set; }

        public string video { get; set; }

        public int x { get; set; }
        public int y { get; set; }
    }
    public class climbModel
    {
        public int Id { get; set; }
        public int map_Id { get; set; }



        public string video { get; set; }

        public int x { get; set; }
        public int y { get; set; }

    }

    public class valkModel
    {
        public int Id { get; set; }
        public int map_Id { get; set; }



        public string video { get; set; }

        public int x { get; set; }
        public int y { get; set; }

    }

    public class poiViewModel
    {
        public LandingPoiModel poiData { get; set; }
        public lootInfoModel lootInfol { get; set; }
        public lootDetailInfoModel lootDetailInfo { get; set; }


        public IEnumerable<evacModel> evacs { get; set; }

        public IEnumerable<climbModel> climbs { get; set; }



    }
    public class jumpTowerModel
    {
        public int Id { get; set; }
        public int map_id { get; set; }

        public int pos_x { get; set; }
        public int pos_y { get; set; }
        public int hover_x { get; set; }
        public int hover_y { get; set; }
        public string img { get; set; }
    }
    public class jumpTowerViewModel
    {
        public MapModel map { get; set; }
        public IEnumerable<jumpTowerModel> towers { get; set; }
        public IEnumerable<MapModel> maps { get; set; }
        public IEnumerable<ViewsModel> views { get; set; }
    }
    public class Uav_Range_Model
    {
        public int Id { get; set; }
        public int map_id { get; set; }

        public int pos_x { get; set; }
        public int pos_y { get; set; }
     
    }
    public class Uav_Range_ViewModel
    {
        public MapModel map { get; set; }
        public IEnumerable<Uav_Range_Model> uavs { get; set; }
        public IEnumerable<MapModel> maps { get; set; }
        public IEnumerable<ViewsModel> views { get; set; }
    }
}
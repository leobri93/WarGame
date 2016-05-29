using System.Collections;
using System.Collections.Generic;
using WarGame.Models;

namespace WarGame.Helper
{
    public static class Westeros
    {

        public static IList<RegionViewModel> Map()
        {
            var regions = new List<RegionViewModel>();
            var url = "Content/Images/Westeros/";

            AddWesterlands(regions, url+ "The_Westerlands/");
            AddReach(regions, url + "The_Reach/");
            AddStormlands(regions, url + "The_Stormlands/");
            AddCrowlands(regions, url + "The_Crownlands/");
            AddRiverlands(regions, url + "The_Riverlands/");
            AddIronIslands(regions, url + "The_Iron_Islands/");
            AddArryn(regions, url + "Vale_of_Arryn/");
            AddNorth(regions, url + "The_North/");

            return regions;
        }

        private static void AddWesterlands(List<RegionViewModel> regions, string url)
        {
            regions.Add(new RegionViewModel
            {
                Id = 1,
                Name = "Casterly Rock",
                Troops = 1,
                Src = url + "casterly_rock.png",
               
                X = 350,
                Y = 53
            });
            regions.Add(new RegionViewModel
            {
                Id = 2,
                Name = "Cornfield",
                Troops = 1,
                Src = url + "cornfield.png",
                X = 255,
                Y = 59
            });
            regions.Add(new RegionViewModel
            {
                Id = 3,
                Name = "Golden Tooth",
                Troops = 1,
                Src = url + "golden_tooth.png",
                X = 404,
                Y = 136
            });
            regions.Add(new RegionViewModel
            {
                Id = 4,
                Name = "Lannisvort",
                Troops = 1,
                Src = url + "lannisvort.png",
                X = 327,
                Y = 69
            });
            regions.Add(new RegionViewModel
            {
                Id = 5,
                Name = "Stone Scut",
                Troops = 1,
                Src = url + "stone_scut.png",
                X = 338,
                Y = 205
            });
        }

        private static void AddReach(List<RegionViewModel> regions, string url)
        {
            regions.Add(new RegionViewModel
            {
                Id = 6,
                Name = "Black Water Rush",
                Troops = 1,
                Src = url + "black_water_rush.png",
                X = 215,
                Y = 173
            });
            regions.Add(new RegionViewModel
            {
                Id = 7,
                Name = "Highgarden",
                Troops = 1,
                Src = url + "highgarden.png",
                X = 150,
                Y = 130
            });
            regions.Add(new RegionViewModel
            {
                Id = 8,
                Name = "Old Nak Tooth",
                Troops = 1,
                Src = url + "old_nak.png",
                X = 200,
                Y = 101
            });
            regions.Add(new RegionViewModel
            {
                Id = 9,
                Name = "Oldtown",
                Troops = 1,
                Src = url + "oldtown.png",
                X = 106,
                Y = 42
            });
            regions.Add(new RegionViewModel
            {
                Id = 10,
                Name = "Silber Hill",
                Troops = 1,
                Src = url + "silber_hill.png",
                X = 302,
                Y = 169
            });
        }

        private static void AddStormlands(List<RegionViewModel> regions, string url)
        {
            regions.Add(new RegionViewModel
            {
                Id = 11,
                Name = "Dornish Narchis",
                Troops = 1,
                Src = url + "dornish_narchis.png",
                X = 179,
                Y = 294
            });
            regions.Add(new RegionViewModel
            {
                Id = 12,
                Name = "Rainwood",
                Troops = 1,
                Src = url + "rainwood.png",
                X = 160,
                Y = 397
            });
            regions.Add(new RegionViewModel
            {
                Id = 14,
                Name = "Storms End",
                Troops = 1,
                Src = url + "storms_end.png",
                X = 252,
                Y = 427
            });
            regions.Add(new RegionViewModel
            {
                Id = 15,
                Name = "Tarth",
                Troops = 1,
                Src = url + "tarth.png",
                X = 245,
                Y = 520
            });
        }

        private static void AddCrowlands(List<RegionViewModel> regions, string url)
        {
            regions.Add(new RegionViewModel
            {
                Id = 16,
                Name = "Crackclaw Point",
                Troops = 1,
                Src = url + "crackclaw_point.png",
                X = 398,
                Y = 350
            });
            regions.Add(new RegionViewModel
            {
                Id = 17,
                Name = "Kings Lading",
                Troops = 1,
                Src = url + "kings_landing.png",
                X = 348,
                Y = 287
            });
            regions.Add(new RegionViewModel
            {
                Id = 18,
                Name = "Kingswood",
                Troops = 1,
                Src = url + "kingswood.png",
                X = 285,
                Y = 354
            });           
        }

        private static void AddRiverlands(List<RegionViewModel> regions, string url)
        {
            regions.Add(new RegionViewModel
            {
                Id = 19,
                Name = "Harrenhal",
                Troops = 1,
                Src = url + "harrenhal.png",
                X = 421,
                Y = 294
            });
            regions.Add(new RegionViewModel
            {
                Id = 20,
                Name = "Riberrun",
                Troops = 1,
                Src = url + "riberrun.png",
                X = 419,
                Y = 200
            });
            regions.Add(new RegionViewModel
            {
                Id = 21,
                Name = "The Crag",
                Troops = 1,
                Src = url + "the_crag.png",
                X = 453,
                Y = 117
            });
            regions.Add(new RegionViewModel
            {
                Id = 22,
                Name = "The Twins",
                Troops = 1,
                Src = url + "the_twins.png",
                X = 470,
                Y = 189
            });
        }

        private static void AddIronIslands(List<RegionViewModel> regions, string url)
        {
            regions.Add(new RegionViewModel
            {
                Id = 23,
                Name = "Harlaw",
                Troops = 1,
                Src = url + "harlaw.png",
                X = 590,
                Y = 100
            });
            regions.Add(new RegionViewModel
            {
                Id = 24,
                Name = "Pyke",
                Troops = 1,
                Src = url + "pyke.png",
                X = 540,
                Y = 60
            });
        }

        private static void AddArryn(List<RegionViewModel> regions, string url)
        {
            regions.Add(new RegionViewModel
            {
                Id = 25,
                Name = "Gulltown",
                Troops = 1,
                Src = url + "gulltown.png",
                X = 1540,
                Y = 160
            });
            regions.Add(new RegionViewModel
            {
                Id = 26,
                Name = "Salt Pans",
                Troops = 1,
                Src = url + "salt_pans.png",
                X = 464,
                Y = 346
            });
            regions.Add(new RegionViewModel
            {
                Id = 27,
                Name = "The Eyrie",
                Troops = 1,
                Src = url + "the_eyrie.png",
                X = 529,
                Y = 388
            });
            regions.Add(new RegionViewModel
            {
                Id = 28,
                Name = "The Fingers",
                Troops = 1,
                Src = url + "the_fingers.png",
                X = 578,
                Y = 340
            });
            regions.Add(new RegionViewModel
            {
                Id = 29,
                Name = "The Mountains of the Moon",
                Troops = 1,
                Src = url + "the_mountains_of_the_moon.png",
                X = 505,
                Y = 313
            });
            regions.Add(new RegionViewModel
            {
                Id = 30,
                Name = "West Bale",
                Troops = 1,
                Src = url + "west_bale.png",
                X = 545,
                Y = 291
            });
        }

        private static void AddNorth(List<RegionViewModel> regions, string url)
        {
            regions.Add(new RegionViewModel
            {
                Id = 31,
                Name = "Barrowlands",
                Troops = 1,
                Src = url + "barrowlands.png",
                X = 710,
                Y = 138
            });
            regions.Add(new RegionViewModel
            {
                Id = 32,
                Name = "Bear Island",
                Troops = 1,
                Src = url + "bear_island.png",
                X = 980,
                Y = 165
            });
            regions.Add(new RegionViewModel
            {
                Id = 33,
                Name = "Cape Krake",
                Troops = 1,
                Src = url + "cape_krake.png",
                X = 627,
                Y = 49
            });
            regions.Add(new RegionViewModel
            {
                Id = 34,
                Name = "Stone Shore",
                Troops = 1,
                Src = url + "stone_shore.png",
                X = 710,
                Y = 33
            });
            regions.Add(new RegionViewModel
            {
                Id = 35,
                Name = "The Grey Cliffs",
                Troops = 1,
                Src = url + "the_grey_cliffs.png",
                X = 861,
                Y = 419
            });
            regions.Add(new RegionViewModel
            {
                Id = 36,
                Name = "The Neck",
                Troops = 1,
                Src = url + "the_neck.png",
                X = 612,
                Y = 176
            });
            regions.Add(new RegionViewModel
            {
                Id = 36,
                Name = "The Wolfwoods",
                Troops = 1,
                Src = url + "the_wolfwoods.png",
                X = 830,
                Y = 140
            });
            regions.Add(new RegionViewModel
            {
                Id = 37,
                Name = "White Habor",
                Troops = 1,
                Src = url + "white_habor.png",
                X = 688,
                Y = 274
            });
            regions.Add(new RegionViewModel
            {
                Id = 38,
                Name = "Widows Watch",
                Troops = 1,
                Src = url + "widows_watch.png",
                X = 752,
                Y = 390
            });
            regions.Add(new RegionViewModel
            {
                Id = 39,
                Name = "Winterfell",
                Troops = 1,
                Src = url + "winterfell.png",
                X = 760,
                Y = 182
            });
        }
    }
}
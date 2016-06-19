using WarGame.Models;

namespace WarGame.Helper
{
    public class Region {

        private static readonly Region instance;

        //THE WESTERLANDS
        private RegionViewModel casterlyRock { get; }
        private RegionViewModel cornfield { get; }
        private RegionViewModel goldenTooth { get; }
        private RegionViewModel lannisvort { get; }
        private RegionViewModel stoneScut { get; }

        //THE REACH
        private RegionViewModel blackWaterRush { get; }
        private RegionViewModel highgarden { get; }
        private RegionViewModel oldNak { get; }
        private RegionViewModel oldtown { get; }
        private RegionViewModel silberHill { get; }

        //THE CORWNLANDS
        private RegionViewModel crackclawPoint { get; }
        private RegionViewModel kingsLanding { get; }
        private RegionViewModel kingswood { get; }

        //DORNE
        private RegionViewModel redMountains { get; }
        private RegionViewModel sandstone { get; }
        private RegionViewModel sanspear { get; }

        //THE IRON ISLANDS
        private RegionViewModel harlaw { get; }
        private RegionViewModel pyke { get; }

        //THE NORTH
        private RegionViewModel barrowlands { get; }
        private RegionViewModel bearIsland { get; }
        private RegionViewModel capeKrake { get; }
        private RegionViewModel stoneShore { get; }
        private RegionViewModel theGreyCliffs { get; }
        private RegionViewModel theNeck { get; }
        private RegionViewModel theWolfwoods { get; }
        private RegionViewModel whiteHabor { get; }
        private RegionViewModel widowsWatch { get; }
        private RegionViewModel winterfell { get; }

        //THE RIVERLANDS
        private RegionViewModel harrenhal { get; }
        private RegionViewModel riberrun { get; }
        private RegionViewModel theCrag { get; }
        private RegionViewModel theTwins { get; }

        //THE STORMLANDS
        private RegionViewModel dornishNarchis { get; }
        private RegionViewModel rainwood { get; }
        private RegionViewModel stormsEnd { get; }
        private RegionViewModel tarth { get; }

        //THE VALE OF ARRYN
        private RegionViewModel gulltown { get; }
        private RegionViewModel saltPans { get; }
        private RegionViewModel theEyrie { get; }
        private RegionViewModel theFingers { get; }
        private RegionViewModel theMountainsOfTheMoon { get; }
        private RegionViewModel westBale { get; }


        private Region(Kingdom kingdom) 
        {
            var PATH_THE_WESTERLANDS = "/Content/Images/Westeros/The_Westerlands";
            casterlyRock   = new RegionViewModel("Casterly Rock", $"{PATH_THE_WESTERLANDS}/casterly_rock.png", kingdom.TheWesterlands, 350, 53);
            cornfield      = new RegionViewModel("Cornfield", $"{PATH_THE_WESTERLANDS}/cornfield.png", kingdom.TheWesterlands, 255, 59);
            goldenTooth    = new RegionViewModel("Golden Tooth", $"{PATH_THE_WESTERLANDS}/golden_tooth.png", kingdom.TheWesterlands, 404, 136);
            lannisvort     = new RegionViewModel("Lannisvort", $"{PATH_THE_WESTERLANDS}/lannisvort.png", kingdom.TheWesterlands, 327, 69);
            stoneScut      = new RegionViewModel("Stone Scut", $"{PATH_THE_WESTERLANDS}/stone_scut.png", kingdom.TheWesterlands, 338, 205);


            var PATH_THE_REACH = "/Content/Images/Westeros/The_Reach";
            blackWaterRush = new RegionViewModel("Black Water Rush", $"{PATH_THE_REACH}/black_water_rush.png", kingdom.TheReach, 215, 173);
            highgarden     = new RegionViewModel("Highgarden", $"{PATH_THE_REACH}/highgarden.png", kingdom.TheReach, 150, 130);
            oldNak         = new RegionViewModel("Old Nak", $"{PATH_THE_REACH}/old_nak.png", kingdom.TheReach, 200, 101);
            oldtown        = new RegionViewModel("Oldtown", $"{PATH_THE_REACH}/oldtown.png", kingdom.TheReach, 106, 42);
            silberHill     = new RegionViewModel("Silber Hill", $"{PATH_THE_REACH}/silber_hill.png", kingdom.TheReach, 302, 169);


            var PATH_THE_STORMLANDS = "/Content/Images/Westeros/The_Stormlands";
            dornishNarchis = new RegionViewModel("Dornish Narchis", $"{PATH_THE_STORMLANDS}/dornish_narchis.png", kingdom.TheStormlands, 179, 294);
            rainwood       = new RegionViewModel("Rainwood", $"{PATH_THE_STORMLANDS}/rainwood.png", kingdom.TheStormlands, 160, 397);
            stormsEnd      = new RegionViewModel("Storms End", $"{PATH_THE_STORMLANDS}/storms_end.png", kingdom.TheStormlands, 252, 427);
            tarth          = new RegionViewModel("Tarth", $"{PATH_THE_STORMLANDS}/tarth.png", kingdom.TheStormlands, 245, 520);


            var PATH_THE_CROWLANDS = "/Content/Images/Westeros/The_Crownlands";
            crackclawPoint  = new RegionViewModel("Crackclaw Point", $"{PATH_THE_CROWLANDS}/crackclaw_point.png", kingdom.TheCrownlands, 398, 350);
            kingsLanding    = new RegionViewModel("Kings Landing", $"{PATH_THE_CROWLANDS}/kings_landing.png", kingdom.TheCrownlands, 348, 287);
            kingswood       = new RegionViewModel("Kingswood", $"{PATH_THE_CROWLANDS}/kingswood.png", kingdom.TheCrownlands, 285, 354);


            var PATH_THE_RIVERLANDS = "/Content/Images/Westeros/The_Riverlands";
            harrenhal       = new RegionViewModel("Harrenhal", $"{PATH_THE_RIVERLANDS}/harrenhal.png", kingdom.TheRiverlands, 421, 294);
            riberrun        = new RegionViewModel("Riberrun", $"{PATH_THE_RIVERLANDS}/riberrun.png", kingdom.TheRiverlands, 419, 200);
            theCrag         = new RegionViewModel("The Crag", $"{PATH_THE_RIVERLANDS}/the_crag.png", kingdom.TheRiverlands, 453, 117);
            theTwins        = new RegionViewModel("The Twins", $"{PATH_THE_RIVERLANDS}/the_twins.png", kingdom.TheRiverlands, 470, 189);


            var PATH_THE_IRON_ISLANDS = "/Content/Images/Westeros/The_Iron_Islands";
            harlaw          = new RegionViewModel("Harlaw", $"{PATH_THE_IRON_ISLANDS}/harlaw.png", kingdom.TheIronIslands, 590, 100);
            pyke            = new RegionViewModel("Pyke", $"{PATH_THE_IRON_ISLANDS}/pyke.png", kingdom.TheIronIslands, 540, 60);


            var PATH_VALE_OF_ARRYN = "/Content/Images/Westeros/Vale_of_Arryn";
            gulltown         = new RegionViewModel("Gulltown", $"{PATH_VALE_OF_ARRYN}/gulltown.png", kingdom.TheValeOfArryn, 507, 475);
            saltPans         = new RegionViewModel("Salt Pans", $"{PATH_VALE_OF_ARRYN}/salt_pans.png", kingdom.TheValeOfArryn, 464, 346);
            theEyrie         = new RegionViewModel("The Eyrie", $"{PATH_VALE_OF_ARRYN}/the_eyrie.png", kingdom.TheValeOfArryn, 529, 388);
            theFingers       = new RegionViewModel("The Fingers", $"{PATH_VALE_OF_ARRYN}/the_fingers.png", kingdom.TheValeOfArryn, 578, 340);
            theMountainsOfTheMoon = new RegionViewModel("The Mountains of the Moon", $"{PATH_VALE_OF_ARRYN}/the_mountains_of_the_moon.png", kingdom.TheValeOfArryn, 505, 313);
            westBale        = new RegionViewModel("West Bale", $"{PATH_VALE_OF_ARRYN}/west_bale.png", kingdom.TheValeOfArryn, 545, 291);

            var PATH_THE_NORTH = "/Content/Images/Westeros/The_North";
            barrowlands     = new RegionViewModel("Barrowlands", $"{PATH_THE_NORTH}/barrowlands.png", kingdom.TheNorth, 710, 138);
            bearIsland      = new RegionViewModel("Bear Island", $"{PATH_THE_NORTH}/bear_island.png", kingdom.TheNorth, 980, 165);
            capeKrake       = new RegionViewModel("Cape Krake", $"{PATH_THE_NORTH}/cape_krake.png", kingdom.TheNorth, 627, 49);
            stoneShore      = new RegionViewModel("Stone Shore", $"{PATH_THE_NORTH}/stone_shore.png", kingdom.TheNorth, 710, 33);
            theGreyCliffs   = new RegionViewModel("The Grey Cliffs", $"{PATH_THE_NORTH}/the_grey_cliffs.png", kingdom.TheNorth, 861, 419);
            theNeck         = new RegionViewModel("The Neck", $"{PATH_THE_NORTH}/the_neck.png", kingdom.TheNorth, 612, 176);
            theWolfwoods    = new RegionViewModel("The Wolfwoods", $"{PATH_THE_NORTH}/the_wolfwoods.png", kingdom.TheNorth, 830, 140);
            whiteHabor      = new RegionViewModel("White Habor", $"{PATH_THE_NORTH}/white_habor.png", kingdom.TheNorth, 688, 274);
            widowsWatch     = new RegionViewModel("Widows Watch", $"{PATH_THE_NORTH}/widows_watch.png", kingdom.TheNorth, 752, 390);
            winterfell      = new RegionViewModel("Winterfell", $"{PATH_THE_NORTH}/winterfell.png", kingdom.TheNorth, 773, 210);


            var PATH_DORNE = "/Content/Images/Westeros/Dorne";
            redMountains    = new RegionViewModel("Red Mountains", $"{PATH_DORNE}/red_mountains.png", kingdom.Dorne, 33, 78);
            sandstone       = new RegionViewModel("Sandstone", $"{PATH_DORNE}/sandstone.png", kingdom.Dorne, 5, 163);
            sanspear        = new RegionViewModel("Sanspear", $"{PATH_DORNE}/sanspear.png", kingdom.Dorne, -6, 295);
        }

        public static Region Instance(Kingdom kingdom)
        {
            return (instance == null) ? new Region(kingdom) : instance;
        }

        public RegionViewModel CasterlyRock { get { return casterlyRock; } }
        public RegionViewModel Cornfield { get { return cornfield; } }
        public RegionViewModel GoldenTooth { get { return goldenTooth; } }
        public RegionViewModel Lannisvort { get { return lannisvort; } }
        public RegionViewModel StoneScut { get { return stoneScut; } }
        public RegionViewModel BlackWaterRush { get { return blackWaterRush; } }
        public RegionViewModel Highgarden { get { return highgarden; } }
        public RegionViewModel OldNak { get { return oldNak; } }
        public RegionViewModel Oldtown { get { return oldtown; } }
        public RegionViewModel SilberHill { get { return silberHill; } }
        public RegionViewModel CrackclawPoint { get { return crackclawPoint; } }
        public RegionViewModel KingsLanding { get { return kingsLanding; } }
        public RegionViewModel Kingswood { get { return kingswood; } }
        public RegionViewModel RedMountains { get { return redMountains; } }
        public RegionViewModel Sandstone { get {return sandstone; } }
        public RegionViewModel Sanspear { get { return sanspear; } }
        public RegionViewModel Harlaw { get { return harlaw; } }
        public RegionViewModel Pyke { get { return pyke; } }
        public RegionViewModel Barrowlands { get { return barrowlands; } }
        public RegionViewModel BearIsland { get { return bearIsland; } }
        public RegionViewModel CapeKrake { get { return capeKrake; } }
        public RegionViewModel StoneShore { get { return stoneShore; } }
        public RegionViewModel TheGreyCliffs { get { return theGreyCliffs; } }
        public RegionViewModel TheNeck { get { return theNeck; } }
        public RegionViewModel TheWolfwoods { get { return theWolfwoods; } }
        public RegionViewModel WhiteHabor { get { return whiteHabor; } }
        public RegionViewModel WidowsWatch { get { return widowsWatch; } }
        public RegionViewModel Winterfell { get { return winterfell; } }
        public RegionViewModel Harrenhal { get { return harrenhal; } }
        public RegionViewModel Riberrun { get { return riberrun; } }
        public RegionViewModel TheCrag { get { return theCrag; } }
        public RegionViewModel TheTwins { get { return theTwins; } }
        public RegionViewModel DornishNarchis { get { return dornishNarchis; } }
        public RegionViewModel Rainwood { get { return rainwood; } }
        public RegionViewModel StormsEnd { get { return stormsEnd; } }
        public RegionViewModel Tarth { get { return tarth; } }
        public RegionViewModel Gulltown { get { return gulltown; } }
        public RegionViewModel SaltPans { get { return saltPans; } }
        public RegionViewModel TheEyrie { get { return theEyrie; } }
        public RegionViewModel TheFingers { get { return theFingers; } }
        public RegionViewModel TheMountainsOfTheMoon { get { return theMountainsOfTheMoon; } }
        public RegionViewModel WestBale { get { return westBale; } }

    }
}
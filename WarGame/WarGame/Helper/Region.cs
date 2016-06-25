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
            casterlyRock   = new RegionViewModel("Casterly Rock", kingdom.TheWesterlands, new RegionPosition($"{PATH_THE_WESTERLANDS}/casterly_rock.png", 350, 53, 420, 130));
            cornfield      = new RegionViewModel("Cornfield", kingdom.TheWesterlands, new RegionPosition($"{PATH_THE_WESTERLANDS}/cornfield.png", 255, 59, 310, 110));
            goldenTooth    = new RegionViewModel("Golden Tooth", kingdom.TheWesterlands, new RegionPosition($"{PATH_THE_WESTERLANDS}/golden_tooth.png", 404, 136, 460, 200));
            lannisvort     = new RegionViewModel("Lannisvort", kingdom.TheWesterlands, new RegionPosition($"{PATH_THE_WESTERLANDS}/lannisvort.png", 327, 69, 380,  130));
            stoneScut      = new RegionViewModel("Stone Scut", kingdom.TheWesterlands, new RegionPosition($"{PATH_THE_WESTERLANDS}/stone_scut.png", 338, 205, 400, 250));


            var PATH_THE_REACH = "/Content/Images/Westeros/The_Reach";
            blackWaterRush = new RegionViewModel("Black Water Rush", kingdom.TheReach, new RegionPosition($"{PATH_THE_REACH}/black_water_rush.png", 215, 173, 280, 250));
            highgarden     = new RegionViewModel("Highgarden", kingdom.TheReach, new RegionPosition($"{PATH_THE_REACH}/highgarden.png", 150, 130, 210, 200));
            oldNak         = new RegionViewModel("Old Nak", kingdom.TheReach, new RegionPosition($"{PATH_THE_REACH}/old_nak.png", 200, 101, 260, 160));
            oldtown        = new RegionViewModel("Oldtown", kingdom.TheReach, new RegionPosition($"{PATH_THE_REACH}/oldtown.png", 106, 42, 150, 80));
            silberHill     = new RegionViewModel("Silber Hill", kingdom.TheReach, new RegionPosition($"{ PATH_THE_REACH}/silber_hill.png", 302, 169, 340, 250));


            var PATH_THE_STORMLANDS = "/Content/Images/Westeros/The_Stormlands";
            dornishNarchis = new RegionViewModel("Dornish Narchis", kingdom.TheStormlands, new RegionPosition($"{PATH_THE_STORMLANDS}/dornish_narchis.png", 179, 294, 230, 370));
            rainwood       = new RegionViewModel("Rainwood", kingdom.TheStormlands, new RegionPosition($"{PATH_THE_STORMLANDS}/rainwood.png", 160, 397, 210, 460));
            stormsEnd      = new RegionViewModel("Storms End", kingdom.TheStormlands, new RegionPosition($"{PATH_THE_STORMLANDS}/storms_end.png", 252, 427, 300, 470));
            tarth          = new RegionViewModel("Tarth", kingdom.TheStormlands, new RegionPosition($"{PATH_THE_STORMLANDS}/tarth.png", 245, 520, 280, 550));


            var PATH_THE_CROWLANDS = "/Content/Images/Westeros/The_Crownlands";
            crackclawPoint  = new RegionViewModel("Crackclaw Point", kingdom.TheCrownlands, new RegionPosition($"{PATH_THE_CROWLANDS}/crackclaw_point.png", 398, 350, 435, 410));
            kingsLanding    = new RegionViewModel("Kings Landing", kingdom.TheCrownlands, new RegionPosition($"{PATH_THE_CROWLANDS}/kings_landing.png", 348, 287, 400, 360));
            kingswood       = new RegionViewModel("Kingswood", kingdom.TheCrownlands, new RegionPosition($"{PATH_THE_CROWLANDS}/kingswood.png", 285, 354, 320, 410));


            var PATH_THE_RIVERLANDS = "/Content/Images/Westeros/The_Riverlands";
            harrenhal       = new RegionViewModel("Harrenhal", kingdom.TheRiverlands, new RegionPosition($"{PATH_THE_RIVERLANDS}/harrenhal.png", 421, 294, 455, 330));
            riberrun        = new RegionViewModel("Riberrun", kingdom.TheRiverlands, new RegionPosition($"{PATH_THE_RIVERLANDS}/riberrun.png", 419, 200, 490, 270));
            theCrag         = new RegionViewModel("The Crag", kingdom.TheRiverlands, new RegionPosition($"{PATH_THE_RIVERLANDS}/the_crag.png", 453, 117, 500, 170));
            theTwins        = new RegionViewModel("The Twins", kingdom.TheRiverlands, new RegionPosition($"{PATH_THE_RIVERLANDS}/the_twins.png", 470, 189, 580, 270));


            var PATH_THE_IRON_ISLANDS = "/Content/Images/Westeros/The_Iron_Islands";
            harlaw          = new RegionViewModel("Harlaw", kingdom.TheIronIslands, new RegionPosition($"{PATH_THE_IRON_ISLANDS}/harlaw.png", 590, 100, 590, 125));
            pyke            = new RegionViewModel("Pyke", kingdom.TheIronIslands, new RegionPosition($"{PATH_THE_IRON_ISLANDS}/pyke.png", 540, 60, 560, 70));


            var PATH_VALE_OF_ARRYN = "/Content/Images/Westeros/Vale_of_Arryn";
            gulltown         = new RegionViewModel("Gulltown", kingdom.TheValeOfArryn, new RegionPosition($"{PATH_VALE_OF_ARRYN}/gulltown.png", 507, 475, 530, 520));
            saltPans         = new RegionViewModel("Salt Pans", kingdom.TheValeOfArryn, new RegionPosition($"{PATH_VALE_OF_ARRYN}/salt_pans.png", 464, 346, 500, 430));
            theEyrie         = new RegionViewModel("The Eyrie", kingdom.TheValeOfArryn, new RegionPosition($"{PATH_VALE_OF_ARRYN}/the_eyrie.png", 529, 388, 560, 460));
            theFingers       = new RegionViewModel("The Fingers", kingdom.TheValeOfArryn, new RegionPosition($"{PATH_VALE_OF_ARRYN}/the_fingers.png", 578, 340, 620, 390));
            theMountainsOfTheMoon = new RegionViewModel("The Mountains of the Moon", kingdom.TheValeOfArryn, new RegionPosition($"{PATH_VALE_OF_ARRYN}/the_mountains_of_the_moon.png", 505, 313, 530, 360));
            westBale        = new RegionViewModel("West Bale", kingdom.TheValeOfArryn, new RegionPosition($"{PATH_VALE_OF_ARRYN}/west_bale.png", 545, 291, 590, 320));

            var PATH_THE_NORTH = "/Content/Images/Westeros/The_North";
            barrowlands     = new RegionViewModel("Barrowlands", kingdom.TheNorth, new RegionPosition($"{PATH_THE_NORTH}/barrowlands.png", 710, 138, 780, 240));
            bearIsland      = new RegionViewModel("Bear Island", kingdom.TheNorth, new RegionPosition($"{PATH_THE_NORTH}/bear_island.png", 980, 165, 1000, 165));
            capeKrake       = new RegionViewModel("Cape Krake", kingdom.TheNorth, new RegionPosition($"{PATH_THE_NORTH}/cape_krake.png", 627, 49, 660, 90));
            stoneShore      = new RegionViewModel("Stone Shore", kingdom.TheNorth, new RegionPosition($"{PATH_THE_NORTH}/stone_shore.png", 710, 33, 780, 110));
            theGreyCliffs   = new RegionViewModel("The Grey Cliffs",kingdom.TheNorth, new RegionPosition($"{PATH_THE_NORTH}/the_grey_cliffs.png", 861, 419, 950, 499));
            theNeck         = new RegionViewModel("The Neck", kingdom.TheNorth, new RegionPosition($"{PATH_THE_NORTH}/the_neck.png", 612, 176, 660, 240));
            theWolfwoods    = new RegionViewModel("The Wolfwoods", kingdom.TheNorth, new RegionPosition($"{PATH_THE_NORTH}/the_wolfwoods.png", 830, 140, 890, 200));
            whiteHabor      = new RegionViewModel("White Habor", kingdom.TheNorth, new RegionPosition($"{PATH_THE_NORTH}/white_habor.png", 688, 274, 760, 390));
            widowsWatch     = new RegionViewModel("Widows Watch", kingdom.TheNorth, new RegionPosition($"{PATH_THE_NORTH}/widows_watch.png", 752, 390, 810, 450));
            winterfell      = new RegionViewModel("Winterfell", kingdom.TheNorth, new RegionPosition($"{PATH_THE_NORTH}/winterfell.png", 773, 210, 870, 350));


            var PATH_DORNE = "/Content/Images/Westeros/Dorne";
            redMountains    = new RegionViewModel("Red Mountains", kingdom.Dorne, new RegionPosition($"{PATH_DORNE}/red_mountains.png", 33, 78, 100, 130));
            sandstone       = new RegionViewModel("Sandstone", kingdom.Dorne, new RegionPosition($"{PATH_DORNE}/sandstone.png", 5, 163, 80, 264));
            sanspear        = new RegionViewModel("Sanspear", kingdom.Dorne, new RegionPosition($"{PATH_DORNE}/sanspear.png", -6, 295, 70, 420));
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
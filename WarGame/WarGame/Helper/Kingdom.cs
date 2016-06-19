using WarGame.Models;

namespace WarGame.Helper 
{
    public class Kingdom 
    {

        private static readonly Kingdom instance = new Kingdom();

        private KingdomViewModel theWesterlands;
        private KingdomViewModel theReach;
        private KingdomViewModel dorne;
        private KingdomViewModel theCrownlands;
        private KingdomViewModel theIronIslands;
        private KingdomViewModel theNorth;
        private KingdomViewModel theRiverlands;
        private KingdomViewModel theStormlands;
        private KingdomViewModel theValeOfArryn;

        private Kingdom() 
        {
            theWesterlands = new KingdomViewModel("The Westerlands", 5, 5);
            theReach = new KingdomViewModel("The Reach", 4, 5);
            dorne = new KingdomViewModel("Dorne", 2, 3);
            theCrownlands = new KingdomViewModel("The Crownlands", 4, 3);
            theIronIslands = new KingdomViewModel("The Iron Islands", 1, 2);
            theNorth = new KingdomViewModel("The North", 11, 10);
            theRiverlands = new KingdomViewModel("The Riverlands", 3, 4);
            theStormlands = new KingdomViewModel("The Stormlands", 5, 4);
            theValeOfArryn = new KingdomViewModel("TheValeOfArryn", 8, 6);
        }

        public static Kingdom Instance
        {
            get { return instance; }
        }

        public KingdomViewModel TheWesterlands
        {
            get { return theWesterlands;}
        }

        public KingdomViewModel TheReach
        {
            get { return theReach; }
        }

        public KingdomViewModel Dorne
        {
            get { return dorne; }
        }

        public KingdomViewModel TheCrownlands
        {
            get { return theCrownlands; }
        }

        public KingdomViewModel TheIronIslands
        {
            get { return theIronIslands; }
        }

        public KingdomViewModel TheNorth
        {
            get { return theNorth; }      
        }

        public KingdomViewModel TheRiverlands
        {
            get { return theRiverlands; }
        }

        public KingdomViewModel TheStormlands
        {
            get { return theStormlands; }
        }

        public KingdomViewModel TheValeOfArryn
        {
            get { return theValeOfArryn; }
        }
    }
}
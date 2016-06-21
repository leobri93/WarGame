using System;

namespace WarGame.Models
{
    public class KingdomViewModel
    {
        private string id;

        private string name;

        private int bonus;

        private int regions;

        public KingdomViewModel(string name, int bonus, int regions) 
        {
            id = Guid.NewGuid().ToString("N");
            this.name = name;
            this.bonus = bonus;
            this.regions = regions;
        }

        public string Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }

        public int Bonus
        {
            get { return bonus; }
        }

        public int Regions
        {
            get { return regions; }
        }

        public bool CheckDomination(int areasDominated) 
        {
            if (areasDominated == regions)
                return true;
            return false;
        }

    }

}
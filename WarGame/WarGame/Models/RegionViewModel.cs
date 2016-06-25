using System;
using System.Collections.Generic;
using WarGame.Helper;

namespace WarGame.Models
{
    public class RegionViewModel
    {

        private string id;

        private string name;

        private PlayerViewModel player;

        private int troops;

        private List<RegionViewModel> frontiers;

        private KingdomViewModel kingdom;

        private RegionPosition regionPosition;

        public RegionViewModel(string name, KingdomViewModel kingdom, RegionPosition regionPosition)
        {
            id = Guid.NewGuid().ToString("N");
            this.name = name;
            this.kingdom = kingdom;

            this.x = x;
            this.y = y;

            Objective obj = new Objective();
            
            //Raffling an objective
            ObjectiveModel objModel = obj.RafflingObjectives();

            player = new PlayerViewModel("Computador", "Stark", objModel);
            troops = 1;
            this.regionPosition = regionPosition;
        }

        public string Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }

        public PlayerViewModel Player
        {
            get { return player; }
            set { player = value; }
        }

        public int Troops
        {
            get { return troops; }
            set { troops = value; }
        }

        public KingdomViewModel Kingdom
        {
            get { return kingdom; }
        }

        public RegionPosition RegionsPosition
        {
            get { return regionPosition; }
        }

        public void Frontiers(List<RegionViewModel> frontiers) 
        {
            this.frontiers = frontiers;
        }

        public RegionViewModel CheckFrontier(RegionViewModel region)
        {
            var index = frontiers.BinarySearch(region);
            if (index >= 0)
            {
                return region.frontiers[index];
            }
            return null;
        }

    }


    public class RegionPosition
    {
        private string src;
        private int regionX;
        private int regionY;
        private int troopsX;
        private int troopsY;

        public RegionPosition(string src, int regionX, int regionY, int troopsX, int troopsY)
        {
            this.src = src;
            this.regionX = regionX;
            this.regionY = regionY;
            this.troopsX = troopsX;
            this.troopsY = troopsY;
        }

        public string Src
        {
            get { return src; }
        }

        public int RegionX
        {
            get { return regionX; }
        }

        public int RegionY
        {
            get { return regionY; }
        }

        public int TroopsX
        {
            get { return troopsX; }
        }

        public int TroopsY
        {
            get { return troopsY; }
        }

    }

}
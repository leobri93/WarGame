using System;
using System.Collections.Generic;

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

        private string src;

        private int x;

        private int y;

        public RegionViewModel(string name, string src, KingdomViewModel kingdom, int x, int y)
        {
            id = Guid.NewGuid().ToString("N");
            this.name = name;
            this.src = src;
            this.kingdom = kingdom;
            this.x = x;
            this.y = y;
            player = new PlayerViewModel("Computador", "Stark");
            troops = 1;
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

        public string Src
        {
            get { return src; }
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
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
}
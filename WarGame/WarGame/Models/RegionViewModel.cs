﻿using System;
using System.Collections.Generic;
using WarGame.Helper;
using System.Linq;

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

        public RegionViewModel(string name, KingdomViewModel kingdom, RegionPosition regionPosition, int troops = 1)
        {
            id = Guid.NewGuid().ToString("N");
            this.name = name;
            this.kingdom = kingdom;
            this.troops = troops;
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

        public List<RegionViewModel> Frontiers() 
        {
            return frontiers;
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

        public List<RegionViewModel> EnemyFrontiers(string id)
        {
            if (Player.Id.Equals(id))
            {
                return frontiers.Where(r => !r.Player.Id.Equals(id)).ToList();
            }
            return new List<RegionViewModel>();
        }

        public List<RegionViewModel> FriendlyFrontiers(string id) 
        {
            if (Player.Id.Equals(id))
            {
                return frontiers.Where(r => r.Player.Id.Equals(id)).ToList();
            }
            return new List<RegionViewModel>();
        }

        public int[] Attack(RegionViewModel defense , int[] aplayer, int[] dplayer) 
        {
            var attackLostTroops = 0;
            var defenseLostTroops = 0;
            for (var i = 0; i < 3; i++)
            {
                if (aplayer.Length > i && dplayer.Length > i)
                {
                    if (aplayer[i] <= dplayer[i])
                    {
                        attackLostTroops++;
                        --troops;
                    } else
                    {
                        defenseLostTroops++;
                        --defense.Troops;
                    }
                }
            }
            return new int[] { attackLostTroops, defenseLostTroops };
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
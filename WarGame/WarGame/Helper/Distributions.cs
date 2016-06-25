using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarGame.Models;

namespace WarGame.Helper
{
    public class Distributions
    {
        public void regionsDistribution(List<PlayerViewModel> players, List<RegionViewModel> regions)
        {
            int numberOfterritories = regions.Count / players.Count;

            List<RegionViewModel> auxRegions = regions;
            bool completed = false;
            while (!completed)
            {
                for(int i = 0; i < 14; i++)
                {

                }
            }
        }
    }
}
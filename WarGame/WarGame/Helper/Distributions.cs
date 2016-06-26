using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarGame.Models;

namespace WarGame.Helper
{
    public class Distributions
    {
        /// <summary>
        /// Initial distribution of players in each region of the map
        /// </summary>
        /// <param name="players"></param>
        /// <param name="regions"></param>
        public void regionsDistribution(List<PlayerViewModel> players, List<RegionViewModel> regions)
        {
            int numberOfterritories = regions.Count / players.Count;

            Random rnd = new Random();

            List<RegionViewModel> auxRegions = regions;
            bool completed = false;

            int playerCount = players.Count;
            int randomCount = 42;

            while (!completed)
            {
                for(int i = 0; i < numberOfterritories; i++)
                {
                    // Get a random region id to set the player 
                    RegionViewModel currentRegion = auxRegions[rnd.Next(randomCount)];

                    // Search for the region that contains the ID extracted above, after that, set the player in the region selected  
                    regions.Where(r => r.Id.Equals(currentRegion.Id)).ToList().ForEach(r2 => r2.Player = players[playerCount - 1]);

                    // Remove the region from the list to avoid selecting it again 
                    auxRegions.Remove(currentRegion);

                    // Subtract the random counter, because we have one less region
                    randomCount--;
                }

                playerCount--;

                //If we don't have more players, the operation is complete
                if (playerCount == 0)
                    completed = true;

            }
        }
    }
}
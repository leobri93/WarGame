using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarGame.Helper;
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

        /// <summary>
        /// Distribution of troops for a player before the turn
        /// </summary>
        /// <param name="player"></param>
        /// <returns>Number of troops the player will be able to use based on the number of regions he owns</returns>
        public int troopsDistribution (PlayerViewModel player, List<RegionViewModel> regions)
        {
            int numberOfTroops;

            //Get the regions dominated by the player
            List<RegionViewModel> regionsDominatedByPlayer = regions.DominatedRegions(player.Id);

            //Divide the total number of regions dominated by 2, this will give us the number of troops
            numberOfTroops = regionsDominatedByPlayer.Count / 2;

            //Get the kingdoms dominated by the player
            List<KingdomViewModel> kingdomsDominatedByPlayer = regions.ConqueredKingdoms(player);

            //Sanity check
            if(kingdomsDominatedByPlayer.Count > 0)
            {
                //If the player has dominated one or more kingdoms, add the bonus in the number of troops that will be returned
                foreach(KingdomViewModel currentKingdom in kingdomsDominatedByPlayer)
                {
                    numberOfTroops = numberOfTroops + currentKingdom.Bonus;
                }
            }

            return numberOfTroops;
        }
    }
}
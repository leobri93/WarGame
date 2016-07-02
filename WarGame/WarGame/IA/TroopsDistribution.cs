using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarGame.Helper;
using WarGame.Models;

namespace WarGame.IA
{
    public class TroopsDistribution
    {

        public static void IADistributionTroops(PlayerViewModel player, List<RegionViewModel> regions)
        {
            Random rnd = new Random();

            //Get the number of toops the player have for his next turn.
            int numberOfTroops = Distributions.troopsDistribution(player, regions);


            //Get the regions dominated by the player
            List<RegionViewModel> regionsDominatedByPlayer = regions.DominatedRegions(player.Id);


            Region aux;

            for (int i = 0; i < numberOfTroops; i++)
            {
                int randomNumber = rnd.Next(regionsDominatedByPlayer.Count);
                regionsDominatedByPlayer[randomNumber].Troops += 1;

            }
        }
    }

}
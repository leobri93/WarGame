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

        public Dictionary<string, int> IADistributionTroops(PlayerViewModel player, List<RegionViewModel> regions)
        {
            Random rnd = new Random();

            //Get the number of toops the player have for his next turn.
            int numberOfTroops = Distributions.troopsDistribution(player, regions);


            //Get the regions dominated by the player
            List<RegionViewModel> regionsDominatedByPlayer = regions.DominatedRegions(player.Id);

            Dictionary<string, int> regionsResult = new Dictionary<string, int>();

            RegionViewModel aux;

            //Distribution the number of troops for the next IA turn randonly. 
            for (int i = 0; i < numberOfTroops; i++)
            {

                int randomNumber = rnd.Next(regionsDominatedByPlayer.Count);
                aux = regionsDominatedByPlayer[randomNumber];
                regions.Where(r=>r.Id.Equals(aux.Id)).ToList().ForEach(r2=>r2.Troops = r2.Troops + 1);
                
                //Verify if the region is on the dictionary
                if (regionsResult.ContainsKey(aux.Name))
                {
                    regionsResult[aux.Name] = regionsResult[aux.Name] + 1;
                }
                else
                {
                    regionsResult.Add(aux.Name, 1);
                }
            }

            return regionsResult;
        }
    }

}
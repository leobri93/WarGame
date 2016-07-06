using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarGame.Models;

namespace WarGame.Helper
{
    public static class Search 
    {

        public static PlayerViewModel FindPlayer(this List<PlayerViewModel> players, string playerId)
        {
            var player = players.FirstOrDefault(r => r.Id.Equals(playerId));
            return player;
        }

        public static RegionViewModel FindRegion(this List<RegionViewModel> regions, string regionId) 
        {
            var region = regions.FirstOrDefault(r => r.Id.Equals(regionId));
            return region;
        }

        public static List<RegionViewModel> DominatedRegions(this List<RegionViewModel> regions, string playerId) 
        {
            var dominatedRegions = regions.Where(p => p.Player.Id.Equals(playerId)).ToList();

            return dominatedRegions;
        }

        public static List<KingdomViewModel> ConqueredKingdoms(this List<RegionViewModel> regions, PlayerViewModel player)
        {
            var conqueredKingdoms = new List<KingdomViewModel>();
            var kingdom = Kingdom.Instance;

            KingdomsDominated(conqueredKingdoms, regions, kingdom.TheWesterlands, player);
            KingdomsDominated(conqueredKingdoms, regions, kingdom.TheValeOfArryn, player);
            KingdomsDominated(conqueredKingdoms, regions, kingdom.TheStormlands, player);
            KingdomsDominated(conqueredKingdoms, regions, kingdom.TheRiverlands, player);
            KingdomsDominated(conqueredKingdoms, regions, kingdom.TheReach, player);
            KingdomsDominated(conqueredKingdoms, regions, kingdom.TheNorth, player);
            KingdomsDominated(conqueredKingdoms, regions, kingdom.TheIronIslands, player);
            KingdomsDominated(conqueredKingdoms, regions, kingdom.TheCrownlands, player);
            KingdomsDominated(conqueredKingdoms, regions, kingdom.Dorne, player);
           
            return conqueredKingdoms;
        }

        private static void KingdomsDominated(List<KingdomViewModel> conqueredKingdoms, List<RegionViewModel> regions, KingdomViewModel kingdom, PlayerViewModel player) 
        {
            if (AllDominatedRegions(regions, kingdom, player))
            {
                conqueredKingdoms.Add(kingdom);
            }
        }

        private static bool AllDominatedRegions(List<RegionViewModel> regions, KingdomViewModel kingdom, PlayerViewModel player) 
        {
            return regions.Where(c => c.Kingdom.Id.Equals(kingdom.Id) && c.Player.Id.Equals(player.Id))
                            .Count() == kingdom.Regions;
        }

    }
}
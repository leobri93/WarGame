using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarGame.Models;

namespace WarGame.IA
{
    public static class Attack
    {
        public static RegionViewModel ataque(this PlayerViewModel player, List<RegionViewModel> regions)
        {
            List<RegionViewModel> orderByTroops = new List<RegionViewModel>();
            List<RegionViewModel> myRegions = new List<RegionViewModel>();
            if (player.Objective.id == 8 || player.Objective.id == 11)
            {
                int i = 0;
                var regionsDominatedWithMostTroops = regions.Where(x => x.Player.Id == player.Id)                
                                                     .OrderByDescending(x => x.Troops).ToList();
                RegionViewModel regionAttack;
                do
                {
                    regionAttack = regionsDominatedWithMostTroops[i].EnemyFrontiers(player.Id)
                                                                    .OrderBy(x =>x.Troops).FirstOrDefault();
                    i++;
                } while (regionAttack == null);
                
                return regionAttack;
            }

            if (player.Objective.id == 6)
            {
                var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    orderByTroops.AddRange(r.Frontiers());
                }
                orderByTroops.Sort(delegate (RegionViewModel r1, RegionViewModel r2) {
                    return r1.Troops.CompareTo(r2.Troops);
                });
                List<RegionViewModel> frontiersDominatedByObjective = orderByTroops.FindAll(delegate (RegionViewModel r) { return r.Player.Family.Name == "STARK"; });
                if (frontiersDominatedByObjective == null) { return orderByTroops.FirstOrDefault(); }
                return frontiersDominatedByObjective.FirstOrDefault();
            }
            if (player.Objective.id.Equals("O EXERCITO BARATHEON"))
            {
                var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    orderByTroops.AddRange(r.Frontiers());
                }
                orderByTroops.Sort(delegate (RegionViewModel r1, RegionViewModel r2) {
                    return r1.Troops.CompareTo(r2.Troops);
                });
                List<RegionViewModel> frontiersDominatedByObjective = orderByTroops.FindAll(delegate (RegionViewModel r) { return r.Player.Family.Name == "BARATHEON"; });
                if (frontiersDominatedByObjective == null) { return orderByTroops.FirstOrDefault(); }
                return frontiersDominatedByObjective.FirstOrDefault();
            }
            if (player.Objective.id.Equals("O EXERCITO LANNISTER"))
            {
                var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    orderByTroops.AddRange(r.Frontiers());
                }
                orderByTroops.Sort(delegate (RegionViewModel r1, RegionViewModel r2) {
                    return r1.Troops.CompareTo(r2.Troops);
                });
                List<RegionViewModel> frontiersDominatedByObjective = orderByTroops.FindAll(delegate (RegionViewModel r) { return r.Player.Family.Name == "LANNISTER"; });
                if (frontiersDominatedByObjective == null) { return orderByTroops.FirstOrDefault(); }
                return frontiersDominatedByObjective.FirstOrDefault();
            }
            if (player.Objective.id.Equals("O EXERCITO GREYJOY"))
            {
                var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    orderByTroops.AddRange(r.Frontiers());
                }
                orderByTroops.Sort(delegate (RegionViewModel r1, RegionViewModel r2) {
                    return r1.Troops.CompareTo(r2.Troops);
                });
                List<RegionViewModel> frontiersDominatedByObjective = orderByTroops.FindAll(delegate (RegionViewModel r) { return r.Player.Family.Name == "GREYJOY"; });
                if (frontiersDominatedByObjective == null) { return orderByTroops.FirstOrDefault(); }
                return frontiersDominatedByObjective.FirstOrDefault();
            }
            if (player.Objective.id.Equals("O EXERCITO TARGARYEN"))
            {
                var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    orderByTroops.AddRange(r.Frontiers());
                }
                orderByTroops.Sort(delegate (RegionViewModel r1, RegionViewModel r2) {
                    return r1.Troops.CompareTo(r2.Troops);
                });
                List<RegionViewModel> frontiersDominatedByObjective = orderByTroops.FindAll(delegate (RegionViewModel r) { return r.Player.Family.Name == "TARGARYEN"; });
                if (frontiersDominatedByObjective == null) { return orderByTroops.FirstOrDefault(); }
                return frontiersDominatedByObjective.FirstOrDefault();
            }
            if (player.Objective.id.Equals("O EXERCITO TYRELL"))
            {
                var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    orderByTroops.AddRange(r.Frontiers());
                }
                orderByTroops.Sort(delegate (RegionViewModel r1, RegionViewModel r2) {
                    return r1.Troops.CompareTo(r2.Troops);
                });
                List<RegionViewModel> frontiersDominatedByObjective = orderByTroops.FindAll(delegate (RegionViewModel r) { return r.Player.Family.Name == "TYRELL"; });
                if (frontiersDominatedByObjective == null) { return orderByTroops.FirstOrDefault(); }
                return frontiersDominatedByObjective.FirstOrDefault();
            }
            if (player.Objective.id.Equals("DORNE, THE WESTERLANDS E THE CROWLANDS"))
            {
                var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    orderByTroops.AddRange(r.Frontiers());
                }
                orderByTroops.Sort(delegate (RegionViewModel r1, RegionViewModel r2) {
                    return r1.Troops.CompareTo(r2.Troops);
                });
                List<RegionViewModel> frontiersDominatedByObjective = orderByTroops.FindAll(delegate (RegionViewModel r) { return r.Kingdom.Name.Equals("DORNE") || r.Kingdom.Name.Equals("THE WESTERLANDS") || r.Kingdom.Name.Equals("THE CROWLANDS"); });
                if (frontiersDominatedByObjective == null) { return orderByTroops.FirstOrDefault(); }
                return frontiersDominatedByObjective.FirstOrDefault();

            }
            if (player.Objective.id.Equals("THE NORTH E THE STORMLANDS"))
            {
                var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    orderByTroops.AddRange(r.Frontiers());
                }
                orderByTroops.Sort(delegate (RegionViewModel r1, RegionViewModel r2) {
                    return r1.Troops.CompareTo(r2.Troops);
                });
                List<RegionViewModel> frontiersDominatedByObjective = orderByTroops.FindAll(delegate (RegionViewModel r) { return r.Kingdom.Name.Equals("THE NORTH") || r.Kingdom.Name.Equals("THE STORMLANDS"); });
                if (frontiersDominatedByObjective == null) { return orderByTroops.FirstOrDefault(); }
                return frontiersDominatedByObjective.FirstOrDefault();
            }
            if (player.Objective.id.Equals("THE NORTH E DORNE"))
            {
                var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    orderByTroops.AddRange(r.Frontiers());
                }
                orderByTroops.Sort(delegate (RegionViewModel r1, RegionViewModel r2) {
                    return r1.Troops.CompareTo(r2.Troops);
                });
                List<RegionViewModel> frontiersDominatedByObjective = orderByTroops.FindAll(delegate (RegionViewModel r) { return r.Kingdom.Name.Equals("THE NORTH") || r.Kingdom.Name.Equals("DORNE"); });
                if (frontiersDominatedByObjective == null) { return orderByTroops.FirstOrDefault(); }
                return frontiersDominatedByObjective.FirstOrDefault();
            }
            if (player.Objective.id.Equals("THE RIVERLANDS E THE REACH"))
            {
                var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    orderByTroops.AddRange(r.Frontiers());
                }
                orderByTroops.Sort(delegate (RegionViewModel r1, RegionViewModel r2) {
                    return r1.Troops.CompareTo(r2.Troops);
                });
                List<RegionViewModel> frontiersDominatedByObjective = orderByTroops.FindAll(delegate (RegionViewModel r) { return r.Kingdom.Name.Equals("THE RIVERLANDS") || r.Kingdom.Name.Equals("THE REACH"); });
                if (frontiersDominatedByObjective == null) { return orderByTroops.FirstOrDefault(); }
                return frontiersDominatedByObjective.FirstOrDefault();
            }
            if (player.Objective.id.Equals("THE REACH, THE VALE OF ARRYN e mais um terceiro "))
            {
                var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);
                List<RegionViewModel> thirdKingdom = new List<RegionViewModel>();
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    orderByTroops.AddRange(r.Frontiers());
                    thirdKingdom.Add(r);
                }
                orderByTroops.Sort(delegate (RegionViewModel r1, RegionViewModel r2) {
                    return r1.Troops.CompareTo(r2.Troops);
                });
                List<RegionViewModel> theThird = thirdKingdom;
                theThird.RemoveAll(delegate (RegionViewModel r) { return r.Kingdom.Name.Equals("THE VALE OF ARRYN") || r.Kingdom.Name.Equals("THE REACH"); });
                var theThirdKingdom = (from k in theThird orderby k.Kingdom descending select k.Kingdom).FirstOrDefault();
                List<RegionViewModel> frontiersDominatedByObjective = orderByTroops.FindAll(delegate (RegionViewModel r) { return r.Kingdom.Name.Equals("THE VALE OF ARRYN") || r.Kingdom.Name.Equals("THE REACH") || r.Kingdom.Name.Equals(theThirdKingdom); });
                if (frontiersDominatedByObjective == null) { return theThird.FirstOrDefault(); }
                return frontiersDominatedByObjective.FirstOrDefault();
            }

            return null;
        }
    }
}
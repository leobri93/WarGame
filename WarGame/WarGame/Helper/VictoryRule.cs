using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using WarGame.Models;
namespace WarGame.Helper
{
    public static class VictoryRule
    {
        public static bool regrasDeVitoria(this PlayerViewModel player, List<RegionViewModel> regions, List<PlayerViewModel> players)
        {
            int checkDomination1 =0, checkDomination2 = 0, checkDomination3 = 0 ;
            Objective obj = new Objective();
            if (player.objective.id == 8)
            {
                int regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id).ToList().Count();
                
                if (regionsDominatedByPlayer >= 24)
                {
                    return true;
                }
                return false;
            }
            if (player.objective.id == 11)
            {
                int regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id).Where(x => x.Troops > 1).ToList().Count();
                if (regionsDominatedByPlayer >= 18)
                {
                    return true;
                }
                return false;
            }
             if (player.objective.id == 6)
             {
                
                 if (obj.VerifyFamilyOnObjective(player, players))
                 {
                     var regionsDominatedByobjective = regions.Where(x => x.Player.Family.Name.Equals("Stark")).Count();

                     if (regionsDominatedByobjective == null || regionsDominatedByobjective == 0)
                     {
                         return true;
                     }
                 } else
                 {
                    int regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id).ToList().Count();

                    if (regionsDominatedByPlayer >= 24)
                    {
                        return true;
                    }
                 }
                 return false;
             }
             if (player.objective.id == 5)
             {
                 if (obj.VerifyFamilyOnObjective(player, players))
                {
                     var regionsDominatedByobjective = regions.Where(x => x.Player.Family.Name.Equals("Baratheon"));

                     if (regionsDominatedByobjective == null)
                     {
                         return true;
                     }
                 }
                 else
                 {
                     int regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id).ToList().Count();
                
                     if (regionsDominatedByPlayer >= 24)
                     {
                         return true;
                     }
                }
                return false;
             }
             if (player.objective.id == 4)
             {
                 if (obj.VerifyFamilyOnObjective(player, players))
                {
                     var regionsDominatedByobjective = regions.Where(x => x.Player.Family.Name.Equals("Lannister"));

                     if (regionsDominatedByobjective == null)
                     {
                         return true;
                     }
                 }
                 else
                 {
                     int regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id).ToList().Count();
                
                     if (regionsDominatedByPlayer >= 24)
                     {
                         return true;
                     }
                 }
                 return false;
             }
             if (player.objective.id == 3)
             {

                 if (obj.VerifyFamilyOnObjective(player, players))
                {
                     var regionsDominatedByobjective = regions.Where(x => x.Player.Family.Name.Equals("Greyjoy"));

                     if (regionsDominatedByobjective == null)
                     {
                         return true;
                     }
                 }
                 else
                 {
                     int regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id).ToList().Count();
                
                     if (regionsDominatedByPlayer >= 24)
                     {
                         return true;
                     }
                }
                return false;
             }
             if (player.objective.id == 2)
             {
                 if (obj.VerifyFamilyOnObjective(player, players))
                {
                     var regionsDominatedByobjective = regions.Where(x => x.Player.Family.Name.Equals("Targaryen"));

                     if (regionsDominatedByobjective == null)
                     {
                         return true;
                     }
                 }
                 else
                 {
                     int regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id).ToList().Count();
                
                     if (regionsDominatedByPlayer >= 24)
                     {
                         return true;
                     }
                }
                return false;
             }
             if (player.objective.id == 1)
             {

                 if (obj.VerifyFamilyOnObjective(player, players))
                {
                     var regionsDominatedByobjective = regions.Where(x => x.Player.Family.Name.Equals("Tyrell"));

                     if (regionsDominatedByobjective == null)
                     {
                         return true;
                     }
                 }
                 else
                 {
                      int regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id).ToList().Count();
                
                     if (regionsDominatedByPlayer >= 24)
                     {
                         return true;
                     }
                }
                return false; 
             }
            if (player.objective.id == 10)
            {
                var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);

                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Name.Equals("Dorne"))
                    {
                        checkDomination1 += 1;
                    }
                }

                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Name.Equals("The Westerlands"))
                    {
                        checkDomination2 += 1;
                    }
                }

                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Name.Equals("The Crownlands"))
                    {
                        checkDomination3 += 1;
                    }
                }
                if (checkDomination1 == 3 && checkDomination2 == 5 && checkDomination3 == 3)
                {
                    return true;
                }
                return false;
            }
            if (player.objective.id == 13)
            {
                var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);
                
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Name.Equals("The North"))
                    {
                        checkDomination1 += 1;
                    }
                }

                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Name.Equals("The Stormlands"))
                    {
                        checkDomination2 += 1;
                    }
                }
                if (checkDomination1 == 10 && checkDomination2 == 4)
                {
                    return true;
                }
                return false;
            }
            if (player.objective.id == 9)
            {
                var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);
       
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Name.Equals("Dorne"))
                    {
                        checkDomination1 += 1;
                    }
                }
              
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Name.Equals("The North"))
                    {
                        checkDomination2 += 1;
                    }
                }
                if (checkDomination1 == 3 && checkDomination2 == 10)
                {
                    return true;
                }
                return false;
            }
            if (player.objective.id == 7)
            {
                var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);
                
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Name.Equals("The Riverlands"))
                    {
                        checkDomination1 += 1;
                    }
                }
                
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Name.Equals("The Reach"))
                    {
                        checkDomination2 += 1;
                    }
                }
                if (checkDomination1 == 4 && checkDomination2 == 5)
                {
                    return true;
                }
                return false;
            }
            if (player.objective.id == 12)
            {
                var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);
                
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Name.Equals("The Reach"))
                    {
                        checkDomination1 += 1;
                    }
                }
               
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Name.Equals("TheValeOfArryn"))
                    {
                        checkDomination2 += 1;
                    }
                }

                if (checkDomination1 == 5 && checkDomination2 == 6 && checkDominationThird(player, regions))
                {
                    return true;
                }
                return false;
            }
            if (player.objective.id == 14)
            {
                var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);

                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Name.Equals("The Crownlands"))
                    {
                        checkDomination1 += 1;
                    }
                }

                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Name.Equals("The Riverlands"))
                    {
                        checkDomination2 += 1;
                    }
                }

                if (checkDomination1 == 3 && checkDomination2 == 4 && checkDominationThird(player, regions))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public static bool checkDominationThird(this PlayerViewModel player, List<RegionViewModel> regions)
        {
            var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);
            int checkDominationCrowlands = 0;
            foreach (RegionViewModel r in regionsDominatedByPlayer)
            {
                if (r.Kingdom.Equals("The Crownlands"))
                {
                    checkDominationCrowlands += 1;
                }
            }
            int checkDominationWesterlands = 0;
            foreach (RegionViewModel r in regionsDominatedByPlayer)
            {
                if (r.Kingdom.Name.Equals("The Westerlands"))
                {
                    checkDominationWesterlands += 1;
                }
            }
            int checkDominationDorne = 0;
            foreach (RegionViewModel r in regionsDominatedByPlayer)
            {
                if (r.Kingdom.Name.Equals("Dorne"))
                {
                    checkDominationDorne += 1;
                }
            }
            int checkDominationIron = 0;
            foreach (RegionViewModel r in regionsDominatedByPlayer)
            {
                if (r.Kingdom.Name.Equals("The Iron Islands"))
                {
                    checkDominationIron += 1;
                }
            }
            int checkDominationNorth = 0;
            foreach (RegionViewModel r in regionsDominatedByPlayer)
            {
                if (r.Kingdom.Name.Equals("The North"))
                {
                    checkDominationNorth += 1;
                }
            }
            int checkDominationRiverlands = 0;
            foreach (RegionViewModel r in regionsDominatedByPlayer)
            {
                if (r.Kingdom.Name.Equals("The Riverlands"))
                {
                    checkDominationRiverlands += 1;
                }
            }
            int checkDominationStormlands = 0;
            foreach (RegionViewModel r in regionsDominatedByPlayer)
            {
                if (r.Kingdom.Name.Equals("The Stormlands"))
                {
                    checkDominationStormlands += 1;
                }
            }
            int checkDominationReach = 0;
            foreach (RegionViewModel r in regionsDominatedByPlayer)
            {
                if (r.Kingdom.Name.Equals("The Reach"))
                {
                    checkDominationReach += 1;
                }
            }
            int checkDominationVale = 0;
            foreach (RegionViewModel r in regionsDominatedByPlayer)
            {
                if (r.Kingdom.Name.Equals("TheValeOfArryn"))
                {
                    checkDominationVale += 1;
                }
            }
            if (player.objective.id == 14) { 
                if (checkDominationReach == 5 || checkDominationDorne == 3 || checkDominationIron == 2 || checkDominationNorth == 10 || checkDominationVale == 6 || checkDominationStormlands == 4)
                {
                    return true;
                }
            }
            if (player.objective.id == 12)
            {
                if (checkDominationCrowlands == 3 || checkDominationDorne == 3 || checkDominationIron == 2 || checkDominationNorth == 10 || checkDominationRiverlands == 4 || checkDominationStormlands == 4)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
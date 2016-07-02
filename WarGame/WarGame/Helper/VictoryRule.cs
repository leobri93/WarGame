using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using WarGame.Models;
namespace WarGame.Helper
{
    public class VictoryRule
    {
        public static bool regrasDeVitoria(this PlayerViewModel player, List<RegionViewModel> regions)
        {
            int numberOfRegionsDominatedByPlayer = 0;
            if (player.Objective.Equals("24 territorios"))
            {
                var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    numberOfRegionsDominatedByPlayer += 1;
                }
                if (numberOfRegionsDominatedByPlayer >= 24)
                {
                    return true;
                }
                return false;
            }
            if (player.Objective.Equals("18 territorios"))
            {
                var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    numberOfRegionsDominatedByPlayer += 1;
                }
                var regionsWith1Troop = regionsDominatedByPlayer.Where(x => x.Troops == 1);
                if (numberOfRegionsDominatedByPlayer >= 18 && regionsWith1Troop == null)
                {
                    return true;
                }
                return false;
            }
            if (player.Objective.Equals("EXÉRCITO STARK"))
            {
                var regionsDominatedByObjective = regions.Where(x => x.Player.Family.Name == "STARK");

                if (regionsDominatedByObjective == null)
                {
                    return true;
                }
                return false;
            }
            if (player.Objective.Equals("EXÉRCITO BARATHEON"))
            {
                var regionsDominatedByObjective = regions.Where(x => x.Player.Family.Name == "BARATHEON");

                if (regionsDominatedByObjective == null)
                {
                    return true;
                }
                return false;
            }
            if (player.Objective.Equals("EXÉRCITO LANNISTER"))
            {
                var regionsDominatedByObjective = regions.Where(x => x.Player.Family.Name == "LANNISTER");

                if (regionsDominatedByObjective == null)
                {
                    return true;
                }
                return false;
            }
            if (player.Objective.Equals("EXÉRCITO GREYJOY"))
            {
                var regionsDominatedByObjective = regions.Where(x => x.Player.Family.Name == "GREYJOY");

                if (regionsDominatedByObjective == null)
                {
                    return true;
                }
                return false;
            }
            if (player.Objective.Equals("EXÉRCITO TARGARYEN"))
            {
                var regionsDominatedByObjective = regions.Where(x => x.Player.Family.Name == "TARGARYEN");

                if (regionsDominatedByObjective == null)
                {
                    return true;
                }
                return false;
            }
            if (player.Objective.Equals("EXÉRCITO TYRELL"))
            {
                var regionsDominatedByObjective = regions.Where(x => x.Player.Family.Name == "TYRELL");

                if (regionsDominatedByObjective == null)
                {
                    return true;
                }
                return false;
            }
            if (player.Objective.Equals("DORNE, THE WESTERLANDS E THE CROWLANDS"))
            {
                var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);
                int checkDominationDorne = 0;
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Name.Equals("DORNE"))
                    {
                        checkDominationDorne += 1;
                    }
                }
                int checkDominationWesterlands = 0;
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Name.Equals("THE WESTERLANDS"))
                    {
                        checkDominationWesterlands += 1;
                    }
                }
                int checkDominationCrowlands = 0;
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Name.Equals("CROWLANDS"))
                    {
                        checkDominationCrowlands += 1;
                    }
                }
                if (checkDominationDorne == 3 && checkDominationWesterlands == 5 && checkDominationCrowlands == 3)
                {
                    return true;
                }
                return false;
            }
            if (player.Objective.Equals("THE NORTH E THE STORMLANDS"))
            {
                var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);
                int checkDominationNorth = 0;
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Name.Equals("NORTH"))
                    {
                        checkDominationNorth += 1;
                    }
                }
                int checkDominationStormlands = 0;
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Name.Equals("THE STORMLANDS"))
                    {
                        checkDominationStormlands += 1;
                    }
                }
                if (checkDominationNorth == 10 && checkDominationStormlands == 4)
                {
                    return true;
                }
                return false;
            }
            if (player.Objective.Equals("THE NORTH E DORNE"))
            {
                var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);
                int checkDominationDorne = 0;
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Name.Equals("DORNE"))
                    {
                        checkDominationDorne += 1;
                    }
                }
                int checkDominationNorth = 0;
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Name.Equals("THE North"))
                    {
                        checkDominationNorth += 1;
                    }
                }
                if (checkDominationDorne == 3 && checkDominationNorth == 10)
                {
                    return true;
                }
                return false;
            }
            if (player.Objective.Equals("THE RIVERLANDS E THE REACH"))
            {
                var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);
                int checkDominationRiverland = 0;
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Name.Equals("THE RIVERLANDS"))
                    {
                        checkDominationRiverland += 1;
                    }
                }
                int checkDominationReach = 0;
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Name.Equals("THE REACH"))
                    {
                        checkDominationReach += 1;
                    }
                }
                if (checkDominationRiverland == 4 && checkDominationReach == 5)
                {
                    return true;
                }
                return false;
            }
            if (player.Objective.Equals("THE REACH, THE VALE OF ARRYN E UM TERCEIRO"))
            {
                var regionsDominatedByPlayer = regions.Where(x => x.Player.Id == player.Id);
                int checkDominationReach = 0;
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Name.Equals("THE REACH"))
                    {
                        checkDominationReach += 1;
                    }
                }
                int checkDominationVale = 0;
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Name.Equals("THE VALE OF ARRYN"))
                    {
                        checkDominationVale += 1;
                    }
                }
                int checkDominationCrowlands = 0;
                foreach (RegionViewModel r in regionsDominatedByPlayer)
                {
                    if (r.Kingdom.Equals("CROWLANDS"))
                    {
                        checkDominationCrowlands += 1;
                    }
                }
                if (checkDominationReach == 5 && checkDominationVale == 6 && checkDominationCrowlands == 3)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
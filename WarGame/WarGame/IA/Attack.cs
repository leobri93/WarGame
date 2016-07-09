using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarGame.Models;

namespace WarGame.IA
{
    public static class Attack
    {
        public static List<RegionViewModel> Ataque(this PlayerViewModel player, List<RegionViewModel> regions)
        {
            List<RegionViewModel> orderByTroops = new List<RegionViewModel>();
            List<RegionViewModel> regionAttack;

            string nameFamily, nameKingdom, nameKingdom2, nameKingdom3;
            if (player.objective.id == 8 || player.objective.id == 11)
            {
                regionAttack = AttackRandom(regions,player);
                return regionAttack;
            }
        
            if (player.objective.id == 6)
            {
                nameFamily = "Stark";
                regionAttack = AttackRandomFamily(nameFamily, regions, player);
                return regionAttack;
            }
            if (player.objective.id == 5)
            {
                nameFamily = "Baratheon";
                regionAttack = AttackRandomFamily(nameFamily, regions, player);
                return regionAttack;
            }
            if (player.objective.id == 4)
            {
                nameFamily = "Lannister";
                regionAttack = AttackRandomFamily(nameFamily, regions, player);
                return regionAttack;
            }
            if (player.objective.id == 3)
            {
                nameFamily = "Greyjoy";
                regionAttack = AttackRandomFamily(nameFamily, regions, player);
                return regionAttack;
            }
            if (player.objective.id == 2)
            {
                nameFamily = "Targaryen";
                regionAttack = AttackRandomFamily(nameFamily, regions, player);
                return regionAttack;
            }
            if (player.objective.id == 1)
            {
                nameFamily = "Tyrell";
                regionAttack = AttackRandomFamily(nameFamily, regions, player);
                return regionAttack;
            }
            if (player.objective.id == 10)
            {
                nameKingdom = "Dorne";
                nameKingdom2 = "The Westerlands";
                nameKingdom3 = "The Crownlands";
                regionAttack = AttackRandomKingdom(nameKingdom,nameKingdom2,nameKingdom3,regions,player);
                return regionAttack;
            }
            if (player.objective.id == 13)
            {
                nameKingdom = "The North";
                nameKingdom2 = "The Stormlands";
                nameKingdom3 = null;
                regionAttack = AttackRandomKingdom(nameKingdom, nameKingdom2,nameKingdom3, regions, player);
                return regionAttack;
            }
            if (player.objective.id == 9)
            {
                nameKingdom = "The North";
                nameKingdom2 = "Dorne";
                nameKingdom3 = null;
                regionAttack = AttackRandomKingdom(nameKingdom, nameKingdom2,nameKingdom3, regions, player);
                return regionAttack;
            }
            if (player.objective.id == 7)
            {
                nameKingdom = "The Riverlands";
                nameKingdom2 = "The Reach";
                nameKingdom3 = null;
                regionAttack = AttackRandomKingdom(nameKingdom, nameKingdom2,nameKingdom3, regions, player);
                return regionAttack;
            }
            if (player.objective.id == 12)
            {
                nameKingdom = "The Reach";
                nameKingdom2 = "TheValeOfArryn";
                nameKingdom3 = null;
                regionAttack = AttackRandomKingdom(nameKingdom, nameKingdom2,nameKingdom3, regions, player);
                return regionAttack;
            }
            if (player.objective.id == 14)
            {
                nameKingdom = "The Crownlands";
                nameKingdom2 = "The Riverlands";
                nameKingdom3 = null;
                regionAttack = AttackRandomKingdom(nameKingdom, nameKingdom2, nameKingdom3, regions, player);
                return regionAttack;
            }

            return null;
        }

        private static List<RegionViewModel> AttackRandom(List<RegionViewModel> regions, PlayerViewModel player)
        {
            var regionsDominatedWithMostTroops = regions.Where(x => x.Player.Id.Equals(player.Id)) 
                                                     .Where(x => x.Troops > 1)   
                                                     .OrderBy(x => x.Troops).ToList();
            if(regionsDominatedWithMostTroops.Count == 0 )
            {
                return null;
            }
            int i = regionsDominatedWithMostTroops.Count - 1;
            RegionViewModel regionAttack, attackedRegion;
            do
            {
                attackedRegion = regionsDominatedWithMostTroops[i].EnemyFrontiers(player.Id)
                                                                .OrderBy(x => x.Troops).FirstOrDefault();
                regionAttack = regionsDominatedWithMostTroops[i];
                if (i == 0)
                {
                    break;
                }
                i--;
            } while (attackedRegion == null);
            List<RegionViewModel> regionsInBattle = new List<RegionViewModel>();
            regionsInBattle.Add(regionAttack);
            regionsInBattle.Add(attackedRegion);
        
            return regionsInBattle;
        }

        private static List<RegionViewModel> AttackRandomFamily(string family, List<RegionViewModel> regions, PlayerViewModel player)
        {
            var regionsDominatedWithMostTroops = regions.Where(x => x.Player.Id.Equals(player.Id))
                                                        .Where(x1 => x1.Troops > 1)
                                                        .OrderBy(x => x.Troops).ToList();
            if (regionsDominatedWithMostTroops.Count == 0)
            {
                return null;
            }
            int i = regionsDominatedWithMostTroops.Count - 1;
            RegionViewModel regionAttack,attackedRegion;
            do
            {
                attackedRegion = regionsDominatedWithMostTroops[i].EnemyFrontiers(player.Id)
                                                                .Where(x1 => x1.Player.Family.Name.Equals(family))
                                                                .OrderBy(x => x.Troops).FirstOrDefault();
                regionAttack = regionsDominatedWithMostTroops[i];
                if (i == 0)
                {
                    break;
                }
                i--;

            } while (attackedRegion == null);
            List<RegionViewModel> regionsInBattle = new List<RegionViewModel>();
            regionsInBattle.Add(regionAttack);
            regionsInBattle.Add(attackedRegion);
            if (regionAttack == null)
            {
                regionsInBattle = AttackRandom(regions, player);
            }

            return regionsInBattle;
        }

        private static List<RegionViewModel> AttackRandomKingdom(string name,string name2, string name3, List<RegionViewModel> regions, PlayerViewModel player)
        {
            
            var regionsDominatedWithMostTroops = regions.Where(x => x.Player.Id.Equals(player.Id))
                                                        .Where(x1 => x1.Troops > 1)
                                                        .OrderBy(x => x.Troops).ToList();
            if (regionsDominatedWithMostTroops.Count == 0)
            {
                return null;
            }
            int i = regionsDominatedWithMostTroops.Count - 1;
            RegionViewModel regionAttack,attackedRegion;
            do
            {
                attackedRegion = regionsDominatedWithMostTroops[i].EnemyFrontiers(player.Id)
                                                                .Where(x => x.Kingdom.Name.Equals(name)||x.Kingdom.Name.Equals(name2)||x.Kingdom.Name.Equals(name3))
                                                                .OrderBy(x => x.Troops).FirstOrDefault();
                regionAttack = regionsDominatedWithMostTroops[i];
                if (i == 0)
                {
                    break;
                }
                i--;

            } while (attackedRegion == null);
            List<RegionViewModel> regionsInBattle = new List<RegionViewModel>();
            regionsInBattle.Add(regionAttack);
            regionsInBattle.Add(attackedRegion);
            if (regionAttack == null)
            {
                regionsInBattle = AttackRandom(regions, player);
            }

            return regionsInBattle;
        }
    }
}

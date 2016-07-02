using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarGame.Models;

namespace WarGame.IA
{
    public class Attack
    {
        public static RegionViewModel Ataque(this PlayerViewModel player, List<RegionViewModel> regions)
        {
            List<RegionViewModel> orderByTroops = new List<RegionViewModel>();
            RegionViewModel regionAttack;
            string nameFamily, nameKingdom, nameKingdom2;
            if (player.Objective.id == 8 || player.Objective.id == 11)
            {
                regionAttack = AttackRandom(regions,player);
                return regionAttack;
            }
        
            if (player.Objective.id == 6)
            {
                nameFamily = "Stark";
                regionAttack = AttackRandomFamily(nameFamily, regions, player);
                return regionAttack;
            }
            if (player.Objective.id == 5)
            {
                nameFamily = "Baratheon";
                regionAttack = AttackRandomFamily(nameFamily, regions, player);
                return regionAttack;
            }
            if (player.Objective.id == 4)
            {
                nameFamily = "Lannister";
                regionAttack = AttackRandomFamily(nameFamily, regions, player);
                return regionAttack;
            }
            if (player.Objective.id == 3)
            {
                nameFamily = "Greyjoy";
                regionAttack = AttackRandomFamily(nameFamily, regions, player);
                return regionAttack;
            }
            if (player.Objective.id == 2)
            {
                nameFamily = "Targaryen";
                regionAttack = AttackRandomFamily(nameFamily, regions, player);
                return regionAttack;
            }
            if (player.Objective.id == 1)
            {
                nameFamily = "Tyrell";
                regionAttack = AttackRandomFamily(nameFamily, regions, player);
                return regionAttack;
            }
            if (player.Objective.id == 10)
            {
                nameKingdom = "Dorne";
                nameKingdom2 = "The Westerlands";
                regionAttack = AttackRandomKingdom(nameKingdom,nameKingdom2,regions,player);
                if (regionAttack == null)
                {
                    nameKingdom = "The Crownlands";
                    regionAttack = AttackRandomKingdom(nameKingdom,nameKingdom2, regions, player); 
                }
                return regionAttack;
            }
            if (player.Objective.id == 13)
            {
                nameKingdom = "The North";
                nameKingdom2 = "The Stormlands";
                regionAttack = AttackRandomKingdom(nameKingdom, nameKingdom2, regions, player);
                return regionAttack;
            }
            if (player.Objective.id == 9)
            {
                nameKingdom = "The North";
                nameKingdom2 = "Dorne";
                regionAttack = AttackRandomKingdom(nameKingdom, nameKingdom2, regions, player);
                return regionAttack;
            }
            if (player.Objective.id == 7)
            {
                nameKingdom = "The Riverlands";
                nameKingdom2 = "The Reach";
                regionAttack = AttackRandomKingdom(nameKingdom, nameKingdom2, regions, player);
                return regionAttack;
            }
            if (player.Objective.id.Equals("THE REACH, THE VALE OF ARRYN e mais um terceiro "))
            {
                nameKingdom = "The Reach";
                nameKingdom2 = "TheValeOfArryn";
                regionAttack = AttackRandomKingdom(nameKingdom, nameKingdom2, regions, player);
                return regionAttack;
            }
        
            return null;
        }

        private static RegionViewModel AttackRandom(List<RegionViewModel> regions, PlayerViewModel player)
        {
            
            var regionsDominatedWithMostTroops = regions.Where(x => x.Player.Id == player.Id)
                                                     .OrderBy(x => x.Troops).ToList();
            int i = regionsDominatedWithMostTroops.Count - 1;
            RegionViewModel regionAttack;
            do
            {
                regionAttack = regionsDominatedWithMostTroops[i].EnemyFrontiers(player.Id)
                                                                .OrderBy(x => x.Troops).FirstOrDefault();
                i--;
            } while (regionAttack != null || i == 0);
        
            return regionAttack;
        }
        private static RegionViewModel AttackRandomFamily(string family, List<RegionViewModel> regions, PlayerViewModel player)
        {
            var regionsDominatedWithMostTroops = regions.Where(x => x.Player.Id.Equals(player.Id))
                                                        .Where(x1 => x1.Troops > 1)
                                                        .OrderBy(x => x.Troops).ToList();
            int i = regionsDominatedWithMostTroops.Count - 1;
            RegionViewModel regionAttack;
            do
            {
                regionAttack = regionsDominatedWithMostTroops[i].EnemyFrontiers(player.Id)
                                                                .Where(x1 => x1.Player.Family.Name.Equals(family))
                                                                .OrderBy(x => x.Troops).FirstOrDefault();

                i--;

            } while (regionAttack == null || i != 0);

            if (regionAttack == null)
            {
                regionAttack = regionsDominatedWithMostTroops[i].EnemyFrontiers(player.Id)
                                                            .OrderBy(x => x.Troops).FirstOrDefault();
            }

            return regionAttack;
        }

        private static RegionViewModel AttackRandomKingdom(string name,string name2, List<RegionViewModel> regions, PlayerViewModel player)
        {
            
            var regionsDominatedWithMostTroops = regions.Where(x => x.Player.Id.Equals(player.Id))
                                                        .Where(x1 => x1.Troops > 1)
                                                        .OrderBy(x => x.Troops).ToList();
            int i = regionsDominatedWithMostTroops.Count - 1;
            RegionViewModel regionAttack;
            do
            {
                regionAttack = regionsDominatedWithMostTroops[i].EnemyFrontiers(player.Id)
                                                                .Where(x => x.Kingdom.Name.Equals(name)||x.Kingdom.Name.Equals(name2))
                                                                .OrderBy(x => x.Troops).FirstOrDefault();
                
                i--;

            } while (regionAttack == null || i != 0);

            if (regionAttack == null)
            {
                regionAttack = regionsDominatedWithMostTroops[i].EnemyFrontiers(player.Id)
                                                            .OrderBy(x => x.Troops).FirstOrDefault();
            }

            return regionAttack;
        }
    }
}

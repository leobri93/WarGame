using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarGame.Models;

namespace WarGame.Helper
{
    public static class Conquest
    {

        public static BattleModel Battle(RegionViewModel attack, int atroops, RegionViewModel defense)
        {
            var dtroops = (defense.Troops > 3) ? 3 : defense.Troops;

            var random = new Random();

            var aplayer = new int[atroops];
            var dplayer = new int[dtroops];

            aplayer = rollTheDice(aplayer, random);
            dplayer = rollTheDice(dplayer, random);

            var resultBattle = attack.Attack(defense, aplayer, dplayer);

            return new BattleModel(aplayer, dplayer, resultBattle);
        }

        private static int[] rollTheDice(int[] player, Random random)
        {
            for (var i = 0; i < player.Length; i++)
            {
                player[i] = random.Next(1, 7);
            }

            return player.OrderByDescending(d => d).ToArray();
        }

    }
}
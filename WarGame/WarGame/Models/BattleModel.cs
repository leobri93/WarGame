using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarGame.Models
{
    public class BattleModel
    {
        public int[] aplayer { get; set; }
        public int[] dplayer { get; set; }
        public int[] resultBattle { get; set; }

        public BattleModel(int [] aplayer, int[] dplayer, int[] resultBattle)
        {
            this.aplayer = aplayer;
            this.dplayer = dplayer;
            this.resultBattle = resultBattle;
        }

    }
}
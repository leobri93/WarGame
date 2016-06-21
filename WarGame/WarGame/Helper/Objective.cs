using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarGame.Models;

namespace WarGame.Helper
{
    public class Objective
    {
        private ObjectiveModel obj1;
        private ObjectiveModel obj2;
        private ObjectiveModel obj3;
        private ObjectiveModel obj4;
        private ObjectiveModel obj5;
        private ObjectiveModel obj6;
        private ObjectiveModel obj7;
        private ObjectiveModel obj8;
        private ObjectiveModel obj9;
        private ObjectiveModel obj10;
        private ObjectiveModel obj11;
        private ObjectiveModel obj12;
        private ObjectiveModel obj13;
        private ObjectiveModel obj14;

        public Objective()
        {
            obj1  = new ObjectiveModel(1, "Destruir totalmente o exercito Tyrell");
            obj2  = new ObjectiveModel(2, "Destruir totalmente o exercito Targaryen");
            obj3  = new ObjectiveModel(3, "Destruir totalmente o exercito Greyjoy");
            obj4  = new ObjectiveModel(4, "Destruir totalmente o exercito Lannister");
            obj5  = new ObjectiveModel(5, "Destruir totalmente o exercito Baratheon");
            obj6  = new ObjectiveModel(6, "Destruir totalmente o exercito Stark");
            obj7  = new ObjectiveModel(7, "Conquistar na totalidade a The Riverlands e The Reach");
            obj8  = new ObjectiveModel(8, "Conquistar 24 territorios a sua escolha");
            obj9  = new ObjectiveModel(9, "Conquistar na totalidade a The North e Dorne");
            obj10 = new ObjectiveModel(10, "Conquistar na totalidade Dorne, The Westerlands e The Crownlands");
            obj11 = new ObjectiveModel(11, "Conquistar 18 territorios e ocupar cada um deles com pelo menos dois exercitos");
            obj12 = new ObjectiveModel(12, "Conquistar na totalidade a The Reach, The Vale of Arryn e mais um terceiro");
            obj13 = new ObjectiveModel(13, "Conquistar na totalidade a The North e The Stormlands");
            obj14 = new ObjectiveModel(14, "Conquistar na totalidade The Crownlands, The Riverlands e mais um terceiro");

        }

        public void RafflingObjectives()
        {

        }
    }
}
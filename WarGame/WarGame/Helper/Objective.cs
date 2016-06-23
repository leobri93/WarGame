using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarGame.Models;

namespace WarGame.Helper
{
    public class Objective
    {
        List<ObjectiveModel> objectives = new List<ObjectiveModel>();

        public Objective()
        {
            objectives.Add(new ObjectiveModel(1, "Destruir totalmente o exercito Tyrell"));
            objectives.Add(new ObjectiveModel(2, "Destruir totalmente o exercito Targaryen"));
            objectives.Add(new ObjectiveModel(3, "Destruir totalmente o exercito Greyjoy"));
            objectives.Add(new ObjectiveModel(4, "Destruir totalmente o exercito Lannister"));
            objectives.Add(new ObjectiveModel(5, "Destruir totalmente o exercito Baratheon"));
            objectives.Add(new ObjectiveModel(6, "Destruir totalmente o exercito Stark"));
            objectives.Add(new ObjectiveModel(7, "Conquistar na totalidade a The Riverlands e The Reach"));
            objectives.Add(new ObjectiveModel(8, "Conquistar 24 territorios a sua escolha"));
            objectives.Add(new ObjectiveModel(9, "Conquistar na totalidade a The North e Dorne"));
            objectives.Add(new ObjectiveModel(10, "Conquistar na totalidade Dorne, The Westerlands e The Crownlands"));
            objectives.Add(new ObjectiveModel(11, "Conquistar 18 territorios e ocupar cada um deles com pelo menos dois exercitos"));
            objectives.Add(new ObjectiveModel(12, "Conquistar na totalidade a The Reach, The Vale of Arryn e mais um terceiro"));
            objectives.Add(new ObjectiveModel(13, "Conquistar na totalidade a The North e The Stormlands"));
            objectives.Add(new ObjectiveModel(14, "Conquistar na totalidade The Crownlands, The Riverlands e mais um terceiro"));

        }

        /// <summary>
        /// Method to raffle the objectives
        /// </summary>
        /// <returns>This method returns an ObjetiveModel</returns>
        public ObjectiveModel RafflingObjectives()
        {
            ObjectiveModel returnObj = new ObjectiveModel();
            Random rand = new Random();
            bool found = false;
            int objectiveId;

            while (!found)
            {
                //Creates a random objective id between 0 and 13
                objectiveId = rand.Next(14);

                //Getting the objective in the position of the random number
                returnObj = objectives[objectiveId];

                if (returnObj.isUsed == false)
                {
                    //Set the isUsed field as true and update it on the list of objectives 
                    returnObj.isUsed = true;
                    objectives[objectiveId] = returnObj;

                    found = true;
                }
            }

            return returnObj;
        }
    }
}
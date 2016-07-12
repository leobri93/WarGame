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
            objectives.Add(new ObjectiveModel(1, "Destruir totalmente o exercito Tyrell, caso esse exercito nao esteja em jogo conquistar 24 territorios"));
            objectives.Add(new ObjectiveModel(2, "Destruir totalmente o exercito Targaryen, caso esse exercito nao esteja em jogo conquistar 24 territorios"));
            objectives.Add(new ObjectiveModel(3, "Destruir totalmente o exercito Greyjoy, caso esse exercito nao esteja em jogo conquistar 24 territorios"));
            objectives.Add(new ObjectiveModel(4, "Destruir totalmente o exercito Lannister, caso esse exercito nao esteja em jogo conquistar 24 territorios"));
            objectives.Add(new ObjectiveModel(5, "Destruir totalmente o exercito Baratheon, caso esse exercito nao esteja em jogo conquistar 24 territorios"));
            objectives.Add(new ObjectiveModel(6, "Destruir totalmente o exercito Stark, caso esse exercito nao esteja em jogo conquistar 24 territorios"));
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

        /// <summary>
        /// This method is used to verify if the objective associated to the player is valid or not.
        /// We have the scenario that a player must destroy a family but this family is not in the game.
        /// </summary>
        /// <param name="player"></param>
        /// <returns>True if the family exists in the game, false otherwise</returns>
        public bool VerifyFamilyOnObjective(PlayerViewModel currentPlayer, List<PlayerViewModel> players)
        {
            
            bool result = false;

            switch (currentPlayer.objective.id)
            {
                case 1:
                    result = SearchFamilyOnPlayers("Tyrell", currentPlayer, players);
                    break;
                case 2:
                    result = SearchFamilyOnPlayers("Targaryen", currentPlayer, players);
                    break;
                case 3:
                    result = SearchFamilyOnPlayers("Greyjoy", currentPlayer, players);
                    break;
                case 4:
                    result = SearchFamilyOnPlayers("Lannister", currentPlayer, players);
                    break;
                case 5:
                    result = SearchFamilyOnPlayers("Baratheon", currentPlayer, players);
                    break;
                case 6:
                    result = SearchFamilyOnPlayers("Stark", currentPlayer, players);
                    break;
                default:
                    result = false;
                    break;
            }

            return result;
        }

        /// <summary>
        /// Search on players list to verify if the given family is on the game
        /// </summary>
        /// <param name="familyName"></param>
        /// <param name="players"></param>
        /// <returns></returns>
        private bool SearchFamilyOnPlayers(string familyName, PlayerViewModel currentPlayer, List<PlayerViewModel> players)
        {
            IEnumerable<PlayerViewModel> aux;

            aux = players.Where(x => x.Family.Name.Equals(familyName));

            if (aux == null || aux.Count() == 0)
            {
                return false;
            }
            else
            {
                if (aux.FirstOrDefault().Family.Name.Equals(currentPlayer.Family.Name))
                    return false;
                else
                    return true;
            }
                
        }
    }
}
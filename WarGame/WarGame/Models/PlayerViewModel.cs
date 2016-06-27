using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarGame.Models
{
    public class PlayerViewModel
    {
        private string id;
        private string name;
        private string family;
        private ObjectiveModel objective { get; set; }

        public PlayerViewModel(string name, string family, ObjectiveModel objective) 
        {
            id = Guid.NewGuid().ToString("N");
            this.name = name;
            this.family = family;
            this.objective = objective;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Family
        {
            get { return family; }
            set { family = value; }
        }
    }
   
}
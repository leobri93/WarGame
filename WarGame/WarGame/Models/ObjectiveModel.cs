using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarGame.Models
{
    public class ObjectiveModel
    {
        public int id { get; set; }
        public string description { get; set; }

        public ObjectiveModel (int id, string description)
        {
            this.id        = id;
            this.description = description;
        }

        public ObjectiveModel ()
        {

        }
    }
}
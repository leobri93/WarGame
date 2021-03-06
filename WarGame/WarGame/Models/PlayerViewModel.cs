﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarGame.Models
{
    public class PlayerViewModel
    {
        private string id;
        private string name;
        private FamilyViewModel family;
        public ObjectiveModel objective { get; set; }
        private bool isPlayer;

        public PlayerViewModel() { }

        public PlayerViewModel(string name, FamilyViewModel family, ObjectiveModel objective, bool isPlayer) 
        {
            id = Guid.NewGuid().ToString("N");
            this.name = name;
            this.family = family;
            this.objective = objective;
            this.isPlayer = isPlayer;
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

        public FamilyViewModel Family
        {
            get { return family; }
            set { family = value; }
        }

        public bool IsPlayer
        {
            get { return isPlayer; }
        }

    }
   
}
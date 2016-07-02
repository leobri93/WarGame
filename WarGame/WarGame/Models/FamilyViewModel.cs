using System;
using System.Collections.Generic;

namespace WarGame.Models
{
    public class FamilyViewModel
    {
        private string id { get; set; }
        private string name { get; set; }
        private string color { get; set; }
        private string src { get; set; }

        public FamilyViewModel() { }

        public FamilyViewModel(string name)
        {
            id = Guid.NewGuid().ToString("N");
            this.name = name;
            color = colors[name];
            src = srcs[name];
        }

        private readonly Dictionary<string, string> colors = new Dictionary<string, string>
        {
            ["Targaryen"] = "#fff",
            ["Lannister"] = "#f00",
            ["Stark"] = "#0f0",
            ["Baratheon"] = "#ff0",
            ["GreyJoy"] = "#0ff",
            ["Tyrell"] = "#00f"
        };

        private readonly Dictionary<string, string> srcs = new Dictionary<string, string>
        {
            ["Targaryen"] = "../Content/Images/targaryen.png",
            ["Lannister"] = "../Content/Images/lannister.png",
            ["Stark"] = "../Content/Images/stark.png",
            ["Baratheon"] = "../Content/Images/baratheon.png",
            ["GreyJoy"] = "../Content/Images/greyjoy.png",
            ["Tyrell"] = "../Content/Images/tyrell.png"
        };

        public string Id
        {
            get { return id; }
        }

        public string Name 
        {
            get { return name; }
            set { name = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Src
        {
            get { return src; }
        }

    }
}
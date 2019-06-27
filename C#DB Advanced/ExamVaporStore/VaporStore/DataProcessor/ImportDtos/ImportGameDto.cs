using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.ImportDtos
{
    public class ImportGameDto
    {
    //        "Name": "Dota 2",
    //        "Price": 0,
    //        "ReleaseDate": "2013-07-09",
    //        "Developer": "Valve",
    //        "Genre": "Action",
    //        "Tags": [
    //    "Multi-player",
    //    "Co-op",
    //    "Steam Trading Cards",
    //    "Steam Workshop",
    //    "SteamVR Collectibles",
    //    "In-App Purchases",
    //    "Valve Anti-Cheat enabled"
    //    ]
    //},

        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "733453453453645")]
        public decimal Price { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Genre { get; set; }

        public List<string> Tags { get; set; }
    }
}

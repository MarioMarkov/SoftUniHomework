using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaporStore.Data.Models
{
    public class GameTag
    {
    //•	GameId – integer, Primary Key, foreign key(required)
    //•	TagId – integer, Primary Key, foreign key(required)
    //•	Game – Game
    //•	Tag – Tag
    //TODO add composite key

    [Required]
    public int GameId { get; set; }
    public Game Game { get; set; }
    
    [Required]
    public int TagId { get; set; }
    public Tag Tag { get; set; }


    }
}

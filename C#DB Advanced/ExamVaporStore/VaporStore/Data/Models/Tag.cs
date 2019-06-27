using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaporStore.Data.Models
{
    public class Tag
    {
    //    •	Id – integer, Primary Key
    //•	Name – text(required)
    //•	GameTags - collection of type GameTag
    public Tag()
    {
        this.GameTags = new HashSet<GameTag>();
    }
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<GameTag> GameTags { get; set; }
    }
}

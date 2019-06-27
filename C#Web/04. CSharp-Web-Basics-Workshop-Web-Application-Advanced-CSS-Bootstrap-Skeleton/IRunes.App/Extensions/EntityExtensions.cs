using IRunes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRunes.App.Extensions
{
    public class EntityExtensions
    {
        public static string ToHtmlAll(this Album album)
        {
            return $"<a href=\"/Albums/Details?id={album.Id}\"></a>";
            
        }
        public static string ToHtmlDetails(this Album album)
        {

        }

        public static string ToHtmlDetails(this Track track)
        {

        }
        public static string ToHtmlAll(this Track track)
        {

        }
    }
}

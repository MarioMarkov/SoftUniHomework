using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_SalesDatabase.Data.Models
{
    public class Store
    {
        public int StoreId { get; set; }


        [Column(TypeName = "nvarchar(80)")]
        public string Name { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}

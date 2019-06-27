using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Items
{
    public class CreateItemInputModel
    {
        [Required]
        [MinLength(2),MaxLength(30)]
        public string Name { get; set; }

        [Range(typeof(decimal),"0.00","10000000000")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}

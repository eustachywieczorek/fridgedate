using System.ComponentModel.DataAnnotations;

namespace FridgeDate.Data.Models
{
    public class FoodItem
    {
        [Key, Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public BarCode BarCode { get; set; }
        [Required]
        public int ShelfLifeDays { get; set; }

    }
}

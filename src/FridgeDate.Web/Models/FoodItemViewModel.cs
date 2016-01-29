using FridgeDate.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace FridgeDate.Web.Models
{
    public class FoodItemViewModel
    {
        [Display(Name = "Product name")]
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Shelflife in days")]
        public int ShelfLifeDays { get; set; }

        [Display(Name = "Barcode id")]
        public int BarCodeId { get; set; }

        //public int MyProperty { get; set; }
    }
}

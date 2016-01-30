using FridgeDate.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.Web;

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
        public string BarCodeId { get; set; }
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}

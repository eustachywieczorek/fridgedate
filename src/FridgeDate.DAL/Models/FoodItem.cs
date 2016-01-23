using FridgeDate.DAL.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeDate.DAL.Models
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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeDate.DAL.Models
{
    public class FoodItemUser
    {
        [Key, Required]
        public string Id { get; set; }
        [Required, ForeignKey("User")]
        public string UserId { get; set; }
        [Required, ForeignKey("FoodItem")]
        public string FoodItemId { get; set; }

        public DateTime DateOpened{ get; set; }

        public bool IsFavourite { get; set; }

        public bool IsDeleted { get; set; }

        public virtual User User { get; set; }

        public virtual FoodItem FoodItem { get; set; }
    }
}

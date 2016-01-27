using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FridgeDate.Data.Models
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

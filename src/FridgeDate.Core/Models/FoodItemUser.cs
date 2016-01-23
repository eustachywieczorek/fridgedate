using System;

namespace FridgeDate.Core.Models
{
    public class FoodItemUser
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string FoodItemId { get; set; }

        public DateTime DateOpened{ get; set; }

        public bool IsFavourite { get; set; }

        public bool IsDeleted { get; set; }

        public virtual User User { get; set; }

        public virtual FoodItem FoodItem { get; set; }
    }
}

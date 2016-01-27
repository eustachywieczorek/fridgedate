using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FridgeDate.Data.Models
{
    public class User
    {
        [Key, Required]
        public string Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public virtual ICollection<FoodItemUser> FoodItems { get; internal set; }
    }
}

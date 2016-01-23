using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeDate.DAL.Models
{
    public class User
    {
        [Key, Required]
        public string Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }


    }
}

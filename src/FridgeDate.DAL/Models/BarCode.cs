using System.ComponentModel.DataAnnotations;

namespace FridgeDate.DAL.Models.Models
{
    public class BarCode
    {
        [Key, Required]
        public string Identifier { get; set; }
        public BarCodeType Type { get; set; }
    }
}
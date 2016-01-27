using System.ComponentModel.DataAnnotations;

namespace FridgeDate.Data.Models
{
    public class BarCode
    {
        [Key, Required]
        public string Identifier { get; set; }
        public BarCodeType Type { get; set; }
    }
}
namespace FridgeDate.Core.Models
{
    public class FoodItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public BarCode BarCode { get; set; }
        public int ShelfLifeDays { get; set; }
    }
}

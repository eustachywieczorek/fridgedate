using FridgeDate.Core.Interfaces;
using FridgeDate.Core.Models;
using Refit;
using System;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FridgeDate.Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private IFridgeDateApi<FoodItem, string> _api;

        public MainPage()
        {
            this.InitializeComponent();
            _api = RestService.For<IFridgeDateApi<FoodItem, string>>("http://localhost:47477/api/FoodItem");
        }

        private void btnCreate_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var foodItem = new FoodItem
            {
                Id = Guid.NewGuid().ToString(),
                Name = tbName.Text,
                ShelfLifeDays = int.Parse(tbShelfLife.Text),
                BarCode = new BarCode
                {
                    Identifier = "23",
                    Type = BarCodeType.QR
                }
            };
            _api.Create(foodItem);

        }
    }
}

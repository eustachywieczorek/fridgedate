using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FridgeDate.Android.Adapters;
using FridgeDate.Core.Interfaces;
using FridgeDate.Core.Models;
using Refit;
using Object = Java.Lang.Object;

namespace FridgeDate.Android.Activities
{
    [Activity(Label = "FoodItemsActivity")]
    public class FoodItemsActivity : Activity
    {
        private ListView _foodItemsListView;
        private IFridgeDateApi<FoodItemUser, string> _foodItemsApi; 

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _foodItemsApi = RestService.For<IFridgeDateApi<FoodItemUser, string>>(Core.Settings.Values.BASE_URL + "/foodItemsUser");
            var progressBar = new ProgressBar(this)
            {
                LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent,
                    ViewGroup.LayoutParams.WrapContent),
                Indeterminate = true
            };
            SetContentView(Resource.Layout.Main);
            Task.Run(async () => await SetFoodItems(progressBar));
            var root = FindViewById<ViewGroup>(Resource.Id.content);
            root.AddView(progressBar);
        }

        private async Task SetFoodItems(ProgressBar progressBar)
        {
            var foodItems = await _foodItemsApi.ReadAll();
            _foodItemsListView = FindViewById<ListView>(Resource.Id.lwItems);
            _foodItemsListView.EmptyView = progressBar;
            _foodItemsListView.Adapter = new FoodItemsAdapter(this, foodItems.ToList());

        }
    }
}
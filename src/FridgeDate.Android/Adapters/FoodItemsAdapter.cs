using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FridgeDate.Core.Models;

namespace FridgeDate.Android.Adapters
{
    public class FoodItemsAdapter : BaseAdapter<FoodItemUser>
    {
        private readonly IEnumerable<FoodItemUser> _foodItemsForUser;
        private readonly Activity _context;

        public FoodItemsAdapter(Activity context, IEnumerable<FoodItemUser> items)
        {
            _context = context;
            _foodItemsForUser = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.FoodItemForUser_ListItem, null);
            var name = view.FindViewById<EditText>(Resource.Id.lblName);
            var foodItemForUser = _foodItemsForUser.ElementAt(position);
            name.Text = foodItemForUser.FoodItem.Name;            
            var daysLeft = view.FindViewById<EditText>(Resource.Id.lblDaysLeft);
            daysLeft.Text =
                $"{foodItemForUser.FoodItem.ShelfLifeDays - (DateTime.Today - foodItemForUser.DateOpened).Days} days left";
            return view;
        }

        public override int Count
        {
            get { return _foodItemsForUser.Count(); }
        }

        public override FoodItemUser this[int position]
        {
            get { return _foodItemsForUser.ElementAt(position); }
        }
    }
}
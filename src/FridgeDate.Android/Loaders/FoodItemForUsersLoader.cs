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
using Object = Java.Lang.Object;

namespace FridgeDate.Android.Loaders
{
    public class FoodItemForUsersLoader : AsyncTaskLoader
    {
        public FoodItemForUsersLoader(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public FoodItemForUsersLoader(Context context) : base(context)
        {
        }

        public override Object LoadInBackground()
        {
            throw new NotImplementedException();
        }
    }
}
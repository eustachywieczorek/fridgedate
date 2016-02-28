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
using FridgeDate.Android.Adapters;
using Object = Java.Lang.Object;

namespace FridgeDate.Android.Activities
{
    [Activity(Label = "FoodItemsActivity")]
    public class FoodItemsActivity : ListActivity, LoaderManager.ILoaderCallbacks
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var progressBar = new ProgressBar(this)
            {
                LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent,
                    ViewGroup.LayoutParams.WrapContent),
                Indeterminate = true
            };
            ListView.EmptyView = progressBar;
            var root = FindViewById<ViewGroup>(Resource.Id.content);
            root.AddView(progressBar);
            ListAdapter = new FoodItemsAdapter(this, null);
            // Create your application here
        }



        public Loader OnCreateLoader(int id, Bundle args)
        {
            return new CursorLoader(this, );
        }

        public void OnLoaderReset(Loader loader)
        {
            throw new NotImplementedException();
        }

        public void OnLoadFinished(Loader loader, Object data)
        {
            throw new NotImplementedException();
        }
    }
}
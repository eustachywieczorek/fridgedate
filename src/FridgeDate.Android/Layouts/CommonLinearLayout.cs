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

namespace FridgeDate.Android.Layouts
{
    public class CommonLinearLayout : LinearLayout
    {
        public CommonLinearLayout(Context context) : base(context)
        {
            Orientation = Orientation.Vertical;
            SetPadding(10, 12, 10, 12);
        }
    }
}
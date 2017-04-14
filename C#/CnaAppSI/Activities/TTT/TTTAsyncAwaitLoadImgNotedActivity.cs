using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace EZOper.TechTester.AndroidCnaAppSI.Activities
{
    [Activity(Label = "Second Activity")]
    public class TTTAsyncAwaitLoadImgNotedActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            int count = Intent.Extras.GetInt("count", -1);
            if (count <= 0)
            {
                return;
            }
            SetContentView(Resource.Layout.TTTAsyncAwaitLoadImgNotedActivity);
            TextView txtView = FindViewById<TextView>(Resource.Id.textView1);
            txtView.Text = String.Format("You clicked the button {0} times in the previous activity.", count);
        }
    }
}

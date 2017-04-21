using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

using EZOper.TechTester.CnaSptAppSI.Adapters;
using EZOper.TechTester.CnaSptAppSI.Models;
using System.Linq;

namespace EZOper.TechTester.CnaSptAppSI
{
    [Activity(Label = "技术探究集", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        internal static readonly ReadOnlyCollection<ActivityItem> AreaDic = new ReadOnlyCollection<ActivityItem>(new List<ActivityItem>()
        {
            new ActivityItem(0,"", typeof(TTTMainListViewActivity),typeof(MainActivity),""),
        });

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // 找到页面元素
            var _functionListView = FindViewById<ListView>(Resource.Id.LvwAreaNameList);
            if (_functionListView != null)
            {
                _functionListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
                {
                    Type areaName = MainActivity.AreaDic[e.Position].Type;
                    var taskDetails = new Intent(this, areaName);
                    StartActivity(taskDetails);
                };
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            var areaListView = FindViewById<ListView>(Resource.Id.LvwAreaNameList);
            //Hook up our adapter to our ListView
            areaListView.Adapter = new ActivityAdapter(this, AreaDic.ToList());
        }
    }
}


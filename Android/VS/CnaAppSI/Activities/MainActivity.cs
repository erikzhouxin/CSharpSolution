using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using EZOper.TechTester.AndroidCnaAppSI.Adapters;

namespace EZOper.TechTester.AndroidCnaAppSI.Activities
{
    [Activity(Label = "技术探究集", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        internal static readonly ReadOnlyDictionary<int, Type> AreaDic = new ReadOnlyDictionary<int, Type>(new Dictionary<int, Type>()
        {
            {0, typeof(TTTMainListViewActivity)}
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
                    Type areaName = MainActivity.AreaDic[e.Position];
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
            areaListView.Adapter = new TypeDictionaryAdapter(this, AreaDic);
        }
    }
}


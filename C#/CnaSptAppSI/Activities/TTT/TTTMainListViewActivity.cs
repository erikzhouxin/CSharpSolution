using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EZOper.TechTester.CnaSptAppSI.Adapters;
using EZOper.TechTester.CnaSptAppSI.Models;

namespace EZOper.TechTester.CnaSptAppSI
{
    [Activity(Label = "临时测试练习功能表")]
    public class TTTMainListViewActivity : Activity
    {
        internal static readonly List<ActivityItem> FuncDic = new List<ActivityItem>()
        {
            new ActivityItem(0, "临时测试练习功能表", typeof(TTTSwipeToRefreshMainActivity), typeof(TTTMainListViewActivity), null),
        };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // 设置显示页面
            SetContentView(Resource.Layout.TTTMainListView);
            // 找到页面元素
            var _functionListView = FindViewById<ListView>(Resource.Id.LvwFunctionList);
            if (_functionListView != null)
            {
                _functionListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
                {
                    var areaName = TTTMainListViewActivity.FuncDic[e.Position].Type;
                    var taskDetails = new Intent(this, (areaName));
                    StartActivity(taskDetails);
                };
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            var areaListView = FindViewById<ListView>(Resource.Id.LvwFunctionList);
            //Hook up our adapter to our ListView
            areaListView.Adapter = new ActivityAdapter(this, FuncDic);
        }
    }
}
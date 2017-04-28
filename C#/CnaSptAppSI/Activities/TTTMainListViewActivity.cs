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
            new ActivityItem(0, "模拟时钟(Xamarin.AnalogClock)", typeof(TTTAnalogClockActivity), typeof(TTTMainListViewActivity),"https://developer.xamarin.com/samples/mobile/AnalogClock/"),
            new ActivityItem(1, "异步等待及通知(Xamarin.AsyncAwait,???)", typeof(TTTAsyncAwaitLoadImgActivity), typeof(TTTMainListViewActivity),"https://developer.xamarin.com/samples/mobile/AsyncAwait/,???"),
            new ActivityItem(2, "下拉刷新(Xamarin.SwipeToRefresh)", typeof(TTTSwipeToRefresh_MainActivity), typeof(TTTMainListViewActivity), "https://developer.xamarin.com/samples/monodroid/SwipeToRefresh/"),
            new ActivityItem(3, "异步下载(Xamarin.AsyncImageAndroid)", typeof(TTTAsyncImageAndroid_DownloadActivity),typeof(TTTMainListViewActivity),"https://developer.xamarin.com/samples/monodroid/AsyncImageAndroid/"),
        };

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

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
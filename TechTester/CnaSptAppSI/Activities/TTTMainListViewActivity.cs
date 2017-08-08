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
    [Activity(Label = "��ʱ������ϰ���ܱ�")]
    public class TTTMainListViewActivity : Activity
    {
        internal static readonly List<ActivityItem> FuncDic = new List<ActivityItem>()
        {
            new ActivityItem(0, "ģ��ʱ��(Xamarin.AnalogClock)", typeof(TTTAnalogClockActivity), typeof(TTTMainListViewActivity),"https://developer.xamarin.com/samples/mobile/AnalogClock/"),
            new ActivityItem(1, "�첽�ȴ���֪ͨ(Xamarin.AsyncAwait,???)", typeof(TTTAsyncAwaitLoadImgActivity), typeof(TTTMainListViewActivity),"https://developer.xamarin.com/samples/mobile/AsyncAwait/,???"),
            new ActivityItem(2, "����ˢ��(Xamarin.SwipeToRefresh)", typeof(TTTSwipeToRefresh_MainActivity), typeof(TTTMainListViewActivity), "https://developer.xamarin.com/samples/monodroid/SwipeToRefresh/"),
            new ActivityItem(3, "�첽����(Xamarin.AsyncImageAndroid)", typeof(TTTAsyncImageAndroid_DownloadActivity),typeof(TTTMainListViewActivity),"https://developer.xamarin.com/samples/monodroid/AsyncImageAndroid/"),
        };

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // ������ʾҳ��
            SetContentView(Resource.Layout.TTTMainListView);
            // �ҵ�ҳ��Ԫ��
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
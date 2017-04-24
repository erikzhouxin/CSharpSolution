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
            new ActivityItem(0, "��ʱ������ϰ���ܱ�", typeof(TTTSwipeToRefreshMainActivity), typeof(TTTMainListViewActivity), null),
        };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

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
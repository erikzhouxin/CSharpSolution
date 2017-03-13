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
using EZOper.TechTester.Adapters;

namespace EZOper.TechTester.Activities
{
    [Activity(Label = "��ʱ������ϰ���ܱ�")]
    public class TTTMainListViewActivity : Activity
    {
        internal static ReadOnlyDictionary<int, Type> FuncDic = new ReadOnlyDictionary<int, Type>(new Dictionary<int, Type>()
        {
            {0,typeof(TTTAnalogClockActivity)},
            {1,typeof(TTTAsyncAwaitLoadImgActivity)},
        });

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
                    var areaName = TTTMainListViewActivity.FuncDic[e.Position];
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
            areaListView.Adapter = new TypeDictionaryAdapter(this, FuncDic);
        }
    }
}
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
using EZOper.TechTester.CnaSptAppSI.Models;

namespace EZOper.TechTester.CnaSptAppSI.Adapters
{
    public class ActivityAdapter : BaseAdapter<Type>
    {
        Activity context = null;
        List<ActivityItem> activitiesList;

        public ActivityAdapter(Activity context, List<ActivityItem> activitiesList) : base()
        {
            this.context = context;
            this.activitiesList = activitiesList ?? new List<ActivityItem>();
        }

        public override Type this[int position]
        {
            get
            {
                return activitiesList[position].Type;
            }
        }

        public override int Count
        {
            get { return activitiesList.Count(); }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            // Get our object for position
            var item = activitiesList[position];

            //Try to reuse convertView if it's not  null, otherwise inflate it from our item layout
            // gives us some performance gains by not always inflating a new view
            // will sound familiar to MonoTouch developers with UITableViewCell.DequeueReusableCell()
            var view = (convertView ?? context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, parent, false)) as TextView;

            view.SetText(item.Name, TextView.BufferType.Normal);

            //Finally return the view
            return view;
        }
    }
}
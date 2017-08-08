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

namespace EZOper.TechTester.CnaSptAppSI.Models
{
    public class ActivityItem
    {
        public ActivityItem(int id, string name, Type type, Type parent, string memo = "")
        {
            ID = id;
            Name = name ?? string.Empty;
            Type = type;
            Parent = parent;
            Memo = memo ?? string.Empty;
        }

        public int ID { get; private set; }

        public string Name { get; private set; }

        public Type Type { get; private set; }

        public Type Parent { get; private set; }

        public string Memo { get; private set; }
    }
}
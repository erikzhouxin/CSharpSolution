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
    public class Forum
    {
        public string CategoryID { get; set; }
        public int CountDiscussions { get; set; }
        public Discussion[] Discussions { get; set; }
    }
}
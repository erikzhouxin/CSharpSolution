using System;
using System.ComponentModel;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using EZOper.TechTester.CnaSptAppSI.ViewModels;
using EZOper.TechTester.CnaSptAppSI.Services;

namespace EZOper.TechTester.CnaSptAppSI
{
	[Activity (Label = "模拟钟表")]
	public class TTTAnalogClockActivity : Activity
	{
		TTTAnalogClock_ViewModel clockView;
        AnalogClockPropertyChangeService clockModel;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set content view to FrameLayout with ClockView.
			FrameLayout frameLayout = new FrameLayout (this);
			clockView = new TTTAnalogClock_ViewModel (this);
			frameLayout.AddView (clockView);
			SetContentView (frameLayout);

			// Create ClockModel to keep clock updated.
			clockModel = new AnalogClockPropertyChangeService
            {
				IsSweepSecondHand = true
			};

			// Initialize clock.
			SetClockHandAngles ();

			clockModel.PropertyChanged += (object sender, PropertyChangedEventArgs e) => 
			{
				// Update clock.
				SetClockHandAngles();
			};
		}

		void SetClockHandAngles()
		{
			clockView.SetClockHandAngles(clockModel.HourAngle, 
										 clockModel.MinuteAngle, 
										 clockModel.SecondAngle);
		}
	}
}



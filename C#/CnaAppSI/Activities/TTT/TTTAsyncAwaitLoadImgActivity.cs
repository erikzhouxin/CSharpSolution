using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using Android.Graphics;
using Java.Lang;

namespace EZOper.TechTester.AndroidCnaAppSI.Activities
{
    [Activity(Label = "异步请求加载图片")]
    public class TTTAsyncAwaitLoadImgActivity : Activity
    {
        Button GetButton;
        TextView ResultTextView;
        EditText ResultEditText;
        ImageView DownloadedImageView;

        private static readonly int ButtonClickNotificationId = 100000000;
        private int _count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.TTTAsyncAwaitLoadImg);

            // Get our button from the layout resource,
            // and attach an event to it
            GetButton = FindViewById<Button>(Resource.Id.GetButton);
            ResultTextView = FindViewById<TextView>(Resource.Id.ResultTextView);
            ResultEditText = FindViewById<EditText>(Resource.Id.ResultEditText);
            DownloadedImageView = FindViewById<ImageView>(Resource.Id.DownloadedImageView);

            // Alternate way to call
            GetButton.Click += HandleClick;
        }

        public async Task<int> DownloadHomepageAsync()
        {
            var httpClient = new HttpClient(); // Xamarin supports HttpClient!

            Task<string> contentsTask = httpClient.GetStringAsync("https://xamarin.com"); // async method!

            // await! control returns to the caller and the task continues to run on another thread
            string contents = await contentsTask;
            ResultEditText.Text += "DownloadHomepage method continues after async call. . . . .\n";

            // After contentTask completes, you can calculate the length of the string.
            int exampleInt = contents.Length;

            ResultEditText.Text += "Downloaded the html and found out the length.\n\n\n";

            byte[] imageBytes = await httpClient.GetByteArrayAsync("https://xamarin.com/content/images/pages/about/team-h.jpg"); // async method!

            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string localFilename = "team.jpg";
            string localPath = System.IO.Path.Combine(documentsPath, localFilename);
            File.WriteAllBytes(localPath, imageBytes); // writes to local storage   

            ResultTextView.Text += "Downloaded the image.\n";

            var localImage = new Java.IO.File(localPath);
            if (localImage.Exists())
            {
                var teamBitmap = BitmapFactory.DecodeFile(localImage.AbsolutePath);
                DownloadedImageView.SetImageBitmap(teamBitmap);
            }

            ResultEditText.Text += contents; // just dump the entire HTML
            return exampleInt; // Task<TResult> returns an object of type TResult, in this case int
        }

        // Alternate way to call - notice the void return
        async void HandleClick(object sender, EventArgs e)
        {
            //			ResultTextView.Text = "loading...";
            //			ResultEditText.Text = "loading...\n";
            //
            //			// await! control returns to the caller
            //			var intResult = await DownloadHomepage();
            //
            //			// when the Task<int> returns, the value is available and we can display on the UI
            //			ResultTextView.Text = "Length: " + intResult ;

            Task<int> sizeTask = DownloadHomepageAsync();

            ResultTextView.Text = "loading...";
            ResultEditText.Text = "loading...\n";
            DownloadedImageView.SetImageResource(Android.Resource.Drawable.IcMenuGallery);

            // await! control returns to the caller
            var length = await sizeTask;

            // when the Task<int> returns, the value is available and we can display on the UI
            ResultTextView.Text = "Length: " + length;

            #region // 发送通知
            NotificationMessage(sender, e);
            #endregion

            // effectively returns void
        }

        void NotificationMessage(object sender, EventArgs e)
        {
            // These are the values that we want to pass to the next activity
            Bundle valuesForActivity = new Bundle();
            valuesForActivity.PutInt("count", _count);

            // Create the PendingIntent with the back stack             
            // When the user clicks the notification, SecondActivity will start up.
            Intent resultIntent = new Intent(this, typeof(TTTAsyncAwaitLoadImgNotedActivity));
            resultIntent.PutExtras(valuesForActivity); // Pass some values to SecondActivity.
            TaskStackBuilder stackBuilder = TaskStackBuilder.Create(this);
            stackBuilder.AddParentStack(Class.FromType(typeof(TTTAsyncAwaitLoadImgNotedActivity)));
            stackBuilder.AddNextIntent(resultIntent);

            PendingIntent resultPendingIntent = stackBuilder.GetPendingIntent(0, PendingIntentFlags.CancelCurrent);

            // Build the notification
            var builder = new Notification.Builder(this)
                .SetAutoCancel(true) // dismiss the notification from the notification area when the user clicks on it
                .SetContentIntent(resultPendingIntent) // start up this activity when the user clicks the intent.
                .SetContentTitle("点击按钮") // Set the title
                //.SetNumber(_count) // Display the count in the Content Info
                .SetSmallIcon(Resource.Drawable.ic_stat_button_click) // This is the icon to display NECESSARY
                .SetContentText(string.Format("你已经点击 {0} 次,多次点击也没用.", _count)); // the message to display.

            var builder2 = new Notification.Builder(this);

            // Finally publish the notification
            NotificationManager notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.Notify(ButtonClickNotificationId, builder.Build());

            _count++;
        }
    }
}



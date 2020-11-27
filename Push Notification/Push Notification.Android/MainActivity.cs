using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using System.Collections.Generic;

using Android.Gms.Common;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;

using Push_Notification.Model;
using Android.Support.V4.App;
using Push_Notification.Droid.Model;

namespace Push_Notification.Droid
{
    [Activity(Label = "Push_Notification", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        [Obsolete]
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            IsPlayServicesAvailable();
            CreateNotificationChannel();

            

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var channel = new NotificationChannel(Constant.CHANNEL_ID,
                                                  "FCM Notifications",
                                                  NotificationImportance.Default)
            {

                Description = "Firebase Cloud Messages appear in this channel"
            };

            var notificationManager = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }

        [Obsolete]
        public void IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                //msgText.Text = "Google Play Services is not available.";
            }
            else
            {
                //msgText.Text = "Google Play Services is available.";
                SharedPerference.saveToken(FirebaseInstanceId.Instance.Token);
                MessagingCenter.Send<string>(FirebaseInstanceId.Instance.Token, Constant.TOKEN_MASSAGING);

            }
        }

        void sentSimpleNotification(String title, String massage)
        {

            var builder = new NotificationCompat.Builder(this, Constant.CHANNEL_ID)
                  .SetAutoCancel(true) // Dismiss the notification from the notification area when the user clicks on it
                  .SetSmallIcon(Resource.Drawable.abc_ic_arrow_drop_right_black_24dp)
                  .SetContentTitle(title) // Set the title
                  .SetContentText(massage); // the message to display.

            // Finally, publish the notification:
            var notificationManager = NotificationManagerCompat.From(this);
            notificationManager.Notify(Constant.NOTIFICATION_ID, builder.Build());

        }
    }
}
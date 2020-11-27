using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Firebase.Messaging;
using Push_Notification.Model;

namespace Push_Notification.Droid.FCMService
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {

        public MyFirebaseMessagingService()
        {

        }
        public override void OnMessageReceived(RemoteMessage message)
        {
            //base.OnMessageReceived(message);
            sentSimpleNotification(message.Data["title"], message.Data["body"]);
        }

        void sentSimpleNotification(String title, String massage)
        {

            var builder = new NotificationCompat.Builder(this, Constant.CHANNEL_ID)
                  .SetAutoCancel(true) 
                  .SetSmallIcon(Resource.Drawable.abc_ic_arrow_drop_right_black_24dp)
                  .SetContentTitle(title)
                  .SetContentText(massage); 

            // Finally, publish the notification:
            var notificationManager = NotificationManagerCompat.From(this);
            notificationManager.Notify(Constant.NOTIFICATION_ID, builder.Build());

        }
    }
}
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
using Firebase.Iid;
using Push_Notification.Droid.Model;

namespace Push_Notification.Droid.FCMService
{
        [Service]
        [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
        public class MyFirebaseIIDService : FirebaseInstanceIdService
        {



            public override void OnTokenRefresh()
            {
                SendRegistrationToServer(FirebaseInstanceId.Instance.Token);
            }
            void SendRegistrationToServer(string token)
            {
                // save new token 
                SharedPerference.saveToken(token);
            }
        }
}
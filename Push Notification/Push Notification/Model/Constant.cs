using System;
using System.Collections.Generic;
using System.Text;

namespace Push_Notification.Model
{
    public class Constant
    {
        public static string TOKEN_MASSAGING = "token_massaging";

        public static string URL_Register_Email = "http://192.168.1.7:8000/registerDevice.php";
        public static string URL_Push_Notification = "http://192.168.1.7:8000/sendSinglePush.php";

        // Andriod Constant
        public static string CHANNEL_ID = "my_notification_channel";
        public static int NOTIFICATION_ID = 100;

        public static String TAG_TOKEN = "tagtoken";
        public static String TAG_TOKEN_ERROR = "token_error";


    }
}

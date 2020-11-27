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
using Push_Notification.Model;

namespace Push_Notification.Droid.Model
{
    class SharedPerference
    {

        public static void saveToken(String token)
        {
            ISharedPreferences prefs = Android.Preferences.PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutString(Constant.TAG_TOKEN, token);
            editor.Apply();
        }

        public static String getToken()
        {
            ISharedPreferences prefs = Android.Preferences.PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
            return prefs.GetString(Constant.TAG_TOKEN,Constant.TAG_TOKEN_ERROR);
        }
    }
}

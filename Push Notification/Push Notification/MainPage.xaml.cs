using Newtonsoft.Json;
using Push_Notification.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Push_Notification
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        
       
        private string FmcToken = "null";
        public MainPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<string>(this, Constant.TOKEN_MASSAGING, (expense) =>
            {
                FmcToken = expense as string;
                Register.IsEnabled = true;
            });

        }

        async void RegisterEmail(Object sender,EventArgs e) {

          
            if (Entary_Email.Text != null)
            {
                SendRegisterationRequest(Entary_Email.Text, FmcToken);
            }
            else
            {
                await DisplayAlert("Alert", "please enter your eamil first  " , "OK");
            }
        }

        private async void SendRegisterationRequest(string memail,string mtoken)                    
        {
            var client = new HttpClient();
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("email", memail),
                 new KeyValuePair<string, string>("token", mtoken)
            });

            var result = await client.PostAsync(Constant.URL_Register_Email, formContent).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                
                Device.BeginInvokeOnMainThread(() =>
                {
                    Push.IsEnabled = true;
                });


            }
        }
        async void PushNotification(Object sender, EventArgs e)
        {

            var client = new HttpClient();
            var formContent = new FormUrlEncodedContent(new[]
            {
                 new KeyValuePair<string, string>("email", Entary_Email.Text),
                 new KeyValuePair<string, string>("title", "FMC"),
                 new KeyValuePair<string, string>("message", "the notificatin that you push")
            });

            var result = await client.PostAsync(Constant.URL_Push_Notification, formContent).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {

                Device.BeginInvokeOnMainThread(() =>
                {
                    Push.IsEnabled = true;
                });


            }
        }

    }
}

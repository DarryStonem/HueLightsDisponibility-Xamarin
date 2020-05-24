using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMeetings.Services;
using MyMeetings.ViewModels;
using MyMeetings.Views;
using Q42.HueApi;
using Q42.HueApi.Interfaces;
using Q42.HueApi.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyMeetings
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new AuthViewModel();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            IRemoteAuthenticationClient authClient = new RemoteAuthenticationClient("", "", "");
            var authUri = authClient.BuildAuthorizeUri("sample", "myhue");

            var authResult = await WebAuthenticator.AuthenticateAsync(
                new Uri(authUri.AbsoluteUri),
                new Uri("mymeetings://"));

            var code = authResult?.Properties.FirstOrDefault(x => x.Key == "code").Value;
            if(String.IsNullOrEmpty(code))
            {
                return;
            }

            var accessToken = await authClient.GetToken(code);
            IRemoteHueClient client = new RemoteHueClient(authClient.GetValidToken);
            var bridges = await client.GetBridgesAsync();
            var currentBridge = bridges.FirstOrDefault().Id;
            try
            {
                //var key = await client.RegisterAsync(bridges.First().Id, "Sample App");
                client.Initialize(bridges.First().Id, "");
                var lights = await client.GetLightsAsync();
                var kitchenLight = lights.FirstOrDefault();
                var lightResult = await client.SendCommandAsync(new LightCommand().TurnOff());
            }
            catch (Exception ex)
            {

            }
            
        }

        private void HueAuth()
        {
            
        }
    }
}

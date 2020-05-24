using System;
using System.Windows.Input;
using MyMeetings.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyMeetings.ViewModels
{
    public class AuthViewModel : BaseViewModel
    {
        public ICommand OpenAuthBrowserCommand;

        public AuthViewModel()
        {
            OpenAuthBrowserCommand = new Command(ExecuteAuthBrowserCommandAsync);
        }

        /// <summary>
        /// Opens the browser to Hue Auth
        /// </summary>
        /// <param name="obj"></param>
        private async void ExecuteAuthBrowserCommandAsync(object obj)
        {
            var service = new HueService("", "", "");
            await Browser.OpenAsync(service.GetHueURL("", ""), BrowserLaunchMode.SystemPreferred);
        }
    }
}
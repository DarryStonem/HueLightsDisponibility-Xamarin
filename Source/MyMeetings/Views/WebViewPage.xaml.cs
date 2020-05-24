using System;
using System.Collections.Generic;
using MyMeetings.Services;
using Xamarin.Forms;

namespace MyMeetings.Views
{
    public partial class WebViewPage : ContentPage
    {
        public WebViewPage()
        {
            InitializeComponent();
            var service = new HueService("", "", "");
            var url = service.GetHueURL("", "");
            webView.Source = new Uri(url);
            webView.Navigated += WebView_Navigated;
        }

        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            
        }
    }
}
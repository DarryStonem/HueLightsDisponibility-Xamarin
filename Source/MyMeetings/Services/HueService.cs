using System;
using MyMeetings.Helpers;

namespace MyMeetings.Services
{
    public class HueService : IHueService
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }
        string AppId { get; set; }

        /// <summary>
        /// Initialize the HueService
        /// </summary>
        /// <param name="clientId">The ClientId you obtain from Hue</param>
        /// <param name="clientSecret">The clientsecret you have received from Hue when registering for the Hue Remote API.</param>
        /// <param name="appId">The appid you obtain from Hue</param>
        public HueService(string clientId, string clientSecret, string appId)
        {
            this.ClientId = clientId;
            this.AppId = appId;
            this.ClientSecret = clientSecret;
        }

        public string GetHueURL(string deviceId, string state)
        {
            var baseUrl = $"{Strings.BaseHueAPIUrl}{Strings.HueAuthString}";
            var urlParams = $"?clientid={this.ClientId}&appid={this.AppId}&deviceid={deviceId}&state={state}&response_type=code";
            return baseUrl+urlParams;
        }
    }
}

using System;
namespace MyMeetings.Services
{
    public interface IHueService
    {
        string GetHueURL(string deviceId, string state);
    }
}

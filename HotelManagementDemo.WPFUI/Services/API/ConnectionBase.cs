using System;
using System.Net.Http;

namespace HotelManagementDemo.WPFUI.Services.API
{
    public static class ConnectionBase
    {
        public static HttpClient _client;
        internal static HttpClient GetInstance()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(Endpoints.BASE_URL);
            return _client;
        }
    }
}

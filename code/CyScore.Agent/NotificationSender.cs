using CyScore.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CyScore.Agent
{
    internal static class NotificationSender
    {
        public static async Task Send(string url, AgentNotificationView notification)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(notification);

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = await streamReader.ReadToEndAsync();
                Console.WriteLine(result);
            }
        }
    }
}

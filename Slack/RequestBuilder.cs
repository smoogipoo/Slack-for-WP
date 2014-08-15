using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Slack_for_WP.Slack;

namespace Slack_for_WP.OAuth
{
    class RequestBuilder
    {
        private const string APIUrl = "https://slack.com/api/{0}";

        internal enum RequestMethods
        {
            POST,
            GET
        }

        internal static string ConstructRequestString(Endpoints endpoint, string[,] parameters)
        {
            string targetURL = string.Format(APIUrl, EndpointHelper.Parse(endpoint));
            string targetVerb = "";

            for (int i = 0; i < parameters.GetLength(0); i++)
            {
                targetVerb += (i == 0 ? "?" : "&") + parameters[i, 0] + "=" + Uri.EscapeDataString(parameters[i, 1]);
            }

            return targetURL + targetVerb;
        }

        internal static async Task<HttpWebRequest> BuildRequest(Endpoints endpoint, string[,] parameters, RequestMethods method = RequestMethods.POST)
        {
            string targetURL = string.Format(APIUrl, EndpointHelper.Parse(endpoint));
            string targetVerb = "";

            for (int i = 0; i < parameters.GetLength(0); i++)
            {
                targetVerb += (i == 0 ? "?" : "&") + parameters[i, 0] + "=" + Uri.EscapeDataString(parameters[i, 1]);
            }

            HttpWebRequest req = null;
            
            switch (method)
            {
                case RequestMethods.GET:
                    req = WebRequest.CreateHttp(targetURL + targetVerb);
                    break;
                case RequestMethods.POST:
                    req = WebRequest.CreateHttp(targetURL);
                    req.ContentType = "application/x-www-form-urlencoded";

                    byte[] data = Encoding.UTF8.GetBytes(targetVerb);
                    using (Stream reqStream = await Task<Stream>.Factory.FromAsync(req.BeginGetRequestStream, req.EndGetRequestStream, null))
                        await reqStream.WriteAsync(data, 0, data.Length);
                    break;
            }

            req.Method = method.ToString();
            return req;
        }

        internal static void PeformRequest(Action<string> callBack, HttpWebRequest request)
        {
            request.BeginGetResponse(c =>
            {
                using (WebResponse response = request.EndGetResponse(c))
                using (StreamReader sR = new StreamReader(response.GetResponseStream()))
                {
                    string receivedText = sR.ReadToEnd();
                    Deployment.Current.Dispatcher.BeginInvoke(delegate { callBack(receivedText); });
                }
            }, request);
        }
    }
}

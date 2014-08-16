using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Slack_for_WP.Slack
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

        internal static HttpWebRequest BuildRequest(Endpoints endpoint, string[,] parameters, RequestMethods method = RequestMethods.POST)
        {
            string targetURL = string.Format(APIUrl, EndpointHelper.Parse(endpoint));
            string targetVerb = "";

            if (parameters != null)
            {
                for (int i = 0; i < parameters.GetLength(0); i++)
                    targetVerb += (i == 0 ? "?" : "&") + parameters[i, 0] + "=" + Uri.EscapeDataString(parameters[i, 1]);
            }

            HttpWebRequest req = null;
            
            switch (method)
            {
                case RequestMethods.GET:
                    req = WebRequest.CreateHttp(targetURL + targetVerb);
                    req.Method = "GET";
                    break;
                case RequestMethods.POST:
                    req = WebRequest.CreateHttp(targetURL);
                    req.Method = "POST";
                    req.ContentType = "application/x-www-form-urlencoded";

                    byte[] data = Encoding.UTF8.GetBytes(targetVerb);
                    using (Stream reqStream = Task<Stream>.Factory.FromAsync(req.BeginGetRequestStream, req.EndGetRequestStream, null).Result)
                        reqStream.Write(data, 0, data.Length);
                    break;
            }

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

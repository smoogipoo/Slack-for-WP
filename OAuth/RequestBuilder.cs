using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Slack_for_WP.Slack;

namespace Slack_for_WP.OAuth
{
    class RequestBuilder
    {
        internal enum RequestMethods
        {
            POST,
            GET
        }

        internal static async Task<HttpWebRequest> BuildRequest(Endpoints endpoint, string[,] additionalParameters, RequestMethods method = RequestMethods.POST)
        {
            string targetURL = string.Format(Connection.APIUrl, EndpointHelper.Parse(endpoint));
            string targetVerb = "";

            for (int i = 0; i < additionalParameters.GetLength(0); i++)
            {
                if (i != 0)
                    targetVerb += "&";
                targetVerb += additionalParameters[i, 0] + Uri.EscapeDataString(additionalParameters[i, 1]);
            }

            byte[] data = Encoding.UTF8.GetBytes(targetVerb);

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(targetURL);
            req.Method = method.ToString();
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = data.Length;

            await Task.Run(delegate
            {
                Mutex mutex = new Mutex(false);

                req.BeginGetRequestStream(delegate(IAsyncResult result)
                {
                    using (Stream reqStream = req.EndGetRequestStream(result))
                        reqStream.Write(data, 0, data.Length);

                    mutex.ReleaseMutex();
                }, null);

                mutex.WaitOne();
            });

            return req;
        }

        internal static string GetResponseString(HttpWebRequest request)
        {
            string responseString = "";

            Mutex mutex = new Mutex(false);

            request.BeginGetResponse(delegate(IAsyncResult result)
            {
                HttpWebResponse response = (HttpWebResponse)result.AsyncState;
                using (StreamReader sR = new StreamReader(response.GetResponseStream()))
                    responseString = sR.ReadToEnd();

                mutex.ReleaseMutex();
            }, null);

            mutex.WaitOne();

            return responseString;
        }
    }
}

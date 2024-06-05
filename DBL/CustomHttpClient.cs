using DBL.Models;
using Newtonsoft.Json;
using System.Net;

namespace Mpesa
{
    public class CustomHttpClient
    {
        private HttpWebRequest webRequest;
        private string url;
        private RequestType requestType;

        public CustomHttpClient(string url, RequestType requestType)
        {
            this.url = url;
            this.requestType = requestType;
            webRequest = (HttpWebRequest)WebRequest.Create(this.url);
            webRequest.AutomaticDecompression = DecompressionMethods.GZip;
            webRequest.ContentType = "application/json";
        }

        public CustomHttpClient(string url, RequestType requestType, Dictionary<string, string> headers)
        {
            this.url = url;
            this.requestType = requestType;
            webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.ContentType = "application/json";

            //---- Add headers
            if (headers != null)
                foreach (var h in headers)
                {
                    webRequest.Headers.Add(h.Key, h.Value);
                }
        }

        public string SendRequest(string requestData, out Exception error)
        {
            error = null;
            webRequest.Method = requestType == RequestType.Post ? "POST" : "GET";
            try
            {
                byte[] bytes = null;
                if (!string.IsNullOrEmpty(requestData))
                {
                    bytes = System.Text.Encoding.ASCII.GetBytes(requestData);
                    webRequest.ContentLength = bytes.Length;
                    using (Stream os = webRequest.GetRequestStream())
                    {
                        os.Write(bytes, 0, bytes.Length);
                    }
                }

                HttpWebResponse response;
                response = (HttpWebResponse)webRequest.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    string responseStr = new StreamReader(responseStream).ReadToEnd();
                    return responseStr;
                }
                else
                {
                    error = new Exception(response.StatusDescription);
                    return "";
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse httpResponse = (HttpWebResponse)ex.Response;

                using (var stream = ex.Response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        string respContent = reader.ReadToEnd();
                        if (!string.IsNullOrEmpty(respContent))
                        {
                            var errorData = JsonConvert.DeserializeObject<ErrorModel>(respContent);
                            if (errorData != null)
                            {
                                if (!string.IsNullOrEmpty(errorData.ErrorCode) && !string.IsNullOrEmpty(errorData.ErrorMessage))
                                    return "Error! " + errorData.ErrorCode + " - " + errorData.ErrorMessage;
                            }
                        }
                    }
                }
                error = ex;
                webRequest.Abort();
                return string.Empty;
            }
            catch (Exception ex)
            {
                error = ex;
                webRequest.Abort();
                return string.Empty;
            }
            finally
            {

            }
        }

        public enum RequestType { Get = 0, Post = 1 }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;

namespace tarea_desktop
{
    public enum httpVerb
    {
        GET,
        POST,
        DELETE,
        PUT
    }
    public class RESTClient
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }
        public bool errorRequest { get; set; }
        public string errorMessage { get; set; }

        //Default Constructor
        public RESTClient(string url, httpVerb httpVerb)
        {
            endPoint = url;
            httpMethod = httpVerb;
            errorRequest = false;
        }

        public string makeRequest()
        {
            string strResponseValue = string.Empty;

            var request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method = httpMethod.ToString();

            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();


                //Proecess the resppnse stream... (could be JSON, XML or HTML etc..._

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //We catch non Http 200 responses here.
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
                errorRequest = true;
                errorMessage = ex.Message.ToString();
            }
            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }

            return strResponseValue;

        }

        public string makeBodyRequest(string bodyJSON)
        {
            string strResponseValue = string.Empty;

            var request = (HttpWebRequest) WebRequest.Create(endPoint);
            request.ContentType = "application/json";

            request.Method = httpMethod.ToString();

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = bodyJSON;

                streamWriter.Write(json);
            }

            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();


                //Proecess the resppnse stream... (could be JSON, XML or HTML etc..._

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //We catch non Http 200 responses here.
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
                errorRequest = true;
            }
            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }

            return strResponseValue;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;

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

        //Default Constructor
        public RESTClient(string url, httpVerb httpVerb)
        {
            endPoint = url;
            httpMethod = httpVerb;

        }

        public string makeRequest()
        {
            string strResponseValue = string.Empty;

            var request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method = httpMethod.ToString();

            HttpWebResponse response = null;
            errorRequest = false;
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

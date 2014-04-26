using System;
using System.Globalization;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace FaceMatrix.Models
{
    public class RoviApi
    {


        public JObject GetCelebByName()
        {
            string json = @"{  CPU: 'Intel',  Drives: [    'DVD read/writer',    '500 gigabyte hard drive'  ]}";
            var jo = JObject.Parse(json);
            return jo;
        }

     
        #region "Helper Methods"
        public static string GetHttpResponse(string searchUrl)
        {
            var results = string.Empty;
            try
            {
                var req = (HttpWebRequest)WebRequest.Create(searchUrl);
                var resp = (HttpWebResponse)req.GetResponse();

                var sr = new StreamReader(resp.GetResponseStream());
                results = sr.ReadToEnd();

                sr.Close();
            }
            catch (Exception e)
            {
                if (e.Message.Contains("400"))
                {
                    results = string.Format("{{\"status\":\"ok\",\"code\":200,\"messages\":{0},\"build\":\"1.0\"}}", e.Message);
                }
            }
            return results;
        }
        public static int RandNumber(int low, int high)
        {
            var rndNum = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), NumberStyles.HexNumber));

            var rnd = rndNum.Next(low, high);

            return rnd;
        }
        #endregion
    
    }
}
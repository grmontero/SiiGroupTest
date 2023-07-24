using Newtonsoft.Json;
using SiiTestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SiiTestDAL.ApiHelper
{
    public class ConsumeApi
    {
        public static int StatusCode = 0;
        public static string ReasonPhrase = "";
        public static async Task<string> getJson(string url)
        {
try { 
            using (HttpClient client = new HttpClient())
            {
                var httpResponseMessage = await client.GetAsync(url);
                    StatusCode = (int)httpResponseMessage.StatusCode;
                    ReasonPhrase = httpResponseMessage.ReasonPhrase;
                var json = await httpResponseMessage.Content.ReadAsStringAsync();
                return json;
            }
            }catch (Exception ex)
            {
                return "";
            }
        }
    }
}

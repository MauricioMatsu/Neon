using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Neon.External
{
    public class APIExternalController : IAPIExternalController
    {
        HttpClient _Client = new HttpClient();
        string _UrlBase = "http://www.apilayer.net";
        string _Access_key = "385eee701cae3b7dba6491115f892f1c";
        public APIExternalController()
        {
            _Client.BaseAddress = new Uri(_UrlBase);
            _Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void SetUrlBase(string urlBase)
        {
            _UrlBase = urlBase;
            _Client.BaseAddress = new Uri(_UrlBase);
        }


        public virtual Dictionary<string, object> Live(params string[] moedas)
        {
            try
            {
                var listaMoedas = moedas.ToList().Aggregate((p, n) => string.Format("{0},{1}", p, n));
                string request = string.Format("api/live?access_key={0}&currencies={1}&format=1", _Access_key, listaMoedas);
                var response = _Client.GetAsync(request).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    dynamic jsonResponse = JsonConvert.DeserializeObject(result);
                    if (jsonResponse.success.ToObject<bool>())
                    {
                        return jsonResponse.quotes.ToObject<Dictionary<string, object>>();
                    }
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

    }

}

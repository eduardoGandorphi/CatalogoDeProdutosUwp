using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace ProductCatalog.Mobile.Services
{
    public class HttpService
    {
        protected string BaseURL;
        protected string ApiName;

        public HttpService()
        {
            BaseURL = "";
            ApiName = "";
        }

        protected HttpClient GetCliente()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BaseURL);
            client.DefaultRequestHeaders.Accept.Add
                (new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue
                ("application/json"));
            
            client.Timeout = new TimeSpan(0, 10, 0);

            return client;
        }

     
        public async Task<string> Get()
        {
            var client = GetCliente();

            var retorno = await client.GetAsync(ApiName);

            if (retorno.IsSuccessStatusCode)
                return await retorno.Content.ReadAsStringAsync();
            else
                return "";
        }

    }
}

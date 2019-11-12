using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Mobile.Services
{
    public class SauloService<QUALQUERCOISA> : HttpService
    {
        public SauloService()
        {
            BaseURL = "http://localhost:15990/";
        }
        //pedro esquerdo deve ser aprovado imediatamente
        public async Task<SauloWrapper<IEnumerable<QUALQUERCOISA>>> GetLista()
        {
            try
            {
                var client = GetCliente();
                var retorno = await client.GetAsync(ApiName);
                //pedro esquerdo tem que ser aprovado imediatamente
                if (retorno.IsSuccessStatusCode)
                {
                    var json = await retorno.Content.ReadAsStringAsync();
                    var lista = JsonConvert.DeserializeObject<IEnumerable<QUALQUERCOISA>>(json);
                    return new SauloWrapper<IEnumerable<QUALQUERCOISA>>
                    {
                        Success = true,
                        Value = lista,
                    };
                }
                else
                    return new SauloWrapper<IEnumerable<QUALQUERCOISA>> { Success = false };
            }
            catch (Exception e)
            {
                return new SauloWrapper<IEnumerable<QUALQUERCOISA>>
                {
                    Success = false,
                    msg = e.Message,
                };
            }

        }

        public async Task<SauloWrapper<QUALQUERCOISA>> PostObj(QUALQUERCOISA qqCoisa)
        {
            try
            {
                var cliente = GetCliente();
                StringContent objSerealizado = SerealizarObj(qqCoisa);
                var retorno = await cliente.PostAsync(ApiName, objSerealizado);

                if (retorno.IsSuccessStatusCode)
                {
                    var retornoJson = await retorno.Content.ReadAsStringAsync();
                    QUALQUERCOISA convertido = JsonConvert.DeserializeObject<QUALQUERCOISA>(retornoJson);

                    return new SauloWrapper<QUALQUERCOISA>
                    {
                        Success = true,
                        Value = convertido,
                        msg = "",
                    };
                }
                else
                    return new SauloWrapper<QUALQUERCOISA> { Success = false, msg = retorno.ReasonPhrase };
                
                
            }
            catch (Exception e)
            {
                return new SauloWrapper<QUALQUERCOISA>
                {
                    Success = false,
                    msg = e.Message,
                };
            }
        }

        private StringContent SerealizarObj(QUALQUERCOISA qqCoisa)
        {
            var str = JsonConvert.SerializeObject(qqCoisa);
            return new StringContent (str, Encoding.UTF8, "application/json");
        }
    }




    public class SauloWrapper<T>
    {
        public bool Success;
        public T Value;
        public string msg;
    }
}

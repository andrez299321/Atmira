using Dto.Infraestructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Utility;
using Utility.Exceptions;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Infraestructure
{
    public class ConsumeApi
    {
        public readonly IHttpClientFactory _httpClientFactory;
        public ConsumeApi(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }



        
        public async Task<R> GetAsync<R>(string path, List<string> parameter)
        {
            try
            {
                string finallyPath = AddParameter(path, parameter);
                var httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Get,
                    finallyPath)
                {
                };

                var httpClient = _httpClientFactory.CreateClient("Backend");
                //header
                httpClient.DefaultRequestHeaders.Add("header", "header");
                //token autentication
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("type", "token");
                
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                if (httpResponseMessage.IsSuccessStatusCode)
                {

                    var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<R>(contentStream);

                }
            }
            catch (Exception ex) 
            {
                throw new TvShowException(ex.Message, ex);
            }

            return default(R);
        }



        public async Task<R> PostAsync<R>(string path, string json)
        {
            List<R> result = new List<R>();
            try { 
                HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Get,
                    path)
                {
                    Content = httpContent
                };
                var httpClient = _httpClientFactory.CreateClient();
                var httpResponseMessage = await httpClient.SendAsync(
                    httpRequestMessage);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string responseStream = await httpResponseMessage.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<R>(responseStream);
                }
            }
            catch (Exception ex) {
                throw new TvShowException(ex.Message, ex);
            }
            return default(R);
        }

        private string AddParameter(string path, List<string> parameter)
        {
            if (parameter != null && parameter.Count > 0)
            {
                foreach (var item in parameter)
                {
                    path += "/" + item;
                }
            }
            return path;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApiService.Services.Common
{
    internal class CommonRequest
    {
        private readonly string baseUrl;

        public CommonRequest(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        public async Task<ServiceResponceModel> MakeGetRequestAsync(string uri)
        {
            ServiceResponceModel response = new ServiceResponceModel()
            {
                StatusCode = -1,
                Message = null

            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Accept.Clear();

                HttpResponseMessage responseMsg = await client.GetAsync(uri);

                response.StatusCode = (int)responseMsg.StatusCode;

                response.Message = await responseMsg.Content.ReadAsStringAsync();
            }

            return response;
        }

        public async Task<ServiceResponceModel> MakePostRequestAsync(string uri, string data)
        {
            ServiceResponceModel response = new ServiceResponceModel()
            {
                StatusCode = -1,
                Message = null
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Accept.Clear();

                StringContent queryString = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage responseMsg = await client.PostAsync(uri, queryString);

                response.StatusCode = (int)responseMsg.StatusCode;

                response.Message = await responseMsg.Content.ReadAsStringAsync();
            }

            return response;
        }

        public async Task<ServiceResponceModel> MakeDeleteRequestAsync(string uri, string data)
        {
            ServiceResponceModel response = new ServiceResponceModel()
            {
                StatusCode = -1,
                Message = null
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Accept.Clear();

                StringContent queryString = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage responseMsg = await client.PostAsync(uri, queryString);

                response.StatusCode = (int)responseMsg.StatusCode;

                response.Message = await responseMsg.Content.ReadAsStringAsync();
            }

            return response;
        }


    }
}

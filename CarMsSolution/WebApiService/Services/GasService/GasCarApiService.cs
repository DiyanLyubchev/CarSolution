using Domain.Contracts;
using Domain.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiService.Adaptors;
using WebApiService.Models;
using WebApiService.Services.Common;

namespace WebApiService.Services.GasService
{
    public class GasCarApiService : ICarGasService
    {

        private readonly string baseURL;
        private readonly WebAdaptor webAdaptor;

        public GasCarApiService(string baseURL)
        {
            this.baseURL = baseURL;

            webAdaptor = new WebAdaptor();
        }

        public async Task<int> AddNewCar(CarViewModel carView)
        {
            CommonRequest serviceJson = new CommonRequest(baseURL);

            string uri = "car/post";

            string carStr = JsonConvert.SerializeObject(webAdaptor.GetCarGas(carView));

            ServiceResponceModel responce = await serviceJson.MakePostRequestAsync(uri, carStr);

            var carID = JsonConvert.DeserializeObject<int>(responce.Message);

            return carID;
        }

        public async Task<List<CarViewModel>> GetGasCarAsync()
        {
            string uri = "car/get";

            CommonRequest serviceJson = new CommonRequest(baseURL);

            ServiceResponceModel responce = await serviceJson.MakeGetRequestAsync(uri);

            var cars = JsonConvert.DeserializeObject<List<CarGasViewModel>>(responce.Message);

            return webAdaptor.Map(cars);
        }

        public async Task RemoveGasCarAsync(int carId)
        {
            string uri = "car/delete";

            CommonRequest serviceJson = new CommonRequest(baseURL);

            string carStr = JsonConvert.SerializeObject(carId);

            await serviceJson.MakeDeleteRequestAsync(uri, carStr);
        }
    }
}

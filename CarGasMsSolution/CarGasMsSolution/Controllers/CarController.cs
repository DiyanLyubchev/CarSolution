using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Application;
using Domain.CustomException;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarGasMsSolution.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Produces("application/json")]
    public class CarController : ControllerBase
    {
        private ICarManager carManager;

        public CarController(ICarManager carManager)
        {
            this.carManager = carManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarViewModel>>> Get()
        {
            var allCars = await carManager.GetCarsAsync();

            return allCars;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody]CarViewModel carViewModel)
        {
            try
            {
                var id = await carManager.AddNewCarAsync(carViewModel);

                return Ok(id);
            }
            catch (CarException ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult> Delete([FromBody]int id)
        {
            try
            {
                await carManager.DeleteCarAsync(id);

                return Ok(id);
            }
            catch (CarException ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}

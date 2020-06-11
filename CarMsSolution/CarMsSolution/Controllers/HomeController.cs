using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarMsSolution.Models;
using Domain.Application;
using Domain.Model;

namespace CarMsSolution.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarManager carManager;

        public HomeController(ICarManager carManager)
        {
            this.carManager = carManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var allCars = await this.carManager.GetCarsAsync();
                return View(allCars);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult NewCar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewCar(CarViewModel car)
        {
            try
            {
                await this.carManager.AddNewCarAsync(car);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

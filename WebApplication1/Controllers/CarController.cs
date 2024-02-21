using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Applications;
using WebApplication1.Applications.DTOModels;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarServise _carServise;
        public CarController(ICarServise carServise)
        {
            _carServise = carServise;
        }

        [HttpPost]
        public async Task<string> CreateCar(Car model)
        {
             await _carServise.CreateNewCAr(model);

            return "Added";
        }
        [HttpGet]

        public async Task<List<Car>> GetAllCars()
        {
            return await _carServise.GetAllCars();
        }

        [HttpGet]

        public async Task<Car> GetById(int id)
        {
            var res = await _carServise.GetById(id);
            return res;
        }

        [HttpPut]
        public async Task<string> UpdateCompany(int id,CarDTO model)
        {
            var res = await _carServise.UpdateById(id, model);
            return res;
        }

        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            var res = await _carServise.Delete(id);
            return res;
        }
    }
}

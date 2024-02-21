using Microsoft.Extensions.FileProviders.Physical;
using WebApplication1.Applications.DTOModels;
using WebApplication1.Models;

namespace WebApplication1.Applications
{
    public interface ICarServise
    {
        public Task<string> CreateNewCAr(Car model);
        public Task<List<Car>> GetAllCars();
        public Task<Car> GetById(int id);
        public Task<bool> Delete(int id);
        public Task<string> UpdateById(int id,CarDTO model);
        

    }
}

using Microsoft.EntityFrameworkCore;
using WebApplication1.Applications.DTOModels;
using WebApplication1.Infrostructer;
using WebApplication1.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApplication1.Applications
{
    public class CarServise : ICarServise
    {
        private readonly ApplicationDbContext _context;
        public CarServise(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> CreateNewCAr(Car car)
        {
            var model = new Car()
            {
                Brand = car.Brand,
            };
            await _context.Cars.AddAsync(model);
            await _context.SaveChangesAsync();

            return "Created";
        }

        public Task<List<Car>> GetAllCars()
        {
            var res = _context.Cars.ToListAsync();
            return res;
        }

        public async Task<Car> GetById(int id)
        {
            var md = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (md != null)
            {
                return md;
            }
            return new Car();
        }

        public async Task<bool> Delete(int id)
        {
            var md = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (md != null)
                if (md != null)
            {
                _context.Cars.Remove(md);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<string> UpdateById(int id,CarDTO model)
        {
            var md = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (md != null)
            {
                md.Brand = model.Brand;
                md.model = model.Model;
                await _context.SaveChangesAsync();
                return "updated";
            }
            return "Error";
        }
    }
}

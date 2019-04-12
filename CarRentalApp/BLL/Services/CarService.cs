using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.Contracts;
using BLL.Models;
using DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CarService : ICarService
    {
        private readonly CarRentalAppContext context;
        private readonly IMapper mapper;

        public CarService(CarRentalAppContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CarInfo>> GetAllCarsAsync()
        {
            return await context.Cars
                .ProjectTo<CarInfo>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}

using BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<CarInfo>> GetAllCarsAsync();
    }
}

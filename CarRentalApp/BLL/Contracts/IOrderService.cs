using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    public interface IOrderService
    {
        Task<OrderInfo> AddAsync(OrderInfo order);
        Task<OrderInfo> EditAsync(OrderInfo order);
        Task<IEnumerable<OrderInfo>> GetAllOrdersAsync();
        Task<IEnumerable<OrderInfo>> GetAsync(Expression<Func<OrderInfo, bool>> expression);
        Task<OrderInfo> FindAsync(int id);
        Task<OrderInfo> DeleteAsync(int id);
    }
}

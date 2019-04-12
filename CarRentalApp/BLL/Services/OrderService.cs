using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.Contracts;
using BLL.Models;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly CarRentalAppContext context;
        private readonly IMapper mapper;

        public OrderService(CarRentalAppContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<OrderInfo> AddAsync(OrderInfo order)
        {
            var entity = mapper.Map<Order>(order);
            context.Orders.Add(entity);
            await context.SaveChangesAsync();

            return mapper.Map<OrderInfo>(entity);
        }

        public async Task<OrderInfo> DeleteAsync(int id)
        {
            var entity = await context.Orders.FindAsync(id);
            if (entity != null)
            {
                context.Orders.Remove(entity);
                await context.SaveChangesAsync();
            }

            return mapper.Map<OrderInfo>(entity);
        }

        public async Task<OrderInfo> EditAsync(OrderInfo order)
        {
            var entity = await FindWithRelatedEntitiesAsync(order.Id);
            if (entity != null)
            {
                var entry = context.Entry(entity);
                var updatedEntity = mapper.Map<Order>(order);
                entry.CurrentValues.SetValues(updatedEntity);
                entry.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }

            return mapper.Map<OrderInfo>(entity);
        }

        private async Task<Order> FindWithRelatedEntitiesAsync(int id)
        {
            return await context.Orders
                .Include(o => o.User)
                .Include(o => o.Car)
                .SingleOrDefaultAsync(o => o.Id == id);
        }

        public async Task<OrderInfo> FindAsync(int id)
        {
            var orderEntity = await FindWithRelatedEntitiesAsync(id);
            return mapper.Map<OrderInfo>(orderEntity);
        }

        public async Task<IEnumerable<OrderInfo>> GetAllOrdersAsync()
        {
            return await context.Orders
                .ProjectTo<OrderInfo>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<OrderInfo>> GetAsync(Expression<Func<OrderInfo, bool>> expression)
        {
            return await context.Orders
                .ProjectTo<OrderInfo>(mapper.ConfigurationProvider)
                .Where(expression)
                .ToListAsync();
        }
    }
}

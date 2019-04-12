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
    public class UserService : IUserService
    {
        private readonly CarRentalAppContext context;
        private readonly IMapper mapper;

        public UserService(CarRentalAppContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<UserInfo>> GetAllUsersAsync()
        {
            return await context.Users
                .ProjectTo<UserInfo>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}

using ShopyWhere.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopyWhere.API.Data.Repositories
{
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository(AppDbContext _dbContext)
            :base(_dbContext)
        {
        }
    }
}

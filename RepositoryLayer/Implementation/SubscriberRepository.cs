using RepositoryLayer.Contract_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Implementation
{
    public class SubscriberRepository : I_SubscriberRepository
    {
        private readonly AppDbContext _dbContext;

        public SubscriberRepository(AppDbContext DbContext)
        {
            _dbContext = DbContext;
        }
    }
}

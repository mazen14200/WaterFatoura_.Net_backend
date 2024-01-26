using RepositoryLayer.Contract_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Implementation
{
    public class RE_TypesRepository : I_RE_TypesRepository
    {
        private readonly AppDbContext _dbContext;

        public RE_TypesRepository(AppDbContext DbContext)
        {
            _dbContext = DbContext;
        }
    }
}

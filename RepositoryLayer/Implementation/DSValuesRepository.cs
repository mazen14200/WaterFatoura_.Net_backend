using RepositoryLayer.Contract_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Implementation
{
    public class DSValuesRepository : I_DSValuesRepository
    {
        private readonly AppDbContext _dbContext;

        public DSValuesRepository(AppDbContext DbContext)
        {
            _dbContext = DbContext;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RepositoryLayer.Contract_interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public List<string> Splitting(string id);
        public string GenerateID_Subscription();
        public string GenerateID_Invoices();
        public Task<T?> GetSingleByIdAsync(string id);
        public Task<T?> GetSingleBy_match_Ex_Async(Expression<Func<T,bool>> match);
        public Task<IEnumerable<T>?> GetAllAsync();
        public Task<string> AddSingle_Async(T Entity);
        public Task<string> AddRange_Async(IEnumerable<T> Entities);
        public Task<string> Delete_Single_Async(string id);

        public Task<string> DeleteRange_Single_Async(IEnumerable<T> Entities);

        public Task<string> Update_Async(T Entity, string id);

        ////////////////
        /////////////
        /////////
        public Task<T?> GetSingleById_Char_Async(char id);

        public Task<string> Delete_Single_Char_Async(char id);

        public Task<string> Update_Char_Async(T Entity, char id);

    }
}

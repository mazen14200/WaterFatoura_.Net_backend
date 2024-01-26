using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RepositoryLayer.Contract_interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace RepositoryLayer.Implementation
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public BaseRepository(AppDbContext DbContext , IMapper mapper)
        {
            _dbContext = DbContext;
            _mapper = mapper;
        }
        public List<string> Splitting(string id)
        {
            string fruits = id;
            string sp_Date;
            int sp_id;
            char separator = '-';
            string[] fruitArray = fruits.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            sp_Date = fruitArray[0] + "-" + fruitArray[1];
            int number = Int16.Parse(fruitArray[2], CultureInfo.InvariantCulture);
            sp_id = number;
            List<string> lii = new List<string>();

            lii.Add(sp_Date);
            lii.Add(sp_id.ToString());
            return lii;
        }

        public string GenerateID_Subscription()
        {
            try 
            {
                
                string sp_Date = "";
                sp_Date = DateTime.Now.ToString("yy-MM");

                //var last = _dbContext.Tbl_Subscription_File.OrderBy(s => s.NO_Subscription).OrderByDescending(s => s.NO_Subscription).FirstOrDefault();
                var last = _dbContext.Tbl_Subscription_File.OrderBy(s => s.NO_Subscription).LastOrDefault();

                if (last != null)
                {
                    var x = last.NO_Subscription;
                    var lis = Splitting(x);

                    if (lis[1] != null)
                    {
                        int number = Int16.Parse(lis[1], CultureInfo.InvariantCulture);
                        number += 1;
                        if (sp_Date == lis[0])
                        {
                            return sp_Date + "-" + number.ToString();
                        }
                        return sp_Date + "-1";
                    }
                }
                return sp_Date + "-1";

            }
            catch (Exception ex)
            {
                return "";
            }
    }


        public string GenerateID_Invoices()
        {
            try
            {


                string sp_Date = "";
                sp_Date = DateTime.Now.ToString("yy-MM");
            //return sp_Date + "-1";
            //var last = _dbContext.Tbl_Invoices.OrderBy(s => s.NO_Invoice).OrderByDescending(s => s.NO_Invoice).FirstOrDefault();
            var last = _dbContext.Tbl_Invoices.OrderBy(s => s.NO_Invoice).LastOrDefault();
            if (last != null)
                {
                    var x = last.NO_Invoice;
                    var lis = Splitting(x);

                    if (lis[1] != null)
                    {
                        int number = Int16.Parse(lis[1], CultureInfo.InvariantCulture);
                        number += 1;
                        if (sp_Date == lis[0])
                        {
                            return sp_Date + "-"+number.ToString();
                        }
                    return sp_Date + "-1";
                }
            }
                return sp_Date + "-1";
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public async Task<IEnumerable<T>?> GetAllAsync()
        {
            try
            {
                IEnumerable<T> ExistingData = _dbContext.Set<T>().ToList();
                return ExistingData;
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public async Task<T?> GetSingleByIdAsync(string id)
        {

            try
            {
                T ExistingRecord = _dbContext.Set<T>().Find(id);
                if(ExistingRecord != null)
                {
                    return ExistingRecord;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public async Task<T?> GetSingleBy_match_Ex_Async(Expression<Func<T, bool>> match)
        {
            try
            {
                T ExistingRecord = _dbContext.Set<T>()
                    .SingleOrDefault(match);
                if (ExistingRecord != null)
                {
                    return ExistingRecord;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> AddSingle_Async(T Entity)
        {
            //IQueryable queryable = _dbContext.Set<T>();
            try
            {
                await _dbContext.Set<T>().AddAsync(Entity);
                await _dbContext.SaveChangesAsync();
                return "Successfuly Added";
            }
            catch(Exception ex){
                return ex.ToString();

            }

        }

        public async Task<string> AddRange_Async(IEnumerable<T> Entities)
        {
            throw new NotImplementedException();
        }
        public async Task<string> DeleteRange_Single_Async(IEnumerable<T> Entities)
        {
            throw new NotImplementedException();
            //try
            //{
            //    IEnumerable<T> ExistingEntities = await this.GetAllAsync();
            //    if (ExistingEntities != null)
            //    {
            //        await _dbContext.Set<T>().RemoveRange(Entities);
            //        await _dbContext.SaveChangesAsync();
            //        return "Successfuly Added";
            //    }

            //}
            //catch (Exception ex)
            //{
            //    return ex.ToString();

            //}
        }


        public async Task<string> Delete_Single_Async(string id)
        {
            try
            {
                T ExistingEntity = await this.GetSingleByIdAsync(id);
                if (ExistingEntity != null)
                {
                    _dbContext.Set<T>().Remove(ExistingEntity);
                    await _dbContext.SaveChangesAsync();
                    return "Successfuly Deleted";
                }
                return "This Record Not Found";


            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


        public async Task<string> Update_Async(T Entity,string id)
        {
            try
            {
                T ExistingEntity = await GetSingleByIdAsync(id);
                if (ExistingEntity != null)
                {
                    ExistingEntity = _mapper.Map<T>(Entity);
                    //////_dbContext.ChangeTracker.Clear();
                    _dbContext.ChangeTracker.Clear();
                    _dbContext.Set<T>().Update(ExistingEntity);
                    await _dbContext.SaveChangesAsync();
                    return "Successfuly updated";
                }
                return "This Record Not Found";


            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
                //////////////////
            //////////////////////////
        ////////////////////////////////////
        public async Task<T?> GetSingleById_Char_Async(char id)
        {

            try
            {
                T ExistingRecord = _dbContext.Set<T>().Find(id);
                if (ExistingRecord != null)
                {
                    return ExistingRecord;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public async Task<string> Delete_Single_Char_Async(char id)
        {
            try
            {
                T ExistingEntity = await this.GetSingleById_Char_Async(id);
                if (ExistingEntity != null)
                {
                    _dbContext.Set<T>().Remove(ExistingEntity);
                    await _dbContext.SaveChangesAsync();
                    return "Successfuly Deleted";
                }
                return "This Record Not Found";


            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


        public async Task<string> Update_Char_Async(T Entity, char id)
        {
            try
            {
                T ExistingEntity = await GetSingleById_Char_Async(id);
                if (ExistingEntity != null)
                {
                    ExistingEntity = _mapper.Map<T>(Entity);
                    //////_dbContext.ChangeTracker.Clear();
                    _dbContext.ChangeTracker.Clear();
                    _dbContext.Set<T>().Update(ExistingEntity);
                    await _dbContext.SaveChangesAsync();
                    return "Successfuly updated";
                }
                return "This Record Not Found";


            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}

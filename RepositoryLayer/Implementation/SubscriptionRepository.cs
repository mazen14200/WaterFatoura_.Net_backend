using DomainLayer.models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Contract_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace RepositoryLayer.Implementation
//{
//    public class SubscriptionRepository : I_SubscriptionRepository
//    {
//        private readonly AppDbContext _dbContext;

//        public SubscriptionRepository(AppDbContext DbContext)
//        {
//            _dbContext = DbContext;
//        }
//        public async Task<Subscription_File?> GetSingle_Subscription_Async(int sp_id,string sp_date)
//        {
//            try
//            {
//                Subscription_File ExistingEntity = await _dbContext.Tbl_Subscription_File
//                    .Where(x => x.sp_id == sp_id && x.sp_Date == sp_date).FirstAsync();
//                if (ExistingEntity != null)
//                {
//                    return ExistingEntity;
//                }
//                return null;

//            }
//            catch (Exception ex)
//            {
//                return null;
//            }
//        }
//        public async Task<IEnumerable<Subscription_File>?> GetAll_Subscription_Async()
//        {
//            try
//            {
//                IEnumerable<Subscription_File> Entities = _dbContext.Tbl_Subscription_File.ToList();
//                if (Entities != null)
//                {
//                    return Entities;
//                }
//                return null;

//            }
//            catch (Exception ex)
//            {
//                return null;
//            }
//        }

//        public async Task<string> AddSingle_Subscription_Async(Subscription_File subscription_File)
//        {
//            try
//            {
//                Subscription_File ExistingEntity = await GetSingle_Subscription_Async(subscription_File.sp_id, subscription_File.sp_Date);
//                if (ExistingEntity == null)
//                {
//                    _dbContext.Tbl_Subscription_File.AddAsync(subscription_File);
//                    await _dbContext.SaveChangesAsync();
//                    return "Successfuly Added";
//                }
//                return "This Record is Repeated";

//            }
//            catch (Exception ex)
//            {
//                return ex.ToString();
//            }
//        }
//        public async Task<string> Update_Subscription_Async(Subscription_File subscriptionEntity)
//        {

//            try
//            {
//                Subscription_File ExistingEntity = await GetSingle_Subscription_Async(subscriptionEntity.sp_id, subscriptionEntity.sp_Date);
//                if (ExistingEntity != null)
//                {
//                    _dbContext.Tbl_Subscription_File.Update(subscriptionEntity);
//                    await _dbContext.SaveChangesAsync();
//                    return "Successfuly updated";
//                }
//                return "Successfuly updated";

//            }
//            catch (Exception ex)
//            {
//                return ex.ToString();
//            }
//        }

//        public async Task<string> Delete_Subscription_Async(int sp_id, string sp_date)
//        {

//            try
//            {
//                Subscription_File ExistingEntity = await GetSingle_Subscription_Async(sp_id, sp_date);
//                if (ExistingEntity != null)
//                {
//                    _dbContext.Tbl_Subscription_File.Remove(ExistingEntity);
//                    await _dbContext.SaveChangesAsync();
//                    return "Successfuly Deleted";
//                }
//                return "This Record is Repeated";

//            }
//            catch (Exception ex)
//            {
//                return ex.ToString();
//            }
//        }
//    }
//}

using DomainLayer.models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Contract_interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace RepositoryLayer.Implementation
//{
//    public class InvoicesRepository : I_InvoicesRepository
//    {
//        private readonly AppDbContext _dbContext;

//        public InvoicesRepository(AppDbContext DbContext)
//        {
//            _dbContext = DbContext;
//        }
//        public List<string> Splitting(string id)
//        {
//            string fruits = id;
//            string sp_Date;
//            int sp_id;
//            char separator = '-';
//            string[] fruitArray = fruits.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
//            sp_Date = fruitArray[0] + "-" + fruitArray[1];
//            int number = Int16.Parse(fruitArray[2], CultureInfo.InvariantCulture);
//            sp_id = number;
//            List<string> lii = new List<string>();

//            lii.Add(sp_Date);
//            lii.Add(sp_id.ToString());
//            return lii;
//        }

//        public async Task<Invoices?> GetSingle_Invoice_Async(string id)
//        {
//            try
//            {
//                var lis = Splitting(id);
//            if (lis[1] != null)
//            {   
//                int sp_id = Int16.Parse(lis[1], CultureInfo.InvariantCulture);

//                Invoices ExistingEntity = await _dbContext.Tbl_Invoices
//                    .Where(x => x.sp_id == sp_id && x.sp_Date == sp_date).FirstAsync();
//                if (ExistingEntity != null)
//                {
//                    return ExistingEntity;
//                }
//                return null;
//            }
//            }
//            catch (Exception ex)
//            {
//                return null;
//            }

//        }
//        public async Task<IEnumerable<Invoices>?> GetAll_Invoices_Async()
//        {
//            try
//            {
//                IEnumerable<Invoices> Entities = _dbContext.Tbl_Invoices.ToList();
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

//        public async Task<string> AddSingle_Invoice_Async(Invoices Invoice)
//        {
//            try
//            {
//                Invoices ExistingEntity = await GetSingle_Invoice_Async(Invoice.sp_id, Invoice.sp_Date);
//                if (ExistingEntity == null)
//                {
//                    await _dbContext.Tbl_Invoices.AddAsync(Invoice);
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
//        public async Task<string> Update_Invoice_Async(Invoices Invoice)
//        {

//            try
//            {
//                Invoices ExistingEntity = await GetSingle_Invoice_Async(Invoice.sp_id, Invoice.sp_Date);
//                if (ExistingEntity != null)
//                {
//                    _dbContext.Tbl_Invoices.Update(Invoice);
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

//        public async Task<string> Delete_Invoice_Async(int sp_id, string sp_date)
//        {

//            try
//            {
//                Invoices ExistingEntity = await GetSingle_Invoice_Async(sp_id, sp_date);
//                if (ExistingEntity != null)
//                {
//                    _dbContext.Tbl_Invoices.Remove(ExistingEntity);
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

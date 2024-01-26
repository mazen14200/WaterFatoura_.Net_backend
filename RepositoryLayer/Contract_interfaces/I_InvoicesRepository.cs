using DomainLayer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Contract_interfaces
{
    public interface I_InvoicesRepository
    {
        public IEnumerable<string> Splitting(string id);
        public Task<IEnumerable<Invoices>?> GetAll_Invoices_Async();

        public Task<Invoices?> GetSingle_Invoice_Async(int sp_id, string sp_date);

        public Task<string> AddSingle_Invoice_Async(Invoices InvoiceEntity);

        public Task<string> Update_Invoice_Async(Invoices InvoiceEntity);
        public Task<string> Delete_Invoice_Async(int sp_id, string sp_date);

    }
}

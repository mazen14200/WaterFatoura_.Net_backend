using DomainLayer.models;
using RepositoryLayer.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Contract_interfaces
{
    public interface I_SubscriptionRepository
    {
        public Task<IEnumerable<Subscription_File>?> GetAll_Subscription_Async();

        public Task<Subscription_File?> GetSingle_Subscription_Async(int sp_id, string sp_date);
       
        public Task<string> AddSingle_Subscription_Async(Subscription_File subscriptionEntity);

        public Task<string> Update_Subscription_Async(Subscription_File subscriptionEntity);
        public Task<string> Delete_Subscription_Async(int sp_id, string sp_date);

    }
}

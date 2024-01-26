using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class DTO_Subscriber_File
    {
        //[ForeignKey("Invoices,Subscription_File")]
        public string Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Area { get; set; }

        public string Mobile { get; set; }

        public string? Reasons { get; set; }
    }
}

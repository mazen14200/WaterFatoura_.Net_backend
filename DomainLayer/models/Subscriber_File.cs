using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.models
{
    public class Subscriber_File
    {
        [Key]
        //[ForeignKey("Invoices,Subscription_File")]
        [MaxLength(10)]
        public string Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string Area { get; set; }
        
        [MaxLength(20)]
        public string Mobile { get; set; }
        
        [MaxLength(100)]
        public string? Reasons { get; set; }


    }
}

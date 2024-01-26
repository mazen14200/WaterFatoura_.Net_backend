using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class DTO_Real_Estate_Types
    {
        //[ForeignKey("Invoices,Subscription_File")]
        public char Code { get; set; }

        public string Name { get; set; }

        public string? Reasons { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.models
{
    public class Real_Estate_Types
    {
        [Key]
        //[ForeignKey("Invoices,Subscription_File")]
        public char Code { get; set; }
        
        [MaxLength(15)]
        public string Name { get; set; }
        
        [MaxLength(100)]
        public string? Reasons { get; set; }


    }
}

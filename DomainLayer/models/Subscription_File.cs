using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.models
{
    public class Subscription_File
    {

        // No
        [Key]
        [MaxLength(14)]
        public string NO_Subscription { get; set; }
        //[ForeignKey("Invoices")]
        //[Key, Column(Order = 0)]
        //public int sp_id { get; set; }

        //[ForeignKey("Invoices")]
        //[MaxLength(6)]
        //[Key, Column(Order = 1)]
        //public string sp_Date { get; set; }

        //FK
        [MaxLength(10)]
        public string FK_Subscriber_No { get; set; }


        //FK
        public char FK_Real_Estate_Types_id { get; set; }

        [MaxLength(2)]
        public int Unit_No { get; set; }

        public bool Is_There_Sanitation { get; set; }

        [MaxLength(10)]
        public int Last_Reading_Meter { get; set; }

        [MaxLength(100)]
        public string? Reasons { get; set; }

    }
}

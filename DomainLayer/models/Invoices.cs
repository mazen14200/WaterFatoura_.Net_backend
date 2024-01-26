using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.models
{
    public class Invoices
    {
        // No
        [Key]
        [MaxLength(14)]
        public string NO_Invoice { get; set; }
        //[ForeignKey("Real_Estate_Types")]
        //public int sp_id { get; set; }

        //[ForeignKey("Real_Estate_Types")]
        //[MaxLength(6)]
        //public string sp_Date { get; set; }


        [MaxLength(2)]
        public string year { get; set; }

        //FK
        public char FK_Real_Estate_Types_id { get; set; }

        //FK_NO_10
        public int FK_Subscription_No_sp_id { get; set; }

        //FK_NO_10
        [MaxLength(6)]
        public string FK_Subscription_No_sp_Date { get; set; }


        //FK
        [MaxLength(10)]
        public string FK_Subscriber_No { get; set; }


        [MaxLength(10)]
        public string Date { get; set; }
        
        [MaxLength(10)]
        public string From { get; set; }
        
        [MaxLength(10)]
        public string To { get; set; }

        [MaxLength(10)]
        public int Previous_Consumption_Amount { get; set; }

        [MaxLength(10)]
        public int Current_Consumption_Amount { get; set; }

        [MaxLength(10)]
        public int Amount_Consumption_Amount { get; set; }

        [MaxLength(11)]
        public float Service_Free { get; set; }

        [MaxLength(11)]
        public float Tax_Rate { get; set; }

        public bool Is_There_Sanitation { get; set; }

        [MaxLength(11)]
        public float Consumption_Value { get; set; }

        [MaxLength(11)]
        public float Wastewater_Consumption_Value { get; set; }

        [MaxLength(11)]
        public float Total_Invoice { get; set; }

        [MaxLength(11)]
        public float Tax_Value { get; set; }

        [MaxLength(11)]
        public float Total_Bill { get; set; }

        [MaxLength(100)]
        public string? Reasons { get; set; }


    }
}

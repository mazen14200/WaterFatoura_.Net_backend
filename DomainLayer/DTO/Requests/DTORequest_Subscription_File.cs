using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO.Requests
{
    public class DTORequest_Subscription_File
    {


        // No
        //[MaxLength(14)]
        //public string NO_Subscription { get; set; }
        //FK
        public string FK_Subscriber_No { get; set; }


        //FK
        public char FK_Real_Estate_Types_id { get; set; }

        public int Unit_No { get; set; }

        public bool Is_There_Sanitation { get; set; }

        public int Last_Reading_Meter { get; set; }

        public string? Reasons { get; set; }
    }
}

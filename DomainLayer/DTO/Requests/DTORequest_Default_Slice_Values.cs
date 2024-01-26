using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO.Requests
{
    public class DTORequest_Default_Slice_Values
    {

        public string Name { get; set; }

        public int Condition { get; set; }


        public float Water_Price { get; set; }

        public float Sanitation_price { get; set; }

        public string? Reasons { get; set; }
    }
}

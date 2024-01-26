using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class DTO_Default_Slice_Values
    {
        public char Code { get; set; }

        public string Name { get; set; }

        public int Condition { get; set; }


        public float Water_Price { get; set; }

        public float Sanitation_price { get; set; }

        public string? Reasons { get; set; }
    }
}

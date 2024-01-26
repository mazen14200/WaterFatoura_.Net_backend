using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.models
{
    public class Default_Slice_Values
    {
        [Key]
        public char Code { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(3)]
        public int Condition { get; set; }


        [MaxLength(7)]
        public float Water_Price { get; set; }

        [MaxLength(7)]
        public float Sanitation_price { get; set; }

        [MaxLength(100)]
        public string? Reasons { get; set; }

    }
}

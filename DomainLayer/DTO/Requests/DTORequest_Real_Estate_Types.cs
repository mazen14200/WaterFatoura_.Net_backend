using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO.Requests
{
    public class DTORequest_Real_Estate_Types
    {

        public string Name { get; set; }

        public string? Reasons { get; set; }
    }
}

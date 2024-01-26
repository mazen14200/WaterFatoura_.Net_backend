using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO.Requests
{
    public class DTORequest_Subscriber_File
    {

        public string Name { get; set; }

        public string City { get; set; }

        public string Area { get; set; }

        public string Mobile { get; set; }

        public string? Reasons { get; set; }
    }
}

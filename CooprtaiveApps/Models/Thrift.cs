using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CooprtaiveApps.Models
{
    public class Thrift
    {
        public int ThriftId { get; set; }
        [Required(ErrorMessage = "ThriftA  is required !")]
        public string ThriftA { get; set; }
        [Required(ErrorMessage = "ThriftB  is required !")]
        public string ThriftB { get; set; }
        [Required(ErrorMessage = "ThriftC  is required !")]
        public string ThriftC { get; set; }
       
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public byte[] RowVersion { get; set; }
    }
}

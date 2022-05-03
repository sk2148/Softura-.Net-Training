using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EFProduct.Models
{
    public class Prod
    {
        [Key]
        [Required]
        public int PID { get; set; }
        public string PName { get; set; }
        public DateTime ManufacDate { get; set; }
    }
}

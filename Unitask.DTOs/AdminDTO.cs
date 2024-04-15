using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitask.DTOs
{
    public class AdminDTO
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string Username { get; set; }
        
        public string Password { get; set; }
    }
}

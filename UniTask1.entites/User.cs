using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniTask.entites
{
    public class User
    {
        public Guid ID { get; set; }
        [Required]
        public string Username { get; set; }
        
    }
}

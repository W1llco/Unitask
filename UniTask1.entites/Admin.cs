using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniTask.entites
{
    public class Admin
    {
        public Guid ID { get; set; }
        [Required]
        public Guid UserID { get; set; }
    }
}

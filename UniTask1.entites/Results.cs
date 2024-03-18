using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniTask.entites
{
    public class Results
    {
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

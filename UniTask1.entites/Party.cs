using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniTask.entites
{
    internal class Party
    {
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }

        public Guid ElectionID { get; set; }
        [Required]

        public Guid RegionID { get; set; }
        [Required]
    }
}

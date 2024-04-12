using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UniTask.entites
{
    public class Election
    {
        public Guid ID { get; set; }
        
        public Guid? Winner { get; set; }
        [Required]

        public Guid VoteSystem{ get; set; }

        public Guid RegionID { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

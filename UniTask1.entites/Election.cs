using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UniTask.entites
{
    internal class Election
    {
        public Guid ID { get; set; }
        
        public Guid? Winner { get; set; }
        [Required]

        public Guid VoteSystem{ get; set; }

        public Guid RegionID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniTask.entites
{
    public class Voter
    {
        public Guid ID { get; set; }
        [Required]

        public string UserID { get; set; }
        [Required]

        public string VerifcationId { get; set; }
        [Required]

        public bool HasVoted { get; set; }
        [Required]

        public Guid RegionID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]

        public string VerificationCode { get; set; }
        

    }
}

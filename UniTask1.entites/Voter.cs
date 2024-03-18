using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniTask.entites
{
    public class Voter : User
    {

        public string UserID { get; set; }
        [Required]

        public string VerifcationId { get; set; }
        [Required]

        public Boolean HasVoted { get; set; }
        [Required]

        public Guid RegionID { get; set; }
        [Required]
    }
}

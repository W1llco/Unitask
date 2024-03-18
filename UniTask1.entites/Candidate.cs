using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniTask.entites
{
    internal class Candidate
    {
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int VoteCount {  get; set; }
        [Required]

        public Guid partyID { get; set; }
        [Required]

        public Guid RegionID { get; set; }
        [Required]
    }
}

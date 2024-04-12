using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniTask.entites
{
    public class Vote
    {
        public Guid ID { get; set; }
        [Required]
        public Guid VoterId { get; set; }
        [Required]
        public Guid ElectionId { get; set; }

        public Guid CandiateId { get; set; }
    }
}

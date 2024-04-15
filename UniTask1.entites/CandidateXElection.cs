using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniTask.Entites
{
    public class CandidateXElection
    {
        public Guid Id { get; set; }
        [Required]
        public Guid CandidateId { get; set; }
        [Required]
        public Guid ElectionId { get; set; }

        public int VoteCount { get; set; } = 0;

    }
}

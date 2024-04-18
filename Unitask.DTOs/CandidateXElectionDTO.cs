using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitask.DTOs
{
    public class CandidateXElectionDTO
    {
        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public Guid ElectionId { get; set; }
        public int VoteCount { get; set; } = 0;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitask.DTOs
{
    public class VoteDTO
    {
        public Guid ID { get; set; }
        public Guid VoterId { get; set; }

        public Guid CandiateId { get; set; }

        public Guid ElectionId { get; set; }
    }
}

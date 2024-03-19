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
        public string Name { get; set; }

        public Guid CandiateId { get; set; }
    }
}

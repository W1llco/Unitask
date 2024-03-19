using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitask.DTOs
{
    public class VoterDTO
    {
        public Guid ID { get; set; }

        public string UserID { get; set; }

        public string VerifcationId { get; set; }

        public bool HasVoted { get; set; }

        public Guid RegionID { get; set; }
    }
}

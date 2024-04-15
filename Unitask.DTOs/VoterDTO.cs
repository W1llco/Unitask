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

        public Guid UserID { get; set; }

        public string Password { get; set; }

        public string VerifcationCode { get; set; }

        public bool IsVerified { get; set; }

        public bool HasVoted { get; set; }

        public Guid RegionID { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get ; set; }


    }
}

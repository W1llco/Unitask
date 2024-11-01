﻿using System;
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
        public Guid UserID { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string VerifcationCode { get; set; }
        [Required]
        public bool IsVerified { get; set; } = false;
        [Required]
        public bool HasVoted { get; set; } = false;
        [Required]
        public Guid RegionID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Email { get; set; }

        public string Salt { get; set; }

    }
}

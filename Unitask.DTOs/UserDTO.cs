﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitask.DTOs
{
    public class UserDTO
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }  

        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}

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
        public string Username { get; set; }  
    }
}

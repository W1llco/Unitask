using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitask.DTOs
{
    public class PartyDTO
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public Guid ElectionID { get; set; }

        public Guid RegionID { get; set; }
    }
}

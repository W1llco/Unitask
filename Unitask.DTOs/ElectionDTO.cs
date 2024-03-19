using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitask.DTOs
{
    public class ElectionDTO
    {
        public Guid ID { get; set; }

        public Guid? Winner { get; set; }

        public Guid VoteSystem { get; set; }

        public Guid RegionID { get; set; }
    }


}

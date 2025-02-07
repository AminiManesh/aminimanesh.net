using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.Core.DTOs.OwnerDTOs
{
    public class ExperienceInfoDTO
    {
        public string ExperienceYears { get; set; }

        public string CompletedProjects { get; set; }

        public string SatisfiedCustomer { get; set; }

        public string Awards { get; set; }
    }
}

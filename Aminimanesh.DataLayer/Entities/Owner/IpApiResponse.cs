using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.DataLayer.Entities.Owner
{
    public class IpApiResponse
    {
        [Key]
        public int IpApiResponseId { get; set; }

        [Display(Name = "Status")]
        [MaxLength]
        public string? Status { get; set; }

        [Display(Name = "Continent")]
        [MaxLength]
        public string? Continent { get; set; }

        [Display(Name = "Country")]
        [MaxLength]
        public string? Country { get; set; }

        [Display(Name = "RegionName")]
        [MaxLength]
        public string? RegionName { get; set; }

        [Display(Name = "City")]
        [MaxLength]
        public string? City { get; set; }

        [Display(Name = "District")]
        [MaxLength]
        public string? District { get; set; }

        [Display(Name = "Zip")]
        [MaxLength]
        public string? Zip { get; set; }

        [Display(Name = "Lat")]
        [MaxLength]
        public double? Lat { get; set; }

        [Display(Name = "Lon")]
        [MaxLength]
        public double? Lon { get; set; }

        [Display(Name = "ISP")]
        [MaxLength]
        public string? ISP { get; set; }

        [Display(Name = "Query")]
        [MaxLength]
        public string? Query { get; set; }
    }
}

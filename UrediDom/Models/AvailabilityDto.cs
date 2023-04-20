using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class AvailabilityDto
    {
        /// <summary>
        /// Gets or Sets RepairmanID
        /// </summary>

        [Key]
        [DataMember(Name = "repairmanID")]
        public long repairmanID { get; set; }

        /// <summary>
        /// Gets or Sets Unavailable
        /// </summary>

        [DataMember(Name = "unavailable")]
        public DateTime? unavailable { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class RepairmanDto
    {
        /// <summary>
        /// Gets or Sets RepairmanID
        /// </summary>

        [Key]
        [DataMember(Name = "repairmanID")]
        public long repairmanID { get; set; }

        /// <summary>
        /// Gets or Sets Sector
        /// </summary>

        [DataMember(Name = "sector")]
        public long sector { get; set; }
    }
}

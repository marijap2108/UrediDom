using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class Availability
    {
        /// <summary>
        /// Gets or Sets RepairmanID
        /// </summary>

        [DataMember(Name = "repairmanID")]
        public long? RepairmanID { get; set; }

        /// <summary>
        /// Gets or Sets Unavailable
        /// </summary>

        [DataMember(Name = "unavailable")]
        public DateTime? Unavailable { get; set; }
    }
}

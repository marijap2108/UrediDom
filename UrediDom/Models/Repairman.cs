using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class Repairman
    {
        /// <summary>
        /// Gets or Sets RepairmanID
        /// </summary>

        [DataMember(Name = "repairmanID")]
        public long? RepairmanID { get; set; }
    }
}

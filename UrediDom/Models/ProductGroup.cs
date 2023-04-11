using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class ProductGroup
    {
        /// <summary>
        /// Gets or Sets GroupID
        /// </summary>

        [DataMember(Name = "groupID")]
        public long? GroupID { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>

        [DataMember(Name = "description")]
        public string Description { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class ProductGroupDto
    {
        /// <summary>
        /// Gets or Sets GroupID
        /// </summary>

        [Key]
        [DataMember(Name = "groupID")]
        public long groupID { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>

        [DataMember(Name = "description")]
        public string description { get; set; }
    }
}

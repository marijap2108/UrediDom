using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class TypeOfProductDto
    {
        /// <summary>
        /// Gets or Sets TypeID
        /// </summary>

        [Key]
        [DataMember(Name = "typeID")]
        public long typeID { get; set; }

        /// <summary>
        /// Gets or Sets TypeName
        /// </summary>

        [DataMember(Name = "typeName")]
        public string typeName { get; set; }
    }
}

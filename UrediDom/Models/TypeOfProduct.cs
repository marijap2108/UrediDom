using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class TypeOfProduct
    {
        /// <summary>
        /// Gets or Sets TypeID
        /// </summary>

        [DataMember(Name = "typeID")]
        public long? TypeID { get; set; }

        /// <summary>
        /// Gets or Sets TypeName
        /// </summary>

        [DataMember(Name = "typeName")]
        public string TypeName { get; set; }
    }
}

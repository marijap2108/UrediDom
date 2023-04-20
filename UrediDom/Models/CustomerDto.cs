using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class CustomerDto
    {
        /// <summary>
        /// Gets or Sets CustomerID
        /// </summary>

        [Key]
        [DataMember(Name = "customerID")]
        public long customerID { get; set; }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>

        [DataMember(Name = "address")]
        public string address { get; set; }
    }
}

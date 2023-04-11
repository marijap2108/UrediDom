using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class Customer
    {
        /// <summary>
        /// Gets or Sets CustomerID
        /// </summary>

        [DataMember(Name = "customerID")]
        public long? CustomerID { get; set; }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>

        [DataMember(Name = "address")]
        public string Address { get; set; }
    }
}

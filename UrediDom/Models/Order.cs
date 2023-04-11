using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class Order
    {
        /// <summary>
        /// Gets or Sets OrderID
        /// </summary>

        [DataMember(Name = "orderID")]
        public long? OrderID { get; set; }

        /// <summary>
        /// Gets or Sets DateOfOrder
        /// </summary>

        [DataMember(Name = "dateOfOrder")]
        public DateTime? DateOfOrder { get; set; }

        /// <summary>
        /// Gets or Sets Amount
        /// </summary>

        [DataMember(Name = "amount")]
        public int? Amount { get; set; }

        /// <summary>
        /// Gets or Sets CustomerID
        /// </summary>

        [DataMember(Name = "customerID")]
        public long? CustomerID { get; set; }

        /// <summary>
        /// Gets or Sets RepairmanID
        /// </summary>

        [DataMember(Name = "repairmanID")]
        public long? RepairmanID { get; set; }
    }
}

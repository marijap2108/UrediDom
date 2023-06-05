using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class OrderDto
    {
        /// <summary>
        /// Gets or Sets OrderID
        /// </summary>

        [Key]
        [DataMember(Name = "orderID")]
        public long orderID { get; set; }

        /// <summary>
        /// Gets or Sets DateOfOrder
        /// </summary>

        [DataMember(Name = "dateOfOrder")]
        public DateTime? dateOfOrder { get; set; }

        /// <summary>
        /// Gets or Sets Amount
        /// </summary>

        [DataMember(Name = "amount")]
        public Single? amount { get; set; }

        /// <summary>
        /// Gets or Sets CustomerID
        /// </summary>

        [DataMember(Name = "customerID")]
        public long? customerID { get; set; }

        /// <summary>
        /// Gets or Sets RepairmanID
        /// </summary>

        [DataMember(Name = "repairmanID")]
        public long? repairmanID { get; set; }

        /// <summary>
        /// Gets or Sets Intent
        /// </summary>

        [DataMember(Name = "intent")]
        public string? intent { get; set; }
    }
}

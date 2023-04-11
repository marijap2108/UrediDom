using System.Runtime.Serialization;

namespace UrediDom.Models
{
    public class Admin
    {
        /// <summary>
        /// Gets or Sets AdminID
        /// </summary>

        [DataMember(Name = "adminID")]
        public long? AdminID { get; set; }
    }
}

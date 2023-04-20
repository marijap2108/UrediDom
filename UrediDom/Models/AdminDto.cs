using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace UrediDom.Models
{
    public class AdminDto
    {
        /// <summary>
        /// Gets or Sets AdminID
        /// </summary>

        [Key]
        [DataMember(Name = "adminID")]
        public long adminID { get; set; }
    }
}

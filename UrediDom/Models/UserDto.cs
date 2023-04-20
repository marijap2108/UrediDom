using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class UserDto : LoginDto
    {
        /// <summary>
        /// Gets or Sets UserID
        /// </summary>

        [Key]
        [DataMember(Name = "userID")]
        public long userID { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>

        [DataMember(Name = "name")]
        public string name { get; set; }

        /// <summary>
        /// Gets or Sets Surname
        /// </summary>

        [DataMember(Name = "surname")]
        public string surname { get; set; }

        /// <summary>
        /// Gets or Sets Username
        /// </summary>

        [DataMember(Name = "username")]
        public string username { get; set; }

        /// <summary>
        /// Gets or Sets Phone
        /// </summary>

        [DataMember(Name = "phone")]
        public string phone { get; set; }

        /// <summary>
        /// Gets or Sets Birthday
        /// </summary>

        [DataMember(Name = "birthday")]
        public DateTime? birthday { get; set; }

        /// <summary>
        /// Gets or Sets Role
        /// </summary>

        [DataMember(Name = "role")]
        public string role { get; set; }
    }
}

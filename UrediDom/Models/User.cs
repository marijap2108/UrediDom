using System.Runtime.Serialization;
using System.Xml.Linq;

namespace UrediDom.Models
{
    public class User
    {
        /// <summary>
        /// Gets or Sets UserID
        /// </summary>

        [DataMember(Name = "userID")]
        public long? UserID { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>

        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Surname
        /// </summary>

        [DataMember(Name = "surname")]
        public string Surname { get; set; }

        /// <summary>
        /// Gets or Sets Username
        /// </summary>

        [DataMember(Name = "username")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>

        [DataMember(Name = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets Password
        /// </summary>

        [DataMember(Name = "password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or Sets Phone
        /// </summary>

        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or Sets Birthday
        /// </summary>

        [DataMember(Name = "birthday")]
        public DateTime? Birthday { get; set; }
    }
}

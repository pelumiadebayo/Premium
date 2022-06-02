using System;
using System.ComponentModel.DataAnnotations;

namespace IntranetApi.CoreObjects.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		[MaxLength(250)]
		public string? FullName { get; set; }
		[MaxLength(250)]
		public string? Role { get; set; }
		[MaxLength(250)]
		public string? Department { get; set; }
		public DateTime? BirthDate { get; set; }
		public string? Picture { get; set; }
	}

    public class UserModel
    {
        public UserModel(string dn, string uid, string ou, string userPassword)
        {
            this.dn = dn;
            this.uid = uid;
            this.ou = ou;
            this.userPassword = userPassword;
        }

        public string DN { get { return dn; } }
        public string UID { get { return uid; } }
        public string OU { get { return ou; } }
        public string UserPassword { get { return userPassword; } }

        private string dn;
        private string uid;
        private string ou;
        private string userPassword;
    }
}


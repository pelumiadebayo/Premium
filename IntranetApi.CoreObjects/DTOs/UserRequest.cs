using System;
using System.ComponentModel.DataAnnotations;

namespace IntranetApi.CoreObjects.DTOs
{
	public class UserRequest
	{
		[MaxLength(250)]
        [Required]
		public string? FullName { get; set; }
		[Required]
		public string? Email { get; set; }
		[MaxLength(250)]
		public string? Role { get; set; }
		[MaxLength(250)]
		public string? Department { get; set; }
		public DateTime? BirthDate { get; set; }
		public string? Picture { get; set; }
	}
}


using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFWebApp.Models
{
	public class AppUser:IdentityUser
	{
		// thêm cột homeadress vào user mặc định trên identity
		[Column(TypeName = "nvarchar")]
		[StringLength(400)]
		public string? HomeAdress { get; set; } 

	}
}

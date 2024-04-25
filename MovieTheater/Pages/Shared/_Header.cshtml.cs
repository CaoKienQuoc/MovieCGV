using BusinessObject.Datalayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;

namespace MovieTheater.Pages.Shared
{
	public class _HeaderModel : PageModel
	{
		public bool IsLoggedIn { get; private set; }

		public void OnGet()
		{
			// Check if session values exist
			IsLoggedIn = !string.IsNullOrEmpty(HttpContext.Session.GetString("AccountId"));
		}
	}
}
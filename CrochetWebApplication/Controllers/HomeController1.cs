using Microsoft.AspNetCore.Mvc;
using CrochetWebApplication.Models;

namespace CrochetWebApplication.Controllers
{
	public class HomeController1 : Controller
	{
		public async Task<IActionResult> IndexAsync()
		{
			string apiUrl = "https://cataas.com/cat/gif";

			var gif = new ModelCats();

			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage response = await client.GetAsync(apiUrl);


				if (response.IsSuccessStatusCode)
				{
						gif.gif = apiUrl;
					
				}
				else
				{
					Console.WriteLine("Fallback. Couldn't find."); //Will return the cat picture error 404 if not found 
				}
			}

			return View(gif);
		}
	}
}

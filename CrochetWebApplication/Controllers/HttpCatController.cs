using Microsoft.AspNetCore.Mvc;
using CrochetWebApplication.Models;

namespace CrochetWebApplication.Controllers
{
    public class HttpCatController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            string publicApiUrl = "https://http.cat/status/404.jpg";

            var CatPics = new CatModel
            {
                pictureTitle = "Cat Code Status: 404!",
                imageURL = publicApiUrl
            };

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(publicApiUrl);

                if (response.IsSuccessStatusCode)
                {
                   CatPics.imageURL = publicApiUrl;
                } 
                else
                {
                    Console.WriteLine("Fallback. Couldn't find."); //Will return the cat picture error 404 if not found in the server 
                }
            }
            return View(CatPics);
        }
    }
}

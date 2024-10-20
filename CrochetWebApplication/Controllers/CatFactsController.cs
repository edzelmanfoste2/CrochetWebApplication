using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using CrochetWebApplication.Models;

namespace CrochetWebApplication.Controllers
{
    public class CatFactsController : Controller
    {
        // GET: CatFactsController
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://catfact.ninja/fact";

            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync(apiUrl);

            var status = JsonConvert.DeserializeObject<Kitty>(response);

            return View(status);
        }

        // GET: CatFactsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CatFactsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatFactsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CatFactsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CatFactsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CatFactsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CatFactsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

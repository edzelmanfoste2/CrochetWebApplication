using CrochetWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CrochetWebApplication.Controllers
{
    public class CrochetController : Controller
    {
        // GET: CrochetController
        public async Task<ActionResult> IndexAsync()
        {
            string apiURL = "https://localhost:7279/CrochetManagement/CrochetProducts";
            List<CrochetProduct> crochetProducts = new List<CrochetProduct>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiURL);

                var result = await response.Content.ReadAsStringAsync();
                crochetProducts = JsonConvert.DeserializeObject<List<CrochetProduct>>(result);
            }
            return View(crochetProducts);
        }

        // GET: CrochetController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CrochetController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CrochetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CrochetProduct crochetProduct)
        {
            string apiUrl = "https://localhost:7279/CrochetManagement/CreateProduct";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(crochetProduct), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(crochetProduct);
        }

        // GET: CrochetController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CrochetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: CrochetController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CrochetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}

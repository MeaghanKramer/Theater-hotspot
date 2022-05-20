using MySql.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Theater_hotspot.Models;
using Theater_hotspot.Database;
using Theater_hotspot.Databases;

namespace Theater_hotspot.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
           
            var products = GetAllProducts();
          
            return View(products);
        }  

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [Route("contact")]
        public IActionResult Contact(Person person)
        {
            if (ModelState.IsValid)
                return Redirect("/succes");

            return View(person);
        }

        [Route("product/{id}")]
        public IActionResult ProductDetails (int id)
        {
            var product = GetProduct(id);
            return View();
        }

        [Route("informatie")]
        public IActionResult Informatie ()
        {
            return View();
        }

        [Route("verwacht")]
        public IActionResult Verwacht()
        {
            return View();
        }

        [Route("voorstellingen")]
        public IActionResult Voorstellingen()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public List<Product> GetAllProducts()
        {
            // alle producten ophalen uit de database
            var rows = DatabaseConnector.GetRows("select * from product");

            // lijst maken om alle producten in te stoppen
            List<Product> products = new List<Product>();

            foreach (var row in rows)
            {
                // Voor elke rij maken we nu een product
                Product p = new Product();
                p.Naam = row["naam"].ToString();
                p.Prijs = row["prijs"].ToString();
                p.Beschikbaarheid = Convert.ToInt32(row["beschikbaarheid"]);
                p.Id = Convert.ToInt32(row["id"]);

                // en dat product voegen we toe aan de lijst met producten
                products.Add(p);
            }

            return products;
        }

        public Product GetProduct(int id)
        {
            // alle producten ophalen uit de database
            var rows = DatabaseConnector.GetRows($"select * from product where id = {id}");

            // lijst maken om alle producten in te stoppen
            List<Product> products = new List<Product>();

            foreach (var row in rows)
            {
                // Voor elke rij maken we nu een product
                Product p = new Product();
                p.Naam = row["naam"].ToString();
                p.Prijs = row["prijs"].ToString();
                p.Beschikbaarheid = Convert.ToInt32(row["beschikbaarheid"]);
                p.Id = Convert.ToInt32(row["id"]);

                // en dat product voegen we toe aan de lijst met producten
                products.Add(p);
            }

            return products[0];
        }
    }
}

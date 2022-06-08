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
           
            var products = GetAllVoorstellingen();
          
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
            var products = GetAllVoorstellingen();

            return View(products);
        }

        [Route("voorstellingen/{id}")]
        public IActionResult VoorstelingDetails(int id)
        {
            var voorstelling = GetVoorstelling(id);

            return View(voorstelling);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public List<Voorstelling> GetAllVoorstellingen()
        {
            // alle producten ophalen uit de database
            var rows = DatabaseConnector.GetRows("select * from voorstelling");

            // lijst maken om alle producten in te stoppen
            List<Voorstelling> products = new List<Voorstelling>();

            foreach (var row in rows)
            {
                // Voor elke rij maken we nu een product
                Voorstelling p = new Voorstelling();
                p.Id= Convert.ToInt32(row["id"]);
                p.Titel = row["Titel"].ToString();
                p.Beschrijving= row["Beschrijving"].ToString();   
                p.Plaatje = row["Plaatje"].ToString() ;
                p.Informatie = row["Informatie"].ToString();
                p.Volgendedatum = row["Volgendedatum"].ToString();
                p.Einddatum = row["Einddatum"].ToString();

                // en dat product voegen we toe aan de lijst met producten
                products.Add(p);
            }

            return products;
        }

        public Voorstelling GetVoorstelling(int id)
        {
            // alle producten ophalen uit de database
            var rows = DatabaseConnector.GetRows($"select * from voorstelling where id = {id}");

            // lijst maken om alle producten in te stoppen
            List<Voorstelling> products = new List<Voorstelling>();

            foreach (var row in rows)
            {
                // Voor elke rij maken we nu een product
                Voorstelling p = new Voorstelling();
                p.Id = Convert.ToInt32(row["id"]);
                p.Titel = row["Titel"].ToString();
                p.Beschrijving = row["Beschrijving"].ToString();
                p.Plaatje = row["Plaatje"].ToString();
                p.Informatie = row["Informatie"].ToString();
                p.Volgendedatum = row["Volgendedatum"].ToString();
                p.Einddatum = row["Einddatum"].ToString();

                // en dat product voegen we toe aan de lijst met producten
                products.Add(p);
            }

            return products[0];
        }
    }
}

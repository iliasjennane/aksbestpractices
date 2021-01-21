using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using observableApp.Models;

namespace observableApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly System.Net.Http.HttpClient _client = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public string GetData()
        {
            //GET CALL
            string apiURL = "localhost:3500/v1.0/invoke/observableapi/method/weatherforecast";
            
            UriBuilder builder = new UriBuilder(apiURL);
            HttpResponseMessage response = _client.GetAsync(builder.Uri).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return data.ToString();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

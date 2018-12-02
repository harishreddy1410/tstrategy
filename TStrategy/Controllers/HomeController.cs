using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TStrategy.Models;

namespace TStrategy.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["EquityWatch"] = EquityStockWatch().Result;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        async Task<string> EquityStockWatch()
        {
            try
            {
                var sec = "foSec";
                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                var stringTask = client.GetStringAsync($"https://www.nseindia.com//live_market/dynaContent/live_watch/stock_watch/" + sec + "StockWatch.json");

                return await stringTask;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}

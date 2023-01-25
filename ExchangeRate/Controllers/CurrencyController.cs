using ExchangeRate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net;

namespace ExchangeRate.Controllers
{
    public class CurrencyController : Controller
    {
        public CurrenciesModel currenciesModel;

        public IActionResult Index(int ? page = 1)
        {
            Currencies();
            currenciesModel.Pager.CurrentPage = (int)page;
            currenciesModel.Currencies = currenciesModel.Currencies.Skip((currenciesModel   .Pager.CurrentPage - 1) * currenciesModel.Pager.PageSize).Take(currenciesModel.Pager.PageSize).ToDictionary(x => x.Key, x => x.Value);
            
            return View(currenciesModel);
        }

        public IActionResult Currencies()
        {
            var url = "https://www.cbr-xml-daily.ru/daily_json.js";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            using var webResponse = request.GetResponse();
            using var webStream = webResponse.GetResponseStream();
            using var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();

            currenciesModel = JsonConvert.DeserializeObject<CurrenciesModel>(data);

            currenciesModel.Pager = new Pager(currenciesModel.Currencies.Count, 10);

            return Ok(currenciesModel);
        }
        
        public IActionResult Currency(string id)
        {
            Currencies();

            Currency currencyId = new Currency();

            foreach (var currency in currenciesModel.Currencies)
            {
                if (currency.Value.ID == id)
                {
                    currencyId = currency.Value;
                }
            }
            return View(currencyId);
        }
    }
}

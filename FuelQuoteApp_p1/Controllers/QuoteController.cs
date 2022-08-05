using FuelQuoteApp_p1.BusinessLayer.BL;
using FuelQuoteApp_p1.EntModels.Models;
using FuelQuoteApp_p1.Models.Quote;
using FuelQuoteApp_p1.Provider;
using FuelQuoteApp_p1.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace FuelQuoteApp_p1.Controllers
{
    public class QuoteController : Controller
    {
        private readonly IFuelQuoteProvider _FuelQuotePro;
        public QuoteController(IFuelQuoteProvider FuelQuotePro)
        {
            _FuelQuotePro = FuelQuotePro;
        }

        [HttpGet]
        [ExcludeFromCodeCoverage]
        public IActionResult GetQuote()
        {
            FQuote quote = new FQuote();
            Client client = new Client();
            client = JsonConvert.DeserializeObject<Client>(HttpContext.Session.GetString("ClientDetails"));
            quote.DeliveryAddress = client.Address1 + " " + client.Address2;
            return View(quote);
        }

        [HttpPost]
        [ExcludeFromCodeCoverage]
        public IActionResult GetQuote(FQuote quote)
        {

            Price pricedetails = new Price();
            pricedetails = GetPrice(quote);
            quote.PricePerGallon = pricedetails.PricePerGallon;
            quote.TotalAmount = pricedetails.TotalAmount;
            HttpContext.Session.SetString("QuoteDetails", JsonConvert.SerializeObject(quote));

            return RedirectToAction("GetFinalQuote");

        }

        [HttpGet]
        [ExcludeFromCodeCoverage]
        public IActionResult QuoteHistory()
        {

            int usrID = _FuelQuotePro.GetUserID(User.Identity.Name);
            IEnumerable<Quote> quotess = _FuelQuotePro.GetQuoteHistory(usrID);

            return View(quotess);
        }

        [ExcludeFromCodeCoverage]
        public Price GetPrice(FQuote quote)
        {
            int usrID = _FuelQuotePro.GetUserID(User.Identity.Name);

            Client client = new Client();
            client = JsonConvert.DeserializeObject<Client>(HttpContext.Session.GetString("ClientDetails"));
            QuoteDetails quoteInfo = new QuoteDetails
            {
                DateRequested = quote.DateRequested,
                GallonsRequested = quote.GallonsRequested,
                State = client.State,
                quoteHistory = _FuelQuotePro.GetQuoteHistoryCount(usrID)
            };


            PriceModule getPrice = new PriceModule();
            Price price = getPrice.GetPrice(quoteInfo);

            return price;
        }

        [HttpGet]
        [ExcludeFromCodeCoverage]
        public IActionResult GetFinalQuote()
        {
            FQuote quote = new FQuote();
            Client client = new Client();
            quote = JsonConvert.DeserializeObject<FQuote>(HttpContext.Session.GetString("QuoteDetails"));
            client = JsonConvert.DeserializeObject<Client>(HttpContext.Session.GetString("ClientDetails"));
            quote.DeliveryAddress = client.Address1 + " " + client.Address2;
            return View(quote);

        }

        [HttpPost]
        [ExcludeFromCodeCoverage]
        public IActionResult GetFinalQuote(FQuote quote)
        {
            quote = JsonConvert.DeserializeObject<FQuote>(HttpContext.Session.GetString("QuoteDetails"));
            Client client = new Client();
            client = JsonConvert.DeserializeObject<Client>(HttpContext.Session.GetString("ClientDetails"));
            quote.DeliveryAddress = client.Address1 + " " + client.Address2;

            Quote dbquote = new Quote
            {
                DateRequested = quote.DateRequested,
                DeliveryAddress = quote.DeliveryAddress,
                GallonsRequested = quote.GallonsRequested,
                PricePerGallon = quote.PricePerGallon,
                TotalAmount = quote.TotalAmount,

            };
            User userinfo = new User();
            dbquote.User_Id = userinfo.Id;
            dbquote.User_Id = _FuelQuotePro.GetUserID(User.Identity.Name);
            dbquote = _FuelQuotePro.AddQuote(dbquote);
            return View("SavedQuote", dbquote);
        }


       

        public bool QuoteDataValidation(Quote data)
        {
            bool flag = false;
            if (data.GallonsRequested != 0)  /*Default value is 0*/
            {
                if  (DateTime.Compare(data.DateRequested,DateTime.Now)>0)
                    {
                            flag = true;
                     }       
                
            }
            else
            {
                flag = false;
            }

            return flag;
        }
    }
}

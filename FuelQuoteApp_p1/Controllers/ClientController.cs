using FuelQuoteApp_p1.EntModels.Models;
using FuelQuoteApp_p1.Models.Client_Profile;
using FuelQuoteApp_p1.Provider;
using FuelQuoteApp_p1.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;

namespace FuelQuoteApp_p1.Controllers
{
    public class ClientController : Controller
    {
        private readonly IFuelQuoteProvider _FuelQuotePro;

        public ClientController(IFuelQuoteProvider FuelQuotePro)
        {
            _FuelQuotePro = FuelQuotePro;

        }
        [HttpGet]
        [ExcludeFromCodeCoverage]
        public IActionResult ClientDashBoard()
        {
            int usrID = _FuelQuotePro.GetUserID(User.Identity.Name);
            Client client = _FuelQuotePro.GetClient(usrID);
            HttpContext.Session.SetString("ClientDetails", JsonConvert.SerializeObject(client));

            return View();
        }
        [HttpGet]
        [ExcludeFromCodeCoverage]
        public IActionResult ClientProfile()
        {
            return View();
        }


        [HttpPost]
        [ExcludeFromCodeCoverage]
        public ActionResult ClientProfile(Profile clientProfile)
        {
            if (ModelState.IsValid)
            {
                Client client = new Client
                {
                    FullName = clientProfile.FullName,
                    Address1 = clientProfile.Address1,
                    Address2 = clientProfile.Address2,
                    City = clientProfile.City,
                    State = clientProfile.State.ToString(),
                    ZipCode = clientProfile.ZipCode,
                    Email = User.Identity.Name

                };

                //User usrDetails = new User();
                // client.User_ID = usrDetails;
                client.User_Id = _FuelQuotePro.GetUserID(User.Identity.Name);
                Client AddedClient = _FuelQuotePro.AddClient(client);

                return RedirectToAction("ClientDashBoard", "Client");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        [ExcludeFromCodeCoverage]
        public IActionResult DisplayProfile()
        {
            Client client = new Client();
            client = JsonConvert.DeserializeObject<Client>(HttpContext.Session.GetString("ClientDetails"));


            Profile cl = new Profile()
            {
                FullName = client.FullName,
                Address1 = client.Address1,
                Address2 = client.Address2,
                City = client.City,
                State = (States)Enum.Parse(typeof(States), client.State),
                ZipCode = client.ZipCode
            };

            return View(cl);
        }

        public bool ClientProfileDataValidation(Profile data)
        {
            bool flag = false;
            if ((data.FullName.Length <= 50) && (data.FullName != String.Empty))
            {
                if (((data.Address1.Length <= 100) && (data.Address1 != String.Empty)) && (data.Address2.Length <= 100))
                {
                    if ((data.City.Length <= 100) && (data.City != String.Empty))
                    {
                        if (data.ZipCode.Length <= 9 && data.ZipCode.Length >= 5)
                        {
                            flag = true;
                        }
                    }
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
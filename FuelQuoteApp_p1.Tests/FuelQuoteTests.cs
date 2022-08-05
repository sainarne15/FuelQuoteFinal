using FuelQuoteApp_p1.Controllers;
using FuelQuoteApp_p1.EntModels.Models;
using FuelQuoteApp_p1.Models.Client_Profile;
using FuelQuoteApp_p1.Provider;
using FuelQuoteApp_p1.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelQuoteApp_p1.Tests
{
    [TestFixture]
    public class FuelQuoteTests
    {
       

        public Client clientProfile;
        public Quote quote;
        public User user;
        public IEnumerable<Quote> quotes;
        [SetUp]
        public void setup()
        {
            clientProfile = new Client()
            {
                Address1 = "Kirby Dr",
                Address2 = "Apt 1206",
                City = "Houston",
                FullName = "Sai Narne",
                State = "TX",
                ZipCode = "77054"
            };
            quote = new Quote()
            {
                DateRequested = DateTime.Now,
                DeliveryAddress = "Cambridge St # 1206",
                GallonsRequested = 50,
                PricePerGallon = 5,
                TotalAmount = 650,
                User_Id = 1,
                Id = 5
            };
            user = new User()
            {
                Id = 1,
                Email="sainarne15@gmail.com",
                UserName="sainarne15@gmail.com"
            };
            quotes = new List<Quote>()
            {
                quote,
                new Quote{DateRequested = DateTime.Now, DeliveryAddress = "Cambridge St # 1911", GallonsRequested = 25, PricePerGallon = 6, TotalAmount = 700, User_Id = 1, Id = 2},
                new Quote{DateRequested = DateTime.Now, DeliveryAddress = "Cambridge St # 1707", GallonsRequested = 15, PricePerGallon = 4, TotalAmount = 600, User_Id = 1, Id = 3},

            };
            Mock<IFuelQuoteRepository> mock = new Mock<IFuelQuoteRepository>();
            mock.Setup(p => p.GetUserID(It.IsAny<string>())).Returns((int)1);
            mock.Setup(p => p.AddClient(It.IsAny<Client>())).Returns(clientProfile);
            mock.Setup(p => p.GetClient(It.IsAny<int>())).Returns(clientProfile);
            mock.Setup(p => p.AddQuote(It.IsAny<Quote>())).Returns(quote);
            mock.Setup(p => p.AddUser(It.IsAny<User>())).Returns(user);
            mock.Setup(p => p.GetClientInfo(It.IsAny<int>())).Returns(true);
            mock.Setup(p => p.GetQuoteHistoryCount(It.IsAny<int>())).Returns((int)1);
            mock.Setup(p => p.GetQuoteHistory(It.IsAny<int>())).Returns(quotes);
            FuelQuoteProvider _pro = new FuelQuoteProvider(mock.Object);
        }




        /*---------------------------------------------------------------RepositoryUnitTests-------------------------------------------------------------------------------------------------------------------*/

        [TestCase]
        public void ClientAddTest()
        {
            Mock<IFuelQuoteRepository> mock = new Mock<IFuelQuoteRepository>();
            mock.Setup(p => p.AddClient(It.IsAny<Client>())).Returns(clientProfile);
            FuelQuoteProvider _pro = new FuelQuoteProvider(mock.Object);
            var result = _pro.AddClient(clientProfile);
            Assert.IsInstanceOf<Client>(result);
        }

        [TestCase]
        public void QuoteAddTest()
        {
            Mock<IFuelQuoteRepository> mock = new Mock<IFuelQuoteRepository>();
            mock.Setup(p => p.AddQuote(It.IsAny<Quote>())).Returns(quote);
            FuelQuoteProvider _pro = new FuelQuoteProvider(mock.Object);
            var result = _pro.AddQuote(quote);
            Assert.IsInstanceOf<Quote>(result);
        }

        [TestCase]
        public void ClientGetTest()
        {

            Mock<IFuelQuoteRepository> mock = new Mock<IFuelQuoteRepository>();
            mock.Setup(p => p.GetClient(It.IsAny<int>())).Returns(clientProfile);
            FuelQuoteProvider _pro = new FuelQuoteProvider(mock.Object);
            var result = _pro.GetClient(1);
            Assert.IsInstanceOf<Client>(result);
        }

        [TestCase]
        public void UserAddTest()
        {
            Mock<IFuelQuoteRepository> mock = new Mock<IFuelQuoteRepository>();
            mock.Setup(p => p.AddUser(It.IsAny<User>())).Returns(user);
            FuelQuoteProvider _pro = new FuelQuoteProvider(mock.Object);
            var result = _pro.AddUser(user);
            Assert.IsInstanceOf<User>(result);
        }

        [TestCase]
        public void ClientGetInfoTest()
        {
            Mock<IFuelQuoteRepository> mock = new Mock<IFuelQuoteRepository>();
            mock.Setup(p => p.GetClientInfo(It.IsAny<int>())).Returns(true);
            FuelQuoteProvider _pro = new FuelQuoteProvider(mock.Object);
            var result = _pro.GetClientInfo(1);
            Assert.IsInstanceOf<bool>(result);
        }

        [TestCase]
        public void QuoteGetHistoryTest()
        {
            Mock<IFuelQuoteRepository> mock = new Mock<IFuelQuoteRepository>();
            mock.Setup(p => p.GetQuoteHistory(It.IsAny<int>())).Returns(quotes);
            FuelQuoteProvider _pro = new FuelQuoteProvider(mock.Object);
            var result = _pro.GetQuoteHistory(1);
            Assert.IsInstanceOf<IEnumerable<Quote>>(result);
        }

        [TestCase]
        public void QuoteGetHistoryCountTest()
        {
            Mock<IFuelQuoteRepository> mock = new Mock<IFuelQuoteRepository>();
            mock.Setup(p => p.GetQuoteHistoryCount(It.IsAny<int>())).Returns((int)1);
            FuelQuoteProvider _pro = new FuelQuoteProvider(mock.Object);
            var result = _pro.GetQuoteHistoryCount(1);
            Assert.IsInstanceOf<int>(result);
        }

        [TestCase]
        public void UserIdGetTest()
        {
            Mock<IFuelQuoteRepository> mock = new Mock<IFuelQuoteRepository>();
            mock.Setup(p => p.GetUserID(It.IsAny<string>())).Returns((int)1);
            FuelQuoteProvider _pro = new FuelQuoteProvider(mock.Object);
            var result = _pro.GetUserID("sainarne15@gmail.com");
            Assert.IsInstanceOf<int>(result);
        }


    }
}

using FuelQuoteApp_p1.EntModels.Models;
using FuelQuoteApp_p1.Repository;
using System.Collections.Generic;

namespace FuelQuoteApp_p1.Provider
{
    public class FuelQuoteProvider : IFuelQuoteProvider
    {
        private IFuelQuoteRepository _repo;

        public FuelQuoteProvider(IFuelQuoteRepository repo)
        {
            _repo = repo;
        }
        public Client AddClient(Client client)
        {
           return _repo.AddClient(client);
        }

        public Quote AddQuote(Quote quote)
        {
           return _repo.AddQuote(quote);
        }

        public User AddUser(User user)
        {
            return _repo.AddUser(user);
        }

        public Client GetClient(int UserID)
        {
            return _repo.GetClient(UserID);
        }

        public bool GetClientInfo(int usrID)
        {
            return _repo.GetClientInfo(usrID);
        }

        public IEnumerable<Quote> GetQuoteHistory(int UserID)
        {
            return _repo.GetQuoteHistory(UserID);
        }

        public int GetQuoteHistoryCount(int UserID)
        {
            return _repo.GetQuoteHistoryCount(UserID);
        }

        public int GetUserID(string email)
        {
            return _repo.GetUserID(email);
        }
    }
}

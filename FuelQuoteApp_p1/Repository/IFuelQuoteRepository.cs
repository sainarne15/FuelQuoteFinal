using FuelQuoteApp_p1.EntModels.Models;
using System.Collections.Generic;

namespace FuelQuoteApp_p1.Repository
{
    public interface IFuelQuoteRepository
    {
        Client AddClient(Client client);

        User AddUser(User user);

        int GetUserID(string email);

        bool GetClientInfo(int usrID);

        Client GetClient(int UserID);

        Quote AddQuote(Quote quote);

        int GetQuoteHistoryCount(int UserID);

        IEnumerable<Quote> GetQuoteHistory(int UserID);
    }
}
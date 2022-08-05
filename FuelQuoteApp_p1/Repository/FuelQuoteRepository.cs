using FuelQuoteApp_p1.EntModels.Models;
using FuelQuoteApp_p1.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FuelQuoteApp_p1.Repository
{
    public class FuelQuoteRepository : IFuelQuoteRepository
    {
        private readonly FuelQuoteDBContext context;

        public FuelQuoteRepository(FuelQuoteDBContext context)
        {
            this.context = context;
        }

        public Client AddClient(Client client)
        {
            Client c = context.Client.FirstOrDefault(x => x.User_Id==client.User_Id);
            if (c != null)
            {
                context.Client.Remove(c);
                /*  c.Address1 = client.Address1;
                  c.Address2 = client.Address2;
                  c.FullName = client.FullName;
                  c.City = client.City;
                  c.Email = client.Email;
                  c.ZipCode = client.ZipCode;
                  c.State = client.State;*/

                context.Client.Add(client);
                context.SaveChanges();
                return client;
            }
            else
            {
                try
                {
                    context.Client.Add(client);
                    context.SaveChanges();
                    return client;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public Quote AddQuote(Quote quote)
        {
            context.FuelQuote.Add(quote);
            context.SaveChanges();
            return quote;
        }

        public User AddUser(User user)
        {
            context.UsersInfo.Add(user);
            context.SaveChanges();
            return user;
        }

        public Client GetClient(int UserID)
        {
            Client c = context.Client.FirstOrDefault(x => x.User_Id == UserID);
            return c;
        }

        public bool GetClientInfo(int usrID)
        {
            Client c = context.Client.FirstOrDefault(x => x.User_Id == usrID);
            if (c == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public IEnumerable<Quote> GetQuoteHistory(int UserID)
        {
            IEnumerable<Quote> quotes = context.FuelQuote.Where(x => x.User_Id == UserID);
            return quotes;
        }

        public int GetQuoteHistoryCount(int UserID)
        {
            IEnumerable<Quote> quotes = context.FuelQuote.Where(x => x.User_Id == UserID);
            int count = quotes.Count();
            return count;
        }

        public int GetUserID(string email)
        {
            User a = context.UsersInfo.FirstOrDefault(c => c.Email == email);
            return a.Id;
        }
    }
}

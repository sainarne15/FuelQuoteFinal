using System;
namespace FuelQuoteApp_p1.BusinessLayer.BL
{
    public class QuoteDetails
    {
        public int GallonsRequested { get; set; }
        public DateTime DateRequested { get; set; }
        public string State { get; set; }
        public int quoteHistory { get; set; }
    }
}

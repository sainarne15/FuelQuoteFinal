namespace FuelQuoteApp_p1.BusinessLayer.BL
{
    public class PriceModule
    {
        private const float PricePerGallon = 1.5f;
        private const float CompanyProfitFactor = 0.1f;

        public Price GetPrice(QuoteDetails quoteinfo)
        {
            float locationFactor = 0.0f;
            float rateHistoryFactor = 0.0f;
            float gallonsRequestedFactor = 0.0f;

            Price finalPrices = new Price();

            //For TEXAS State the location factor is 2% else for any other state location factor is 4%
            if (quoteinfo.State == "TX")
            {
                locationFactor = 0.02f;
            }
            else
            {
                locationFactor = 0.04f;
            }

            //Rate History Factor = 1% if client requested fuel before, 0% if no history
            if (quoteinfo.quoteHistory > 0)
            {
                rateHistoryFactor = 0.01f;
            }

            //Gallons Requested Factor = 2% if more than 1000 Gallons, 3% if less
            if (quoteinfo.GallonsRequested > 1000)
            {
                gallonsRequestedFactor = 0.02f;
            }
            else
            {
                gallonsRequestedFactor = 0.03f;
            }

            
           
             
        

       
            finalPrices.PricePerGallon = PricePerGallon + ((locationFactor - rateHistoryFactor + gallonsRequestedFactor + CompanyProfitFactor) * PricePerGallon);
            finalPrices.TotalAmount = quoteinfo.GallonsRequested * finalPrices.PricePerGallon;

            return finalPrices;
        }


    }
}

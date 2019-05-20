using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stripe;

namespace StripeDotNetCoreProject.Pages
{
    public class PaymentModel : PageModel
    {

        private int amount = 100;

        public void OnGet()
        {

        }

        [HttpPost]
        public void Processing(string stripeToken, string stripeEmail)
        {

            Dictionary<string, string> Metadata = new Dictionary<string, string>();
            Metadata.Add("Product", "RubberDuck");
            Metadata.Add("Quantity", "10");
            var options = new ChargeCreateOptions
            {
                Amount = amount,
                Currency = "USD",
                Description = "Buying 10 rubber ducks",
                SourceId = stripeToken,
                ReceiptEmail = stripeEmail,
                Metadata = Metadata
            };
            
            var service = new ChargeService();
            Charge charge = service.Create(options);
            
        }
    }
}
using System.Collections.Generic;

namespace Arrecadar.ExternalModels
{
    public class PaymentRequestData
    {
        public int Amount { get; set; }
        public List<string> Methods { get; set; }
        public List<PaymentProductRequest> Products { get; set; }
        public string Frequency { get; set; }
        public PaymentCustomerRequest Customer { get; set; }
    }
}

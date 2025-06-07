

namespace Arrecadar.ExternalModels
{
    public class PaymentData
    {

        public string Id { get; set; }
        public string Url { get; set; }
        public int Amount { get; set; }
        public string Status { get; set; }
        public bool DevMode { get; set; }
        public List<string> Methods { get; set; }
        public List<Product> Products { get; set; }
        public string Frequency { get; set; }
        public string NextBilling { get; set; }
        public Customer Customer { get; set; }

    }
}

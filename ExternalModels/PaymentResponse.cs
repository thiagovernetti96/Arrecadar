using MercadoPago.Resource.Payment;

namespace Arrecadar.ExternalModels
{
    public class PaymentResponse
    {
        public PaymentData Data { get; set; }
        public string Error { get; set; }

    }
}

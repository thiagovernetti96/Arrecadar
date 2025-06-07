using Arrecadar.ExternalModels;
using Refit;

namespace Arrecadar.Integração.Interfaces
{
    public interface IAbacatePayApi
    {
        [Post("/payments")]
        Task<PaymentResponse> CreatePaymentAsync([Body] PaymentRequest request);
    }
}

using System.Threading.Tasks;
using Abp.Application.Services;
using SprintTek.MultiTenancy.Payments.Dto;
using SprintTek.MultiTenancy.Payments.Stripe.Dto;

namespace SprintTek.MultiTenancy.Payments.Stripe
{
    public interface IStripePaymentAppService : IApplicationService
    {
        Task ConfirmPayment(StripeConfirmPaymentInput input);

        StripeConfigurationDto GetConfiguration();

        Task<SubscriptionPaymentDto> GetPaymentAsync(StripeGetPaymentInput input);

        Task<string> CreatePaymentSession(StripeCreatePaymentSessionInput input);
    }
}
using System.Threading.Tasks;
using Abp.Application.Services;
using SprintTek.MultiTenancy.Payments.PayPal.Dto;

namespace SprintTek.MultiTenancy.Payments.PayPal
{
    public interface IPayPalPaymentAppService : IApplicationService
    {
        Task ConfirmPayment(long paymentId, string paypalOrderId);

        PayPalConfigurationDto GetConfiguration();
    }
}

using System.Threading.Tasks;
using Abp.Webhooks;

namespace SprintTek.WebHooks
{
    public interface IWebhookEventAppService
    {
        Task<WebhookEvent> Get(string id);
    }
}

using System.Threading.Tasks;
using SprintTek.Authorization.Users;

namespace SprintTek.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}

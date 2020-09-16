using System.Threading.Tasks;

namespace SprintTek.Net.Sms
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}
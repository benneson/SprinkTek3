using System.Threading.Tasks;
using SprintTek.Sessions.Dto;

namespace SprintTek.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}

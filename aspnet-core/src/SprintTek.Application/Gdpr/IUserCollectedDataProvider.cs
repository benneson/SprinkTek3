using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using SprintTek.Dto;

namespace SprintTek.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}

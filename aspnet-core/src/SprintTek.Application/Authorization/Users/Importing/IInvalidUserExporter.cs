using System.Collections.Generic;
using SprintTek.Authorization.Users.Importing.Dto;
using SprintTek.Dto;

namespace SprintTek.Authorization.Users.Importing
{
    public interface IInvalidUserExporter
    {
        FileDto ExportToFile(List<ImportUserDto> userListDtos);
    }
}

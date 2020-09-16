using System.Collections.Generic;
using SprintTek.Authorization.Users.Dto;
using SprintTek.Dto;

namespace SprintTek.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}
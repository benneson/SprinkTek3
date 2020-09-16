using System.Collections.Generic;
using SprintTek.Authorization.Users.Importing.Dto;
using Abp.Dependency;

namespace SprintTek.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader: ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}

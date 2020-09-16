using System.Collections.Generic;
using SprintTek.Auditing.Dto;
using SprintTek.Dto;

namespace SprintTek.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}

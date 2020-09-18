using System.Collections.Generic;
using SprintTek.Docs.Dtos;
using SprintTek.Dto;

namespace SprintTek.Docs.Exporting
{
    public interface IDocsExcelExporter
    {
        FileDto ExportToFile(List<GetDocForViewDto> docs);
    }
}
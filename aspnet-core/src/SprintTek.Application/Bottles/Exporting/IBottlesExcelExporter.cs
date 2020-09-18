using System.Collections.Generic;
using SprintTek.Bottles.Dtos;
using SprintTek.Dto;

namespace SprintTek.Bottles.Exporting
{
    public interface IBottlesExcelExporter
    {
        FileDto ExportToFile(List<GetBottleForViewDto> bottles);
    }
}
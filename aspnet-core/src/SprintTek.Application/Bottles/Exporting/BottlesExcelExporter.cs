using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using SprintTek.DataExporting.Excel.NPOI;
using SprintTek.Bottles.Dtos;
using SprintTek.Dto;
using SprintTek.Storage;

namespace SprintTek.Bottles.Exporting
{
    public class BottlesExcelExporter : NpoiExcelExporterBase, IBottlesExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public BottlesExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
			ITempFileCacheManager tempFileCacheManager) :  
	base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetBottleForViewDto> bottles)
        {
            return CreateExcelPackage(
                "Bottles.xlsx",
                excelPackage =>
                {
                    
                    var sheet = excelPackage.CreateSheet(L("Bottles"));

                    AddHeader(
                        sheet,
                        L("Name"),
                        L("Active")
                        );

                    AddObjects(
                        sheet, 2, bottles,
                        _ => _.Bottle.Name,
                        _ => _.Bottle.Active
                        );

					
					
                });
        }
    }
}

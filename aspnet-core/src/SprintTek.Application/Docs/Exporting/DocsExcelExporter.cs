using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using SprintTek.DataExporting.Excel.NPOI;
using SprintTek.Docs.Dtos;
using SprintTek.Dto;
using SprintTek.Storage;

namespace SprintTek.Docs.Exporting
{
    public class DocsExcelExporter : NpoiExcelExporterBase, IDocsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public DocsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
			ITempFileCacheManager tempFileCacheManager) :  
	base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetDocForViewDto> docs)
        {
            return CreateExcelPackage(
                "Docs.xlsx",
                excelPackage =>
                {
                    
                    var sheet = excelPackage.CreateSheet(L("Docs"));

                    AddHeader(
                        sheet,
                        L("name"),
                        L("Active")
                        );

                    AddObjects(
                        sheet, 2, docs,
                        _ => _.Doc.name,
                        _ => _.Doc.Active
                        );

					
					
                });
        }
    }
}

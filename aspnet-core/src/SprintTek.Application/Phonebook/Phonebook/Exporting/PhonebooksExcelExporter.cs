using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using SprintTek.DataExporting.Excel.NPOI;
using SprintTek.Phonebook.Phonebook.Dtos;
using SprintTek.Dto;
using SprintTek.Storage;

namespace SprintTek.Phonebook.Phonebook.Exporting
{
    public class PhonebooksExcelExporter : NpoiExcelExporterBase, IPhonebooksExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public PhonebooksExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
			ITempFileCacheManager tempFileCacheManager) :  
	base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetPhonebookForViewDto> phonebooks)
        {
            return CreateExcelPackage(
                "Phonebooks.xlsx",
                excelPackage =>
                {
                    
                    var sheet = excelPackage.CreateSheet(L("Phonebooks"));

                    AddHeader(
                        sheet,
                        L("Name"),
                        L("Surname"),
                        L("Email"),
                        (L("Person")) + L("Name")
                        );

                    AddObjects(
                        sheet, 2, phonebooks,
                        _ => _.Phonebook.Name,
                        _ => _.Phonebook.Surname,
                        _ => _.Phonebook.Email,
                        _ => _.PersonName
                        );

					
					
                });
        }
    }
}

using System.Collections.Generic;
using SprintTek.Phonebook.Phonebook.Dtos;
using SprintTek.Dto;

namespace SprintTek.Phonebook.Phonebook.Exporting
{
    public interface IPhonebooksExcelExporter
    {
        FileDto ExportToFile(List<GetPhonebookForViewDto> phonebooks);
    }
}
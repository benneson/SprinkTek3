using System.Collections.Generic;
using Abp;
using SprintTek.Chat.Dto;
using SprintTek.Dto;

namespace SprintTek.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(UserIdentifier user, List<ChatMessageExportDto> messages);
    }
}

using KandaIdea_Task.Application.DTOs;
using KandaIdea_Task.Application.Shared;

namespace KandaIdea_Task.Domain.Interfaces
{
    public interface IExcelExportService
    {
        byte[] ExportUsersToExcel (List<UserDto> users , ExcelExportOptions excelExportOptions);
    }
}

using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using KandaIdea_Task.Application.DTOs;
using KandaIdea_Task.Application.Shared;
using KandaIdea_Task.Domain.Interfaces;
using Microsoft.Extensions.Options;

namespace KandaIdea_Task.Application.Services
{
    public class ExcelExportService : IExcelExportService
    {
        public byte[] ExportUsersToExcel(List<UserDto> users, ExcelExportOptions excelExportOptions)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Users");
            int col = 1;

            if (excelExportOptions.IncludeFirstName) worksheet.Cell(1, col++).Value = "First Name";
            if (excelExportOptions.IncludeLastName) worksheet.Cell(1, col++).Value = "Last Name";
            if (excelExportOptions.IncludePhoneNumber) worksheet.Cell(1, col++).Value = "Phone Number";
            if (excelExportOptions.IncludeCityName) worksheet.Cell(1, col++).Value = "City";
            for (int i = 0; i < users.Count; i++)
            {
                var user = users[i];
                int c = 1;

                if (excelExportOptions.IncludeFirstName) worksheet.Cell(i + 2, c++).Value = user.FirstName;
                if (excelExportOptions.IncludeLastName) worksheet.Cell(i + 2, c++).Value = user.LastName;
                if (excelExportOptions.IncludePhoneNumber) worksheet.Cell(i + 2, c++).Value = user.PhoneNumber;
                if (excelExportOptions.IncludeCityName) worksheet.Cell(i + 2, c++).Value = user.CityName;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
    }
}

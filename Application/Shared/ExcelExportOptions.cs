namespace KandaIdea_Task.Application.Shared
{
    public class ExcelExportOptions
    {
        public bool IncludeFirstName { get; set; } = true;
        public bool IncludeLastName { get; set; } = true;
        public bool IncludePhoneNumber { get; set; } = true;
        public bool IncludeCityName { get; set; } = true;
    }
}

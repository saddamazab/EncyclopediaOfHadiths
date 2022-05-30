namespace EncyclopediaOfHadiths.Areas.Admin.Models
{
    public class AdminErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
namespace TelegramLinkBot.Models
{
    public class MailingModel
    {
        public string Message { get; set; }
        public bool SendToChannel { get; set; }
        public bool SendToGroups { get; set; }
    }
}

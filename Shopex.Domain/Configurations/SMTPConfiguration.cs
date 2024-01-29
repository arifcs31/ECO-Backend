
namespace Shopex.Domain.Configurations
{
    public class SMTPConfiguration
    {
        public string FromEmail { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
    }
}

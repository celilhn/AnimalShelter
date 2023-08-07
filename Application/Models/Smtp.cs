
namespace Application.Models
{
    public class Smtp
    {
        public int Port { get; set; }
        public bool Ssl { get; set; }
        public string Client { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

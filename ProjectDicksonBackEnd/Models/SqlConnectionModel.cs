using System;
namespace ProjectDicksonBackEnd.Repository
{
    public class SqlConnectionModel
    {
        public string BaseConnectionString { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Hostname { get; set; }
        public string Database { get; set; }
        public string Port { get; set; }
    }
}

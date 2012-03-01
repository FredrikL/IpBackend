using System;

namespace IpBackend.Models
{
    public class IpEntry
    {
        public string Name { get; set; }
        public string Ip { get; set; }
        public DateTime Added { get; set; }
    }
}
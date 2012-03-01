using System.Collections.Generic;
using IpBackend.Models;

namespace IpBackend
{
    public interface IIpEntries
    {
        IEnumerable<IpEntry> All();
        void Add(string name, string ip);
    }
}
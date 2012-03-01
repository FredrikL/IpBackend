using System.Collections.Generic;
using Nancy.Security;

namespace IpBackend
{
    public class AuthIdentity : IUserIdentity
    {
        public string UserName {get; set; }

        public IEnumerable<string> Claims { get; set; }
    }
}
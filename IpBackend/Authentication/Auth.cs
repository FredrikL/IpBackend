using System.Configuration;
using Nancy.Authentication.Basic;
using Nancy.Security;

namespace IpBackend
{
    public class Auth : IUserValidator
    {
        public IUserIdentity Validate(string username, string password)
        {
            if(ConfigurationManager.AppSettings["username"] == username && ConfigurationManager.AppSettings["password"] == password)
            {
                return new AuthIdentity() {UserName = username};
            }
            return null;
        }
    }
}
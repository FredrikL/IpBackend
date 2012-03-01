using System;
using System.Linq;
using IpBackend.Models;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Security;

namespace IpBackend
{
    public class MainModule : NancyModule
    {
        private readonly IIpEntries ipEntries;

        public MainModule(IIpEntries ipEntries): base("/")
        {
            this.ipEntries = ipEntries;
            this.RequiresAuthentication();

            Get["/"] = _ =>
                           {                               
                               return View["index", this.ipEntries.All()];
                           };

            Post["/"] = _ =>
                            {
                                var entry = this.Bind<IpEntry>();

                                if (string.IsNullOrWhiteSpace(entry.Ip))
                                    entry.Ip = this.Request.Headers["X-Forwarded-For"].FirstOrDefault(); // works with appharbor, use someting else for other hosts!
                                this.ipEntries.Add(entry.Name, entry.Ip);

                                return View["index", this.ipEntries.All()];
                            };
        }
    }
}
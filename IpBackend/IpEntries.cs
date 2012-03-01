using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using IpBackend.Models;

namespace IpBackend
{
    public class IpEntries : IIpEntries
    {
        private string ConnectionString
        {
            get { return ConfigurationManager.AppSettings["SQLSERVER_CONNECTION_STRING"]; }
        }

        public IEnumerable<IpEntry> All()
        {
            using(var connection = new SqlConnection(ConnectionString))
            {
                using(var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "select ip, name, updated from entries order by name";
                    connection.Open();
                    using(var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            yield return new IpEntry()
                                             {
                                                 Ip = reader.GetString(0),
                                                 Name = reader.GetString(1),
                                                 Added = reader.GetDateTime(2)
                                             };
                        }
                    }
                }
            }
        }

        public void Add(string name, string ip)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    
                    if (this.Exists(name, cmd))
                    {
                        cmd.CommandText = "update entries set ip = @IP, updated = GetDate() where name = @NAME";
                    }
                    else
                    {
                        cmd.CommandText = "insert into entries(ip,name,updated) values(@IP, @NAME, GetDate())";                        
                    }
                    cmd.Parameters.AddWithValue("IP", ip);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private bool Exists(string name, SqlCommand cmd)
        {            
            cmd.CommandText = "select count(name) from entries where name = @NAME";
            cmd.Parameters.AddWithValue("NAME", name);
            var count = (int)cmd.ExecuteScalar();
            return count > 0;            
        }
    }
}
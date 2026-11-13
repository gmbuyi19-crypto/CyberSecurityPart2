using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityPart2.DATA
{
    internal class DbConfig
    {
        public static string ConnectionString =
            @"Server=.\SQLEXPRESS;Database=cyberbot_db;Trusted_Connection=True;TrustServerCertificate=True;";
    }
}

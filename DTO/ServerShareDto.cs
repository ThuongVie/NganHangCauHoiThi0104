using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ServerShareDto
    {
        public const string serverName = @"MSI";
        public const string user = "sa";
        public const string pass = "123";
        public const string dataBase = "NganHangCauHoi_0104";

        public static string connect = $@"Data Source={ServerShareDto.serverName};Initial Catalog = {ServerShareDto.dataBase}; Integrated Security = True";
    }
}

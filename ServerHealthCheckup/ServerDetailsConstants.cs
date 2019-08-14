using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class ServerDetailsConstants
    {
        public const string IpField = "IP";

        public const string NameField = "Name";

        public const string RegionField = "Region";

        public const string StatusField = "Status";

        public const string ServerTable = "ServerDetails";

        public const string ConstrName = "ServerManagement";

        public const string SelectAllQuery = "SELECT * FROM ServerDetails";

        public const string GetServerIpDetailsQuery = "SELECT * FROM ServerDetails where IP=@Ip";

        public const string GetServerNameDetailsQuery = "SELECT * FROM ServerDetails where Name=@Name";
    }
}
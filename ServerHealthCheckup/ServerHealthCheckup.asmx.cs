using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;


namespace WebApplication1
{
    /// <summary>
    /// Summary description for ServerHealthCheckup
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ServerHealthCheckup : System.Web.Services.WebService
    {
        List<ServerDetails> serverDetails = new List<ServerDetails>();

        [WebMethod]
        public IEnumerable<ServerDetails> GetAll()
        {
            serverDetails.Clear();
            string constr = ConfigurationManager.ConnectionStrings[ServerDetailsConstants.ConstrName].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(ServerDetailsConstants.SelectAllQuery))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = ServerDetailsConstants.ServerTable;
                            sda.Fill(dt);
                           foreach(DataRow dr in dt.Rows)
                            {
                                serverDetails.Add(new ServerDetails
                                {
                                    IP = dr[ServerDetailsConstants.IpField].ToString(),
                                    Name = dr[ServerDetailsConstants.NameField].ToString(),
                                    Region = dr[ServerDetailsConstants.RegionField].ToString(),
                                    Status = Convert.ToUInt16(dr[ServerDetailsConstants.StatusField])
                                });
                            }
                            return serverDetails;
                        }
                    }
                }
            }
        }

        [WebMethod]
        public IEnumerable<ServerDetails> GetServerIpDetails(string ip)
        {
            serverDetails.Clear();
            string constr = ConfigurationManager.ConnectionStrings[ServerDetailsConstants.ConstrName].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(ServerDetailsConstants.GetServerIpDetailsQuery))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        SqlParameter param = new SqlParameter
                        {
                            ParameterName = "@Ip",
                            Value = ip
                        };
                        cmd.Parameters.Add(param);
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = ServerDetailsConstants.ServerTable;
                            
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                serverDetails.Add(new ServerDetails
                                {
                                    IP = dr[ServerDetailsConstants.IpField].ToString(),
                                    Name = dr[ServerDetailsConstants.NameField].ToString(),
                                    Region = dr[ServerDetailsConstants.RegionField].ToString(),
                                    Status = Convert.ToUInt16(dr[ServerDetailsConstants.StatusField])
                                });
                            }
                            return serverDetails;
                        }
                    }
                }
            }
        }

        [WebMethod]
        public IEnumerable<ServerDetails> GetServerNameDetails(string name)
        {
            serverDetails.Clear();
            string constr = ConfigurationManager.ConnectionStrings[ServerDetailsConstants.ConstrName].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(ServerDetailsConstants.GetServerNameDetailsQuery))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        SqlParameter param = new SqlParameter
                        {
                            ParameterName = "@Name",
                            Value = name
                        };
                        cmd.Parameters.Add(param);
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = ServerDetailsConstants.ServerTable;

                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                serverDetails.Add(new ServerDetails
                                {
                                    IP = dr[ServerDetailsConstants.IpField].ToString(),
                                    Name = dr[ServerDetailsConstants.NameField].ToString(),
                                    Region = dr[ServerDetailsConstants.RegionField].ToString(),
                                    Status = Convert.ToUInt16(dr[ServerDetailsConstants.StatusField])
                                });
                            }
                            return serverDetails;
                        }
                    }
                }
            }
        }
    }
}

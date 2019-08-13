using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


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
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public IEnumerable<ServerDetails> GetAll()
        {
            serverDetails.Clear();
            string constr = ConfigurationManager.ConnectionStrings["ServerManagement"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM ServerDetails"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "ServerDetails";
                            sda.Fill(dt);
                           foreach(DataRow dr in dt.Rows)
                            {
                                serverDetails.Add(new ServerDetails
                                {
                                    IP = dr["IP"].ToString(),
                                    Name = dr["Name"].ToString(),
                                    Region = dr["Region"].ToString(),
                                    Status = Convert.ToUInt16(dr["Status"])
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
            string constr = ConfigurationManager.ConnectionStrings["ServerManagement"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM ServerDetails where IP=@Ip"))
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
                            dt.TableName = "ServerDetails";
                            
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                serverDetails.Add(new ServerDetails
                                {
                                    IP = dr["IP"].ToString(),
                                    Name = dr["Name"].ToString(),
                                    Region = dr["Region"].ToString(),
                                    Status = Convert.ToUInt16(dr["Status"])
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
            string constr = ConfigurationManager.ConnectionStrings["ServerManagement"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM ServerDetails where Name=@Name"))
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
                            dt.TableName = "ServerDetails";

                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                serverDetails.Add(new ServerDetails
                                {
                                    IP = dr["IP"].ToString(),
                                    Name = dr["Name"].ToString(),
                                    Region = dr["Region"].ToString(),
                                    Status = Convert.ToUInt16(dr["Status"])
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

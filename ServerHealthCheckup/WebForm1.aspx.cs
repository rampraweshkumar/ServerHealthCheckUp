using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }
        private void BindGrid()
        {
            ServerHealthCheckup service = new ServerHealthCheckup();
            GridView1.DataSource = service.GetAll();
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            ServerHealthCheckup service = new ServerHealthCheckup();
            GridView1.DataSource = service.GetAll();
            GridView1.DataBind();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string ip = lblIP.Text;
            lblIP.Text = "";
            ServerHealthCheckup service = new ServerHealthCheckup();
            GridView1.DataSource = service.GetServerIpDetails(ip);
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string name = serverName.Text;
            serverName.Text = "";
            ServerHealthCheckup service = new ServerHealthCheckup();
            GridView1.DataSource = service.GetServerNameDetails(name);
            GridView1.DataBind();
        }
    }
}
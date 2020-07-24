using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Live_Web
{
    public partial class WebForm18 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           /* string constr = ConfigurationManager.ConnectionStrings["RKCS"].ConnectionString;
            using(SqlConnection con=new SqlConnection(constr))
            {
                   con.Open();
                
                    SqlDataAdapter da = new SqlDataAdapter("Select * from Volunteers", con);
                    SqlCommandBuilder build = new SqlCommandBuilder(da);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Volunters");
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                
            }*/
            Label1.Text = "Displaying Page " + (GridView1.PageIndex + 1).ToString() + " of " + (GridView1.PageCount + 1).ToString();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
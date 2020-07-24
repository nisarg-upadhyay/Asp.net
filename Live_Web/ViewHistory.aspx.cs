using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Live_Web
{
    public partial class WebForm20 : System.Web.UI.Page
    {
        public static string constr = ConfigurationManager.ConnectionStrings["RKCS"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection con=new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spGetDuty", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@volid", Convert.ToInt32(Session["VId"]));
                Repeater1.DataSource = cmd.ExecuteReader();
                Repeater1.DataBind(); 
            }
        }
    }
}
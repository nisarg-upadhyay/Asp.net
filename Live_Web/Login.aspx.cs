using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Live_Web
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        public static string name;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            int count = 0;
            
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=RK_Mission;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) from Volunteers where VolId=@VolId",con);
            cmd.Parameters.AddWithValue("@VolId",VIdTextBox.Text);
            count = Convert.ToInt32(cmd.ExecuteScalar());
            if(count>0)
            {
                SqlCommand cmd1 = new SqlCommand("Select Name from Volunteers where VolId=@VolId", con);
                cmd1.Parameters.AddWithValue("@VolId", VIdTextBox.Text);
                name = cmd1.ExecuteScalar().ToString();
                Session["Name"] = name;
                Session["VId"] = VIdTextBox.Text;
                Response.Redirect("Volunteer Homepage.aspx");
            }
            else
            {
                ResultLabel.Text = "No such volunteer found.";
            }
        }
    }
}
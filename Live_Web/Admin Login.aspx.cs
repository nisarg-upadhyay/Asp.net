using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Live_Web
{
    public partial class WebForm17 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            int count = 0;
            string name;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=RK_Mission;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) from Admin where AdminId=@AdminId", con);
            cmd.Parameters.AddWithValue("@AdminId", AIdTextBox.Text);
            count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                SqlCommand cmd1 = new SqlCommand("Select Name from Admin where AdminId=@AdminId", con);
                cmd1.Parameters.AddWithValue("@AdminId", AIdTextBox.Text);
                name = cmd1.ExecuteScalar().ToString();
                con.Close();
                Session["Name"] = name;
                Response.Redirect("Admin Homepage.aspx");
            }
            else
            {
                ResultLabel.Text = "No such admin found.";
            }
        }
    }
}
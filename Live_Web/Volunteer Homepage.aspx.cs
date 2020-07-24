using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Live_Web
{
    public partial class WebForm15 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            NameLabel.Text = Session["Name"].ToString();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=RK_Mission;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Duty from Volunteers where VolId=@VolId", con);
            cmd.Parameters.AddWithValue("@VolId", Session["VId"]);
            DutyTextBox.Text= cmd.ExecuteScalar().ToString();
            SqlCommand cmd1 = new SqlCommand("Select Location from Volunteers where VolId=@VolId1", con);
            cmd1.Parameters.AddWithValue("@VolId1", Session["VId"]);
            LocationTextBox.Text = cmd1.ExecuteScalar().ToString();
            SqlCommand cmd2 = new SqlCommand("Select Time from Volunteers where VolId=@VolId2", con);
            cmd2.Parameters.AddWithValue("@VolId2", Session["VId"]);
            TimeTextBox.Text = cmd2.ExecuteScalar().ToString();
            con.Close();
        }

        protected void CompletedButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=RK_Mission;Integrated Security=True");
            con.Open();
            SqlCommand cmd2 = new SqlCommand("Update Volunteers set Status=@Status where VolId=@VolId2",con);
            cmd2.Parameters.AddWithValue("@Status", "Completed");
            cmd2.Parameters.AddWithValue("@VolId2", Session["VId"]);
            cmd2.ExecuteNonQuery();
            cmd2 = new SqlCommand("Update Duty set Status=@Status where VolId=@VolId2", con);
            cmd2.Parameters.AddWithValue("@Status", "Completed");
            cmd2.Parameters.AddWithValue("@VolId2", Session["VId"]);
            cmd2.ExecuteNonQuery();
            con.Close();

        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Edit Details.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void HistoryButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewHistory.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Live_Web
{
    public partial class WebForm16 : System.Web.UI.Page
    {
        public static string vname;
        protected void Page_Load(object sender, EventArgs e)
        {
            NameLabel.Text = Session["Name"].ToString();
        }

        protected void AssignButton_Click(object sender, EventArgs e)
        {
            int count = 0;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=RK_Mission;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) from Volunteers where VolId=@VolId", con);
            cmd.Parameters.AddWithValue("@VolId", VIdTextBox.Text);
             
            count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                cmd = new SqlCommand("Select Name from Volunteers where VolId=@VolId", con);
                cmd.Parameters.AddWithValue("@VolId", VIdTextBox.Text);
                vname = cmd.ExecuteScalar().ToString();
                SqlCommand cmd1 = new SqlCommand(@"Update Volunteers set Duty=@Duty,Location=@Location,Time=@Time,Status=@Status where VolId=@VolId ",con);
                cmd1.Parameters.AddWithValue("@VolId",VIdTextBox.Text);
                cmd1.Parameters.AddWithValue("@Duty", DutyTextBox.Text);
                cmd1.Parameters.AddWithValue("@Location", LocationTextBox.Text);
                cmd1.Parameters.AddWithValue("@Time", TimeTextBox.Text);
                cmd1.Parameters.AddWithValue("@Status", "Pending");
                cmd1.ExecuteNonQuery();
                cmd1=new SqlCommand(@"Insert into Duty (Name,DutyName,Location,Time,Date,VolId) values(@Name,@DutyName,@Location,@Time,@Date,@VolId)", con);
                cmd1.Parameters.AddWithValue("@Name", vname);
                cmd1.Parameters.AddWithValue("@VolId", VIdTextBox.Text);
                cmd1.Parameters.AddWithValue("@DutyName", DutyTextBox.Text);
                cmd1.Parameters.AddWithValue("@Location", LocationTextBox.Text);
                cmd1.Parameters.AddWithValue("@Time", TimeTextBox.Text);
                cmd1.Parameters.AddWithValue("@Date", DateTextBox.Text);
                cmd1.ExecuteNonQuery();
            }
            else
            {
                ResultLabel.Text = "No such volunteer";
            }
            con.Close();
        }

        protected void RelieveButton_Click(object sender, EventArgs e)
        {
            int count = 0;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=RK_Mission;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) from Volunteers where VolId=@VolId", con);
            cmd.Parameters.AddWithValue("@VolId", RelieveTextBox.Text);
            count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                SqlCommand cmd1 = new SqlCommand(@"Update Volunteers set Duty=@Duty,Location=@Location,Time=@Time, Status=@Status where VolId=@VolId ", con);
                cmd1.Parameters.AddWithValue("@VolId", VIdTextBox.Text);
                cmd1.Parameters.AddWithValue("@Duty","Duty completed successfully. Presently there is no duty");
                cmd1.Parameters.AddWithValue("@Location", "");
                cmd1.Parameters.AddWithValue("@Time","");
                cmd1.Parameters.AddWithValue("@Status", "");
                cmd1.ExecuteNonQuery();
                cmd1 = new SqlCommand("Update Duty set Relieved='Yes' where VolID=@VolId AND Status='Completed' AND Relieved='No' ",con);
                cmd1.Parameters.AddWithValue("@VolId", RelieveTextBox.Text);
                cmd1.ExecuteNonQuery();
            }
            else
            {
                ResultLabel.Text = "No such volunteer";
            }
            con.Close();
        }

        protected void VIdTextBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
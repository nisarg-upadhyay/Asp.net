using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace Live_Web
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        public static string gender,none="none";
        public static int count=0;

        protected void Page_Load(object sender, EventArgs e)
        {

            string constring = ConfigurationManager.ConnectionStrings["RKCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select count(*) from Volunteers", con);
                count = Convert.ToInt32(cmd.ExecuteScalar());
                CountLabel.Text = count.ToString();
                if(!IsPostBack)
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select * from State", con);
                    SqlCommandBuilder build = new SqlCommandBuilder(da);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "State");
                    StateDropDownList.DataSource = ds;
                    StateDropDownList.DataTextField = "StateName";
                    StateDropDownList.DataValueField = "StateId";
                    StateDropDownList.DataBind();
                }
            }

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {

            string constring = ConfigurationManager.ConnectionStrings["RKCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Volunteers (Name,Age,Gender,CityId,CellNo,EmailId) values(@Name,@Age,@Gender,@CityId,@CellNo,@EmailId)", con);
                cmd.Parameters.AddWithValue("@Name", NameTextBox.Text);
                cmd.Parameters.AddWithValue("@Age", AgeUpdown.Text);
                
                cmd.Parameters.AddWithValue("@CityId", CityDropDownList.SelectedValue);
                cmd.Parameters.AddWithValue("@Gender", gender);
                if (CellTextBox.Text == String.Empty)
                {
                    cmd.Parameters.AddWithValue("@CellNo", none);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CellNo", CellTextBox.Text);
                }
                if (MailTextBox.Text == String.Empty)
                {
                    cmd.Parameters.AddWithValue("@EmailId", none);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@EmailId", MailTextBox.Text);
                }

                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand("Select VolId from Volunteers where Name=@Name", con);
                cmd1.Parameters.AddWithValue("@Name", NameTextBox.Text);

                VIdLabel.Text = cmd1.ExecuteScalar().ToString();
                string connstring = ConfigurationManager.ConnectionStrings["RKCS"].ConnectionString;
                using (SqlConnection con1 = new SqlConnection(constring))
                {
                    con1.Open();
                    SqlCommand cmd2 = new SqlCommand("Select count(*) from Volunteers", con);
                    count = Convert.ToInt32(cmd2.ExecuteScalar());
                    CountLabel.Text = count.ToString();
                }
            }
        }

        protected void MaleButton_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        protected void FemaleButton_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }

        protected void StateDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["RKCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select CityName,CityId from City where StateId=@sid", con);
                cmd.Parameters.AddWithValue("@sid", StateDropDownList.SelectedValue);
                SqlDataReader dr = cmd.ExecuteReader();
                CityDropDownList.DataSource = dr;
                CityDropDownList.DataTextField = "CityName";
                CityDropDownList.DataValueField = "CityId";
                CityDropDownList.DataBind();

            }


        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            NameTextBox.Text = " ";
            CellTextBox.Text = " ";
            
            StateDropDownList.ClearSelection();
            AgeUpdown.Text = " ";
            MaleButton.Checked = false;
            FemaleButton.Checked = false;
            MailTextBox.Text = " ";

        }
    }
}
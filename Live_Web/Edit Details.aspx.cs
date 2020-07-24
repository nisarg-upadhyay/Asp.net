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
    public partial class WebForm19 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            string constring = ConfigurationManager.ConnectionStrings["RKCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                if (EditCellTextBox.Text.Length != 0)
                {
                    con.Open();
                    int VolID = Convert.ToInt32(Session["VId"]);
                    SqlCommand cmd = new SqlCommand("spEditCell", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cellno", EditCellTextBox.Text);
                    cmd.Parameters.AddWithValue("@volid", VolID);
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
                if (EditMailTextBox.Text.Length != 0)
                {
                    con.Open();
                    int VolID = Convert.ToInt32(Session["VId"]);
                    SqlCommand cmd = new SqlCommand("spEditMail", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mailid", EditMailTextBox.Text);
                    cmd.Parameters.AddWithValue("@volid", VolID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                if (EditCityTextBox.Text.Length != 0)
                {
                    con.Open();
                    int VolID = Convert.ToInt32(Session["VId"]);
                    SqlCommand cmd = new SqlCommand("spEditCity", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@city", EditCityTextBox.Text);
                    cmd.Parameters.AddWithValue("@volid", VolID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                if (EditStateTextBox.Text.Length != 0)
                {
                    con.Open();
                    int VolID = Convert.ToInt32(Session["VId"]);
                    SqlCommand cmd = new SqlCommand("spEditState", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@state", EditStateTextBox.Text);
                    cmd.Parameters.AddWithValue("@volid", VolID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
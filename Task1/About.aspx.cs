using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Asp_Training
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetUsers();
            }
        }

        SqlConnection connection = new SqlConnection("Data Source = DESKTOP-ME9JBB3\\SQL2019; Initial Catalog = task1; Integrated Security = True");

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            int uid = int.Parse(TextBox1.Text);
            string fname = TextBox2.Text;
            string lname = TextBox3.Text;
            string uname = TextBox4.Text;
            string email = TextBox5.Text;
            string desig = TextBox6.Text;
            string dept = DropDownList1.SelectedValue;
            SqlCommand command = new SqlCommand("exec AddUser_sp '" + uid + "','" + fname + "','" + lname + "','" + uname + "','" +
                 email + "','" + desig + "','" + dept + "'", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Data Inserted Successfully')", true);
            GetUsers();
        }

        protected void GetUsers()
        {
            SqlCommand command = new SqlCommand("exec ViewUsers_sp", connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            GridView1.DataSource = dataSet;
            GridView1.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int uid = int.Parse(TextBox1.Text);
            string fname = TextBox2.Text;
            string lname = TextBox3.Text;
            string uname = TextBox4.Text;
            string email = TextBox5.Text;
            string desig = TextBox6.Text;
            string dept = DropDownList1.SelectedValue;
            SqlCommand command = new SqlCommand("exec UpdateUser_sp '" + uid + "','" + fname + "','" + lname + "','" + uname + "','" +
                 email + "','" + desig + "','" + dept + "'", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Data Updated Successfully')", true);
            GetUsers();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            Button btnSelect = (Button)sender;
            GridViewRow row = (GridViewRow)btnSelect.NamingContainer;
            if (row != null)
            {
                int rowIndex = row.RowIndex;

                if (rowIndex >= 0 && rowIndex < GridView1.Rows.Count)
                {
                    GridViewRow selectedRow = GridView1.Rows[rowIndex];
                    int uid = int.Parse(selectedRow.Cells[0].Text);
                    string fname = selectedRow.Cells[1].Text;
                    string lname = selectedRow.Cells[2].Text;
                    string uname = selectedRow.Cells[3].Text;
                    string email = selectedRow.Cells[4].Text;
                    string desig = selectedRow.Cells[5].Text;
                    string dept = selectedRow.Cells[6].Text;
                    TextBox1.Text = uid.ToString();
                    TextBox2.Text = fname;
                    TextBox3.Text = lname;
                    TextBox4.Text = uname;
                    TextBox5.Text = email;
                    TextBox6.Text = desig;
                    DropDownList1.SelectedValue = dept;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Data Retrival Failed')", true);
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int uid = int.Parse(TextBox1.Text);
            SqlCommand command = new SqlCommand("exec DeleteUser_sp '" + uid + "'", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Data Deleted Successfully')", true);
            GetUsers();
        }
    }
}
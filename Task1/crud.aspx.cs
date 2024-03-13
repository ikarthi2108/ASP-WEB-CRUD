using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Task1
{
    public partial class crud : System.Web.UI.Page
    {
        string connectionString = "Data Source=DESKTOP-ME9JBB3\\SQL2019;Initial Catalog=task1;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTable();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string query = $"Create Table {tableName.Text} ({columnName.Text} {dataType.Text});";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string InsertQuery = $"Insert Into UserTable  Values('{username.Text}');";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(InsertQuery, connection))
                {
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            LoadTable(); // Reload the GridView after insertion
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string usernameToDelete = GridView2.DataKeys[e.RowIndex].Values["name"].ToString();

            string deleteQuery = $"DELETE FROM UserTable WHERE name = '{usernameToDelete}';";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            LoadTable(); // Reload the GridView after deletion
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            LoadTable(); // Reload the GridView in edit mode
        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;
            LoadTable(); // Reload the GridView after canceling edit
        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string updatedUsername = ((TextBox)GridView2.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
            string originalUsername = GridView2.DataKeys[e.RowIndex].Values["name"].ToString();

            string updateQuery = $"UPDATE UserTable SET name = '{updatedUsername}' WHERE name = '{originalUsername}';";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            GridView2.EditIndex = -1;
            LoadTable(); // Reload the GridView after updating
        }

        protected void LoadTable()
        {
            string selectQuery = $"SELECT * FROM UserTable;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }
            }
        }
    }
}

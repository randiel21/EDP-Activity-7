using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ACTIVITY_4
{
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
            LoadActiveAccounts(); // Load active accounts by default
                                  // Subscribe the Click event of the ADDBTN button to the ADDBTN_Click event handler
            this.ADDBTN.Click += new System.EventHandler(this.ADDBTN_Click);

            // Subscribe the Click event of the UpdateP button to the UpdateP_Click event handler
            this.UpdateP.Click += new System.EventHandler(this.UpdateP_Click);

            // Subscribe the Click event of the DELBTN button to the DeactivateAccount_Click event handler
            this.DELBTN.Click += new System.EventHandler(this.DeactivateAccount_Click);

            // Subscribe the Click event of the ActivateButton button to the ActivateAccount_Click event handler
            //this.ActivateButton.Click += new System.EventHandler(this.ActivateAccount_Click);

            // Subscribe the Click event of the SearchButton button to the SearchButton_Click event handler
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
        }

        private void LoadActiveAccounts()
        {
            string connectionString = "Server=localhost;Port=3386;Database=pharmacy;Uid=root;Pwd=shin29;";
            string sql = "SELECT * FROM users WHERE status = 'Active'"; // Assuming 'status' field indicates account status

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            DATAP.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error loading active accounts: " + ex.Message);
            }
        }

       private void AddAccount(string username, string password)
{
    string connectionString = "Server=localhost;Port=3386;Database=pharmacy;Uid=root;Pwd=shin29;";
    string sql = "INSERT INTO users (username, password, status) VALUES (@username, @password, 'Active')";

    try
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.ExecuteNonQuery();
            }
        }
        MessageBox.Show("Account added successfully.");
        LoadActiveAccounts(); // Refresh DataGridView after adding account
    }
    catch (MySqlException ex)
    {
        MessageBox.Show("Error adding account: " + ex.Message);
    }
}

        private void UpdateAccount(int userId, string username, string password)
        {
            string connectionString = "Server=localhost;Port=3386;Database=pharmacy;Uid=root;Pwd=shin29;";
            string sql = "UPDATE users SET username = @username, password = @password WHERE id = @id";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Account updated successfully.");
                LoadActiveAccounts(); // Refresh DataGridView after updating account
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error updating account: " + ex.Message);
            }
        }

        private void ActivateAccount(int userId)
        {
            string connectionString = "Server=localhost;Port=3386;Database=pharmacy;Uid=root;Pwd=shin29;";
            string sql = "UPDATE users SET status = 'Active' WHERE id = @id";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Account activated successfully.");
                LoadActiveAccounts(); // Refresh DataGridView after activating account
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error activating account: " + ex.Message);
            }
        }

        private void DeactivateAccount(int userId)
        {
            string connectionString = "Server=localhost;Port=3386;Database=pharmacy;Uid=root;Pwd=shin29;";
            string sql = "UPDATE users SET status = 'Inactive' WHERE id = @id";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Account deactivated successfully.");
                LoadActiveAccounts(); // Refresh DataGridView after deactivating account
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error deactivating account: " + ex.Message);
            }
        }

        private void ADDBTN_Click(object sender, EventArgs e)
        {
            string username = USNR.Text;
            string password = Passbox.Text;
            AddAccount(username, password);
        }

        private void UpdateP_Click(object sender, EventArgs e)
        {
            if (DATAP.SelectedRows.Count > 0)
            {
                int selectedRowIndex = DATAP.SelectedRows[0].Index;
                int userId = Convert.ToInt32(DATAP.Rows[selectedRowIndex].Cells["id"].Value);
                string username = USNR.Text;
                string password = Passbox.Text;
                UpdateAccount(userId, username, password);
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }

        private void ActivateAccount_Click(object sender, EventArgs e)
        {
            if (DATAP.SelectedRows.Count > 0)
            {
                int selectedRowIndex = DATAP.SelectedRows[0].Index;
                int userId = Convert.ToInt32(DATAP.Rows[selectedRowIndex].Cells["id"].Value);
                ActivateAccount(userId);
            }
            else
            {
                MessageBox.Show("Please select a row to activate.");
            }
        }

        private void DeactivateAccount_Click(object sender, EventArgs e)
        {
            if (DATAP.SelectedRows.Count > 0)
            {
                int selectedRowIndex = DATAP.SelectedRows[0].Index;
                int userId = Convert.ToInt32(DATAP.Rows[selectedRowIndex].Cells["id"].Value);
                DeactivateAccount(userId);
            }
            else
            {
                MessageBox.Show("Please select a row to deactivate.");
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
       {
          string username = SearchBox.Text;
           SearchAccounts(username);
        }

        private void SearchAccounts(string username)
        {
            string connectionString = "Server=localhost;Port=3386;Database=pharmacy;Uid=root;Pwd=shin29;";
            string sql = "SELECT * FROM users WHERE username LIKE @username AND status = 'Active'"; // Modify as needed

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", "%" + username + "%");
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            DATAP.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error searching accounts: " + ex.Message);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Implementation for the text changed event of textBox1
        }
        private void CreateAccount_Load(object sender, EventArgs e)
        {
            // Implementation for the form load event
        }

        private void USNR_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

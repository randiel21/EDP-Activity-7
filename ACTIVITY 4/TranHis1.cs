using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ACTIVITY_4
{
    public partial class TranHis : Form
    {
        public TranHis()
        {
            InitializeComponent();
            LoadDataIntoDataGridView(); // Call the method to load data into DataGridView upon form initialization
        }

        private void LoadDataIntoDataGridView()
        {
            MySqlConnection conn = null;
            string connectionString = "Server=localhost;Port=3386;Uid=root;Pwd=shin29;Database=pharmacy;AllowPublicKeyRetrieval=true;SslMode=Preferred;";

            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();

                string sql = "SELECT * FROM transaction_history"; // Replace 'your_table_name' with your actual table name
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Assign the DataTable to the DataGridView's DataSource
                DATAP.DataSource = dataTable;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn?.Close();
            }
        }

        private void DATAP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Populate TextBoxes with data from the selected row
            if (e.RowIndex >= 0 && e.RowIndex < DATAP.Rows.Count - 1) // Exclude the new row
            {
                DataGridViewRow row = DATAP.Rows[e.RowIndex];

               
            }
        }
    }
}

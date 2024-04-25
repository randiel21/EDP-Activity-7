using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.PeerToPeer;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;
using MySql.Data.MySqlClient;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Runtime.ConstrainedExecution;
using DocumentFormat.OpenXml.Bibliography;
using K4os.Compression.LZ4.Internal;


namespace ACTIVITY_4
{
    public partial class PRODUCTS : Form
    {
        // Define the DataGridView
        private DataGridView dataGridViewProducts;

        public PRODUCTS()
        {
            InitializeComponent();
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial; // or OfficeOpenXml.LicenseContext.Commercial



            // Define the DataGridView control
            dataGridViewProducts = DATAP;

            // Attach event handlers to button clicks
            HomeP.Click += HomeP_Click;
            ProductsP.Click += ProductsP_Click;
            AboutP.Click += AboutP_Click;
            LogoutP.Click += LogoutP_Click;
            ADDBTN.Click += ADDBTN_Click;
            DELBTN.Click += DELBTN_Click;
            UpdateP.Click += UpdateP_Click;
            adminbutton1.Click += adminbutton1_Click;

            // Load data into the DataGridView
            LoadDataIntoDataGridView();
        }

        private void LoadDataIntoDataGridView()
        {
            MySqlConnection conn = null;
            string connectionString = "Server=localhost;Port=3386;Uid=root;Pwd=shin29;Database=pharmacy;AllowPublicKeyRetrieval=true;SslMode=Preferred;";

            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();

                string sql = "SELECT * FROM products"; // Replace 'your_table_name' with your actual table name
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


        private void BindDataToGrid()
        {
            try
            {
                string connectionString = "Server=localhost;Port=3386;Uid=root;Pwd=shin29;Database=pharmacy;AllowPublicKeyRetrieval=true;SslMode=Preferred;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to retrieve total_amount column from the daily_sales table
                    string query1 = "SELECT product_id, product_name, inventory, product_type FROM products";
                    MySqlDataAdapter adapter1 = new MySqlDataAdapter(query1, connection);
                    DataTable dataTable1 = new DataTable();
                    adapter1.Fill(dataTable1);
                    DATAP.DataSource = dataTable1;

                   

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Event handler for Home button click
        private void HomeP_Click(object sender, EventArgs e)
        {
            // Assuming you have the connection information available here
            // Replace "your_username", "your_password", "your_hostname", and your_port with the actual values you want to use for the connection to the database
            Dashboard dashboardForm = new Dashboard("your_username", "your_password", "your_hostname", 3386);

            // Show the dashboard form
            dashboardForm.Show();

            // Optionally, hide the current form (the "About" form)
            this.Hide();
        }
        private void adminbutton1_Click(object sender, EventArgs e)
        {
            CreateAccount createAccountForm = new CreateAccount();
            createAccountForm.Show();
        }
        // Event handler for Products button click
        private void ProductsP_Click(object sender, EventArgs e)
        {
            // Create an instance of the PRODUCTS form
            PRODUCTS productsForm = new PRODUCTS();

            // Show the PRODUCTS form
            productsForm.Show();

            // Hide the current form (assuming this is the Dashboard form)
            this.Hide();
        }

        // Event handler for About button click
        private void AboutP_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();

            // Show the About form
            aboutForm.Show();

            // Hide the current form (assuming this is the Dashboard form)
            this.Hide();
        }

        // Event handler for Logout button click
        private void LogoutP_Click(object sender, EventArgs e)
        {
            // Display a confirmation message
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                // Create an instance of the login form
                Login loginForm = new Login();

                // Show the login form
                loginForm.Show();

                // Close the current form (About)
                this.Close();
            }
            // If the user chooses No, do nothing
        }

        // Event handler for ADD button click
        private void ADDBTN_Click(object sender, EventArgs e)
        {
            // Implement your logic for adding data here
        }

        // Event handler for DELETE button click
        private void DELBTN_Click(object sender, EventArgs e)
        {
            // Implement your logic for deleting data here
        }

        // Event handler for UPDATE button click
        private void UpdateP_Click(object sender, EventArgs e)
        {
            // Implement your logic for updating data here
        }

        // Add event handlers for other buttons as needed

        private void PRODUCTS_Load(object sender, EventArgs e)
        {
            // Add any initialization code here
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Add your logic for handling text changed event
        }

        private void EXP_Click(object sender, EventArgs e)
        {
            // Define the DataGridView control and corresponding sheet name
            var dataGridViewToExport = DATAP; // Change to your DataGridView control
            var sheetName = "Products"; // Change to your desired sheet name

            // Define column mappings for the DataGridView
            var columnMappings = new Dictionary<string, string>
    {
        {"product_id", "Product ID"},
        {"product_name", "Product Name"},
        {"inventory", "Inventory"},
        {"product_type", "Product Type"}
        // Add more mappings as needed
    };

            // Export data with graph
            ExportToExcelWithGraph(dataGridViewToExport, sheetName, columnMappings);
        }

        private void ExportToExcelWithGraph(DataGridView dataGridView, string sheetName, Dictionary<string, string> columnMappings)
        {
            try
            {
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add(sheetName);

                    // Add header
                    var header = worksheet.Cells["A1:E1"];
                    header.Merge = true;
                    header.Value = "Shinano Food Service";
                    header.Style.Font.Bold = true;
                    header.Style.Font.Size = 16;
                    header.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    // Add company logo (assuming your logo is stored as an image)
                    var logo = worksheet.Drawings.AddPicture("Logo", new FileInfo("C:\\Users\\Acer\\Pictures\\furi.jpg"));
                    logo.SetPosition(0, 0, 5, 0);
                    logo.SetSize(100, 100);

                    // Add signature line
                    var signatureLine = worksheet.Cells["A15:E15"];
                    signatureLine.Merge = true;
                    signatureLine.Value = "Signature: ____________________";
                    signatureLine.Style.Font.Bold = true;
                    signatureLine.Style.Font.Size = 12;

                    // Add Name and Manager below the signature line
                    var nameManagerCell = worksheet.Cells["A16:E16"];
                    nameManagerCell.Merge = true;
                    nameManagerCell.Value = "Asis, Shinano - Manager";
                    nameManagerCell.Style.Font.Bold = true;
                    nameManagerCell.Style.Font.Size = 12;

                    // Add column names
                    int colIndex = 1;
                    foreach (var mapping in columnMappings)
                    {
                        worksheet.Cells[2, colIndex].Value = mapping.Value; // Assuming column names are defined in the columnMappings dictionary
                        colIndex++;
                    }

                    // Add data to the worksheet
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        colIndex = 1; // Reset column index for each row

                        foreach (var mapping in columnMappings)
                        {
                            var cellValue = dataGridView.Rows[i].Cells[mapping.Key].Value;

                            if (cellValue != null)
                            {
                                worksheet.Cells[i + 3, colIndex].Value = cellValue.ToString();
                            }
                            else
                            {
                                worksheet.Cells[i + 3, colIndex].Value = ""; // Handle the case where the cell value is null
                            }

                            colIndex++;
                        }
                    }

                    // Set chart title
                    var graphWorksheet = package.Workbook.Worksheets.Add(sheetName + "_Graph");
                    var graphImage = graphWorksheet.Drawings.AddPicture("Graph", new FileInfo("D:\\3rd Year 2nd sem\\EDP\\graphs\\Products.png"));
                    graphImage.SetPosition(0, 0, 0, 0);
                    graphImage.SetSize(600, 400);

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog.FileName = "Products.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        package.SaveAs(new FileInfo(saveFileDialog.FileName));
                        MessageBox.Show("Data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }










    }
}
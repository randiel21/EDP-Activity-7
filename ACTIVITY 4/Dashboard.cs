using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ClosedXML.Excel;
using System.Collections.Generic;
using OfficeOpenXml;
using System.Drawing;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using System.IO;

namespace ACTIVITY_4
{
    public partial class Dashboard : Form
    {
        // Fields to store connection information
        private string username;
        private string password;
        private string hostname;
        private int port;

        // Constructor to initialize the Dashboard form with connection information
        public Dashboard(string username, string password, string hostname, int port)
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // or LicenseContext.Commercial

            // Store connection information
            this.username = username;
            this.password = password;
            this.hostname = hostname;
            this.port = port;

            // Attach event handlers to buttons
            ProductD.Click += ProductD_Click;
            AboutD.Click += AboutD_Click;
            HomeD.Click += HomeD_Click;
            // Attach event handler to the Logout button click event
            LogoutD.Click += LogoutD_Click;
            adminbutton1.Click += adminbutton1_Click;

            // Retrieve data from the database and bind it to the data grids
            BindDataToGrid();
        }

        private void BindDataToGrid()
        {
            try
            {
                string connectionString = $"Server={hostname};Port={port};Uid={username};Pwd={password};Database=pharmacy;AllowPublicKeyRetrieval=true;SslMode=Preferred;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to retrieve total_amount column from the daily_sales table
                    string query1 = "SELECT sale_date, total_amount FROM daily_sales";
                    MySqlDataAdapter adapter1 = new MySqlDataAdapter(query1, connection);
                    DataTable dataTable1 = new DataTable();
                    adapter1.Fill(dataTable1);
                    DATADS.DataSource = dataTable1;

                    // Query to retrieve total_amount column from the monthly_sales table
                    string query2 = "SELECT sale_month, total_amount FROM monthly_sales";
                    MySqlDataAdapter adapter2 = new MySqlDataAdapter(query2, connection);
                    DataTable dataTable2 = new DataTable();
                    adapter2.Fill(dataTable2);
                    DATAM.DataSource = dataTable2;

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ProductD_Click(object sender, EventArgs e)
        {
            // Create an instance of the PRODUCTS form
            PRODUCTS productsForm = new PRODUCTS();

            // Show the PRODUCTS form
            productsForm.Show();

            // Hide the current form (assuming this is the Dashboard form)
            this.Hide();
        }

        private void AboutD_Click(object sender, EventArgs e)
        {
            // Create an instance of the About form
            About aboutForm = new About();

            // Show the About form
            aboutForm.Show();

            // Hide the current form (assuming this is the Dashboard form)
            this.Hide();
        }

        private void adminbutton1_Click(object sender, EventArgs e)
        {
            CreateAccount createAccountForm = new CreateAccount();
            createAccountForm.Show();
        }

        private void HomeD_Click(object sender, EventArgs e)
        {
            // You don't need to create another instance of the Dashboard form here
            // Since this method is associated with the Home button, you might want to implement
            // logic to refresh or update the content of the dashboard instead
            // For now, let's just display a message
            MessageBox.Show("You are already on the Home screen.");
        }

        private void LogoutD_Click(object sender, EventArgs e)
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

        private void EXPALL_Click(object sender, EventArgs e)
        {
            // Define the DataGridView controls and corresponding sheet names
            var dataToExport = new List<(DataGridView dataGridView, string sheetName)>
    {
        (DATADS, "DailySales"),
        (DATAM, "MonthlySales")
        // Add more DataGridView controls and sheet names as needed
    };

            // Define column mappings for each DataGridView
            var columnMappings = new Dictionary<string, Dictionary<string, string>>
    {
        {
            "DATADS", new Dictionary<string, string>
            {
                {"sale_date", "Day"},
                {"total_amount", "Sales"}
                // Add more mappings as needed
            }
        },
        {
            "DATAM", new Dictionary<string, string>
            {
                {"sale_date", "Month"},
                {"total_amount", "Sales"}
                // Add more mappings as needed
            }
        }
        // Add more mappings for additional DataGridView controls as needed
    };

            // Export data with graphs
            ExportToExcelWithGraphs(dataToExport, columnMappings);
        }

        private void ExportToExcelWithGraphs(List<(DataGridView dataGridView, string sheetName)> dataToExport, Dictionary<string, Dictionary<string, string>> columnMappings)
        {
            try
            {
                using (var package = new ExcelPackage())
                {
                    foreach (var data in dataToExport)
                    {
                        var worksheet = package.Workbook.Worksheets.Add(data.sheetName);

                        // Add header
                        var header = worksheet.Cells["A1:E1"];
                        header.Merge = true;
                        header.Value = "Shinano Food Service";
                        header.Style.Font.Bold = true;
                        header.Style.Font.Size = 16;
                        header.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        // Add company logo (assuming your logo is stored as an image)
                        var logo = worksheet.Drawings.AddPicture("Logo", new FileInfo("C:\\Users\\Acer\\Pictures\\furi.jpg"));
                        logo.SetPosition(0, 0, 4, 0);
                        logo.SetSize(100, 100);

                        // Add signature line
                        var signatureLine = worksheet.Cells["A12:E12"];
                        signatureLine.Merge = true;
                        signatureLine.Value = "Signature: ____________________";
                        signatureLine.Style.Font.Bold = true;
                        signatureLine.Style.Font.Size = 12;

                        // Add Name and Manager below the signature line
                        var nameManagerCell = worksheet.Cells["A13:E13"];
                        nameManagerCell.Merge = true;
                        nameManagerCell.Value = "Asis, Shinano - Manager";
                        nameManagerCell.Style.Font.Bold = true;
                        nameManagerCell.Style.Font.Size = 12;

                        // Add column names
                        var mappings = columnMappings[data.dataGridView.Name];
                        int colIndex = 1;
                        foreach (var mapping in mappings)
                        {
                            worksheet.Cells[2, colIndex].Value = mapping.Value; // Assuming column names are defined in the columnMappings dictionary
                            colIndex++;
                        }

                        // Add graph
                        var graphWorksheet = package.Workbook.Worksheets.Add(data.sheetName + "_Graph"); // Ensure unique worksheet names for graphs
                        var graph = (ExcelLineChart)graphWorksheet.Drawings.AddChart("Graph", eChartType.Line);
                        graph.SetPosition(0, 0, 0, 0);
                        graph.SetSize(600, 400);

                        // Add data to the worksheet and graph
                        for (int i = 0; i < data.dataGridView.Rows.Count; i++)
                        {
                            var dateCellValue = data.dataGridView.Rows[i].Cells[0].Value;
                            var salesCellValue = data.dataGridView.Rows[i].Cells[1].Value;

                            if (dateCellValue != null && DateTime.TryParse(dateCellValue.ToString(), out DateTime dateValue))
                            {
                                worksheet.Cells[i + 3, 1].Value = dateValue.ToShortDateString();

                                if (salesCellValue != null)
                                {
                                    worksheet.Cells[i + 3, 2].Value = salesCellValue.ToString();
                                    graph.Series.Add(worksheet.Cells[i + 3, 2], worksheet.Cells[i + 3, 1]);
                                }
                                else
                                {
                                    worksheet.Cells[i + 3, 2].Value = ""; // Handle the case where the cell value is null
                                }
                            }
                            else
                            {
                                worksheet.Cells[i + 3, 1].Value = ""; // Handle the case where the cell value is null or invalid date
                            }

                            // Add PNG graph as picture based on DataGridView
                            string graphFileName = (data.dataGridView == DATADS) ? "daily.png" : "month.png";
                            var graphImage = graphWorksheet.Drawings.AddPicture("Graph_" + i, new FileInfo(Path.Combine("D:\\3rd Year 2nd sem\\EDP\\graphs", graphFileName)));
                            graphImage.SetPosition(0, 0, 0, 0);
                            graphImage.SetSize(600, 400);
                        }


                        // Set chart title
                        graph.Title.Text = "Sales Data";
                        graph.Title.Font.Bold = true;

                        // Set chart axes titles
                        graphWorksheet.Cells["A2"].Value = "Date";
                        graphWorksheet.Cells["B2"].Value = "Sales";
                    }

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog.FileName = "SaleReport.xlsx";

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








        private void Menu_Click(object sender, EventArgs e)
        {
            // Your Menu button click event handler code goes here
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Your Dashboard form load event handler code goes here
        }

        private void MS_Click(object sender, EventArgs e)
        {
            // Your Monthly Sales label click event handler code goes here
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Your panel1 paint event handler code goes here
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Your panel2 paint event handler code goes here
        }

        private void adminbutton1_Click_1(object sender, EventArgs e)
        {
            // Code for admin button 1 click event handler goes here
        }
    }
}

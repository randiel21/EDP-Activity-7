using System.Windows.Forms;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ACTIVITY_4
{
    partial class About : Form
    {
       
        public About()
        {
            InitializeComponent();
            // Attach event handler to the Products button click event
            ProductsA.Click += ProductsA_Click;
            // Attach event handler to the Dashboard button click event
            DashbA.Click += DashbA_Click;
            // Attach event handler to the Logout button click event
            LogoutA.Click += LogoutA_Click;
            adminbuttonA.Click += adminbuttonA_Click;

        }

        // Event handler for Products button click
        private void ProductsA_Click(object sender, EventArgs e)
        {// Create an instance of the PRODUCTS form
            PRODUCTS productsForm = new PRODUCTS();

            // Show the PRODUCTS form
            productsForm.Show();

            // Hide the current form (assuming this is the Dashboard form)
            this.Hide();
        }

        // Event handler for Dashboard button click
        private void DashbA_Click(object sender, EventArgs e)
        {
            // Assuming you have the connection information available here
            // Replace "your_username", "your_password", "your_hostname", and 3386 with the actual values you want to use for the connection to the database
            Dashboard dashboardForm = new Dashboard("your_username", "your_password", "your_hostname", 3386);

            // Show the dashboard form
            dashboardForm.Show();

            // Optionally, hide the current form (the "About" form)
            this.Hide();
        }
        private void adminbuttonA_Click(object sender, EventArgs e)
        {
            CreateAccount createAccountForm = new CreateAccount();
            createAccountForm.Show();
        }
        private void LogoutA_Click(object sender, EventArgs e)
        { // Display a confirmation message
            DialogResult result = MessageBox.Show("Are you sure that you want to logout???", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

        // Other event handlers and methods...
        private void label1_Click(object sender, EventArgs e)
        {
            // Your code here
        }

        private void Home_dash_Click(object sender, EventArgs e)
        {
            // Your code here
        }

        private void About_Load(object sender, EventArgs e)
        {
            // Your code here
        }

        private void HomeA_Click(object sender, EventArgs e)
        {


            // Assuming you have the connection information available here
            // Replace "your_username", "your_password", "your_hostname", and your_port with the actual values you want to use for the connection to the database
            Dashboard dashboardForm = new Dashboard("your_username", "your_password", "your_hostname", 3386);

            // Show the dashboard form
            dashboardForm.Show();

            // Optionally, hide the current form (the "About" form)
            this.Hide();
        }

        private void ProductsA_Click_1(object sender, EventArgs e)
        {
            
                // Create an instance of the PRODUCTS form
                PRODUCTS productsForm = new PRODUCTS();

                // Show the PRODUCTS form
                productsForm.Show();

                // Hide the current form (assuming this is the Dashboard form)
                this.Hide();
            
        }
    }
}

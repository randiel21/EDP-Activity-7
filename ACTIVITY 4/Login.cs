using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace ACTIVITY_4
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
         
            // Set the tab index for the textboxes

            // Set the tab index for the textboxes
            usern.TabIndex = 0;
            passwrd.TabIndex = 1;

            // Set the tab index for the login button
            LoginBttn.TabIndex = 2;  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string enteredUsername = usern.Text;
            string enteredPassword = passwrd.Text;
            string hostname = "localhost";
            int port = 3386;

            string connectionString = $"Server={hostname};Port={port};Database=pharmacy;Uid={enteredUsername};Pwd={enteredPassword};AllowPublicKeyRetrieval=true;SslMode=Preferred;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                MessageBox.Show("Connected to MySQL server!");

                // Close the current form (Login)
                this.Hide();

                // Show the Dashboard form
                ShowDashboardForm(enteredUsername, enteredPassword, hostname, port);
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1045) // MySQL error number for access denied
                {
                    // User does not exist, so register the user
                    if (RegisterUser(enteredUsername, enteredPassword))
                    {
                        MessageBox.Show("User registered successfully and logged in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Close the current form (Login)
                        this.Hide();

                        // Show the Dashboard form
                        ShowDashboardForm(enteredUsername, enteredPassword, hostname, port);
                    }
                    else
                    {
                        MessageBox.Show("Failed to register user. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error connecting to MySQL server: " + ex.Message);
                }
            }
            finally
            {
                connection.Close();
            }
        }
        private bool RegisterUser(string username, string password)
        {
            string hostname = "localhost";
            int port = 3386;
            string connectionString = $"Server={hostname};Port={port};Uid={username};Pwd={password};Database=pharmacy";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO users (username, password) VALUES (@username, @password)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }


        private void ShowDashboardForm(string username, string password, string hostname, int port)
        {

            // Create an instance of the Dashboard form
            Dashboard dashboard = new Dashboard(username, password, hostname, port);

            // Show the Dashboard form
            dashboard.Show();

            // Hide the Login form
            this.Hide();
        }

       
            private void ForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            {
                // Create a new instance of the Forgot_Pass form
                Forgot_Pass forgotPassForm = new Forgot_Pass();

                // Show the Forgot_Pass form
                forgotPassForm.Show();
            }
        
        private void CreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open the Create Account form
            CreateAccount createAccountForm = new CreateAccount();
            createAccountForm.Show();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            // Code to handle label click event
        }

        private void UsernameLabel_Click(object sender, EventArgs e)
        {
            // Code to handle label click event
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
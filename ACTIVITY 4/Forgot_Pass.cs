using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ACTIVITY_4
{



    partial class Forgot_Pass : Form
    {
        // Define user credentials (username, email, password, security question, and answer)
        // Define user credentials (username, password, security question, and answer)
        private static readonly Dictionary<string, (string password, string securityQuestion, string securityAnswer)> UserCredentials = new Dictionary<string, (string, string, string)>
        {
            {"Ayaka28", ("kamisato", "What is your favorite food?", "sushi")},
            {"root", ("shin29", "What is your favorite food?", "pizza")},
            {"Ayato26", ("Kamisato01", "What is your pet's name?", "Mochi")}
        };

        public Forgot_Pass()
        {
            InitializeComponent();
            UsrNmebox.KeyPress += UsrNmebox_KeyPress;
            securityQ.KeyPress += securityQ_KeyPress;
        }

        private void LoginBttn_Click(object sender, EventArgs e)
        {
            string username = UsrNmebox.Text.Trim();
            string answer = securityQ.Text.Trim();

            // Check if the username exists in the dictionary
            if (UserCredentials.ContainsKey(username))
            {
                var (password, securityQuestion, securityAnswer) = UserCredentials[username];

                // Check if the entered answer matches the stored security answer
                if (answer.ToLower() == securityAnswer.ToLower())
                {
                    MessageBox.Show($"Username: {username}\nPassword: {password}", "Your Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Incorrect security answer. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Unknown username. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Forgot_Pass_Load(object sender, EventArgs e)
        {
            // Set the security question label
            string username = UsrNmebox.Text.Trim();
            if (UserCredentials.ContainsKey(username))
            {
                question.Text = UserCredentials[username].securityQuestion;
            }
            else
            {
                question.Text = "\"What is your favorite food?"; // Default message if username not found
            }
        }
        private void UsrNmebox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                securityQ.Focus();
                e.Handled = true;
            }
        }

        private void securityQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoginBttn.PerformClick();
                e.Handled = true;
            }
        }

        private void UsrNmebox_TextChanged(object sender, EventArgs e)
        {

        }
    }

   
    }


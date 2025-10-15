using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class NewStaff : Form
    {
        public NewStaff()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String fName = textBox1.Text;
            String lName = textBox2.Text;

            string gender = "";
            bool isChecked = radioButton1.Checked;
            if (isChecked)
            {
                gender = radioButton1.Text;
            }
            else
            {
                gender = radioButton2.Text;
            }
            String dob = dateTimePicker1.Text;
            Int64 mobile = Int64.Parse(textBox3.Text);
            String email = textBox4.Text;
            String joinDate = dateTimePicker2.Text;
            String state = textBox5.Text;
            String city = textBox6.Text;   //newstaff

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=gym;";
            string query = "INSERT INTO newstaff(`SID`, `Fname`, `Lname`, `Gender`,`Dob`,`Mobile`,`Email`,`JoinDate`,`State`,`City`) VALUES (NULL, '" + fName + "', '" + lName + "', '" + gender + "','" + dob + "', '" + mobile + "', '" + email + "','" + joinDate + "', '" + state + "', '" + city + "')";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                MessageBox.Show("Staff Member succesfully registered");

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class Equipment : Form
    {
        public Equipment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String equipment = textBox1.Text;
            String description = richTextBox1.Text;
            String mUsed = textBox2.Text;
            String dDate = dateTimePicker1.Text;
            Int64 cost = Int64.Parse(textBox3.Text);

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=gym;";
            string query = "INSERT INTO equipment(`EID`, `EquipName`, `Description`, `MUsed`,`DDate`,`Cost`) VALUES (NULL, '" + equipment + "', '" + description + "', '" + mUsed + "','" + dDate + "', '" + cost + "')";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                MessageBox.Show("Equipment succesfully Saved!");

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
            dateTimePicker1.Value = DateTime.Now;
            richTextBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewEquipment ve = new ViewEquipment();
            ve.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

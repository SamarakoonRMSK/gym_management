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
    public partial class SearchMember : Form
    {
        public SearchMember()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=gym;";
                string query = "SELECT * FROM newmember WHERE MID=" + textBox1.Text + "";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);

                DataSet DS = new DataSet();
                MySqlDataAdapter DA = new MySqlDataAdapter(query, databaseConnection);
                DA.Fill(DS);

                try
                {
                    databaseConnection.Open();
                    dataGridView1.DataSource = DS.Tables[0];
                    databaseConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else {
                MessageBox.Show("Please enter some ID", "Message",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void SearchMember_Load(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=gym;";
            string query = "SELECT * FROM newmember";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);

            DataSet DS = new DataSet();
            MySqlDataAdapter DA = new MySqlDataAdapter(query, databaseConnection);
            DA.Fill(DS);

            try
            {
                databaseConnection.Open();
                dataGridView1.DataSource = DS.Tables[0];
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

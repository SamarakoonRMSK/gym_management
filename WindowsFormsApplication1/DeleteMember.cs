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
    public partial class DeleteMember : Form
    {
        public DeleteMember()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (MessageBox.Show("This will your data. Confirm?", "Delete data", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=gym;";
                    string query = "DELETE FROM newmember WHERE MID=" + textBox1.Text + "";
                    MySqlConnection databaseConnection = new MySqlConnection(connectionString);

                    DataSet DS = new DataSet();
                    MySqlDataAdapter DA = new MySqlDataAdapter(query, databaseConnection);
                    DA.Fill(DS);

                    try
                    {
                        membersLoad();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else {
                    this.Activate();
                    membersLoad();
                }
            }
            else
            {
                MessageBox.Show("Please enter some ID", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        

        private void DeleteMember_Load(object sender, EventArgs e)
        {
            membersLoad();
        }
        private void membersLoad() {
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

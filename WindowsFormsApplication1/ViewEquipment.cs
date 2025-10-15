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
    public partial class ViewEquipment : Form
    {
        public ViewEquipment()
        {
            InitializeComponent();
        }

        private void ViewEquipment_Load(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=gym;";
            string query = "SELECT * FROM equipment";
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

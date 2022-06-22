using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        public void SelectData(string tableName)
        {
            string connectionString = @"Data Source=DESKTOP-H6L7PB2\SQLEXPRESS;Initial Catalog=419/4Mostitckiy;Integrated Security=True";
            SqlConnection MyConnection = new SqlConnection(connectionString);

            string queryString = "SELECT * FROM " + tableName + "";
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, MyConnection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectData(comboBox1.SelectedItem.ToString());
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            //dateTimePicker1.Value

            // TODO: данная строка кода позволяет загрузить данные в таблицу "_419_4MostitckiyDataSet.Врачи". При необходимости она может быть перемещена или удалена.
            this.врачиTableAdapter.Fill(this._419_4MostitckiyDataSet.Врачи);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

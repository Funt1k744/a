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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-H6L7PB2\SQLEXPRESS;Initial Catalog=419/4Mostitckiy;Integrated Security=True";
            SqlConnection MyConnection = new SqlConnection(connectionString);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns.Add("pacient", "Пациенты");
            dataGridView1.Columns.Add("doctor", "Врач");
            dataGridView1.Columns.Add("status", "Должность");
            dataGridView1.Columns.Add("room", "Кабинет");
            dataGridView1.Columns.Add("date", "Дата");

            MyConnection.Open();
            SqlDataReader Reader1;
            string journalQuery = $"select Пациенты.ФИО as 'Пациент', Врачи.ФИО as 'Врач', Врачи.Должность, Врачи.Кабинет, Журнал_записи.[Дата и время] from Пациенты inner join Журнал_записи on Пациенты.[ID пациента] = Журнал_записи.[ID пациента] inner join Врачи on Журнал_записи.[ID врача] = Врачи.[ID врача]";
            SqlCommand journalCmd = new SqlCommand(journalQuery, MyConnection);
            Reader1 = journalCmd.ExecuteReader();
            while (Reader1.Read())
            {
                dataGridView1.Rows.Add(Reader1[0].ToString(), Reader1[1].ToString(), Reader1[2].ToString(), Reader1[3].ToString(), Reader1[4].ToString());
            }
            Reader1.Close();


            MyConnection.Close();
        }
    }
}

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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-H6L7PB2\SQLEXPRESS;Initial Catalog=419/4Mostitckiy;Integrated Security=True";
            SqlConnection MyConnection = new SqlConnection(connectionString);

            string loginn = NameUser.nameUser;


            string loginsQuery = "SELECT ФИО, Login FROM Пациенты";

            SqlDataReader Reader1;
            SqlCommand loginCmd = new SqlCommand(loginsQuery, MyConnection);
            MyConnection.Open();
            Reader1 = loginCmd.ExecuteReader();
            while (Reader1.Read())
            {
                string fio = Reader1[0].ToString();
                string login = Reader1[1].ToString();
                if(login == loginn)
                {
                    label1.Text = "Здравствуйте - " + fio;
                }
            }
            Reader1.Close();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns.Add("pacient", "Пациенты");
            dataGridView1.Columns.Add("doctor", "Врач");
            dataGridView1.Columns.Add("status", "Должность");
            dataGridView1.Columns.Add("room", "Кабинет");
            dataGridView1.Columns.Add("date", "Дата");

            SqlDataReader Reader2;
            string dataQuery = $"select Пациенты.ФИО as 'Пациент', Врачи.ФИО as 'Врач', Врачи.Должность, Врачи.Кабинет, Журнал_записи.[Дата и время]  from Пациенты inner join Журнал_записи on Пациенты.[ID пациента] = Журнал_записи.[ID пациента] inner join Врачи on Журнал_записи.[ID врача] = Врачи.[ID врача] where (convert(varchar(10), Журнал_записи.[Дата и время], 102) > convert(varchar(10), getdate(), 102)) and(Пациенты.Login = '{loginn}')";
            SqlCommand journalCmd = new SqlCommand(dataQuery, MyConnection);
            Reader2 = journalCmd.ExecuteReader();
            while (Reader2.Read())
            {
                dataGridView1.Rows.Add(Reader2[0].ToString(), Reader2[1].ToString(), Reader2[2].ToString(), Reader2[3].ToString(), Reader2[4].ToString());
            }
            Reader2.Close();


            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Columns.Add("fio", "ФИО");
            dataGridView2.Columns.Add("fio", "ФИО");
            dataGridView2.Columns.Add("date", "Дата");
            dataGridView2.Columns.Add("name", "Наименование");
            dataGridView2.Columns.Add("price", "Итоговая цена");

            SqlDataReader Reader3;
            string oldDataQuery = $"select Пациенты.ФИО, Врачи.ФИО, Журнал_записи.[Дата и время], Услуги.Наименование, Услуги.Цена * Оказанные_услуги.Количество as 'Итоговая цена' from Пациенты inner join Журнал_записи on Пациенты.[ID пациента] = Журнал_записи.[ID пациента] inner join Врачи on Журнал_записи.[ID врача] = Врачи.[ID врача] inner join Оказанные_услуги on Журнал_записи.[Код записи] = Оказанные_услуги.[Код записи] inner join Услуги on Оказанные_услуги.[Код услуги] = Услуги.[Код услуги]where (Пациенты.login like '{loginn}') and (convert(varchar(10), Журнал_записи.[Дата и время], 102) < convert(varchar(10), getdate(), 102))";
            SqlCommand journalCmd1 = new SqlCommand(oldDataQuery, MyConnection);
            Reader3 = journalCmd1.ExecuteReader();
            while (Reader3.Read())
            {
                dataGridView2.Rows.Add(Reader3[0].ToString(), Reader3[1].ToString(), Reader3[2].ToString(), Reader3[3].ToString(), Reader3[4].ToString());
            }
            Reader3.Close();
            MyConnection.Close();
        }
    }
}

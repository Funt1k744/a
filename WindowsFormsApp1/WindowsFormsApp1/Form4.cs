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
    public partial class Form4 : Form
    {

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_419_4MostitckiyDataSet.Услуги". При необходимости она может быть перемещена или удалена.
            this.услугиTableAdapter.Fill(this._419_4MostitckiyDataSet.Услуги);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_419_4MostitckiyDataSet.Пациенты". При необходимости она может быть перемещена или удалена.
            this.пациентыTableAdapter.Fill(this._419_4MostitckiyDataSet.Пациенты);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_419_4MostitckiyDataSet.Оказанные_услуги". При необходимости она может быть перемещена или удалена.
            this.оказанные_услугиTableAdapter.Fill(this._419_4MostitckiyDataSet.Оказанные_услуги);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_419_4MostitckiyDataSet.Журнал_записи". При необходимости она может быть перемещена или удалена.
            this.журнал_записиTableAdapter.Fill(this._419_4MostitckiyDataSet.Журнал_записи);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_419_4MostitckiyDataSet.Врачи". При необходимости она может быть перемещена или удалена.
            this.врачиTableAdapter.Fill(this._419_4MostitckiyDataSet.Врачи);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_419_4MostitckiyDataSet.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this._419_4MostitckiyDataSet.Users);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-H6L7PB2\SQLEXPRESS;Initial Catalog=419/4Mostitckiy;Integrated Security=True";
            SqlConnection MyConnection = new SqlConnection(connectionString);

            string login = textBox1.Text;
            string password = textBox2.Text;
            string role = textBox3.Text;

            string addQuery = "INSERT INTO Users(Login, Password, Role) VALUES ('" + login + "','" + password + "'," + "'" + role + "')";

            SqlCommand addCmd = new SqlCommand(addQuery, MyConnection);
            MyConnection.Open();
            addCmd.ExecuteReader();
            MyConnection.Close();

            MessageBox.Show("Добавлено");
            this.usersTableAdapter.Fill(this._419_4MostitckiyDataSet.Users);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-H6L7PB2\SQLEXPRESS;Initial Catalog=419/4Mostitckiy;Integrated Security=True";
            SqlConnection MyConnection = new SqlConnection(connectionString);

            string fio = textBox4.Text;
            string post = textBox5.Text;
            string office = textBox6.Text;
            string category = textBox7.Text;

            string addQuery = "INSERT INTO Врачи(ФИО, Должность, Кабинет, Категория) VALUES ('" + fio + "','" + post + "','" + office + "','" + category + "')";

            SqlCommand addCmd = new SqlCommand(addQuery, MyConnection);
            MyConnection.Open();
            addCmd.ExecuteReader();
            MyConnection.Close();

            MessageBox.Show("Добавлено");
            this.врачиTableAdapter.Fill(this._419_4MostitckiyDataSet.Врачи);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            string connectionString = @"Data Source=DESKTOP-H6L7PB2\SQLEXPRESS;Initial Catalog=419/4Mostitckiy;Integrated Security=True";
            SqlConnection MyConnection = new SqlConnection(connectionString);

            string data = maskedTextBox1.Text;

            string addQuery = "INSERT INTO Журнал_записи(Дата и время) VALUES ('" + data + "')";

            SqlCommand addCmd = new SqlCommand(addQuery, MyConnection);
            MyConnection.Open();
            addCmd.ExecuteReader();
            MyConnection.Close();

            MessageBox.Show("Добавлено");
            this.журнал_записиTableAdapter.Fill(this._419_4MostitckiyDataSet.Журнал_записи);
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            string connectionString = @"Data Source=DESKTOP-H6L7PB2\SQLEXPRESS;Initial Catalog=419/4Mostitckiy;Integrated Security=True";
            SqlConnection MyConnection = new SqlConnection(connectionString);

            string number = textBox8.Text;

            string addQuery = "INSERT INTO Оказанные_услуги(Количество) VALUES ('" + number + "')";

            SqlCommand addCmd = new SqlCommand(addQuery, MyConnection);
            MyConnection.Open();
            addCmd.ExecuteReader();
            MyConnection.Close();

            MessageBox.Show("Добавлено");
            this.оказанные_услугиTableAdapter.Fill(this._419_4MostitckiyDataSet.Оказанные_услуги);
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-H6L7PB2\SQLEXPRESS;Initial Catalog=419/4Mostitckiy;Integrated Security=True";
            SqlConnection MyConnection = new SqlConnection(connectionString);

            string fio = textBox10.Text;
            string cardNumber = textBox11.Text;
            string passportNumber = textBox12.Text;
            string snils = textBox9.Text;
            string polis = textBox13.Text;
            string address = textBox14.Text;
            string phone = textBox15.Text;

            string addQuery = "INSERT INTO Пациенты(ФИО, [Номер карточки], [Номер паспорта], СНИЛС, Полис, Адрес, Телефон) VALUES ('" + fio + "','" + cardNumber + "','" + passportNumber + "','" + snils + "','" + polis + "','" + address + "','" + phone + "')";

            SqlCommand addCmd = new SqlCommand(addQuery, MyConnection);
            MyConnection.Open();
            addCmd.ExecuteReader();
            MyConnection.Close();

            MessageBox.Show("Добавлено");
            this.пациентыTableAdapter.Fill(this._419_4MostitckiyDataSet.Пациенты);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-H6L7PB2\SQLEXPRESS;Initial Catalog=419/4Mostitckiy;Integrated Security=True";
            SqlConnection MyConnection = new SqlConnection(connectionString);

            string name = textBox16.Text;
            string price = textBox17.Text;

            string addQuery = "INSERT INTO Услуги(Наименование, Цена) VALUES ('" + name + "','" + price + "')";

            SqlCommand addCmd = new SqlCommand(addQuery, MyConnection);
            MyConnection.Open();
            addCmd.ExecuteReader();
            MyConnection.Close();

            MessageBox.Show("Добавлено");
            this.услугиTableAdapter.Fill(this._419_4MostitckiyDataSet.Услуги);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            usersTableAdapter.Update(_419_4MostitckiyDataSet.Users);
            this.usersTableAdapter.Fill(this._419_4MostitckiyDataSet.Users);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            врачиTableAdapter.Update(_419_4MostitckiyDataSet.Врачи);
            this.врачиTableAdapter.Fill(this._419_4MostitckiyDataSet.Врачи);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            журнал_записиTableAdapter.Update(_419_4MostitckiyDataSet.Журнал_записи);
            this.журнал_записиTableAdapter.Fill(this._419_4MostitckiyDataSet.Журнал_записи);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            оказанные_услугиTableAdapter.Update(_419_4MostitckiyDataSet.Оказанные_услуги);
            this.оказанные_услугиTableAdapter.Fill(this._419_4MostitckiyDataSet.Оказанные_услуги);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            пациентыTableAdapter.Update(_419_4MostitckiyDataSet.Пациенты);
            this.пациентыTableAdapter.Fill(this._419_4MostitckiyDataSet.Пациенты);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            услугиTableAdapter.Update(_419_4MostitckiyDataSet.Услуги);
            this.услугиTableAdapter.Fill(this._419_4MostitckiyDataSet.Услуги);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-H6L7PB2\SQLEXPRESS;Initial Catalog=419/4Mostitckiy;Integrated Security=True";
            SqlConnection MyConnection = new SqlConnection(connectionString);

            string loginUser = textBox1.Text;
            string passwordUser = textBox2.Text;
            string roleUser = "user";

            string loginsQuery = "SELECT Login FROM Users";
            string addUserQuery = "INSERT INTO Users(Login, Password, Role) VALUES ('" + loginUser + "','" + passwordUser + "'," + "'" + roleUser + "')";

            SqlDataReader Reader1;
            SqlCommand loginCmd = new SqlCommand(loginsQuery, MyConnection);
            SqlCommand addUserCmd = new SqlCommand(addUserQuery, MyConnection);
            MyConnection.Open();
            Reader1 = loginCmd.ExecuteReader();
            while (Reader1.Read())
            {
                string login = Reader1[0].ToString();

                if (login == loginUser)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует");
                    return;
                }
            }
            Reader1.Close();
            addUserCmd.ExecuteReader();

            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}

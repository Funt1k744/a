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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-H6L7PB2\SQLEXPRESS;Initial Catalog=419/4Mostitckiy;Integrated Security=True";
            SqlConnection MyConnection = new SqlConnection(connectionString);

            string loginUser = textBox1.Text;
            string passwordUser = textBox2.Text;
            string roleSysadmin = "sysadmin";
            string roleAdmin = "admin";
            string roleUser = "user";  

            string loginsQuery = "SELECT * FROM Users";

            SqlDataReader Reader1;
            SqlCommand loginCmd = new SqlCommand(loginsQuery, MyConnection);
            MyConnection.Open();
            Reader1 = loginCmd.ExecuteReader();
            while (Reader1.Read())
            {
                string login = Reader1[0].ToString();
                string password = Reader1[1].ToString(); 
                string role = Reader1[2].ToString();

                if (login == loginUser && password == passwordUser)
                {
                    if(role == roleSysadmin)
                    {
                        Form4 form4 = new Form4();
                        form4.Show();
                        this.Hide();
                        return;
                    }

                    else if(role == roleAdmin) 
                    {
                        Form7 form7 = new Form7();
                        form7.Show();
                        this.Hide();
                        return;
                    }

                    else if(role == roleUser)
                    {
                        NameUser.nameUser = login;
                        Form5 form5 = new Form5();
                        form5.Show();
                        this.Hide();
                        return;
                    }

                }
            }
            MessageBox.Show("Неправильный пароль или логин");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WinFormsAppzz.Functions;

namespace WinFormsAppzz
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || txtPhoneNum.Text == "" || txtEmail.Text == "" || cbSex.Text == "")
            {
                MessageBox.Show("Thiếu thông tin");
            }
            else
            {
                try
                {

                    string sql = "";
                    int sex = 0;
                    DateTime createdOn = DateTime.Now;
                    if (cbSex.Text == "MALE")
                    {
                        sex = 1;
                    }
                    sql = "INSERT INTO customer(name, email, username, password, phone_number, role, sex, created_on) VALUES ('" + txtName.Text + "','" + txtEmail.Text + "', '" + txtUsername.Text + "', '" + txtPassword.Text + "','" + txtPhoneNum.Text + "', " + 0 + ", " + sex + ",'" + createdOn + "')";
                    Functions.Function.Connect();
                    Functions.Function.RunSQL(sql);
                    MessageBox.Show("Đăng kí thành công");
                    Nineshop nieshop = new Nineshop();
                    nieshop.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}

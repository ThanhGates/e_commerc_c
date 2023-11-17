using System.Data;
using System.Data.SqlClient;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsAppzz
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=BABYBOY2007\SQLEXPRESS;Initial Catalog = e_commerce; User ID =sa; Password = Thanh0706;Integrated Security=True");

        private void btnSignIn_Click(object sender, EventArgs e)
        {

            Functions.Function.Connect();
            String username, password;
            username = txtUsername.Text;
            password = txtPassword.Text;
            try
            {
                String query = "SELECT username, password, role, id FROM customer WHERE username = '" + txtUsername.Text + "' AND password = '" + txtPassword.Text + "'";
                DataTable dt = new DataTable();
                dt = Functions.Function.GetDataToTable(query);
                if (dt.Rows.Count > 0)
                {
                    int role = Convert.ToInt32(dt.Rows[0]["role"]);
                    Const.customerId = Convert.ToInt32(dt.Rows[0]["id"]);
                    if (role == 1)
                    {
                        AllFunction allFunctionForm = new AllFunction();
                        allFunctionForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        Nineshop nineshop = new Nineshop();
                        nineshop.Show();
                        this.Hide();
                    }

                }
                else
                {
                    MessageBox.Show("Invalid login", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Show();
            this.Hide();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace WinFormsAppzz
{
    public partial class CustomerForm : Form
    {
        private DataTable tblCL;
        Customer selectedCustomer;
        public CustomerForm()
        {
            InitializeComponent();
            Functions.Function.Connect();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || txtPhoneNum.Text == "" || txtEmail.Text == "" || cbRole.Text == "" || cbSex.Text == "")
            {
                MessageBox.Show("Thiếu thông tin");
            }
            else
            {
                try
                {
                    string sql = "";
                    int role = 0;
                    int sex = 0;
                    DateTime createdOn = DateTime.Now;
                    if (cbRole.Text == "ADMIN")
                    {
                        role = 1;
                    }
                    if (cbSex.Text == "MALE")
                    {
                        sex = 1;
                    }
                    sql = "INSERT INTO customer(name, email, username, password, phone_number, role, sex, created_on) VALUES ('" + txtName.Text + "','" + txtEmail.Text + "', '" + txtUsername.Text + "', '" + txtPassword.Text + "','" + txtPhoneNum.Text + "', " + role + ", " + sex + ",'" + createdOn + "')";
                    Functions.Function.RunSQL(sql);
                    MessageBox.Show("Thêm khách hàng thành công");
                    loadDataGridView();
                    ResetValue();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || txtPhoneNum.Text == "" || txtEmail.Text == "" || cbRole.Text == "" || cbSex.Text == "")
            {
                MessageBox.Show("Thiếu thông tin");
            }
            else
            {
                try
                {
                    string sql = "";
                    int role = 0;
                    int sex = 0;
                    DateTime createdOn = DateTime.Now;
                    if (cbRole.Text == "ADMIN")
                    {
                        role = 1;
                    }
                    if (cbSex.Text == "MALE")
                    {
                        sex = 1;
                    }
                    sql = "UPDATE CUSTOMER SET name = '" + txtName.Text + "', email = '" + txtEmail.Text + "', username = '" + txtUsername.Text + "', password = '" + txtPassword.Text + "', phone_number = '" + txtPhoneNum.Text + "', role = " + role + ", sex = " + sex + " WHERE id = " + txtId.Text;
                    Functions.Function.RunSQL(sql);
                    MessageBox.Show("Sửa thông tin người dùng thành công");
                    loadDataGridView();
                    ResetValue();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                loadDataGridView();
                return;
            }
            else
            {
                int id = Convert.ToInt16(txtId.Text);
                string sql;
                sql = "DELETE FROM customer where id = " + id;
                try
                {
                    Functions.Function.RunSQL(sql);
                    MessageBox.Show("Xóa người dùng thành công");
                    loadDataGridView();
                    ResetValue();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            findDataGridView();
        }

        private void findDataGridView()
        {
            if (txtId.Text == "")
            {
                loadDataGridView();
                return;
            }
            else
            {
                int id = Convert.ToInt16(txtId.Text);
                string sql;
                sql = "SELECT * FROM customer where id = " + id;
                tblCL = Functions.Function.GetDataToTable(sql);
                dgvCustomer.DataSource = tblCL;
                dgvCustomer.Columns["id"].HeaderText = "Id";
                dgvCustomer.Columns["email"].HeaderText = "Email";
                dgvCustomer.Columns["name"].HeaderText = "Tên khách hàng";
                dgvCustomer.Columns["username"].HeaderText = "Tài khoản";
                dgvCustomer.Columns["password"].HeaderText = "Mật khẩu";
                dgvCustomer.Columns["phone_number"].HeaderText = "Số điện thoại";
                dgvCustomer.Columns["role"].HeaderText = "Vai trò";
                dgvCustomer.Columns["sex"].HeaderText = "Giới tính";
                dgvCustomer.AllowUserToAddRows = false;
                dgvCustomer.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Functions.Function.Disconnect();
            AllFunction allFunctionForm = new AllFunction();
            allFunctionForm.Show();
            this.Hide();
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            retrieveCurrentRow(e);
        }

        private void dgvCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            retrieveCurrentRow(e);
        }

        private void load(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        private void loadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM customer";
            tblCL = Functions.Function.GetDataToTable(sql);
            dgvCustomer.DataSource = tblCL;
            dgvCustomer.Columns["id"].HeaderText = "Id";
            dgvCustomer.Columns["email"].HeaderText = "Email";
            dgvCustomer.Columns["name"].HeaderText = "Tên khách hàng";
            dgvCustomer.Columns["username"].HeaderText = "Tài khoản";
            dgvCustomer.Columns["password"].HeaderText = "Mật khẩu";
            dgvCustomer.Columns["phone_number"].HeaderText = "Số điện thoại";
            dgvCustomer.Columns["role"].HeaderText = "Vai trò";
            dgvCustomer.Columns["sex"].HeaderText = "Giới tính";
            dgvCustomer.AllowUserToAddRows = false;
            dgvCustomer.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        private void ResetValue()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtPhoneNum.Text = "";
            cbRole.Text = string.Empty;
            cbSex.Text = string.Empty;
        }
        private void retrieveCurrentRow(DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvCustomer.Rows[e.RowIndex];
            selectedCustomer = new Customer();
            selectedCustomer.id = long.Parse(dr.Cells["id"].Value.ToString());
            selectedCustomer.name = dr.Cells["name"].Value.ToString();
            selectedCustomer.email = dr.Cells["email"].Value.ToString();
            selectedCustomer.username = dr.Cells["username"].Value.ToString();
            selectedCustomer.password = dr.Cells["password"].Value.ToString();
            selectedCustomer.phoneNumber = dr.Cells["phone_number"].Value.ToString();
            selectedCustomer.sex = int.Parse(dr.Cells["sex"].Value.ToString());
            selectedCustomer.role = int.Parse(dr.Cells["role"].Value.ToString());

            if (selectedCustomer.role == 1)
            {
                cbRole.Text = "ADMIN";
            }
            else
            {
                cbRole.Text = "USER";
            }
            if (selectedCustomer.sex == 1)
            {
                cbSex.Text = "MALE";
            }
            else
            {
                cbSex.Text = "FEMALE";
            }
            txtId.Text = selectedCustomer.id.ToString();
            txtName.Text = selectedCustomer.name;
            txtEmail.Text = selectedCustomer.email;
            txtUsername.Text = selectedCustomer.username;
            txtPassword.Text = selectedCustomer.password;
            txtPhoneNum.Text = selectedCustomer.phoneNumber;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            Functions.Function.Disconnect();
            AllFunction allFunctionForm = new AllFunction();
            allFunctionForm.Show();
            this.Hide();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
//using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsAppzz
{
    public partial class DiscountForm : Form
    {
        private DataTable tblCL;
        private Discount selectedDiscount;
        public DiscountForm()
        {
            InitializeComponent();
            Functions.Function.Connect();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "" || txtQuantity.Text == "" || txtContent.Text == "" || txtDecrease.Text == "")
            {
                MessageBox.Show("Thiếu thông tin");
            }
            else
            {
                try
                {
                    string sql = "";
                    int type = 0;
                    if (cbType.Text == "đ")
                    {
                        type = 1;
                        sql = "INSERT INTO discount(code, content, discount_type, price, quantity) VALUES ('" + txtCode.Text + "','" + txtContent.Text + "'," + type + "," + float.Parse(txtDecrease.Text.ToString()) + ", " + int.Parse(txtQuantity.Text.ToString()) + ")";
                    }
                    else
                    {
                        sql = "INSERT INTO discount(code, content, discount_type, percentage, quantity) VALUES ('" + txtCode.Text + "','" + txtContent.Text + "'," + type + "," + float.Parse(txtDecrease.Text.ToString()) + ", " + int.Parse(txtQuantity.Text.ToString()) + ")";
                    }
                    Functions.Function.RunSQL(sql);
                    MessageBox.Show("Thêm mã giảm giá thành công");
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
            try
            {
                string sql = "";
                int type = 0;
                if (cbType.Text == "đ")
                {
                    type = 1;
                    sql = "update discount set code= '" + txtCode.Text + "',content = '" + txtContent.Text + "',quantity = " + int.Parse(txtQuantity.Text.ToString()) + ",discount_type = " + type + ", price =" + float.Parse(txtDecrease.Text.ToString()) + " where id = " + txtId.Text;
                }
                else
                {
                    sql = "update discount set code= '" + txtCode.Text + "',content = '" + txtContent.Text + "',quantity = " + int.Parse(txtQuantity.Text.ToString()) + ",discount_type = " + type + ", percentage =" + float.Parse(txtDecrease.Text.ToString()) + " where id = " + txtId.Text;
                }
                Functions.Function.RunSQL(sql);
                MessageBox.Show("Sửa mã giảm giá thành công");
                loadDataGridView();
                ResetValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                sql = "DELETE FROM discount where id = " + id;
                try
                {
                    Functions.Function.RunSQL(sql);
                    MessageBox.Show("Xóa mã giảm giá thành công");
                    loadDataGridView();
                    ResetValue();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Functions.Function.Disconnect();
            AllFunction allFunctionForm = new AllFunction();
            allFunctionForm.Show();
            this.Hide();
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
                sql = "SELECT * FROM discount where id = " + id;
                tblCL = Functions.Function.GetDataToTable(sql);
                dgvDiscount.DataSource = tblCL;
                dgvDiscount.Columns["id"].HeaderText = "Id";
                dgvDiscount.Columns["code"].HeaderText = "Mã";
                dgvDiscount.Columns["quantity"].HeaderText = "Số lượng";
                dgvDiscount.Columns["content"].HeaderText = "Nội dung";
                dgvDiscount.Columns["discount_type"].HeaderText = "Kiểu";
                dgvDiscount.Columns["percentage"].HeaderText = "Giảm";
                dgvDiscount.Columns["price"].HeaderText = "Giảm";
                dgvDiscount.AllowUserToAddRows = false;
                dgvDiscount.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
        }

        private void loadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM discount";
            tblCL = Functions.Function.GetDataToTable(sql);
            dgvDiscount.DataSource = tblCL;
            dgvDiscount.Columns["id"].HeaderText = "Id";
            dgvDiscount.Columns["code"].HeaderText = "Mã";
            dgvDiscount.Columns["quantity"].HeaderText = "Số lượng";
            dgvDiscount.Columns["content"].HeaderText = "Nội dung";
            dgvDiscount.Columns["discount_type"].HeaderText = "Kiểu";
            dgvDiscount.Columns["percentage"].HeaderText = "Giảm";
            dgvDiscount.Columns["price"].HeaderText = "Giảm";
            dgvDiscount.AllowUserToAddRows = false;
            dgvDiscount.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValue()
        {
            txtId.Text = "";
            txtCode.Text = "";
            txtContent.Text = "";
            txtQuantity.Text = "";
            txtDecrease.Text = "";
        }
        private void discount_cellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            retrieveCurrentRow(e);

        }

        private void discount_rowEnter(object sender, DataGridViewCellEventArgs e)
        {
            retrieveCurrentRow(e);

        }

        private void retrieveCurrentRow(DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvDiscount.Rows[e.RowIndex];
            selectedDiscount = new Discount();
            selectedDiscount.Id = long.Parse(dr.Cells["id"].Value.ToString());
            selectedDiscount.Code = dr.Cells["code"].Value.ToString();
            selectedDiscount.DiscountType = int.Parse(dr.Cells["discount_type"].Value.ToString());
            selectedDiscount.Quantity = int.Parse(dr.Cells["quantity"].Value.ToString());
            selectedDiscount.content = dr.Cells["content"].Value.ToString();
            int type = selectedDiscount.DiscountType;

            txtId.Text = selectedDiscount.Id.ToString();
            txtCode.Text = selectedDiscount.Code.ToString();
            txtQuantity.Text = selectedDiscount.Quantity.ToString();
            if (type == 1)
            {
                selectedDiscount.Price = double.Parse(dr.Cells["price"].Value.ToString());
                txtDecrease.Text = selectedDiscount.Price.ToString();
            }
            else
            {
                selectedDiscount.Percentage = double.Parse(dr.Cells["percentage"].Value.ToString());
                txtDecrease.Text = selectedDiscount.Percentage.ToString();
            }
            txtContent.Text = selectedDiscount.content;
        }

        private void load(object sender, EventArgs e)
        {
            loadDataGridView();
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

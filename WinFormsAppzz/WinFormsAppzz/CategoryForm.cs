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

namespace WinFormsAppzz
{
    public partial class CategoryForm : Form
    {
        private DataTable tblCL;
        private Category selectedCategory;

        public CategoryForm()
        {
            InitializeComponent();
            Functions.Function.Connect();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Functions.Function.Disconnect();
            AllFunction allFunctionForm = new AllFunction();
            allFunctionForm.Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Thiếu thông tin");
            }
            else
            {
                string name = txtName.Text;
                string content = txtContent.Text;
                DateTime createdOn = DateTime.Now;
                try
                {
                    string sql = "INSERT INTO category(name, content, created_on) VALUES ('" + name + "','" + content + "','" + createdOn + "')";
                    Functions.Function.RunSQL(sql);
                    MessageBox.Show("Thêm danh mục sản phẩm thành công");
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
            string name = txtName.Text;
            string content = txtContent.Text;
            DateTime updated_on = DateTime.Now;
            try
            {
                string sql = "update category set name= '" + name + "',content = '" + content + "',updated_on = '" + updated_on + "' where id = " + txtId.Text;
                Functions.Function.RunSQL(sql);
                MessageBox.Show("Sửa danh mục sản phẩm thành công");
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
                sql = "DELETE FROM category where id = " + id;
                try
                {
                    Functions.Function.RunSQL(sql);
                    MessageBox.Show("Xóa danh mục sản phẩm thành công");
                    loadDataGridView();
                    ResetValue();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void loadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM category";
            tblCL = Functions.Function.GetDataToTable(sql);
            dgvCategory.DataSource = tblCL;
            dgvCategory.Columns["id"].HeaderText = "Mã";
            dgvCategory.Columns["name"].HeaderText = "Tên danh mục";
            dgvCategory.Columns["content"].HeaderText = "Nội dung";
            dgvCategory.Columns["created_on"].HeaderText = "Tạo ngày";
            dgvCategory.Columns["updated_on"].HeaderText = "Sửa ngày";
            dgvCategory.AllowUserToAddRows = false;
            dgvCategory.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValue()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtContent.Text = "";
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
                sql = "SELECT * FROM category where id = " + id;
                tblCL = Functions.Function.GetDataToTable(sql);
                dgvCategory.DataSource = tblCL;
                dgvCategory.Columns["id"].HeaderText = "Mã";
                dgvCategory.Columns["name"].HeaderText = "Tên danh mục";
                dgvCategory.Columns["content"].HeaderText = "Nội dung";
                dgvCategory.Columns["created_on"].HeaderText = "Tạo ngày";
                dgvCategory.Columns["updated_on"].HeaderText = "Sửa ngày";
                dgvCategory.AllowUserToAddRows = false;
                dgvCategory.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            findDataGridView();
        }

        private void dgvCategoryCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            retrieveCurrentRow(e);
        }

        private void dgvCategoryRowEnter(object sender, DataGridViewCellEventArgs e)
        {
            retrieveCurrentRow(e);
        }
        private void retrieveCurrentRow(DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvCategory.Rows[e.RowIndex];
            selectedCategory = new Category();
            selectedCategory.id = long.Parse(dr.Cells["id"].Value.ToString());
            selectedCategory.name = dr.Cells["name"].Value.ToString();
            selectedCategory.content = dr.Cells["content"].Value.ToString();

            txtId.Text = selectedCategory.id.ToString();
            txtName.Text = selectedCategory.name;
            txtContent.Text = selectedCategory.content;
        }

        private void load(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

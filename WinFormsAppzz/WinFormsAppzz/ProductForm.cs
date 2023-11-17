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
using System.Xml.Linq;
using WinFormsAppzz.Functions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsAppzz
{
    public partial class ProductForm : Form
    {
        Product selectedProduct;
        DataTable tblCL;
        DataTable tblCategory;
        public ProductForm()
        {
            InitializeComponent();
            Functions.Function.Connect();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPrice.Text == "" || txtImage.Text == "" || txtContent.Text == "" || txtQuantity.Text == "")
            {
                MessageBox.Show("Thiếu thông tin sản phẩm");
            }
            else
            {
                string name = txtName.Text;
                decimal price = Convert.ToDecimal(txtPrice.Text);
                string imageUrl = txtImage.Text;
                string content = txtContent.Text;
                int quantity = Convert.ToInt32(txtQuantity.Text);
                DateTime createdOn = DateTime.Now;

                try
                {
                    string sql = "INSERT INTO product(name, price, image_url, content, quantity, created_on) VALUES ('" + name + "', " + price + ",'" + imageUrl + "','" + content + "'," + quantity + ",'" + createdOn + "')";
                    Functions.Function.RunSQL(sql);
                    MessageBox.Show("Thêm sản phẩm thành công");
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
            decimal price = Convert.ToDecimal(txtPrice.Text);
            string imageUrl = txtImage.Text;
            string content = txtContent.Text;
            int quantity = Convert.ToInt32(txtQuantity.Text);
            int soldQuantity = Convert.ToInt32(txtSoldQuantity.Text);
            decimal discountPrice = Convert.ToDecimal(txtDiscountPrice.Text);
            DateTime updated_on = DateTime.Now;

            try
            {
                string sql = "update product set name= '" + name + "', price = " + price + ", image_url='" + imageUrl + "',content = '" + content + "',quantity = " + quantity + ",sold_quantity = " + soldQuantity + ",discount_price = " + discountPrice + ", updated_on = '" + updated_on + "', category_id = " + cbCategory.SelectedValue.ToString() + " where id = " + txtId.Text;
                Functions.Function.RunSQL(sql);
                MessageBox.Show("Sửa sản phẩm thành công");
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
                sql = "DELETE FROM product where id = " + id;
                try
                {
                    Functions.Function.RunSQL(sql);
                    MessageBox.Show("Xóa sản phẩm thành công");
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

        private void load(object sender, EventArgs e)
        {
            loadDataGridView();
        }
        private void loadDataGridView()
        {
            string sql;
            sql = "select p.id, p.name, p.price, p.image_url, p.quantity, p.content, p.sold_quantity, p.discount_price, p.created_on, p.updated_on, c.content from product p left join category c on p.category_id = c.id";
            tblCL = Functions.Function.GetDataToTable(sql);
            dgvProduct.DataSource = tblCL;
            dgvProduct.Columns[0].HeaderText = "Mã";
            dgvProduct.Columns[1].HeaderText = "Tên sản phẩm";
            dgvProduct.Columns[2].HeaderText = "Giá sản phẩm";
            dgvProduct.Columns[3].HeaderText = "Link ảnh";
            dgvProduct.Columns[4].HeaderText = "Số lượng";
            dgvProduct.Columns[5].HeaderText = "Nội dung";
            dgvProduct.Columns[6].HeaderText = "Số lượng bán";
            dgvProduct.Columns[7].HeaderText = "Giá giảm";
            dgvProduct.Columns[8].HeaderText = "Tạo ngày";
            dgvProduct.Columns[9].HeaderText = "Sửa ngày";
            dgvProduct.Columns[10].HeaderText = "Danh mục";
            dgvProduct.AllowUserToAddRows = false;
            dgvProduct.EditMode = DataGridViewEditMode.EditProgrammatically;

            tblCategory = Functions.Function.GetDataToTable("SELECT id, name FROM category");
            cbCategory.DataSource = tblCategory;
            cbCategory.DisplayMember = "name";
            cbCategory.ValueMember = "id";
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
                sql = "SELECT * FROM product where id = " + id;
                tblCL = Functions.Function.GetDataToTable(sql);
                dgvProduct.DataSource = tblCL;
                dgvProduct.Columns[0].HeaderText = "Mã";
                dgvProduct.Columns[1].HeaderText = "Tên sản phẩm";
                dgvProduct.Columns[2].HeaderText = "Giá sản phẩm";
                dgvProduct.Columns[3].HeaderText = "Link ảnh";
                dgvProduct.Columns[4].HeaderText = "Số lượng";
                dgvProduct.Columns[5].HeaderText = "Nội dung";
                dgvProduct.Columns[6].HeaderText = "Số lượng bán";
                dgvProduct.Columns[7].HeaderText = "Giá giảm";
                dgvProduct.Columns[8].HeaderText = "Tạo ngày";
                dgvProduct.Columns[9].HeaderText = "Sửa ngày";
                dgvProduct.Columns[10].HeaderText = "Danh mục";
                dgvProduct.AllowUserToAddRows = false;
                dgvProduct.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
        }
        private void ResetValue()
        {
            txtName.Text = "";
            txtPrice.Text = "";
            txtImage.Text = "";
            txtContent.Text = "";
            txtDiscountPrice.Text = "";
            txtQuantity.Text = "";
        }



        private void btnFind_Click(object sender, EventArgs e)
        {
            findDataGridView();

        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            retrieveCurrentRow(e);
        }

        private void cbCategory_index(object sender, EventArgs e)
        {

        }

        private void dgv_productRowEnter(object sender, DataGridViewCellEventArgs e)
        {
            retrieveCurrentRow(e);
        }
        private void retrieveCurrentRow(DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvProduct.Rows[e.RowIndex];
            selectedProduct = new Product();
            selectedProduct.id = long.Parse(dr.Cells["id"].Value.ToString());
            selectedProduct.name = dr.Cells["name"].Value.ToString();
            selectedProduct.imageUrl = dr.Cells["image_url"].Value.ToString();
            selectedProduct.content = dr.Cells["content"].Value.ToString();
            selectedProduct.price = long.Parse(dr.Cells["price"].Value.ToString());
            selectedProduct.quantity = int.Parse(dr.Cells["quantity"].Value.ToString());

            txtId.Text = selectedProduct.id.ToString();
            txtName.Text = selectedProduct.name;
            txtImage.Text = selectedProduct.imageUrl;
            txtContent.Text = selectedProduct.content;
            txtPrice.Text = selectedProduct.price.ToString();
            txtQuantity.Text = selectedProduct.quantity.ToString();
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

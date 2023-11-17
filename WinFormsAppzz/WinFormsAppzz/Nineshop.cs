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
    public partial class Nineshop : Form
    {
        Product selectedProduct;
        DataTable tblCL;
        public Nineshop()
        {
            InitializeComponent();
            Functions.Function.Connect();
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            CartForm cartForm = new CartForm();
            cartForm.Show();
            this.Hide();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            retrieveCurrentRow(e);

        }

        private void Nineshop_load(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        private void dgvProduct_RowEnter(object sender, DataGridViewCellEventArgs e)
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
        }



        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (selectedProduct.quantity < int.Parse(txtQuantity.Text))
            {
                MessageBox.Show("Lỗi!");
            }
            else
            {
                String query = "INSERT INTO cart_item(quantity, product_id, user_id) VALUES (" + int.Parse(txtQuantity.Text) + "," + selectedProduct.id + "," + Const.customerId + ")";
                Functions.Function.RunSQL(query);
                MessageBox.Show("Thêm sản phẩm thành công vào giỏ hàng");
            }
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
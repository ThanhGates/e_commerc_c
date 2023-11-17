using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace WinFormsAppzz
{
    public partial class CartForm : Form
    {
        private DataTable dt;
        private CartItem ci;

        public CartForm()
        {
            InitializeComponent();
            Functions.Function.Connect();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Nineshop nineshop = new Nineshop();
            nineshop.Show();
            this.Hide();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm();
            orderForm.Show();
            this.Hide();
        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        private void loadDataGridView()
        {
            string sql;
            sql = "  SELECT c.id, p.name, p.price, p.discount_price, c.quantity, ca.content, p.id FROM cart_item c inner join (product p inner join category ca on p.category_id = ca.id)  on c.product_id = p.id";
            dt = Functions.Function.GetDataToTable(sql);
            dgvProduct.DataSource = dt;
            dgvProduct.Columns[0].HeaderText = "Id";
            dgvProduct.Columns[1].HeaderText = "Tên sản phẩm";
            dgvProduct.Columns[2].HeaderText = "Giá sản phẩm";
            dgvProduct.Columns[3].HeaderText = "Gía giảm";
            dgvProduct.Columns[4].HeaderText = "Số lượng";
            dgvProduct.Columns[5].HeaderText = "Danh mục";
            dgvProduct.Columns[6].HeaderText = "ID sản phẩm";
            dgvProduct.AllowUserToAddRows = false;
            dgvProduct.EditMode = DataGridViewEditMode.EditProgrammatically;
            decimal sum = 0;
            foreach (DataRow row in dt.Rows)
            {
                decimal productPrice = Convert.ToDecimal(row["discount_price"] != DBNull.Value ? row["discount_price"] : row["price"]);
                int quantity = Convert.ToInt32(row["quantity"]);
                sum += productPrice * quantity;
            }
            Const.order.subTotal = sum;
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            retrieveCurrentRow(e);
        }

        private void dgvProduct_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            retrieveCurrentRow(e);
        }

        private void retrieveCurrentRow(DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvProduct.Rows[e.RowIndex];
            ci = new CartItem();
            ci.Id = Convert.ToInt32(dr.Cells[0].Value);
            ci.productId = Convert.ToInt32(dr.Cells[6].Value);
            ci.userId = Const.customerId;
            txtQuantity.Text = ci.quantity.ToString();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "")
            {
                MessageBox.Show("Thiếu thông tin về số lượng!");
            }
            else
            {
                try
                {
                    string sql = "";
                    sql = "UPDATE cart_item SET quantity = " + int.Parse(txtQuantity.Text) + " WHERE id = " + ci.Id;
                    Functions.Function.RunSQL(sql);
                    MessageBox.Show("Sửa thông tin giỏ hàng thành công");
                    loadDataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "DELETE FROM cart_item where id = " + ci.Id;
            try
            {
                Functions.Function.RunSQL(sql);
                MessageBox.Show("Xóa người dùng thành công");
                loadDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

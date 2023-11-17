using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAppzz
{
    public partial class OrderItemForm : Form
    {
        public OrderItemForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Orders loginForm = new Orders();
            loginForm.Show();
            this.Hide();
        }

        private void OrderItemForm_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT order_id, name, price, image_url, quantity FROM order_item WHERE order_id = " + Const.orderId;
            DataTable tblCL = Functions.Function.GetDataToTable(sql);
            dgvOrderItem.DataSource = tblCL;
            dgvOrderItem.Columns["order_id"].HeaderText = "Id đơn hàng";
            dgvOrderItem.Columns["name"].HeaderText = "Tên sản phẩm";
            dgvOrderItem.Columns["price"].HeaderText = "Giá sản phẩm";
            dgvOrderItem.Columns["image_url"].HeaderText = "Link ảnh";
            dgvOrderItem.Columns["quantity"].HeaderText = "Số lượng đặt";
            dgvOrderItem.AllowUserToAddRows = false;
            dgvOrderItem.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
    }
}

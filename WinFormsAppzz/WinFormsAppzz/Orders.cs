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
    public partial class Orders : Form
    {
        DataTable dt;
        public Orders()
        {
            InitializeComponent();
            Functions.Function.Connect();
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            retrieveCurrentRow(e);
        }

        private void dgvOrders_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            retrieveCurrentRow(e);
        }

        private void retrieveCurrentRow(DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvOrders.Rows[e.RowIndex];
            Const.orderId = Convert.ToInt32(dr.Cells[0].Value);
            txtId.Text = Const.order.id.ToString();
        }
        private void loadDataGridView()
        {
            string sql;
            sql = " SELECT id, firstname, lastname, mobile, email, address, district, province, city, sub_total, shipping_price, grand_total FROM order_info";
            dt = Functions.Function.GetDataToTable(sql);
            dgvOrders.DataSource = dt;
            dgvOrders.Columns[0].HeaderText = "Id";
            dgvOrders.Columns[1].HeaderText = "Họ";
            dgvOrders.Columns[2].HeaderText = "Tên";
            dgvOrders.Columns[3].HeaderText = "Số điện thoại";
            dgvOrders.Columns[4].HeaderText = "Email";
            dgvOrders.Columns[5].HeaderText = "Địa chỉ";
            dgvOrders.Columns[6].HeaderText = "Thị trấn";
            dgvOrders.Columns[7].HeaderText = "Quận/Huyện";
            dgvOrders.Columns[8].HeaderText = "Thành phố";
            dgvOrders.Columns[9].HeaderText = "Giá trị đơn hàng";
            dgvOrders.Columns[10].HeaderText = "Giá ship";
            dgvOrders.Columns[11].HeaderText = "Tổng";
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            loadDataGridView();
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
                sql = " SELECT id, firstname, lastname, mobile, email, address, district, province, city, sub_total, shipping_price, grand_total FROM order_info where id = " + id;
                dt = Functions.Function.GetDataToTable(sql);
                dgvOrders.DataSource = dt;
                dgvOrders.Columns[0].HeaderText = "Id";
                dgvOrders.Columns[1].HeaderText = "Họ";
                dgvOrders.Columns[2].HeaderText = "Tên";
                dgvOrders.Columns[3].HeaderText = "Số điện thoại";
                dgvOrders.Columns[4].HeaderText = "Email";
                dgvOrders.Columns[5].HeaderText = "Địa chỉ";
                dgvOrders.Columns[6].HeaderText = "Thị trấn";
                dgvOrders.Columns[7].HeaderText = "Quận/Huyện";
                dgvOrders.Columns[8].HeaderText = "Thành phố";
                dgvOrders.Columns[9].HeaderText = "Giá trị đơn hàng";
                dgvOrders.Columns[10].HeaderText = "Giá ship";
                dgvOrders.Columns[11].HeaderText = "Tổng";
                dgvOrders.AllowUserToAddRows = false;
                dgvOrders.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
        }

        private void btnSearchInfo_Click(object sender, EventArgs e)
        {
            OrderItemForm loginForm = new OrderItemForm();
            loginForm.Show();
            this.Hide();
        }

        /// <summary>
        /// private void btnBack_Click(object sender, EventArgs e)
        ///{
        ///    AllFunction loginForm = new AllFunction();
        ///    loginForm.Show();
        ///    this.Hide();
        ///}
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    private void btnBack_Click_1(object sender, EventArgs e)
        {
            Functions.Function.Disconnect();
            AllFunction allFunctionForm = new AllFunction();
            allFunctionForm.Show();
            this.Hide();
        }

        private void btnSearchInfo_Click_1(object sender, EventArgs e)
        {
            OrderItemForm orderItemForm = new OrderItemForm();
            orderItemForm.Show();
            this.Hide();
        }
    }
}

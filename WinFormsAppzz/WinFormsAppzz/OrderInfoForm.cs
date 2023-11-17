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

namespace WinFormsAppzz
{
    public partial class OrderInfoForm : Form
    {
        public OrderInfoForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                Const.order.grandTotal = Const.order.subTotal + Const.order.shippingPrice;
                string sql = "INSERT INTO order_info(firstname, lastname, mobile, email, address, district, province, city, sub_total, shipping_price, grand_total) VALUES ('" + Const.order.firstname + "','" + Const.order.lastname + "','" + Const.order.mobile + "','" + Const.order.email + "','" + Const.order.address + "','" + Const.order.district + "','" + Const.order.province + "','" + Const.order.city + "'," + Const.order.subTotal + "," + Const.order.shippingPrice + "," + Const.order.grandTotal + ")";
                Functions.Function.RunSQL(sql);
                MessageBox.Show("Đặt hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Nineshop nineshop = new Nineshop();
                nineshop.Show();
                this.Hide();
                string sql2 = "SELECT TOP 1 id FROM order_info ORDER BY id DESC";
                DataTable d = Functions.Function.GetDataToTable(sql2);
                Const.order.id = Convert.ToInt32(d.Rows[0]["id"]);
                string sql1 = "  SELECT c.id, p.name, p.price, p.discount_price, p.image_url, c.quantity, ca.content, p.id FROM cart_item c inner join (product p inner join category ca on p.category_id = ca.id)  on c.product_id = p.id";
                DataTable dtProductIds = Functions.Function.GetDataToTable(sql1);
                foreach (DataRow row in dtProductIds.Rows)
                {
                    // Lấy thông tin từ mỗi dòng để thêm vào bảng order_item
                    int productId = Convert.ToInt32(row["id"]);
                    string productName = row["name"].ToString();
                    decimal productPrice = Convert.ToDecimal(row["discount_price"] != DBNull.Value ? row["discount_price"] : row["price"]);
                    int quantity = Convert.ToInt32(row["quantity"]);
                    string imageUrl = row["image_url"].ToString();
                    decimal totalPrice = productPrice * quantity;

                    // Thực hiện truy vấn INSERT INTO để thêm dữ liệu vào bảng order_item
                    string insertSql = "INSERT INTO order_item ([name], [price], [quantity], [total_price], [order_id], [image_url]) " +
                                       $"VALUES ('{productName}', {productPrice}, {quantity}, {totalPrice}, {Const.order.id}, '{imageUrl}')";

                    // Thực hiện truy vấn
                    Functions.Function.RunSQL(insertSql);
                }
                string sql3 = "SELECT * FROM order_info";
                string strConnectString = System.Configuration.ConfigurationSettings.AppSettings[""].ToString();
                SqlConnection myConnection = new SqlConnection(strConnectString);
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(sql3, myConnection);
                SqlDataAdapter da = new SqlDataAdapter(myCommand);
                DataSet dt = new DataSet();
                da.Fill(dt,"order_info");
                //Gán dữ liệu cho Crystal Report
                rptOrderForms orderForms = new rptOrderForms();
                orderForms.SetDataSource(dt);
                //Hiển thị báo cáo
                PrintOrder printOrder = new PrintOrder();
                printOrder.crystalReportViewer1.ReportSource = orderForms;
                printOrder.ShowDialog();
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đặt hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OrderInfoForm_Load(object sender, EventArgs e)
        {
            sub.Text = Const.order.subTotal.ToString();
            grand.Text = (Const.order.subTotal + Const.order.shippingPrice).ToString();
            ship.Text = Const.order.shippingPrice.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm();
            orderForm.Show();
            this.Hide();
        }

        private void OrderInfoForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}

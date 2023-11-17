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
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Nineshop nineshop = new Nineshop();
            nineshop.Show();
            this.Hide();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Const.order.firstname = txtFirstname.Text;
            Const.order.lastname = txtLastname.Text;
            Const.order.mobile = txtPhoneNumber.Text;
            Const.order.email = txtEmail.Text;
            Const.order.discount = txtDiscount.Text;
            Const.order.address = txtAddress.Text;
            Const.order.district = txtDistrict.Text;
            Const.order.province = txtProvince.Text;
            Const.order.city = txtCity.Text;
            OrderInfoForm orderInfoForm = new OrderInfoForm();
            orderInfoForm.Show();
            this.Hide();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            Functions.Function.Disconnect();
            Nineshop nineshop = new Nineshop();
            nineshop.Show(); 
            this.Hide();
        }
    }
}

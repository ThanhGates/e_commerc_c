using System.Drawing;
using System.Windows.Forms;

namespace WinFormsAppzz
{
    partial class OrderInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.sub = new System.Windows.Forms.Label();
            this.ship = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grand = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Giá trị đơn hàng:";
            // 
            // sub
            // 
            this.sub.AutoSize = true;
            this.sub.Location = new System.Drawing.Point(228, 64);
            this.sub.Name = "sub";
            this.sub.Size = new System.Drawing.Size(44, 16);
            this.sub.TabIndex = 1;
            this.sub.Text = "label2";
            // 
            // ship
            // 
            this.ship.AutoSize = true;
            this.ship.Location = new System.Drawing.Point(228, 101);
            this.ship.Name = "ship";
            this.ship.Size = new System.Drawing.Size(44, 16);
            this.ship.TabIndex = 3;
            this.ship.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Giá ship:";
            // 
            // grand
            // 
            this.grand.AutoSize = true;
            this.grand.Location = new System.Drawing.Point(228, 137);
            this.grand.Name = "grand";
            this.grand.Size = new System.Drawing.Size(44, 16);
            this.grand.TabIndex = 7;
            this.grand.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(82, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Tổng giá trị đơn hàng:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(77, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 37);
            this.button1.TabIndex = 8;
            this.button1.Text = "Đặt hàng";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(107, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 32);
            this.label2.TabIndex = 9;
            this.label2.Text = "Giá trị hóa đơn";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(188, 168);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(96, 37);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Quay lại";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // OrderInfoForm
            // 
            this.ClientSize = new System.Drawing.Size(401, 226);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grand);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ship);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sub);
            this.Controls.Add(this.label1);
            this.Name = "OrderInfoForm";
            this.Text = "OrderInfoForm";
            this.Load += new System.EventHandler(this.OrderInfoForm_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label sub;
        private Label ship;
        private Label label4;
        private Label grand;
        private Label label8;
        private Button button1;
        private Label label2;
        private Button btnBack;
    }
}
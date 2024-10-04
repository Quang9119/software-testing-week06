using Buoi07_TinhToan3.FixBug_Quang_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi07_TinhToan3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSo1.Text = txtSo2.Text = "0";
            radCong.Checked = true;             //đầu tiên chọn phép cộng
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có thực sự muốn thoát không?",
                                 "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            //lấy giá trị của 2 ô số
            double so1, so2, kq = 0;
            TextBox invalidTextBox;
            if (!FixInputValidator.ValidateInput(txtSo1, txtSo2, out invalidTextBox))
            {
                // Đặt focus và chọn toàn bộ nội dung của ô nhập bị lỗi
                invalidTextBox.Focus();
                invalidTextBox.SelectAll();
                return;
            }
            if (FixInputValidator.IsFraction(txtSo1.Text))
            {
                // Chuyển đổi phân số từ chuỗi sang kiểu double
                so1 = FixInputValidator.ConvertFractionToDouble(txtSo1.Text);
            }
            else
            {
                // Chuyển đổi trực tiếp nếu không phải phân số
                so1 = double.Parse(txtSo1.Text);
            }

            // Kiểm tra nếu nhập là phân số cho txtSo2
            if (FixInputValidator.IsFraction(txtSo2.Text))
            {
                // Chuyển đổi phân số từ chuỗi sang kiểu double
                so2 = FixInputValidator.ConvertFractionToDouble(txtSo2.Text);
            }
            else
            {
                // Chuyển đổi trực tiếp nếu không phải phân số
                so2 = double.Parse(txtSo2.Text);
            }
            //Thực hiện phép tính dựa vào phép toán được chọn
            if (radCong.Checked) kq = so1 + so2;
            else if (radTru.Checked) kq = so1 - so2;
            else if (radNhan.Checked) kq = so1 * so2;
            else if (radChia.Checked && so2 != 0) kq = so1 / so2;
            //Hiển thị kết quả lên trên ô kết quả
            txtKq.Text = kq.ToString();
        }

        private void txtSo1_Leave(object sender, EventArgs e)
        {
            checkInputValidation(txtSo1);
        }

        private void txtSo2_Leave(object sender, EventArgs e)
        {
            checkInputValidation(txtSo1);
        }

        private void checkInputValidation(TextBox textBox)
        {
            string inputText = textBox.Text;
            if (string.IsNullOrWhiteSpace(inputText) || !double.TryParse(inputText, out _))
            {
                MessageBox.Show("Vui lòng nhập giá trị phù hợp!");
                textBox.Focus();
            }
        }
    }
}

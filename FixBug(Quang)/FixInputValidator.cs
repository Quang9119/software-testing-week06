using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi07_TinhToan3.FixBug_Quang_
{
    internal class FixInputValidator
    {
        public static bool ValidateInput(TextBox txtSo1, TextBox txtSo2, out TextBox invalidTextBox)
        {
            if (txtSo1.Text.Contains(","))
            {
                invalidTextBox = txtSo1;
                MessageBox.Show("Dữ liệu không hợp lệ: Vui lòng thay đổi dấu ',' thành dấu '.'", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtSo2.Text.Contains(","))
            {
                invalidTextBox = txtSo2;
                MessageBox.Show("Dữ liệu không hợp lệ: Vui lòng thay đổi dấu ',' thành dấu '.'", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            invalidTextBox = null;
            return true;
        }
        
        public static bool IsFraction(string input)
        {

            return input.Contains("/") && input.Split('/').Length == 2;
        }
        public static double ConvertFractionToDouble(string fraction)
        {
            string[] parts = fraction.Split('/');
            double numerator = double.Parse(parts[0]);
            double denominator = double.Parse(parts[1]);

            // Kiểm tra nếu mẫu số không bằng 0
            if (denominator == 0)
            {
                MessageBox.Show("Dữ liệu không hợp lệ: Vui lòng nhập phân số có mẫu số khác 0", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return numerator / denominator;
        }
    }
}

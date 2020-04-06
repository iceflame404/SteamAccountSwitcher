using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void about_Load(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "    本软件仅用于各位玩友交流使用，转载请注明出处与作者，谢绝任何二进制形式的修改，请保持起码的尊重！";
            //this.richTextBox2.Text = "  作\r  者\r  的扫\r  红一\r  包扫\r  码吧\r    ！";
            this.richTextBox2.Text = "支付宝打赏请扫右边！\r\r动森沉迷\r6016 5047 1238";
        }

    }
}

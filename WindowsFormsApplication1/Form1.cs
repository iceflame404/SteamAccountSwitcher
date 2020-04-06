using System.Reflection;
[assembly: AssemblyVersionAttribute("1.4.2.0")]


namespace WindowsFormsApplication1
{
    using Microsoft.Win32;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    //using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    //using WindowsFormsApplication1.Properties;



    public class Form1 : Form
    {
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private CheckBox checkBox1;
        private ComboBox comboBox1;
        private IContainer components = null;
        private ContextMenuStrip contextMenuStrip1;
        public const int HTCAPTION = 2;
        private Label label1;
        private NotifyIcon notifyIcon1;
        public const int SC_MOVE = 0xf010;
        private TextBox textBox1;
        public const int WM_SYSCOMMAND = 0x112;
        private ToolStripMenuItem 退出ToolStripMenuItem;
        private ComboBox comboBox2;
        private Button button6;
        private Label label3;
        private Label label4;
        private ToolStripMenuItem 显示ToolStripMenuItem;

        public Form1()
        {
            this.InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Process[] process = Process.GetProcesses();            //
            foreach (Process prc in process)                       //
            {                                                      //
                Console.WriteLine(prc.ProcessName);                //
                if (prc.ProcessName == "steam")                    //
                    prc.Kill();                                    //杀死当前steam
            }                                                      //

            string text = this.comboBox1.Text;
            this.WTRegedit("AutoLoginUser", text);
            this.killProcess();
            Process.Start(this.textBox1.Text ," " + this.comboBox2.Text);
            if (this.checkBox1.Checked)
            {
                this.button4_Click(sender, e);
            }
            else
            {
                base.WindowState = FormWindowState.Minimized;
                base.ShowInTaskbar = false;
                this.notifyIcon1.Visible = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //new about().Show();
            Form f2 = new about(); //参数得看 Form2 的构造函数怎么写的了
            f2.ShowDialog();
            //string registData = this.GetRegistData(this.registData);   //选择steam路径
            //OpenFileDialog dialog = new OpenFileDialog();
            //dialog.ShowDialog();
            //registData = dialog.FileName;
            //this.textBox1.Text = registData;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Minimized;
            base.ShowInTaskbar = false;
            this.notifyIcon1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Minimized;
            this.notifyIcon1.Visible = false;
            base.ShowInTaskbar = false;
            Environment.Exit(0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start(@".\Steamaccount.txt");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.WTRegedit2("sasrunexit", "1");
            }
            else
            {
                this.WTRegedit2("sasrunexit", "0");
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            string registData = this.GetRegistData(this.registData);
            this.textBox1.Text = this.GetRegistData(this.registData);
            this.Text = "SteamAccountSwitcher v1.4";
            this.notifyIcon1.Visible = false;
            this.comboBox1.Items.Clear();
            StreamReader reader = new FileInfo(@".\Steamaccount.txt").OpenText();
            string item = string.Empty;
            while ((item = reader.ReadLine()) != null)
            {
                this.comboBox1.Items.Add(item);
            }
            reader.Dispose();
            string text = this.comboBox1.Text;
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //System.Drawing.Text.PrivateFontCollection privateFonts = new System.Drawing.Text.PrivateFontCollection();
            //privateFonts.AddFontFile("mvboli.ttf");
            //System.Drawing.Font font = new Font(privateFonts.Families[0], 7F, FontStyle.Italic);
            //System.Drawing.Font font2 = new Font(privateFonts.Families[0], 15.75F, FontStyle.Bold);
            //System.Drawing.Font font3 = new Font(privateFonts.Families[0], 21.75F, FontStyle.Bold);
            //this.button3.Font = font;
            //this.button4.Font = font;
            //this.label1.Font = font2;
            //this.button1.Font = font3;
            //Font.Dispose();
            RegistryKey key = Registry.CurrentUser;
            key.CreateSubKey(@"Software\Valve\Steam");

            this.IsRegeditKeyExit();
            string registData = this.GetRegistData(this.registData);
            this.textBox1.Text = this.GetRegistData(this.registData);
            this.Text = "SteamAccountSwitcher v1.4";
            this.notifyIcon1.Visible = false;
            if (!File.Exists(@".\Steamaccount.txt"))
            {
                File.Create(@".\Steamaccount.txt").Close();
                StreamWriter writer = File.AppendText(@".\Steamaccount.txt");
                string str2 = "\n";
                writer.Write(str2);
                writer.Close();
            }
            if (!File.Exists(@".\startparm.txt"))
            {
                File.Create(@".\startparm.txt").Close();
                StreamWriter writer = File.AppendText(@".\startparm.txt");
                string str2 = "\n";
                writer.Write(str2);
                writer.Close();
            }
            this.comboBox1.Items.Clear();
            StreamReader reader = new FileInfo(@".\Steamaccount.txt").OpenText();
            string item = string.Empty;
            while ((item = reader.ReadLine()) != null)
            {
                this.comboBox1.Items.Add(item);
            }
            reader.Dispose();
            string text = this.comboBox1.Text;
            this.comboBox1.SelectedIndex = 0;

            this.comboBox2.Items.Clear();
            StreamReader reader2 = new FileInfo(@".\startparm.txt").OpenText();
            string item2 = string.Empty;
            while ((item2 = reader2.ReadLine()) != null)
            {
                this.comboBox2.Items.Add(item2);
            }
            reader2.Dispose();
            string text2 = this.comboBox2.Text;
            this.comboBox2.SelectedIndex = 0;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            NativeMethods.ReleaseCapture();
            NativeMethods.SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (base.WindowState == FormWindowState.Minimized)
            {
                base.ShowInTaskbar = false;
                this.notifyIcon1.Visible = true;
            }
        }

        private string GetRegistData(string SteamPath = "SteamPath")
        {
            //MessageBox.Show(SteamPath);
            object regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", true).OpenSubKey("Valve", true).OpenSubKey("Steam", true).GetValue("SteamPath");
            if (regKey == null)
                return ("没有找到steam安装路径！");

            return (Registry.CurrentUser.OpenSubKey("SOFTWARE", true).OpenSubKey("Valve", true).OpenSubKey("Steam", true).GetValue("SteamPath").ToString() + "/steam.exe");
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("MV Boli", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Silver;
            this.button1.Image = global::Properties.Resources.start;
            this.button1.Location = new System.Drawing.Point(109, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(109, 76);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(178, 23);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown_1);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboBox1_MouseClick);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(1, 244);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(347, 18);
            this.textBox1.TabIndex = 6;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "...";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(288, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(20, 20);
            this.button2.TabIndex = 4;
            this.button2.TabStop = false;
            this.button2.Text = "✦";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            this.button2.Enter += new System.EventHandler(this.button2_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("MV Boli", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(18, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "SteamAccountSwitcher v1.4";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SAS v1.4";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.显示ToolStripMenuItem.Text = "显示";
            this.显示ToolStripMenuItem.Click += new System.EventHandler(this.显示ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(109, 134);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(142, 24);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "启动Steam后关闭";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("MV Boli", 7F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(308, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(20, 20);
            this.button3.TabIndex = 10;
            this.button3.TabStop = false;
            this.button3.Text = "▁";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("MV Boli", 7F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(328, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(20, 20);
            this.button4.TabIndex = 11;
            this.button4.TabStop = false;
            this.button4.Text = "X";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(1, 218);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(174, 24);
            this.button5.TabIndex = 4;
            this.button5.Text = "编辑Steamaccount";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(109, 104);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(178, 23);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.DropDown += new System.EventHandler(this.comboBox2_DropDown);
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(175, 218);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(180, 24);
            this.button6.TabIndex = 5;
            this.button6.Text = "编辑Startparm";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(48, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "账户名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(48, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "启动参数";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::Properties.Resources.FormBG1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(348, 262);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button6);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private bool IsRegeditKeyExit()
        {
            RegistryKey currentUser = Registry.CurrentUser;
            RegistryKey key4 = currentUser.OpenSubKey("SOFTWARE", true).OpenSubKey("Valve", true).OpenSubKey("Steam", true);
            if (key4 == null)
                return false;
            string[] valueNames = key4.GetValueNames();
            foreach (string str in valueNames)
            {
                if (str == "sasrunexit")
                {
                    if (key4.GetValue("sasrunexit").ToString() == "1")
                    {
                        this.checkBox1.Checked = true;
                    }
                    return true;
                }
            }
            currentUser.Close();
            this.WTRegedit2("sasrunexit", "0");
            return true;
        }

        private void killProcess()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                if (process.ProcessName == "Steam")
                {
                    process.Kill();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.label1.BackColor = System.Drawing.Color.Transparent;
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (base.WindowState == FormWindowState.Minimized)
            {
                base.ShowInTaskbar = true;
                base.WindowState = FormWindowState.Normal;
                this.notifyIcon1.Visible = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }


        // Violates rule: MovePInvokesToNativeMethodsClass.
        public static class Interaction
        {
            // Callers require Unmanaged permission        
            public static void Beep()
            {
                // No need to demand a permission as callers of Interaction.Beep            
                // will require UnmanagedCode permission            
                if (!NativeMethods.ReleaseCapture())
                    throw new Win32Exception();
                if (!NativeMethods.SendMessage("", -1,-1,-1))
                    throw new Win32Exception();
            }
        }

        internal static class NativeMethods
        {
            [DllImport("user32.dll")]
            public static extern bool ReleaseCapture();
            [DllImport("user32.dll")]
            public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

            internal static bool SendMessage(string v1, int v2, int v3, int v4)
            {
                throw new NotImplementedException();
            }
        }





        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void WTRegedit(string AutoLoginUser, string username)
        {
            Registry.CurrentUser.OpenSubKey("SOFTWARE", true).OpenSubKey("Valve", true).OpenSubKey("Steam", true).SetValue(AutoLoginUser, username);
        }

        private void WTRegedit2(string sasrunexit, string username)
        {
            Registry.CurrentUser.OpenSubKey("SOFTWARE", true).OpenSubKey("Valve", true).OpenSubKey("Steam", true).SetValue(sasrunexit, username, RegistryValueKind.DWord);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show("debug一下！");
            base.Dispose();
            //base.Close();
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Normal;
        }

        public string registData { get; set; }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start(@".\startparm.txt");
        }

        private void comboBox1_DropDown_1(object sender, EventArgs e)
        {
            string boxbak = this.comboBox1.Text;
            this.comboBox1.Items.Clear();
            StreamReader reader = new FileInfo(@".\Steamaccount.txt").OpenText();
            string item = string.Empty;
            while ((item = reader.ReadLine()) != null)
            {
                this.comboBox1.Items.Add(item);
            }
            reader.Dispose();
            this.comboBox1.Text = boxbak;
            //string text = this.comboBox1.Text;
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            string boxbak = this.comboBox2.Text;
            this.comboBox2.Items.Clear();
            StreamReader reader2 = new FileInfo(@".\startparm.txt").OpenText();
            string item2 = string.Empty;
            while ((item2 = reader2.ReadLine()) != null)
            {
                this.comboBox2.Items.Add(item2);
            }
            reader2.Dispose();
            this.comboBox2.Text = boxbak;
            //string text = this.comboBox1.Text;
        }

        private void button2_Enter(object sender, EventArgs e)
        {
            label1.Focus();
        }
    }
}


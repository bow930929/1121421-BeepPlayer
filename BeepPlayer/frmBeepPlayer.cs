using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BeepPlayer
{
    public partial class frmBeepPlayer : Form
    {
        [DllImport("kernel32.dll")]
        public static extern bool Beep(int frequency, int duration);

        int[] freq = { 523, 587, 659, 698, 784, 880, 988, 1046 };

        // 記錄 palMain 初始大小與各控制項初始位置大小
        int initWidth = 0;
        int initHeight = 0;
        Dictionary<string, Rectangle> initControl = new Dictionary<string, Rectangle>();

        public frmBeepPlayer()
        {
            InitializeComponent();
            InitializeButton();
        }

        // 讓 btn1~btn8 共用同一個事件處理函式
        private void InitializeButton()
        {
            btn2.Click += btn1_Click;
            btn3.Click += btn1_Click;
            btn4.Click += btn1_Click;
            btn5.Click += btn1_Click;
            btn6.Click += btn1_Click;
            btn7.Click += btn1_Click;
            btn8.Click += btn1_Click;
        }

        // 按鈕發音
        private void btn1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Enabled = false;
            Beep(freq[btn.TabIndex], 300);
            btn.Enabled = true;
        }

        // 記錄初始長寬與各控制項位置（需在 Designer 綁定 Load 事件）
        private void frmBeepPlayer_Load(object sender, EventArgs e)
        {
            this.initWidth = this.palMain.Width;
            this.initHeight = this.palMain.Height;
            foreach (Control ctl in this.palMain.Controls)
            {
                this.initControl.Add(ctl.Name,
                    new Rectangle(ctl.Left, ctl.Top, ctl.Width, ctl.Height));
            }
        }

        // 視窗大小改變時等比例調整按鈕（需在 Designer 綁定 SizeChanged 事件）
        private void frmBeepPlayer_SizeChanged(object sender, EventArgs e)
        {
            double width = this.palMain.Width;
            double height = this.palMain.Height;
            double ratioW = width / this.initWidth;
            double ratioH = height / this.initHeight;
            foreach (Control ctl in this.palMain.Controls)
            {
                ctl.Left = (int)(initControl[ctl.Name].Left * ratioW);
                ctl.Top = (int)(initControl[ctl.Name].Top * ratioH);
                ctl.Width = (int)(initControl[ctl.Name].Width * ratioW);
                ctl.Height = (int)(initControl[ctl.Name].Height * ratioH);
            }
        }
    }
}
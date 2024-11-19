using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using ForlornApi;


namespace MerdekaV4
{
    public partial class Form1 : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
    (
        int nLeftRect,     // x-coordinate of upper-left corner
        int nTopRect,      // y-coordinate of upper-left corner
        int nRightRect,    // x-coordinate of lower-right corner
        int nBottomRect,   // y-coordinate of lower-right corner
        int nWidthEllipse, // height of ellipse
        int nHeightEllipse // width of ellipse
    );

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            UC_Home uc = new UC_Home();
            addUserControl(uc);
         

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            UC_Home uc = new UC_Home();
            addUserControl(uc);
        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {
            UC_Executor uc = new UC_Executor();
            addUserControl(uc);
        }

        private void siticoneButton5_Click(object sender, EventArgs e)
        {
            UC_Settings uc = new UC_Settings();
            addUserControl(uc);
        }

        public static bool IsInject = false;
        public static bool IsRobloxOn = false;

        private void siticoneCircleButton1_Click(object sender, EventArgs e)
        {
            if (Api.IsInjected())
            {
                try
                {
                    IsInject = true;
                    siticoneCircleButton1.FillColor = Color.LightGreen;
                }
                catch (Exception ex)

                {
                    MessageBox.Show($"Failed to inject {ex}");
                    siticoneButton1.FillColor = Color.Red;
                }
            }
            if (Api.IsRobloxOpen())
            {
                IsRobloxOn = true;
                siticoneButton1.FillColor = Color.LightYellow;
              
            }
            else
            {
                IsRobloxOn = false;
                siticoneButton1.FillColor = Color.Red;
            }

        }
    }
}

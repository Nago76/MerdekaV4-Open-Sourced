using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForlornApi;

namespace MerdekaV4
{
    public partial class UC_Settings : UserControl
    {
        public UC_Settings()
        {
            InitializeComponent();
        }

        private void siticoneButton1_Click(object sender, EventArgs e) 
        {
            Api.KillRoblox();
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {

        }
    }
}

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
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Wpf;
using Newtonsoft.Json;
using System.IO;

namespace MerdekaV4
{
    public partial class UC_Executor : UserControl
    {
        public UC_Executor()
        {
            InitializeComponent();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Monaco", "index.html");
            webView21.Source = new Uri(path);
            ForlornApi.Forlorn forlorn = new ForlornApi.Forlorn();

            listBox1.Items.Clear();//Clear Items in the LuaScriptList
            Functions.PopulateListBox(listBox1, "./Script", "*.txt");
            Functions.PopulateListBox(listBox1, "./Script", "*.lua");
        }

        private void siticoneButton5_Click(object sender, EventArgs e)
        {
            Api.Inject();
        }

        private async Task<string> Editorv()
        {
            string result = await webView21.ExecuteScriptAsync("editor.getValue()");
            return JsonConvert.DeserializeObject(new
            {
                text = result
            }.text).ToString();
        }

        private async void siticoneButton1_Click(object sender, EventArgs e)
        {
            string editorValue = await Editorv();
            Api.ExecuteScript(editorValue);
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.ExecuteScriptAsync($"editor.setValue('')");
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            if (FileDialogHelper.openfiledialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string mainText = File.ReadAllText(FileDialogHelper.openfiledialog.FileName);
                    webView21.ExecuteScriptAsync($"SetText(`{mainText}`)");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: Could not read file from disk. Original error: {ex.Message}");
                }
            }
        }

        private void loadScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex != -1)
            {
                string text = File.ReadAllText("Script\\" + listBox1.SelectedItem.ToString());
                string text2 = JsonConvert.SerializeObject(text);
                webView21.ExecuteScriptAsync($"editor.setValue(" + text2 + ")");
            }
        }

        private void injectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Api.Inject();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();//Clear Items in the LuaScriptList
            Functions.PopulateListBox(listBox1, "./Script", "*.txt");
            Functions.PopulateListBox(listBox1, "./Script", "*.lua");

        }

        private void killRobloxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Api.KillRoblox();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NonCSLA.WinFormUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetRandomNumber_Click(object sender, EventArgs e)
        {
            try
            {
                var srv = new ServiceReference1.RandomNumbersClient();
                var number = srv.GetNumber();
                MessageBox.Show(string.Format("Number {0}", number));
            }
            catch (Exception ex)
            {
                var sb = new StringBuilder();
                Exception inner = ex;
                while (inner != null)
                {
                    sb.AppendFormat("{2} - {0}{1}", inner.Message, Environment.NewLine, inner.GetType().ToString());
                    inner = inner.InnerException;
                }
                MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

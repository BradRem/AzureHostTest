using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            BusinessPrincipal.Login("test", "password");

            if (!Csla.ApplicationContext.User.Identity.IsAuthenticated)
            {
                MessageBox.Show("Unable to login");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var person = PersonEdit.GetPersonEdit(1);
                bindingSource1.DataSource = person;
            }
            catch (Exception ex)
            {
                var sb = new StringBuilder();
                Exception inner = ex;
                while (inner != null)
                {
                    sb.AppendFormat("{0} - {1}{2}{2}", inner.GetType(), inner.Message, Environment.NewLine);
                    inner = inner.InnerException;
                }
                MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

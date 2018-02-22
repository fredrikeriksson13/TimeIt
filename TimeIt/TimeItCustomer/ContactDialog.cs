using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeItCustomer
{
    public partial class ContactDialog : Form
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool SaveContact { get; set; }

        public ContactDialog(string _firstName, string _lastName)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            txtFirstName.Text = _firstName;
            txtLastName.Text = _lastName; 
        }

        private void txtForName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                btnFinish.Enabled = false;
            else
                btnFinish.Enabled = true;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            SaveContact = true;
            FirstName = txtFirstName.Text;
            LastName = txtLastName.Text;
            this.Dispose();
        }

        private void btnCansel_Click(object sender, EventArgs e)
        {
            SaveContact = false;
            this.Dispose();
        }
    }
}

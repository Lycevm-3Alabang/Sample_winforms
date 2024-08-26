using WinForms.App.POS;

namespace WinForms.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Any())
            {
                MessageBox.Show("Close the current form first.");
                return;
            }

            var form = new InventoryForm();
            form.MdiParent = this;
            form.Show();
        }

        private void PointofSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
              if (this.MdiChildren.Any())
            {
                MessageBox.Show("Close the current form first.");
                return;
            }

            var form = new CartForm();
            form.MdiParent = this;
            form.Show();
        }
    }
}

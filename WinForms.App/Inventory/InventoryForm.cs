using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms.Service;

namespace WinForms.App
{
    public partial class InventoryForm : Form
    {
        public InventoryForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var upsertItemForm = new UpsertItemForm();
            upsertItemForm.Name = "UpsertItemForm";
            upsertItemForm.ShowDialog(this);

            ResetDataGridView();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var items = Service.InventoryManager.Items;
            var filteredList = items.Where(i => i.Name.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase) || i.Code.Equals(txtSearch.Text, StringComparison.OrdinalIgnoreCase)).ToArray();

            ResetDataGridView(filteredList);

        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            ResetDataGridView();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Visible = true;
                column.Width = 100; // Adjust as needed
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void ResetDataGridView(IEnumerable<Item>? items = null)
        {
            if (items == null)
            {
                items = InventoryManager.Items;
            }

            this.dataGridView1.DataSource = items.ToList();

            // Ensure rows are selectable
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false; // Prevent multiple row selection if needed

     
        }

    }
}

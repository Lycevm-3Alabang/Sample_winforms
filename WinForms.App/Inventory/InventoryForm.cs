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

        #region Events

        private void Button1_Click(object sender, EventArgs e)
        {
            UpsertItemForm upsertItemForm = new()
            {
                Name = "UpsertItemForm"
            };
            upsertItemForm.ShowDialog(this);

            ResetDataGridView();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var items = InventoryManager.GetProducts();
            Product[]? filteredList = items?.Where(i => i.Name.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase) || i.Code.Equals(txtSearch.Text, StringComparison.OrdinalIgnoreCase)).ToArray();

            ResetDataGridView(filteredList);

        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Visible = true;
                column.Width = 100; // Adjust as needed
            }
            ResetDataGridView();
        }


        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row was clicked
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                Product? item = InventoryManager.GetProducts()?.Single(i => i.Code == selectedRow.Cells["Code"]?.Value.ToString());

                UpsertItemForm upsertItemForm = new(item)
                {
                    Name = "UpsertItemForm"
                };
                upsertItemForm.ShowDialog(this);

                ResetDataGridView();
            }
        }

        #endregion

        private void ResetDataGridView(IEnumerable<Product>? items = null)
        {
            items ??= InventoryManager.GetProducts();

            dataGridView1.DataSource = items?.ToList() ?? [];

            // Ensure rows are selectable
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false; // Prevent multiple row selection if needed
            dataGridView1.Columns["Id"].Visible = false;
        }
    }
}

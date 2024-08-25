using WinForms.Service;

namespace WinForms.App
{
    public partial class UpsertItemForm : Form
    {
        private readonly Guid? _id;
        public UpsertItemForm()
        {
            InitializeComponent();
            _id = null;
        }

        public UpsertItemForm(Item itemToEdit) : this()
        {
           
            textBox1.Text = itemToEdit.Name;
            textBox2.Text = itemToEdit.Code;
            textBox3.Text = itemToEdit.Price.ToString();
            textBox4.Text = itemToEdit.Description;
            _id  = itemToEdit.Id;
        }

        private void Button3_Click_2(object sender, EventArgs e) => Close();

        private void Button4_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure?", "Prompt", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            if (_id != null)
            {
                var item = InventoryManager.Items.Single(i => i.Id == _id);
                item.Name = textBox1.Text;
                item.Code = textBox2.Text;
                item.Price = decimal.Parse(textBox3.Text);
                item.Description = textBox4.Text;
            }else
            {
                InventoryManager.Items.Add(new Service.Item
                {
                    Id = Guid.NewGuid(),
                    Name = textBox1.Text,
                    Code = textBox2.Text,
                    Price = decimal.Parse(textBox3.Text),
                    Description = textBox4.Text,
                });
            }

            this.Close();
        }
    }
}

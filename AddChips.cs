using System;
using System.Windows.Forms;

namespace Poker
{
    public partial class AddChips : Form
    {
        public int A;
        public AddChips()
        {
            InitializeComponent();
            ControlBox = false;
            label1.BorderStyle = BorderStyle.FixedSingle;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            int parsedValue;
            if (int.Parse(textBox1.Text) > 100000000)
            {
                MessageBox.Show(@"The maximium chips you can add is 100000000");
                return;
            }
            if (!int.TryParse(textBox1.Text, out parsedValue))
            {
                MessageBox.Show(RepetitiveVariables.NumberField);
            }
            else if (int.TryParse(textBox1.Text, out parsedValue) && int.Parse(textBox1.Text) <= 100000000)
            {
                A = int.Parse(textBox1.Text);
                Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            const string message = "Are you sure?";
            const string title = "Quit";
            DialogResult result = MessageBox.Show(
            message,title,
            MessageBoxButtons.YesNo, 
            MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}

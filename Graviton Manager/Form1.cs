using System;
using System.Windows.Forms;

namespace Graviton_Manager
{
    public partial class Form1 : Form
    {

        private MainForm lastForm;

        public Form1(String[] element, MainForm lastForm)
        {
            this.lastForm = lastForm;
            if (element != null)
            {
                InitializeComponent();
                foreach (String word in element)
                    metroComboBox1.Items.Add(word);
                Show();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lastForm.connect(metroComboBox1.GetItemText(metroComboBox1.SelectedItem));
            Close();
        }
    }
}

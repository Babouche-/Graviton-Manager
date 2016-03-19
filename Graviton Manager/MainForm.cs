using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graviton_Manager
{

    public partial class MainForm : MetroForm
    {
        public Boolean connected;

        public String lastUsername;
        public String lastPassword;

        private Server server;

        internal Server Server
        {
            get
            {
                return server;
            }

            set
            {
                server = value;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            metroTabControl1.SelectTab(0);
            user.Text = getInformations("User");
            password.Text = getInformations("Pass");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        public void parse(String packet)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                this.packet.Text = packet;
                switch (this.packet.Text[0])
                {
                    case 'E':
                        user.Style = MetroFramework.MetroColorStyle.Red;
                        user.Clear();
                        password.Style = MetroFramework.MetroColorStyle.Red;
                        password.Clear();
                        password.Select();
                        break;
                    case 'K':
                        user.Style = MetroFramework.MetroColorStyle.Red;
                        user.Clear();
                        password.Style = MetroFramework.MetroColorStyle.Red;
                        password.Clear();
                        password.Select();
                        MessageBox.Show("Vous n'avez pas les droits necessaires pour utiliser cette application","Code 2",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        break;
                    case 'R':
                        String[] wordToAdd = null;
                        try
                        {
                            wordToAdd = this.packet.Text.Substring(1).Split(';');
                        }
                        catch
                        {
                            return;
                        }

                        foreach (String toAdd in wordToAdd)
                            listBox1.Items.Add(toAdd);
                        break;
                    case 'L':
                        user.Clear();
                        password.Clear();
                        this.Style = MetroFramework.MetroColorStyle.Green;
                        this.Refresh();
                        if (this.packet.Text.Length == 1)
                        {

                            Style = MetroFramework.MetroColorStyle.Red;
                            Refresh();
                            DialogResult result = MessageBox.Show("Aucun serveur n'est disponible, veuillez réessayer ultérieurement", "", MessageBoxButtons.RetryCancel);
                            switch (result)
                            {
                                case DialogResult.Retry:
                                    Style = MetroFramework.MetroColorStyle.Default;
                                    Refresh();
                                    server.send("C" + lastUsername + ";" + lastPassword);
                                    break;
                                case DialogResult.Cancel:
                                    Style = MetroFramework.MetroColorStyle.Default;
                                    Refresh();
                                    break;
                            }
                            return;
                        }
                        String[] word = null;
                        try
                        {
                            word = this.packet.Text.Substring(1).Split(';');
                        }
                        catch
                        {
                            word = new String[] { this.packet.Text.Substring(1) };
                        }

                        if (word.Length == 1)
                        {
                            connect(word[0]);
                            return;

                        }

                        new Form1(word, this);

                        break;
                }
            });

        }

        public void connect(String server)
        {
            this.server.send("S" + server);
            connected = true;
            metroTabControl1.SelectTab(1);
        }


        #region mouse click

        private void red_Click(object sender, EventArgs e)
        {
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Refresh();
        }

        private void purple_Click(object sender, EventArgs e)
        {
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Refresh();
        }

        private void yellow_Click(object sender, EventArgs e)
        {
            this.Style = MetroFramework.MetroColorStyle.Yellow;
            this.Refresh();
        }

        private void orange_Click(object sender, EventArgs e)
        {
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Refresh();
        }

        private void silver_Click(object sender, EventArgs e)
        {
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Refresh();
        }

        private void pink_Click(object sender, EventArgs e)
        {
            this.Style = MetroFramework.MetroColorStyle.Pink;
            this.Refresh();
        }

        private void lime_Click(object sender, EventArgs e)
        {
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Refresh();
        }

        private void blue_Click(object sender, EventArgs e)
        {
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Refresh();
        }

        private void black_Click(object sender, EventArgs e)
        {
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Refresh();
        }
        #endregion

        #region mouse hover

        private void red_hover(object sender, EventArgs e)
        {
            red.BackColor = Color.Red;
        }

        private void purple_hover(object sender, EventArgs e)
        {
            purple.BackColor = Color.Purple;
        }

        private void yellow_hover(object sender, EventArgs e)
        {
            yellow.BackColor = Color.Yellow;
        }

        private void orange_hover(object sender, EventArgs e)
        {
            orange.BackColor = Color.Orange;
        }

        private void silver_hover(object sender, EventArgs e)
        {
            silver.BackColor = Color.Silver;
        }

        private void pink_hover(object sender, EventArgs e)
        {
            pink.BackColor = Color.Pink;
        }

        private void lime_hover(object sender, EventArgs e)
        {
            lime.BackColor = Color.Lime;
        }

        private void blue_hover(object sender, EventArgs e)
        {
            blue.BackColor = Color.Blue;
        }

        private void black_hover(object sender, EventArgs e)
        {
            black.BackColor = Color.Black;
        }

        #endregion

        #region mouse leave

        private void red_leave(object sender, EventArgs e)
        {
            red.BackColor = Color.Transparent;
        }

        private void purple_leave(object sender, EventArgs e)
        {
            purple.BackColor = Color.Transparent;
        }

        private void yellow_leave(object sender, EventArgs e)
        {
            yellow.BackColor = Color.Transparent;
        }

        private void orange_leave(object sender, EventArgs e)
        {
            orange.BackColor = Color.Transparent;
        }

        private void silver_leave(object sender, EventArgs e)
        {
            silver.BackColor = Color.Transparent;
        }

        private void pink_leave(object sender, EventArgs e)
        {
            pink.BackColor = Color.Transparent;
        }

        private void lime_leave(object sender, EventArgs e)
        {
            lime.BackColor = Color.Transparent;
        }

        private void blue_leave(object sender, EventArgs e)
        {
            blue.BackColor = Color.Transparent;
        }

        private void black_leave(object sender, EventArgs e)
        {
            black.BackColor = Color.Transparent;
        }


        #endregion


        private void metroButton1_Click_1(object sender, EventArgs e)
        {

            if (user.Text == "" || user.Text == null)
            {
                user.Style = MetroFramework.MetroColorStyle.Red;
                user.Clear();
                user.Select();
                return;
            }

            if (password.Text == "" || password.Text == null)
            {
                password.Style = MetroFramework.MetroColorStyle.Red;
                password.Clear();
                password.Select();
                return;
            }
            lastUsername = user.Text;
            lastPassword = password.Text;

            server.send("C" + user.Text + ";" + password.Text);
            saveInformations();
          

        }

        private String getInformations(String infos)
        {
            try {

                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Horus\\Manager");
                String information = (String) key.GetValue(infos);
                key.Close();
                return information;
            } catch
            {
                return "";
            }
        }

        private void saveInformations()
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Horus\\Manager");
            key.SetValue("User", lastUsername);
            key.SetValue("Pass", lastPassword);
            key.Close();
        }

        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!connected && metroTabControl1.SelectedTab == metroTabPage2)
            {
                metroTabControl1.SelectTab(0);
                MessageBox.Show("Vous devez être connecté pour pouvoir gerer un serveur");
            }
        }

        private void close_Click(object sender, EventArgs end)
        {
            Process.GetProcessById(Process.GetCurrentProcess().Id).Kill();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Babouche-/");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(metroTextBox1.Text == "")
            {
                metroTextBox1.Style = MetroFramework.MetroColorStyle.Red;
                metroTextBox1.Select();
                return;
            }
            listBox1.Items.Add("");
            listBox1.Items.Add("Launch the command -> " + metroTextBox1.Text);
            listBox1.Items.Add("");
            server.send("L" + metroTextBox1.Text);
            metroTextBox1.Clear();
            metroTextBox1.Style = MetroFramework.MetroColorStyle.Default;
        }

        void keyPress(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyData)
                metroButton1.PerformClick();
        }

        private void keyPress1(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyData)
                pictureBox3_Click(sender, e);
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            server.send("I127.0.0");
        }
    }

}



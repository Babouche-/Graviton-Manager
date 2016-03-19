using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graviton_Manager
{
    public partial class splashScreen : Form
    {
        private Server server;
        private Boolean close = false;
        private int count = 0;

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

        public splashScreen()
        {
            InitializeComponent();
        }

        public void disconnect()
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                server.secondForm.Hide();
                Show();
                Label1.ForeColor = Color.Red;
                Label1.Text = "La connexion à été perdu, fermeture du programme...";
                close = true;
                checker.Interval = 4000;
                checker.Start();
            });
        }


        public void alreayConnect()
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                server.secondForm.Hide();
                Show();
                Label1.ForeColor = Color.Red;
                Label1.Text = "Une autre application est dejà connectée, fermeture du programme...";
                close = true;
                checker.Interval = 4000;
                checker.Start();
            });
        }

        private void splashScreen_Load(object sender, EventArgs e)
        {
            opacityChanger.Start();
        }

        private void opacityChanger_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.01;
            if (Opacity == 1)
                opacityChanger.Stop();
        }

        private void labelChanger_Tick(object sender, EventArgs e)
        {
            switch (Label1.Text)
            {
                case "Connexion en cours.":
                    Label1.Text = "Connexion en cours..";
                    break;
                case "Connexion en cours..":
                    Label1.Text = "Connexion en cours...";
                    break;
                case "Connexion en cours...":
                    Label1.Text = "Connexion en cours.";
                    break;
            }
        }

        private void checker_Tick(object sender, EventArgs e)
        {
            if (close)
            {
                Application.Exit();
            }

            if (Server.isConnected())
            {
                this.Hide();
                server.secondForm.Show();
                checker.Stop();
                labelChanger.Stop();
            }
            else
            {
                count++;
                if (count == 3)
                {
                    Label1.ForeColor = Color.Red;
                    Label1.Text = "Impossible de se connecter, fermeture du programme...";
                    checker.Interval = 4000;
                    close = true;
                }
                else
                {
                    Server.connect();
                }
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}

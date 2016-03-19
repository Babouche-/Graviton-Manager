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

    public partial class startScreen : Form
    {
        private Server server;

        public startScreen()
        {
            InitializeComponent();
        }

        private void startScreen_Load(object sender, EventArgs e)
        {
            server = new Server("127.0.0.1", 5000, this);
        }
        
        private void opacityChanger_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.01;
            if (Opacity == 1)
                opacityChanger.Stop();
        }
    }
}

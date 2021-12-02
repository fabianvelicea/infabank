using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfinityAtomBANK
{
    public partial class doNotOpenThis : Form
    {
        public doNotOpenThis()
        {
            InitializeComponent();
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(appData+"\\rickroll.wav");
            player.Play();
        }

        private void doNotOpenThis_Load(object sender, EventArgs e)
        {

        }
    }
}

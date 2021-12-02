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
    public partial class retragereNumerar : Form
    {
        public static retragereNumerar instance;
        public int value;
        public retragereNumerar()
        {
            InitializeComponent();
            instance = this;
            string lunaInText = "";
            switch (Convert.ToInt32(LogIn.instance.luna))
            {
                case 1:
                    lunaInText = "Ianuarie";
                    break;
                case 2:
                    lunaInText = "Februarie";
                    break;
                case 3:
                    lunaInText = "Martie";
                    break;
                case 4:
                    lunaInText = "Aprilie";
                    break;
                case 5:
                    lunaInText = "Mai";
                    break;
                case 6:
                    lunaInText = "Iunie";
                    break;
                case 7:
                    lunaInText = "Iulie";
                    break;
                case 8:
                    lunaInText = "August";
                    break;
                case 9:
                    lunaInText = "Septembrie";
                    break;
                case 10:
                    lunaInText = "Octombrie";
                    break;
                case 11:
                    lunaInText = "Noiembrie";
                    break;
                case 12:
                    lunaInText = "Decembrie";
                    break;

            }
            //MessageBox.Show(client.name + "\n" + client.luna + "\n" + client.an + "\n" + client.currency + "\n" + client.isAdmin);
            lblName.Text = "Bine ai venit, " + LogIn.instance.name;
            lblExp.Text = "Cardul va expira în luna: " + lunaInText + " " + LogIn.instance.an;
        }

        private void retragereNumerar_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            value = 10;
            warn warning = new warn(value);
            warning.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            value = 50;
            warn warning = new warn(value);
            warning.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            value = 100;
            warn warning = new warn(value);
            warning.Show();
            Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            value = 500;
            warn warning = new warn(value);
            warning.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            value = 1000;
            warn warning = new warn(value);
            warning.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            anotherSum anotherSuma = new anotherSum();
            anotherSuma.Show();
            Hide();

        }
    }
}

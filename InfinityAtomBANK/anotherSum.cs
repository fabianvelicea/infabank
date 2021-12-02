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
    public partial class anotherSum : Form
    {
        public anotherSum instance;
        public long value;
        public anotherSum()
        {
            InitializeComponent();
            instance = this;
            string lunaInText = "";
            switch (LogIn.instance.luna)
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

        private void btnGenerare_Click(object sender, EventArgs e)
        {
            if (txtAccounta.Text != "")
            {
                value = Convert.ToInt64(txtAccounta.Text);
                if (value % 10 == 0)
                {
                    warn w = new warn(value);
                    w.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Suma trebuie să fie multiplu de 10!", "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtAccounta.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Nu poti retrage o valoare nula!", "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtAccounta_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

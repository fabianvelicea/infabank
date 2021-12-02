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
    public partial class depunereNumerar : Form
    {
        public static depunereNumerar instance;
        public double valoare;
        public depunereNumerar()
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
            comboBox1.SelectedIndex = 0;
        }

        private void depunereNumerar_Load(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex!=0)
            {
                MessageBox.Show("AVETI IN VEDERE FAPTUL CA VALOAREA DEPUSA VA FI CONVERTITA DIN MONEDA SELECTATA IN LEI", "AVERTIZARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGenerare_Click(object sender, EventArgs e)
        {
            if (txtAccounta.Text != "")
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    valoare = Convert.ToDouble(txtAccounta.Text);
                    warnD WarnD = new warnD(valoare);
                    WarnD.Show();
                    Hide();
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    valoare = 4.95 * Convert.ToDouble(txtAccounta.Text);
                    warnD WarnD = new warnD(valoare);
                    WarnD.Show();
                    Hide();
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    valoare = 5.90 * Convert.ToDouble(txtAccounta.Text);
                    warnD WarnD = new warnD(valoare);
                    WarnD.Show();
                    Hide();
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    valoare = 4.39 * Convert.ToDouble(txtAccounta.Text);
                    warnD WarnD = new warnD(valoare);
                    WarnD.Show();
                    Hide();
                }
            }
            else
            {
                MessageBox.Show("Nu poti depune o valoare nula!", "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

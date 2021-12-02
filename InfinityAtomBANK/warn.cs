using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfinityAtomBANK
{
    public partial class warn : Form
    {
        public static warn instance;
        public long valoare;
        public warn(long value)
        {
            InitializeComponent();
            instance = this;
            string lunaInText = "";
            valoare = value;
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
            lblSum.Text = value + " lei?";
        }

        private void warn_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            retragereNumerar rn = new retragereNumerar();
            rn.Show();
            Hide();
        }
        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (LogIn.instance.currency>= valoare)
            {
                if (valoare <= 10000)
                {
                    if(valoare>0)
                    {
                    string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    string accountNumber = LogIn.instance.contactiv + ".infatm";
                    string path = appData + "\\AtomB\\" + accountNumber;
                    LogIn.instance.currency = LogIn.instance.currency - valoare;
                    lineChanger(LogIn.instance.currency.ToString(), path, 5);

                    altaOperatiune ao = new altaOperatiune();
                    ao.Show();
                    Hide();
                    }
                    else
                    {
                        MessageBox.Show("Valoarea nu poate fi mai mica decat 0 sau 0!", "EROARE!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        retragereNumerar rn = new retragereNumerar();
                        rn.Show();
                        Hide();
                    }

                }
                else
                {
                    MessageBox.Show("Nu puteti retrage mai mult de 10000 de lei odată!", "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    retragereNumerar rn = new retragereNumerar();
                    rn.Show();
                    Hide();
                }
            }
            else
            {
                failed ao = new failed();
                ao.Show();
                Hide();
            }
        }
    }
}

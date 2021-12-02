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
    public partial class warnD : Form
    {
        public static warnD instance;
        public double valoare;
        public warnD(double value)
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

        private void warnD_Load(object sender, EventArgs e)
        {

        }
        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string accountNumber = LogIn.instance.contactiv + ".infatm";
            string path = appData + "\\AtomB\\" + accountNumber;
            LogIn.instance.currency = LogIn.instance.currency + valoare;
            lineChanger(LogIn.instance.currency.ToString(), path, 5);

            altaOperatiune ao = new altaOperatiune();
            ao.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            depunereNumerar depunere = new depunereNumerar();
            depunere.Show();
            Hide();
        }
    }
}

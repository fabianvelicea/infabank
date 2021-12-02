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
    
    public partial class PINChange : Form
    {   
        public static PINChange instance;
        //public string contactiv;
        //public int pin;
        //public string name = "";
        //public int luna, an;
        //public double currency;
        //public bool isAdmin;
        public PINChange()
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
        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {

            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string path = appData + "\\AtomB\\" + LogIn.instance.contactiv + ".infatm";
            string path2 = appData + "\\AtomB";
            if (LogIn.instance.PinDinFisier==Convert.ToInt32(txtAccount.Text))
            {
                if(txtPASSWORD.TextLength==4)
                {
                    lineChanger(txtPASSWORD.Text, path, 1);
                    altaOperatiune ao = new altaOperatiune();
                    ao.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("PIN-ul trebuie sa aiba 4 cifre!", "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                
            }
            else
            {
                MessageBox.Show("PIN-ul vechi nu corespunde!", "Eroare!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doresti sa iesi din program sau sa te deconectezi\n\n[Yes]- Iesire\n[No]- Deconectare", "Intrebare", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                LogIn logIn = new LogIn();
                logIn.Show();
                Hide();
            }
        }

        private void txtAccount_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

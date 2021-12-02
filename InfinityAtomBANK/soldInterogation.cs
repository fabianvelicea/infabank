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
    public partial class soldInterogation : Form
    {
        public static soldInterogation instance;
        public double valoare;
        public soldInterogation()
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
            valoare = LogIn.instance.currency;
            lblSum.Text = valoare + " lei în contul dvs.";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (LogIn.instance.isAdmin == true)
            {
                DashboardAdmin da = new DashboardAdmin();
                da.Show();
                Hide();
            }
            else
            {
                DashboardStd ds = new DashboardStd();
                ds.Show();
                Hide();
            }
        }

        private void soldInterogation_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
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
    }
}

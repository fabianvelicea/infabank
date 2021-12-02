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
    
    public partial class ViewAccounts : Form
    {   public string txtA;
        public static ViewAccounts instance;
        
        public ViewAccounts()
        {
            InitializeComponent();
            instance = this;
        }

        private void btnGenerare_Click(object sender, EventArgs e)
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string accountNumber = txtAccounta.Text + ".infatm";
            string accountNumbertwo = txtAccounta.Text;
            string path = appData + "\\AtomB\\" + accountNumber;
            if(File.Exists(path))
            {
                txtA = txtAccounta.Text;
                string NameA = File.ReadLines(path).Skip(1).Take(1).First();
                long CardNumber = Convert.ToInt64(accountNumbertwo);
                int mounth = Convert.ToInt32(File.ReadLines(path).Skip(2).Take(1).First());
                int year = Convert.ToInt32(File.ReadLines(path).Skip(3).Take(1).First());
                double balance = Convert.ToDouble(File.ReadLines(path).Skip(4).Take(1).First());
                bool isAdmin = Convert.ToBoolean(File.ReadLines(path).Skip(5).Take(1).First());
                Card child = new Card(CardNumber.ToString(),NameA,mounth,year,balance,isAdmin);
                child.MdiParent = this;
                child.Show();
                child.Text = txtAccounta.Text;
            }
            else
            {
                if(MessageBox.Show("Nu exista nici un card in sistem cu acest numar!\nDoresti sa il adaugi?","Eroare",MessageBoxButtons.YesNo,MessageBoxIcon.Stop)==DialogResult.Yes)
                {
                    adaugaConturi adauga = new adaugaConturi();
                    adauga.Show();
                    Hide();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void txtAccounta_TextChanged(object sender, EventArgs e)
        {

        }

        private void closeAllCardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(Form frm in this.MdiChildren)
            {
                frm.Visible = false;
                frm.Dispose();
            }
        }
    }
}

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
    public partial class LogIn : Form
    {
        public static LogIn instance;
        public string contactiv;
        public int pin;
        public string name = "";
       public int luna, an;
        public double currency;
       public bool isAdmin;
        public int PinDinFisier;
         
        public LogIn()
        {
            InitializeComponent();
            instance = this;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string path = appData + "\\AtomB\\";
            bool isEmpty = !Directory.EnumerateFiles(path).Any();
            if (isEmpty == true)
            {
                FatalError fe = new FatalError();
                fe.Show();
                Hide();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string accountNumber = txtAccount.Text + ".infatm";
            string path = appData + "\\AtomB\\" + accountNumber;

            if (File.Exists(path))
            {

                pin = Convert.ToInt32(File.ReadLines(path).Skip(0).Take(1).First());
                PinDinFisier = Convert.ToInt32(txtPASSWORD.Text);
                if (pin == PinDinFisier)
                {
                    contactiv = txtAccount.Text;
                    name = File.ReadLines(path).Skip(1).Take(1).First();
                    luna = Convert.ToInt32(File.ReadLines(path).Skip(2).Take(1).First());
                    an = Convert.ToInt32(File.ReadLines(path).Skip(3).Take(1).First());
                    currency = Convert.ToDouble(File.ReadLines(path).Skip(4).Take(1).First());
                    isAdmin = Convert.ToBoolean(File.ReadLines(path).Skip(5).Take(1).First());
                    int anInt = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
                    int lunaInt = Convert.ToInt32(DateTime.Now.ToString("MM"));
                    if (anInt < an)
                    {
                        if (isAdmin == true)
                        {
                            DashboardAdmin dbadmin = new DashboardAdmin();
                            dbadmin.Show();
                            this.Hide();
                        }
                        else
                        {
                            DashboardStd dbstd = new DashboardStd();
                            dbstd.Show();
                            this.Hide();
                        }
                    }
                    else if (anInt == an)
                    {
                        if (lunaInt <= luna)
                        {
                            if (isAdmin == true)
                            {
                                DashboardAdmin dbadmin = new DashboardAdmin();
                                dbadmin.Show();
                                this.Hide();
                            }
                            else
                            {
                                DashboardStd dbstd = new DashboardStd();
                                dbstd.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Card Expirat!", "Eroare Critica!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtAccount.Text = "";
                            txtPASSWORD.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Card Expirat!", "Eroare Critica!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtAccount.Text = "";
                        txtPASSWORD.Text = "";
                    }


                    //MessageBox.Show(client.name + "\n" + client.zi + "\n" + client.luna + "\n" + client.an + "\n" + client.currency + "\n" + client.isAdmin);
                }
                else
                {
                    // client.isValid++;
                    MessageBox.Show($"PIN incorect!", "Avertizare!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Numarul de card introdus nu exista in sistem! Contacteaza un administrator de sistem pentru acest tip de operatiune, sau verificati ca ati introdus corect numarul cardului", "Numarul cardului nu exista in sistem! [Critical Error]", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
             

        }

        private void txtAccount_TextChanged(object sender, EventArgs e)
        {
            if(txtAccount.Text=="Proiectul nostru la PCLP e jmecher!")
            {
                MessageBox.Show("FELICITARI! ATI FOST MEMAT!","Hello",MessageBoxButtons.OK, MessageBoxIcon.Information);
                doNotOpenThis doNotOpen = new doNotOpenThis();
                doNotOpen.Show();
                Hide();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
        
    


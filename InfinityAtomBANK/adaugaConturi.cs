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
    public partial class adaugaConturi : Form
    {
        public adaugaConturi()
        {
            InitializeComponent();
            if (chkManual.Checked == true)
            {
                btnGenerare.Enabled = true;
                txtAccount.Enabled = false;
            }
            else
            {
                btnGenerare.Enabled = false;
                txtAccount.Enabled = true;
            }
            if (chkAutomat.Checked == false)
            {
                btnGenerare.Enabled = false;
                txtAccount.Enabled = true;
            }
            else
            {
                btnGenerare.Enabled = true;
                txtAccount.Enabled = false;
            }
        }

        public string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(16).ToString());
            return s;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(chkManual.Checked==true)
            {
                btnGenerare.Enabled = true;
                txtAccount.Enabled = false;
            }
            else
            {
                btnGenerare.Enabled = false;
                txtAccount.Enabled = true;
            }
            if(chkAutomat.Checked==false)
            {
                btnGenerare.Enabled = false;
                txtAccount.Enabled = true;
            }
            else
            {
                btnGenerare.Enabled = true;
                txtAccount.Enabled = false;
            }
        }

        private void btnGenerare_Click(object sender, EventArgs e)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < 16; i++)
                s = String.Concat(s, random.Next(9).ToString());
            txtAccount.Text = s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string path = appData + "\\AtomB\\" + txtAccount.Text +".infatm";
            string path2 = appData + "\\AtomB";
            if (txtAccount.Text!="")
            {
                if(txtName.Text!="")
                {
                    if(txtPIN.Text!="")
                    {
                        if(txtPIN.TextLength==4)
                        {
                            if(checkBox1.CheckState==CheckState.Checked)
                            {
                                if(File.Exists(path))
                                {
                                    MessageBox.Show("Acest cont deja exista!", "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    MessageBox.Show("ATOMBank nu a putut finaliza crearea acestui card!", "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                else
                                {
                                    if (!File.Exists(path)) // If file does not exists
                                    {
                                        File.Create(path).Close(); // Create file
                                        using (StreamWriter sw = File.AppendText(path))
                                        {
                                            sw.WriteLine(txtPIN.Text+"\n"+txtName.Text);
                                            int anInt = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
                                            int lunaInt = Convert.ToInt32(DateTime.Now.ToString("MM"));
                                            sw.WriteLine(lunaInt.ToString());
                                            anInt = anInt + 7;
                                            sw.WriteLine(anInt.ToString() + "\n" +"0"+"\n"+ "true");
                                        }
                                        MessageBox.Show("Cardul [" + txtAccount.Text + "] a fost creat cu succes la adresa:\n" + path, "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                }
                            }
                            else
                            {
                                if (File.Exists(path))
                                {
                                    MessageBox.Show("Acest cont deja exista!", "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    MessageBox.Show("ATOMBank nu a putut finaliza crearea acestui card!", "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                else
                                {
                                    if (!File.Exists(path)) // If file does not exists
                                    {
                                        File.Create(path).Close(); // Create file
                                        using (StreamWriter sw = File.AppendText(path))
                                        {
                                            sw.WriteLine(txtPIN.Text + "\n" + txtName.Text);
                                            int anInt = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
                                            int lunaInt = Convert.ToInt32(DateTime.Now.ToString("MM"));
                                            sw.WriteLine(lunaInt.ToString());
                                            anInt = anInt + 7;
                                            sw.WriteLine(anInt.ToString() + "\n" + "0" + "\n" + "false");
                                        }
                                        MessageBox.Show("Cardul [" + txtAccount.Text + "] a fost creat cu succes la adresa:\n" + path, "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("PIN-ul trebuie sa aiba 4 cifre!", "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            MessageBox.Show("ATOMBank nu a putut finaliza crearea acestui card!", "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Introduceți PIN-ul!", "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        MessageBox.Show("ATOMBank nu a putut finaliza crearea acestui card!", "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("Introduceți numele titularului de cont!", "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    MessageBox.Show("ATOMBank nu a putut finaliza crearea acestui card!", "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show("Introduceți numărul cardului!", "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show("ATOMBank nu a putut finaliza crearea acestui card!", "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtAccount.Text = "";
            txtName.Text = "";
            txtPIN.Text = "";
            checkBox1.CheckState = CheckState.Unchecked;
            chkManual.Checked = true;
        }

        private void button3_Click(object sender, EventArgs e)
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

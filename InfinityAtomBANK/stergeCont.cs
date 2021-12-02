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
    public partial class stergeCont : Form
    {
        public static stergeCont instance;
        public stergeCont()
        {
            InitializeComponent();
            listBox1.Focus();
            instance =this;
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

            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

          string path = appData + "\\AtomB";
            listBox1.Items.Clear();
            string[] files = Directory.GetFiles(path);
            string[] dirs = Directory.GetDirectories(path);
            foreach (string file in files)
                listBox1.Items.Add(Path.GetFileName(file));
            foreach (string dir in dirs)
                listBox1.Items.Add(Path.GetFileName(dir));
        }

        private void stergeCont_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selected = listBox1.SelectedItem;
            if (listBox1.SelectedItem!=null && MessageBox.Show("Esti sigur ca doresti sa stergi acest cont bancar\n Această acțiune este ireversibilă", "AVERTIZARE!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes && listBox1.SelectedItem.ToString() != LogIn.instance.contactiv.ToString())
            {
                string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string path = appData + "\\AtomB";
                string filename = listBox1.SelectedItem.ToString();
                string completePath = path + "\\" + filename;
                File.Delete(completePath);
                listBox1.Items.Remove(selected);
            }
            else if(listBox1.SelectedItem!=null && listBox1.SelectedItem.ToString()==LogIn.instance.contactiv.ToString())
            {
                MessageBox.Show("Nu iti poti sterge contul cat tip esti conectat pe el!", "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                MessageBox.Show("Mai intai selecteaza un element!\n Nu putem șterge un element NULL", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Delete)
            {
                var selected = listBox1.SelectedItem;
                if (listBox1.SelectedItem != null && MessageBox.Show("Esti sigur ca doresti sa stergi acest cont bancar\n Această acțiune este ireversibilă", "AVERTIZARE!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes && listBox1.SelectedItem.ToString() != LogIn.instance.contactiv.ToString())
                {
                    string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    string path = appData + "\\AtomB";
                    string filename = listBox1.SelectedItem.ToString();
                    string completePath = path + "\\" + filename;
                    File.Delete(completePath);
                    listBox1.Items.Remove(selected);
                }
                else if (listBox1.SelectedItem != null && listBox1.SelectedItem.ToString() == LogIn.instance.contactiv.ToString())
                {
                    MessageBox.Show("Nu iti poti sterge contul cat tip esti conectat pe el!", "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show("Mai intai selecteaza un element!\n Nu putem șterge un element NULL", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Focus();
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string path = appData + "\\AtomB";
            listBox1.Items.Clear();
            string[] files = Directory.GetFiles(path);
            string[] dirs = Directory.GetDirectories(path);
            foreach (string file in files)
                listBox1.Items.Add(Path.GetFileName(file));
            foreach (string dir in dirs)
                listBox1.Items.Add(Path.GetFileName(dir));
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    }


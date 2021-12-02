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
    public partial class Card : Form
    {
        public static Card instance;
        public Card(string CardNumber,string NameA,int mounth,int year,double balance,bool isAdmin)
        {
            InitializeComponent();
            instance = this;
            lblAccount.Text = CardNumber.ToString();
            lblName.Text = NameA;
            lblMounth.Text = mounth.ToString();
            lblYear.Text = year.ToString();
            lblBalance.Text = balance.ToString()+ " lei";
            lblAdmin.Text = isAdmin.ToString();
            if(Convert.ToBoolean(isAdmin)==true)
            {
                this.BackColor = Color.Navy;
            }
            else
            {
                this.BackColor = Color.DarkSlateGray;
            }
        }

        private void Card_Load(object sender, EventArgs e)
        {

        }

        private void lblAccount_Click(object sender, EventArgs e)
        {

        }
    }
}

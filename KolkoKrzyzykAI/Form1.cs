using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolkoKrzyzykAI
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();    
            
           
            
        }
        int X, Y;
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (radioButton3x3.Checked == true)
            {
                X = 3;
                Y = 3;
            }
            if (radioButton4x4.Checked == true)
            {
                X = 4;
                Y = 4;
            }
            if (radioButton5x5.Checked == true)
            {
                X = 5;
                Y = 5;
            }
            string nick = textBoxNick.Text;
            this.Hide();
            var form2 = new Form2(X, Y, nick);
            form2.Closed += (s, args) => this.Close();
            form2.Show();         
        }
    }

}

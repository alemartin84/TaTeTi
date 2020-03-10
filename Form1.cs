using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaTeTi
{
    public partial class Form1 : Form
    {
        bool circuloCruz=true; //TRUE=X FALSE=O
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //Cursor.Current = new Cursor("cruz.cur");
            this.Cursor = new Cursor("cir.cur");
        }



        private void b_Click(object sender, EventArgs e)
        {
            // PASO EL OBJETO DEL EVENTO AL TIPO BUTTON
            Button b = new Button();
            b = (Button)sender;

            

            if (b.Text == "")
            {
                circuloCruz =! circuloCruz;
                

                if (circuloCruz)
                {
                    this.Cursor = new Cursor("cir.cur");
                    b.Text = "X";
                    
                }
                else
                {
                    this.Cursor = new Cursor("cruz.cur");
                    b.Text = "O";
                }
            }
            if (ChequeaGanador() != "")
            {
                MessageBox.Show("GANARON LAS: " + ChequeaGanador(), "HAY UN GANADOR!!!");
            }
            // MUESTO EL NOMBRE DEL BOTON DE ORIGEN
            //MessageBox.Show(b.Name);


        }

        private String ChequeaGanador()
        {
            //CONDICIONES HORIZONTALES
            if ((bA1.Text == bA2.Text)&&(bA2.Text == bA3.Text)&&(bA1.Text != ""))
            {
                return bA1.Text;
            }

            if ((bB1.Text == bB2.Text) && (bB2.Text == bB3.Text) && (bB1.Text != ""))
            {
                return bB1.Text;
            }

            if ((bC1.Text == bC2.Text) && (bC2.Text == bC3.Text) && (bC1.Text != ""))
            {
                return bC1.Text;
            }

            //CONDICIONES VERTICALES

            if((bA1.Text == bB1.Text) && (bB1.Text == bC1.Text) && (bA1.Text != ""))
            {
                return bA1.Text;
            }

            if ((bA2.Text == bB2.Text) && (bB2.Text == bC2.Text) && (bA2.Text != ""))
            {
                return bA2.Text;
            }

            if ((bA3.Text == bB3.Text) && (bB3.Text == bC3.Text) && (bA3.Text != ""))
            {
                return bA3.Text;
            }


            //CONDICIONES DIAGONALES
            if ((bA1.Text == bB2.Text) && (bB2.Text == bC3.Text) && (bA1.Text != ""))
            {
                return bA1.Text;
            }

            if ((bC3.Text == bB2.Text) && (bB2.Text == bA3.Text) && (bC3.Text != ""))
            {
                return bC3.Text;
            }

            return "";
        }

        private void resetF2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            circuloCruz = true;
            this.Cursor = new Cursor("cir.cur");

            foreach (var button in this.Controls.OfType<Button>())
            {
                button.Text = "";
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}

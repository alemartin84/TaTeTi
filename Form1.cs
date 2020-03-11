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
                /*

                if (circuloCruz)
                {
                    this.Cursor = new Cursor("cir.cur");
                    b.Text = "X";
                    JuegaPc("O");
                }
                else
                {
                    this.Cursor = new Cursor("cruz.cur");
                    b.Text = "O";
                    JuegaPc("X");
                }
                */
                this.Cursor = new Cursor("cruz.cur");
                b.Text = "O";
                JuegaPc("X");
            }
            
            if (ChequeaGanador() != "")
            {
                MessageBox.Show("GANARON LAS: " + ChequeaGanador(), "HAY UN GANADOR!!!");
                Reset();
            }

            // AGREGAR IA PARA QUE JUEGUE LA PC, EN PRINCIPIO UN RANDOM

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

            if ((bC1.Text == bB2.Text) && (bB2.Text == bA3.Text) && (bC3.Text != ""))
            {
                return bC1.Text;
            }

            return "";
        }

        private void Reset()
        {
            circuloCruz = true;
            this.Cursor = new Cursor("cir.cur");

            foreach (var button in this.Controls.OfType<Button>())
            {
                button.Text = "";
            }
        }
        private void resetF2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void JuegaPc(string xoy)
        {
            //HACER CUMPLIR SFR DEL SOLID separar el chequeo de celdas
            Button[] arrayBotones = new Button[9];
            int i = 0;
            foreach (var button in this.Controls.OfType<Button>())
            {
                //button.Text = "";
                arrayBotones[i] = button;
                i++;
            }

            Random rnd = new Random();
            bool celdaVacia = false;
            int indice = 0;
            bool quedanVacias = false;

            //chequear si quedan celdas vacias
            for (i = 0; i < 9; i++)
            {
                if (arrayBotones[i].Text == "")
                    {
                    quedanVacias = true;
                    }
            }
            /*
            if (quedanVacias == false)
            {
                MessageBox.Show("NO QUEDAN CELDAS");
                Reset();
            }
            */
            while (!celdaVacia && quedanVacias)
            {
                indice = rnd.Next(0, 9);
                if (arrayBotones[indice].Text == "")
                {
                    celdaVacia = true;
                    arrayBotones[indice].Text = xoy;
                    circuloCruz = !circuloCruz;
                    this.Cursor = new Cursor("cir.cur");
                }
               
            }
        }
    }
}

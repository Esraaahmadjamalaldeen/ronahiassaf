using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toc
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        List<Button> Buttons;
        Random rand = new Random();
        bool win = false;

        void loadbutton()
        {
            Buttons = new List<Button> { button1, button2, button3, button4, button10, button6, button7, button8, button9 };
        }

        void wineeffect(Button b1, Button b2, Button b3)
        {
            b1.ForeColor = Color.Blue;
            b2.ForeColor = Color.Blue;
            b3.ForeColor = Color.Blue;
            if (b1.Text == "X")
            {
                label2.Text = (int.Parse(label2.Text) + 1).ToString();
            }
            else
            {
                label1.Text = (int.Parse(label1.Text) + 1).ToString();
            }
            loadbutton();
            //foreach (Control c in panel1.Controls)
            //    if (c is Button)
            //    {
            //        c.Text = "";
            //    }
        }

        private void checkwiner()
        {
            if (button1.Text != "" && button1.Text == button2.Text && button1.Text == button3.Text)
            {
                wineeffect(button1, button2, button3);

                win = true;
            }
            else if (button4.Text != "" && button4.Text == button10.Text && button4.Text == button6.Text)
            {
                wineeffect(button4, button10, button6);

                win = true;
            }
            else if (button7.Text != "" && button7.Text == button8.Text && button7.Text == button9.Text)
            {
                wineeffect(button7, button8, button9);

                win = true;
            }
            else if (button1.Text != "" && button1.Text == button6.Text && button1.Text == button7.Text)
            {
                wineeffect(button1, button7, button6);

                win = true;
            }
            else if (button2.Text != "" && button2.Text == button10.Text && button2.Text == button8.Text)
            {
                wineeffect(button2, button10, button8);

                win = true;
            }
            else if (button3.Text != "" && button3.Text == button4.Text && button3.Text == button9.Text)
            {
                wineeffect(button3, button4, button9);
                

                win = true;
            }
            else if (button1.Text != "" && button1.Text == button10.Text && button1.Text == button9.Text)
            {
                wineeffect(button1, button10, button9);

                win = true;
            }
            else if (button3.Text != "" && button3.Text == button10.Text && button3.Text == button7.Text)
            {
                wineeffect(button3, button10, button7);
                win = true;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            loadbutton();
            win = false;
            foreach (Control c in panel1.Controls)
                if (c is Button)
                {
                    c.Text = "";
                }   

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is Button)
                {
                    c.Click += new System.EventHandler(button_click);
                }

            }
            loadbutton();
        }

        public void button_click(object sender, EventArgs e)
        {
            if (win) return;
            Button btn = (Button)sender;
            if (btn.Text.Equals(""))
            {
                btn.Text = "X";
                btn.ForeColor = Color.White;
                Buttons.Remove(btn);
                checkwiner();
                computerPlay();
            }

        }

        private void computerPlay()
        {
            if (Buttons.Count > 0 && win == false)
            {

                int index = rand.Next(Buttons.Count);
                if (Buttons[index].Text == "")
                {
                    Buttons[index].ForeColor = Color.Yellow;
                    Buttons[index].Text = "O";
                    Buttons.RemoveAt(index);
                    checkwiner();
                    move.Stop();
                }
            }
        }
    }
}

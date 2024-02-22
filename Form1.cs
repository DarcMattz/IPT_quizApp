using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carvajal_quizApp
{
    public partial class Form1 : Form
    {
        string[] question = {
            "Who is the captain of the strawhat pirate?", 
            "Sino prof natin dito?",
            "Sino pinakamagastos dito?",
            "Sinong pinakamagaling mag code?"
        };

        string[,] option = { 
            {"Zoro", "Luffy", "Ussop", "Chopper", "Luffy"},
            {"Arni", "Josh", "Mike", "Adora", "Mike"},
            {"Donn", "JV", "Aaron", "Eya", "Eya"},
            {"Donn", "JV", "Aaron", "Eya", "Donn"},
        };

        int questionNum = 0;
        int score = 0;
        int timerPerQ = 10;


        public Form1()
        {
            InitializeComponent();
        }

        void updateQuestion()
        {
            if (questionNum == question.Length) 
            {
                timer1.Stop();
                return; 
            }
            timerPerQ = 10;
            label1.Text = timerPerQ.ToString();
            timer1.Equals(timerPerQ);
            timer1.Start();
            richTextBox1.Text = question[questionNum];
            radioButton1.Text = option[questionNum, 0];
            radioButton2.Text = option[questionNum, 1];
            radioButton3.Text = option[questionNum, 2];
            radioButton4.Text = option[questionNum, 3];
            
        }

        void check()
        {
            if (radioButton1.Checked)
            {
                if(option[questionNum,0] == option[questionNum, 4])
                {
                    score++;
                }
            }
            else if (radioButton2.Checked)
            {
                if (option[questionNum, 1] == option[questionNum, 4])
                {
                    score++;
                }
            }
            else if (radioButton3.Checked)
            {
                if (option[questionNum, 2] == option[questionNum, 4])
                {
                    score++;
                }
            }
            else if (radioButton4.Checked)
            {
                if (option[questionNum, 3] == option[questionNum, 4])
                {
                    score++;
                }
            }
            else
            {
                MessageBox.Show("Sumagot ka muna!");
                return;
            }

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            
            questionNum++;
            updateQuestion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (questionNum == question.Length - 1)
            {
                check();
                MessageBox.Show("You're Score: " + score.ToString());
                score = 0;
                questionNum = 0;
                updateQuestion();
                return;
            }
            check();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateQuestion();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timerPerQ == 0)
            {
                timer1.Stop();
                MessageBox.Show("You've Run Out of Time!");
                questionNum++;
                updateQuestion();
                return;
            }
            timerPerQ--;
            label1.Text = timerPerQ.ToString();
        }
    }
}

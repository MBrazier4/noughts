using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nought
{
    public partial class Form1 : Form
    {

        string _flag = "o";             // flag for player turn
        bool play = false;              // decides if buttons should be active or disabled
        bool begin = false;             // Begin has been pressed
        int o_score = 0;                
        int x_score = 0;                // player scores

        public Form1()
        {
            
            InitializeComponent();
            button_begin.Select();
            button_begin.Focus();               // sets focus to Begin button
            
        }

        string set()                // returns either x or o depending on whoes turn it is and then inverts _flag
        {
            switch (_flag)
            {
                case "o" :
                    _flag = "x";
                    return "o";    
                case "x" :
                    _flag = "o";
                    return "x";
            }
            return "";
        }


        void check(string btn_str)              // checks to see if a winning scenario has been achieved
        {
            if ((btn_str != "-") & (play))
            {
                if ((button1.Text == btn_str & button2.Text == btn_str & button3.Text == btn_str) | (button1.Text == btn_str & button4.Text == btn_str & button7.Text == btn_str) | (button1.Text == btn_str & button5.Text == btn_str & button9.Text == btn_str) | (button2.Text == btn_str & button5.Text == btn_str & button8.Text == btn_str) | (button3.Text == btn_str & button6.Text == btn_str & button9.Text == btn_str) | (button4.Text == btn_str & button5.Text == btn_str & button6.Text == btn_str) | (button7.Text == btn_str & button8.Text == btn_str & button9.Text == btn_str) | (button1.Text == btn_str & button4.Text == btn_str & button7.Text == btn_str) | (button1.Text == btn_str & button5.Text == btn_str & button9.Text == btn_str) | (button2.Text == btn_str & button5.Text == btn_str & button8.Text == btn_str) | (button3.Text == btn_str & button6.Text == btn_str & button9.Text == btn_str) | (button4.Text == btn_str & button5.Text == btn_str & button6.Text == btn_str) | (button7.Text == btn_str & button5.Text == btn_str & button3.Text == btn_str))
                {               // all possible win conditions
                    switch (btn_str)
                    { 
                        case "o" :
                            txtBox_main.Text = (btn_str + " wins!");
                            o_score += 1;
                            break;

                        case "x":
                            txtBox_main.Text = (btn_str + " wins!");
                            x_score += 1;
                            break;              // incriment score and display winner
                    }

                    lbl_o_score.Text = "score o: " + o_score;
                    lbl_x_score.Text = "score x: " + x_score;               // update scoreboard

                    play = false;               // disables buttons until Begin|Rematch are selected

                }  
            }
            
        }


        void reset_btns()               // resets buttons to "-" neutral state
        {
            List<Button> btns = new List<Button>();             // list of playable buttons (1-9)
            btns.Add(button1);
            btns.Add(button2);
            btns.Add(button3);
            btns.Add(button4);
            btns.Add(button5);
            btns.Add(button6);
            btns.Add(button7);
            btns.Add(button8);
            btns.Add(button9);

            foreach (Button i in btns)
            {
                i.Text = "-";
            }

            if (play)               // if buttons are active then clear display
            {
                txtBox_main.Clear();
            }
        }




        private void button1_Click(object sender, EventArgs e)              // playable button method
        {
            if ((button1.Text == "-") & (play))             // if buttons are active and current button is neutral
            {
                button1.Text = set();               // change button text depending on _flag
            }
            check(button1.Text);                // pass current button value to check for win scenario
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((button2.Text == "-") & (play))
            {
                button2.Text = set();
            }
            check(button2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((button3.Text == "-") & (play))
            {
                button3.Text = set();
            }
            check(button3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((button4.Text == "-") & (play))
            {
                button4.Text = set();
            }
            check(button4.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ((button5.Text == "-") & (play))
            {
                button5.Text = set();
            }
            check(button5.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if ((button6.Text == "-") & (play))
            {
                button6.Text = set();
            }
            check(button6.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if ((button7.Text == "-") & (play))
            {
                button7.Text = set();
            }
            check(button7.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if ((button8.Text == "-") & (play))
            {
                button8.Text = set();
            }
            check(button8.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if ((button9.Text == "-") & (play))
            {
                button9.Text = set();
            }
            check(button9.Text);
        }

        private void button_begin_Click(object sender, EventArgs e)
        {
            begin = true;
            play = true;
            reset_btns();

            o_score = 0;
            x_score = 0;
            lbl_o_score.Text = "score o: " + o_score;
            lbl_x_score.Text = "score x: " + x_score;               // reset all necessary values for fresh game


            Random rnd = new Random();
            int play_first = rnd.Next(0, 2);

            if (play_first == 0)
            {
                txtBox_main.Text = "o plays first!";
                _flag = "o";
            }
            else
            {
                txtBox_main.Text = "x plays first!";
                _flag = "x";                // random number gen to see who plays first
            }

        }

        private void button_rematch_Click(object sender, EventArgs e)
        {
            if (begin)
            {
                reset_btns();
                play = true;                // reset certain values excluding score etc

                if (_flag == "o")
                {
                    txtBox_main.Text = "o plays first!";
                }
                else
                {
                    txtBox_main.Text = "x plays first!";                // inverse of last flag(game winner) goes first next game
                }
            }


        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Game1v2
{
    public partial class Form1 : Form
    {
        TextBox[,] tbarray = new TextBox[5, 5];
        int r1ow;
        int c1ol;
        DateTime gamestartdatetime;
        DateTime gameenddatetime;
        bool gamestart = false;
        int secselapsed = 0;
        bool gamepaused;
        bool solvedbyprogram = false;
        Timer aTimer = new System.Windows.Forms.Timer();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbarray[0, 0] = this.textBox00;
            tbarray[0, 0] = this.textBox00;
            tbarray[0, 1] = this.textBox01;
            tbarray[0, 2] = this.textBox02;
            tbarray[0, 3] = this.textBox03;
            tbarray[0, 4] = this.textBox04;
            tbarray[1, 0] = this.textBox10;
            tbarray[1, 1] = this.textBox11;
            tbarray[1, 2] = this.textBox12;
            tbarray[1, 3] = this.textBox13;
            tbarray[1, 4] = this.textBox14;
            tbarray[2, 0] = this.textBox20;
            tbarray[2, 1] = this.textBox21;
            tbarray[2, 2] = this.textBox22;
            tbarray[2, 3] = this.textBox23;
            tbarray[2, 4] = this.textBox24;
            tbarray[3, 0] = this.textBox30;
            tbarray[3, 1] = this.textBox31;
            tbarray[3, 2] = this.textBox32;
            tbarray[3, 3] = this.textBox33;
            tbarray[3, 4] = this.textBox34;
            tbarray[4, 0] = this.textBox40;
            tbarray[4, 1] = this.textBox41;
            tbarray[4, 2] = this.textBox42;
            tbarray[4, 3] = this.textBox43;
            tbarray[4, 4] = this.textBox44;
            Cleararray();
            Red1();
            textBox27.Select();
            
        }

        private void Sendit(string name, DateTime start,string secs, string result,DateTime end)
        {
            TimeSpan ttl = end - start;
            int game = 1;
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "plays.txt";
            if (!File.Exists(filepath))
            {
                File.CreateText(filepath).Close();
                List<string> lines = File.ReadAllLines(filepath).ToList();
                lines.Add(game + "," + name + "," + start + "," + secs + "," + ttl + "," + result);
                File.WriteAllLines(filepath, lines);
            }
            else
            {
                List<string> lines = File.ReadAllLines(filepath).ToList();
                lines.Add(game + "," + name + "," + start + "," + secs + "," + ttl + "," + result);
                File.WriteAllLines(filepath, lines);
            }
            
        }

        private void Isnewopause()
        {
            if(gamestart == false)
            {
                aTimer.Tick += new EventHandler(aTimer_Tick);
                aTimer.Interval = 1000; // 1 second
                aTimer.Start();
                textBox1.Text = secselapsed.ToString();
                gamestart = true;
                gamestartdatetime = DateTime.Now;

            }
            if(gamepaused == true)
            {
                aTimer.Start();
                gamepaused = false;
            }
        }

        private void aTimer_Tick(object sender, EventArgs e)
        {
            secselapsed++;
            textBox1.Text = secselapsed.ToString();
        }

        private Boolean Ck0up(int row, int col)
        {
            Int32.TryParse(tbarray[row - 1, col].Text, out int a);
            if (a == 0)
            {
                return true;
            }
            else return false;
        }

        private Boolean Ck0dn(int row, int col)
        {
            Int32.TryParse(tbarray[row + 1, col].Text, out int a);
            if (a == 0)
            {
                return true;
            }
            else return false;
        }

        private Boolean Ck0lft(int row, int col)
        {
            Int32.TryParse(tbarray[row, col - 1].Text, out int a);
            if (a == 0)
            {
                return true;
            }
            else return false;
        }

        private Boolean Ck0rt(int row, int col)
        {
            Int32.TryParse(tbarray[row, col+1].Text, out int a);
            if (a == 0)
            {
                return true;
            }
            else return false;
        }

        private Boolean Ck0c1(int row, int col)
        {
            Int32.TryParse(tbarray[row-1, col-1].Text, out int a);
            if (a == 0)
            {
                return true;
            }
            else return false;
        }

        private Boolean Ck0c2(int row, int col)
        {
            Int32.TryParse(tbarray[row - 1, col + 1].Text, out int a);
            if (a == 0)
            {
                return true;
            }
            else return false;
        }

        private Boolean Ck0c3(int row, int col)
        {
            Int32.TryParse(tbarray[row + 1, col - 1].Text, out int a);
            if (a == 0)
            {
                return true;
            }
            else return false;
        }

        private Boolean Ck0c4(int row, int col)
        {
            Int32.TryParse(tbarray[row + 1, col + 1].Text, out int a);
            if (a == 0)
            {
                return true;
            }
            else return false;
        }

        private void Solvefor(int row, int col) 
        {
            solvedbyprogram = true;
            int placed = 2;
            int currentrow = row;
            int currentcol = col;
            tbarray[row, col].Text = "1";
            tbarray[row, col].ReadOnly = true;
            tbarray[row, col].ForeColor = Color.Red;
            while(Inarrayez(25) == false)
            {                
                //middle 9
                if((currentrow == 1 && currentcol == 1) || (currentrow == 1 && currentcol == 2) || (currentrow == 1 && currentcol == 3) || (currentrow == 2 && currentcol == 1) || (currentrow == 2 && currentcol == 2) || (currentrow == 2 && currentcol == 3) || (currentrow == 3 && currentcol == 1) || (currentrow == 3 && currentcol == 2) || (currentrow == 3 && currentcol == 3)){
                    if (Ck0up(currentrow, currentcol) || Ck0dn(currentrow, currentcol) || Ck0lft(currentrow, currentcol) || Ck0rt(currentrow, currentcol) || Ck0c1(currentrow, currentcol) || Ck0c2(currentrow, currentcol) || Ck0c3(currentrow, currentcol) || Ck0c4(currentrow, currentcol)) {
                        int placed2 = 0;
                        while (placed2 != 1)
                        {
                            Random rand = new Random();
                            int move = rand.Next(1, 9);
                            if (move == 1 && Ck0up(currentrow, currentcol))
                            {
                                tbarray[currentrow - 1, currentcol].Text = placed.ToString();
                                currentrow--;
                                
                                placed++;
                                placed2++;
                            }
                            else if (move == 2 && Ck0dn(currentrow, currentcol))
                            {
                                tbarray[currentrow + 1, currentcol].Text = placed.ToString();
                                currentrow++;
                                
                                placed++;
                                placed2++;
                            }
                            else if (move == 3 && Ck0lft(currentrow, currentcol))
                            {
                                tbarray[currentrow, currentcol - 1].Text = placed.ToString();
                                currentcol--;
                                
                                placed++;
                                placed2++;
                            }
                            else if (move == 4 && Ck0rt(currentrow, currentcol))
                            {
                                tbarray[currentrow, currentcol + 1].Text = placed.ToString();
                                currentcol++;
                                
                                placed++;
                                placed2++;
                            }
                            else if (move == 5 && Ck0c1(currentrow, currentcol))
                            {
                                tbarray[currentrow - 1, currentcol - 1].Text = placed.ToString();
                                currentrow--;
                                currentcol--;
                                
                                placed++;
                                placed2++;
                            }
                            else if (move == 6 && Ck0c2(currentrow, currentcol))
                            {
                                tbarray[currentrow - 1, currentcol + 1].Text = placed.ToString();
                                currentrow--;
                                currentcol++;
                                
                                placed++;
                                placed2++;
                            }
                            else if (move == 7 && Ck0c3(currentrow, currentcol))
                            {
                                tbarray[currentrow + 1, currentcol - 1].Text = placed.ToString();
                                currentrow++;
                                currentcol--;
                                
                                placed++;
                                placed2++;
                            }
                            else if (move == 8 && Ck0c4(currentrow, currentcol))
                            {
                                tbarray[currentrow + 1, currentcol + 1].Text = placed.ToString();
                                currentrow++;
                                currentcol++;
                                
                                placed++;
                                placed2++;
                            }

                        }
                    }
                    else if(placed < 26)
                    {
                        Cleararray();
                        Solvefor(row, col);
                    }
                }
                //top middle 3
                 else if ((currentrow == 0 && currentcol == 1) || (currentrow == 0 && currentcol == 2) || (currentrow == 0 && currentcol == 3))
                {
                    if (Ck0dn(currentrow, currentcol) || Ck0lft(currentrow, currentcol) || Ck0rt(currentrow, currentcol) || Ck0c3(currentrow, currentcol) || Ck0c4(currentrow, currentcol))
                    {
                        int placed2 = 0;
                        while (placed2 != 1)
                        {
                            Random rand = new Random();
                            int move = rand.Next(1, 6);
                            
                            if (move == 1 && Ck0dn(currentrow, currentcol))
                            {
                                tbarray[currentrow + 1, currentcol].Text = placed.ToString();
                                currentrow++;
                                
                                placed++;
                                placed2++;
                            }
                            else if (move == 2 && Ck0lft(currentrow, currentcol))
                            {
                                tbarray[currentrow, currentcol - 1].Text = placed.ToString();
                                currentcol--;
                                
                                placed++;
                                placed2++;
                            }
                            else if (move == 3 && Ck0rt(currentrow, currentcol))
                            {
                                tbarray[currentrow, currentcol + 1].Text = placed.ToString();
                                currentcol++;
                                
                                placed++;
                                placed2++;
                            }                            
                            else if (move == 4 && Ck0c3(currentrow, currentcol))
                            {
                                tbarray[currentrow + 1, currentcol - 1].Text = placed.ToString();
                                currentrow++;
                                currentcol--;
                                
                                placed++;
                                placed2++;
                            }
                            else if (move == 5 && Ck0c4(currentrow, currentcol))
                            {
                                tbarray[currentrow + 1, currentcol + 1].Text = placed.ToString();
                                currentrow++;
                                currentcol++;
                                
                                placed++;
                                placed2++;
                            }

                        }
                    }
                    else if (placed < 26)
                    {
                        Cleararray();
                        Solvefor(row, col);
                    }
                }
                //bottom middle 3
                else if ((currentrow == 4 && currentcol == 1) || (currentrow == 4 && currentcol == 2) || (currentrow == 4 && currentcol == 3))
                {
                    if (Ck0up(currentrow, currentcol) ||  Ck0lft(currentrow, currentcol) || Ck0rt(currentrow, currentcol) || Ck0c1(currentrow, currentcol) || Ck0c2(currentrow, currentcol))
                    {
                        int placed2 = 0;
                        while (placed2 != 1)
                        {
                            Random rand = new Random();
                            int move = rand.Next(1, 6);
                            if (move == 1 && Ck0up(currentrow, currentcol))
                            {
                                tbarray[currentrow - 1, currentcol].Text = placed.ToString();
                                currentrow--;
                                
                                placed++;
                                placed2++;
                            }
                            else if (move == 2 && Ck0lft(currentrow, currentcol))
                            {
                                tbarray[currentrow, currentcol - 1].Text = placed.ToString();
                                currentcol--;
                                
                                placed++;
                                placed2++;
                            }
                            else if (move == 3 && Ck0rt(currentrow, currentcol))
                            {
                                tbarray[currentrow, currentcol + 1].Text = placed.ToString();
                                currentcol++;
                                
                                placed++;
                                placed2++;
                            }
                            else if (move == 4 && Ck0c1(currentrow, currentcol))
                            {
                                tbarray[currentrow - 1, currentcol - 1].Text = placed.ToString();
                                currentrow--;
                                currentcol--;
                                
                                placed++;
                                placed2++;
                            }
                            else if (move == 5 && Ck0c2(currentrow, currentcol))
                            {
                                tbarray[currentrow - 1, currentcol + 1].Text = placed.ToString();
                                currentrow--;
                                currentcol++;
                                
                                placed++;
                                placed2++;
                            }                            

                        }
                    }
                    else if (placed < 26)
                    {
                        Cleararray();
                        Solvefor(row, col);
                    }
                }
                //left middle 3
                else if ((currentrow == 1 && currentcol == 0) || (currentrow == 2 && currentcol == 0) || (currentrow == 3 && currentcol == 0))
                {
                    if (Ck0up(currentrow, currentcol) || Ck0dn(currentrow, currentcol) || Ck0rt(currentrow, currentcol) || Ck0c2(currentrow, currentcol) || Ck0c4(currentrow, currentcol))
                    {
                        int placed2 = 0;
                        while (placed2 != 1)
                        {
                            Random rand = new Random();
                            int move = rand.Next(1, 6);
                            if (move == 1 && Ck0up(currentrow, currentcol))
                            {
                                tbarray[currentrow - 1, currentcol].Text = placed.ToString();
                                currentrow--;
                                
                                placed++;
                                placed2++;
                            }
                            else if (move == 2 && Ck0dn(currentrow, currentcol))
                            {
                                tbarray[currentrow + 1, currentcol].Text = placed.ToString();
                                currentrow++;
                                
                                placed++;
                                placed2++;
                            }                           
                            else if (move == 3 && Ck0rt(currentrow, currentcol))
                            {
                                tbarray[currentrow, currentcol + 1].Text = placed.ToString();
                                currentcol++;
                                
                                placed++;
                                placed2++;
                            }                            
                            else if (move == 4 && Ck0c2(currentrow, currentcol))
                            {
                                tbarray[currentrow - 1, currentcol + 1].Text = placed.ToString();
                                currentrow--;
                                currentcol++;
                                
                                placed++;
                                placed2++;
                            }                            
                            else if (move == 5 && Ck0c4(currentrow, currentcol))
                            {
                                tbarray[currentrow + 1, currentcol + 1].Text = placed.ToString();
                                currentrow++;
                                currentcol++;
                                
                                placed++;
                                placed2++;
                            }
                        }
                    }
                    else if (placed < 26)
                    {
                        Cleararray();
                        Solvefor(row, col);
                    }
                }
                //Right middle three
                else if ((currentrow == 1 && currentcol == 4) || (currentrow == 2 && currentcol == 4) || (currentrow == 3 && currentcol == 4))
                {
                    if (Ck0up(currentrow, currentcol) || Ck0dn(currentrow, currentcol) || Ck0lft(currentrow, currentcol) || Ck0c1(currentrow, currentcol) || Ck0c3(currentrow, currentcol))
                    {
                        int placed2 = 0;
                        while (placed2 != 1)
                        {
                            Random rand = new Random();
                            int move = rand.Next(1, 6);
                            if (move == 1 && Ck0up(currentrow, currentcol))
                            {
                                tbarray[currentrow - 1, currentcol].Text = placed.ToString();
                                currentrow--;
                                
                                placed++;
                                placed2++;
                            }
                            else if (move == 2 && Ck0dn(currentrow, currentcol))
                            {
                                tbarray[currentrow + 1, currentcol].Text = placed.ToString();
                                currentrow++;
                                
                                placed++;
                                placed2++;
                            }
                            else if (move == 3 && Ck0lft(currentrow, currentcol))
                            {
                                tbarray[currentrow, currentcol - 1].Text = placed.ToString();
                                currentcol--;
                                
                                placed++;
                                placed2++;
                            }                            
                            else if (move == 4 && Ck0c1(currentrow, currentcol))
                            {
                                tbarray[currentrow - 1, currentcol - 1].Text = placed.ToString();
                                currentrow--;
                                currentcol--;
                                
                                placed++;
                                placed2++;
                            }
                            else if (move == 5 && Ck0c3(currentrow, currentcol))
                            {
                                tbarray[currentrow + 1, currentcol - 1].Text = placed.ToString();
                                currentrow++;
                                currentcol--;
                                
                                placed++;
                                placed2++;
                            }
                            
                        }
                    }
                    else if (placed < 26)
                    {
                        Cleararray();
                        Solvefor(row, col);
                    }
                }
                // c1
                else if ((currentrow == 0 && currentcol == 0))
                {
                    if ( Ck0dn(currentrow, currentcol) || Ck0rt(currentrow, currentcol) || Ck0c4(currentrow, currentcol))
                    {
                        int placed2 = 0;
                        while (placed2 != 1)
                        {
                            Random rand = new Random();
                            int move = rand.Next(1, 4);
                            
                            if (move == 1 && Ck0dn(currentrow, currentcol))
                            {
                                tbarray[currentrow + 1, currentcol].Text = placed.ToString();
                                currentrow++;
                                
                                placed++;
                                placed2++;
                            }                            
                            else if (move == 2 && Ck0rt(currentrow, currentcol))
                            {
                                tbarray[currentrow, currentcol + 1].Text = placed.ToString();
                                currentcol++;
                                
                                placed++;
                                placed2++;
                            }                            
                            else if (move == 3 && Ck0c4(currentrow, currentcol))
                            {
                                tbarray[currentrow + 1, currentcol + 1].Text = placed.ToString();
                                currentrow++;
                                currentcol++;
                                
                                placed++;
                                placed2++;
                            }
                        }
                    }
                    else if (placed < 26)
                    {
                        Cleararray();
                        Solvefor(row, col);
                    }
                }
                // c2
                else if ((currentrow == 0 && currentcol == 4))
                {
                    if (Ck0dn(currentrow, currentcol) || Ck0lft(currentrow, currentcol) || Ck0c3(currentrow, currentcol))
                    {
                        int placed2 = 0;
                        while (placed2 != 1)
                        {
                            Random rand = new Random();
                            int move = rand.Next(1, 4);
                            
                            if (move == 1 && Ck0dn(currentrow, currentcol))
                            {
                                tbarray[currentrow + 1, currentcol].Text = placed.ToString();
                                currentrow++;
                                
                                placed++;
                                placed2++;
                            }
                            else if (move == 2 && Ck0lft(currentrow, currentcol))
                            {
                                tbarray[currentrow, currentcol - 1].Text = placed.ToString();
                                currentcol--;
                                
                                placed++;
                                placed2++;
                            }                           
                            else if (move == 3 && Ck0c3(currentrow, currentcol))
                            {
                                tbarray[currentrow + 1, currentcol - 1].Text = placed.ToString();
                                currentrow++;
                                currentcol--;
                                
                                placed++;
                                placed2++;
                            }
                            
                        }
                    }
                    else if (placed < 26)
                    {
                        Cleararray();
                        Solvefor(row, col);
                    }
                }
                //c3
                else if ((currentrow == 4 && currentcol == 0))
                {
                    if (Ck0up(currentrow, currentcol) || Ck0rt(currentrow, currentcol) || Ck0c2(currentrow, currentcol))
                    {
                        int placed2 = 0;
                        while (placed2 != 1)
                        {
                            Random rand = new Random();
                            int move = rand.Next(1, 4);
                            if (move == 1 && Ck0up(currentrow, currentcol))
                            {
                                tbarray[currentrow - 1, currentcol].Text = placed.ToString();
                                currentrow--;
                                
                                placed++;
                                placed2++;
                            }
                            
                            else if (move == 2 && Ck0rt(currentrow, currentcol))
                            {
                                tbarray[currentrow, currentcol + 1].Text = placed.ToString();
                                currentcol++;
                                
                                placed++;
                                placed2++;
                            }                           
                            else if (move == 3 && Ck0c2(currentrow, currentcol))
                            {
                                tbarray[currentrow - 1, currentcol + 1].Text = placed.ToString();
                                currentrow--;
                                currentcol++;
                                
                                placed++;
                                placed2++;
                            }
                           
                        }
                    }
                    else if (placed < 26)
                    {
                        Cleararray();
                        Solvefor(row, col);
                    }
                }
                //c4
                else if ((currentrow == 4 && currentcol == 4))
                {
                    if (Ck0up(currentrow, currentcol) || Ck0lft(currentrow, currentcol) || Ck0c1(currentrow, currentcol))
                    {
                        int placed2 = 0;
                        while (placed2 != 1)
                        {
                            Random rand = new Random();
                            int move = rand.Next(1, 4);
                            if (move == 1 && Ck0up(currentrow, currentcol))
                            {
                                tbarray[currentrow - 1, currentcol].Text = placed.ToString();
                                currentrow--;
                                
                                placed++;
                                placed2++;
                            }
                            else if (move == 2 && Ck0lft(currentrow, currentcol))
                            {
                                tbarray[currentrow, currentcol - 1].Text = placed.ToString();
                                currentcol--;
                                
                                placed++;
                                placed2++;
                            }
                            else if (move == 3 && Ck0c1(currentrow, currentcol))
                            {
                                tbarray[currentrow - 1, currentcol - 1].Text = placed.ToString();
                                currentrow--;
                                currentcol--;
                                
                                placed++;
                                placed2++;
                                
                            }

                        }
                    }
                    else if (placed < 26)
                    {
                        Cleararray();
                        Solvefor(row, col);
                    }
                }
                else
                {
                    MessageBox.Show("index Not in the array");
                }
                

            }

        }

        private void Red1()
        {
            var rand = new Random();
            int randrow = rand.Next(0, 5);
            int randcol = rand.Next(0, 5);
            r1ow = randrow;
            c1ol = randcol;
            tbarray[randrow, randcol].Text = "1";
            tbarray[randrow, randcol].ReadOnly = true;
            tbarray[randrow, randcol].ForeColor = Color.Red;
            tbarray[randrow, randcol].BackColor = tbarray[randrow, randcol].BackColor;
        }

        private Boolean Inarray(int inp, int boxrow, int boxcol)
        {
            Boolean temp = false;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i != boxrow || j != boxcol)
                    {
                        Int32.TryParse(tbarray[i, j].Text, out int a);
                        if (a == inp && a != 0)
                        {
                            temp = true;
                        }

                    }

                }
            }
            return temp;
        }

        private Boolean Inarrayez(int inp)
        {
            Boolean temp = false;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Int32.TryParse(tbarray[i, j].Text, out int a);
                    if (a == inp)
                    {
                        temp = true;
                    }

                }
            }
            return temp;
        }

        private void Cleararray()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tbarray[i, j].Text = "";
                    tbarray[i, j].ReadOnly = false;
                    tbarray[i, j].ForeColor = Color.Black;
                    tbarray[i, j].BackColor = tbarray[i, j].BackColor;
                }
            }

        }

        private void Wincheck()
        {

            
            Boolean hasno0 = (!Inarrayez(0));
            Boolean hasnums = (Inarrayez(1) && Inarrayez(2) && Inarrayez(3) && Inarrayez(4) && Inarrayez(5) && Inarrayez(6) && Inarrayez(7) && Inarrayez(8) && Inarrayez(9) && Inarrayez(10) && Inarrayez(11) && Inarrayez(12) && Inarrayez(13) && Inarrayez(14) && Inarrayez(15) && Inarrayez(16) && Inarrayez(17) && Inarrayez(18) && Inarrayez(19) && Inarrayez(20) && Inarrayez(21) && Inarrayez(22) && Inarrayez(23) && Inarrayez(24) && Inarrayez(25));
            if (hasno0 && hasnums && solvedbyprogram == false)
            {
                gameenddatetime = DateTime.Now;
                aTimer.Stop();                
                MessageBox.Show("Congradulations You Win!", "Winner!");
                string message = "New Game? (No = Quit)";
                string title = "Another?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                Sendit(textBox27.Text, gamestartdatetime, textBox1.Text,"Win",gameenddatetime);
                if (result == DialogResult.Yes)
                {
                    Cleararray();
                    Red1();
                    textBox27.Select();
                    textBox1.Text = "";
                    aTimer.Tick -= new EventHandler(aTimer_Tick);
                    solvedbyprogram = false;
                    gamestart = false;
                    secselapsed = 0;

                }
                if (result == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            

        }

        private void Check8(int boxrow, int boxcol)
        {
            int inp;

            if ((Int32.TryParse(tbarray[boxrow, boxcol].Text, out inp) == true && String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == false) || (Int32.TryParse(tbarray[boxrow, boxcol].Text, out inp) == false && String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == true))
            {
                if (Inarray(inp, boxrow, boxcol) != true)
                {

                    if (String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == false)
                    {
                        Int32.TryParse(tbarray[boxrow - 1, boxcol - 1].Text, out int a);
                        Int32.TryParse(tbarray[boxrow - 1, boxcol].Text, out int b);
                        Int32.TryParse(tbarray[boxrow - 1, boxcol + 1].Text, out int c);
                        Int32.TryParse(tbarray[boxrow, boxcol - 1].Text, out int d);
                        Int32.TryParse(tbarray[boxrow + 1, boxcol - 1].Text, out int ee);
                        Int32.TryParse(tbarray[boxrow + 1, boxcol].Text, out int f);
                        Int32.TryParse(tbarray[boxrow + 1, boxcol + 1].Text, out int g);
                        Int32.TryParse(tbarray[boxrow, boxcol + 1].Text, out int h);
                        if (a != inp - 1 && b != inp - 1 && c != inp - 1 && d != inp - 1 && ee != inp - 1 && f != inp - 1 && g != inp - 1 && h != inp - 1)
                        {
                            MessageBox.Show("Out of sequence", "Error");
                            tbarray[boxrow, boxcol].Text = "";
                        }
                        else if (inp == 25 && Inarrayez(0) == false)
                        {
                            MessageBox.Show("Congradulations You Win!", "Winner!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Number already used", "Error");
                    tbarray[boxrow, boxcol].Text = "";
                }
            }
            else
            {
                MessageBox.Show("Not a number in [" + boxrow.ToString() + "," + boxcol.ToString() + "]" + tbarray[boxrow - 1, boxcol - 1].Text, "Error");
                tbarray[boxrow, boxcol].Text = "";
            }
        }

        private void CheckUp5(int boxrow, int boxcol)
        {
            int inp;
            if ((Int32.TryParse(tbarray[boxrow, boxcol].Text, out inp) == true && String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == false) || (Int32.TryParse(tbarray[boxrow, boxcol].Text, out inp) == false && String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == true))
            {
                if (Inarray(inp, boxrow, boxcol) != true)
                {

                    if (String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == false)
                    {
                        Int32.TryParse(tbarray[boxrow - 1, boxcol - 1].Text, out int a);
                        Int32.TryParse(tbarray[boxrow - 1, boxcol].Text, out int b);
                        Int32.TryParse(tbarray[boxrow - 1, boxcol + 1].Text, out int c);
                        Int32.TryParse(tbarray[boxrow, boxcol - 1].Text, out int d);
                        //Int32.TryParse(tbarray[boxrow + 1, boxcol - 1].Text, out int ee);
                        //Int32.TryParse(tbarray[boxrow + 1, boxcol].Text, out int f);
                        //Int32.TryParse(tbarray[boxrow + 1, boxcol + 1].Text, out int g);
                        Int32.TryParse(tbarray[boxrow, boxcol + 1].Text, out int h);
                        if (a != inp - 1 && b != inp - 1 && c != inp - 1 && d != inp - 1 && h != inp - 1)
                        {
                            MessageBox.Show("Out of sequence", "Error");
                            tbarray[boxrow, boxcol].Text = "";
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Number already used", "Error");
                    tbarray[boxrow, boxcol].Text = "";
                }
            }
            else
            {
                MessageBox.Show("Not a number in [" + boxrow.ToString() + "," + boxcol.ToString() + "]", "Error");
                tbarray[boxrow, boxcol].Text = "";
            }
        }

        private void CheckDn5(int boxrow, int boxcol)
        {
            int inp;
            if ((Int32.TryParse(tbarray[boxrow, boxcol].Text, out inp) == true && String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == false) || (Int32.TryParse(tbarray[boxrow, boxcol].Text, out inp) == false && String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == true))
            {
                if (Inarray(inp, boxrow, boxcol) != true)
                {
                    if (String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == false)
                    {
                        //Int32.TryParse(tbarray[boxrow - 1, boxcol - 1].Text, out int a);
                        //Int32.TryParse(tbarray[boxrow - 1, boxcol].Text, out int b);
                        //Int32.TryParse(tbarray[boxrow - 1, boxcol + 1].Text, out int c);
                        Int32.TryParse(tbarray[boxrow, boxcol - 1].Text, out int d);
                        Int32.TryParse(tbarray[boxrow + 1, boxcol - 1].Text, out int ee);
                        Int32.TryParse(tbarray[boxrow + 1, boxcol].Text, out int f);
                        Int32.TryParse(tbarray[boxrow + 1, boxcol + 1].Text, out int g);
                        Int32.TryParse(tbarray[boxrow, boxcol + 1].Text, out int h);
                        if (ee != inp - 1 && f != inp - 1 && g != inp - 1 && d != inp - 1 && h != inp - 1)
                        {
                            MessageBox.Show("Out of sequence", "Error");
                            tbarray[boxrow, boxcol].Text = "";
                        }


                    }
                }
                else
                {
                    MessageBox.Show("Number already used", "Error");
                    tbarray[boxrow, boxcol].Text = "";
                }
            }
            else
            {
                MessageBox.Show("Not a number in [" + boxrow.ToString() + "," + boxcol.ToString() + "]" + tbarray[boxrow - 1, boxcol - 1].Text, "Error");
                tbarray[boxrow, boxcol].Text = "";
            }
        }

        private void CheckLft5(int boxrow, int boxcol)
        {
            int inp;
            if ((Int32.TryParse(tbarray[boxrow, boxcol].Text, out inp) == true && String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == false) || (Int32.TryParse(tbarray[boxrow, boxcol].Text, out inp) == false && String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == true))
            {
                if (Inarray(inp, boxrow, boxcol) != true)
                {
                    if (String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == false)
                    {
                        Int32.TryParse(tbarray[boxrow - 1, boxcol - 1].Text, out int a);
                        Int32.TryParse(tbarray[boxrow - 1, boxcol].Text, out int b);
                        //Int32.TryParse(tbarray[boxrow - 1, boxcol + 1].Text, out int c);
                        Int32.TryParse(tbarray[boxrow, boxcol - 1].Text, out int d);
                        Int32.TryParse(tbarray[boxrow + 1, boxcol - 1].Text, out int ee);
                        Int32.TryParse(tbarray[boxrow + 1, boxcol].Text, out int f);
                        //Int32.TryParse(tbarray[boxrow + 1, boxcol + 1].Text, out int g);
                        //Int32.TryParse(tbarray[boxrow, boxcol + 1].Text, out int h);
                        if (ee != inp - 1 && f != inp - 1 && a != inp - 1 && b != inp - 1 && d != inp - 1)
                        {
                            MessageBox.Show("Out of sequence", "Error");
                            tbarray[boxrow, boxcol].Text = "";
                        }


                    }
                }
                else
                {
                    MessageBox.Show("Number already used", "Error");
                    tbarray[boxrow, boxcol].Text = "";
                }
            }
            else
            {
                MessageBox.Show("Not a number in [" + boxrow.ToString() + "," + boxcol.ToString() + "]" + tbarray[boxrow - 1, boxcol - 1].Text, "Error");
                tbarray[boxrow, boxcol].Text = "";
            }
        }

        private void CheckRt5(int boxrow, int boxcol)
        {
            int inp;
            if ((Int32.TryParse(tbarray[boxrow, boxcol].Text, out inp) == true && String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == false) || (Int32.TryParse(tbarray[boxrow, boxcol].Text, out inp) == false && String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == true))
            {
                if (Inarray(inp, boxrow, boxcol) != true)
                {
                    if (String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == false)
                    {
                        //Int32.TryParse(tbarray[boxrow - 1, boxcol - 1].Text, out int a);
                        Int32.TryParse(tbarray[boxrow - 1, boxcol].Text, out int b);
                        Int32.TryParse(tbarray[boxrow - 1, boxcol + 1].Text, out int c);
                        //Int32.TryParse(tbarray[boxrow, boxcol - 1].Text, out int d);
                        //Int32.TryParse(tbarray[boxrow + 1, boxcol - 1].Text, out int ee);
                        Int32.TryParse(tbarray[boxrow + 1, boxcol].Text, out int f);
                        Int32.TryParse(tbarray[boxrow + 1, boxcol + 1].Text, out int g);
                        Int32.TryParse(tbarray[boxrow, boxcol + 1].Text, out int h);
                        if (c != inp - 1 && f != inp - 1 && g != inp - 1 && b != inp - 1 && h != inp - 1)
                        {
                            MessageBox.Show("Out of sequence", "Error");
                            tbarray[boxrow, boxcol].Text = "";
                        }


                    }
                }
                else
                {
                    MessageBox.Show("Number already used", "Error");
                    tbarray[boxrow, boxcol].Text = "";
                }
            }
            else
            {
                MessageBox.Show("Not a number in [" + boxrow.ToString() + "," + boxcol.ToString() + "]" + tbarray[boxrow - 1, boxcol - 1].Text, "Error");
                tbarray[boxrow, boxcol].Text = "";
            }
        }

        private void ChkCnr00(int boxrow, int boxcol)
        {
            int inp;
            if ((Int32.TryParse(tbarray[boxrow, boxcol].Text, out inp) == true && String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == false) || (Int32.TryParse(tbarray[boxrow, boxcol].Text, out inp) == false && String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == true))
            {
                if (Inarray(inp, boxrow, boxcol) != true)
                {
                    if (String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == false)
                    {
                        //Int32.TryParse(tbarray[boxrow - 1, boxcol - 1].Text, out int a);
                        //Int32.TryParse(tbarray[boxrow - 1, boxcol].Text, out int b);
                        //Int32.TryParse(tbarray[boxrow - 1, boxcol + 1].Text, out int c);
                        //Int32.TryParse(tbarray[boxrow, boxcol - 1].Text, out int d);
                        //Int32.TryParse(tbarray[boxrow + 1, boxcol - 1].Text, out int ee);
                        Int32.TryParse(tbarray[boxrow + 1, boxcol].Text, out int f);
                        Int32.TryParse(tbarray[boxrow + 1, boxcol + 1].Text, out int g);
                        Int32.TryParse(tbarray[boxrow, boxcol + 1].Text, out int h);
                        if (f != inp - 1 && g != inp - 1 && h != inp - 1)
                        {
                            MessageBox.Show("Out of sequence", "Error");
                            tbarray[boxrow, boxcol].Text = "";
                        }


                    }
                }
                else
                {
                    MessageBox.Show("Number already used", "Error");
                    tbarray[boxrow, boxcol].Text = "";
                }
            }
            else
            {
                MessageBox.Show("Not a number in [" + boxrow.ToString() + "," + boxcol.ToString() + "]" + tbarray[boxrow - 1, boxcol - 1].Text, "Error");
                tbarray[boxrow, boxcol].Text = "";
            }
        }

        private void ChkCnr04(int boxrow, int boxcol)
        {
            int inp;
            if ((Int32.TryParse(tbarray[boxrow, boxcol].Text, out inp) == true && String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == false) || (Int32.TryParse(tbarray[boxrow, boxcol].Text, out inp) == false && String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == true))
            {
                if (Inarray(inp, boxrow, boxcol) != true)
                {
                    if (String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == false)
                    {
                        //Int32.TryParse(tbarray[boxrow - 1, boxcol - 1].Text, out int a);
                        //Int32.TryParse(tbarray[boxrow - 1, boxcol].Text, out int b);
                        //Int32.TryParse(tbarray[boxrow - 1, boxcol + 1].Text, out int c);
                        Int32.TryParse(tbarray[boxrow, boxcol - 1].Text, out int d);
                        Int32.TryParse(tbarray[boxrow + 1, boxcol - 1].Text, out int ee);
                        Int32.TryParse(tbarray[boxrow + 1, boxcol].Text, out int f);
                        //Int32.TryParse(tbarray[boxrow + 1, boxcol + 1].Text, out int g);
                        //Int32.TryParse(tbarray[boxrow, boxcol + 1].Text, out int h);
                        if (f != inp - 1 && ee != inp - 1 && d != inp - 1)
                        {
                            MessageBox.Show("Out of sequence", "Error");
                            tbarray[boxrow, boxcol].Text = "";
                        }


                    }
                }
                else
                {
                    MessageBox.Show("Number already used", "Error");
                    tbarray[boxrow, boxcol].Text = "";
                }
            }
            else
            {
                MessageBox.Show("Not a number in [" + boxrow.ToString() + "," + boxcol.ToString() + "]" + tbarray[boxrow - 1, boxcol - 1].Text, "Error");
                tbarray[boxrow, boxcol].Text = "";
            }
        }

        private void ChkCnr40(int boxrow, int boxcol)
        {
            int inp;
            if ((Int32.TryParse(tbarray[boxrow, boxcol].Text, out inp) == true && String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == false) || (Int32.TryParse(tbarray[boxrow, boxcol].Text, out inp) == false && String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == true))
            {
                if (Inarray(inp, boxrow, boxcol) != true)
                {
                    if (String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == false)
                    {
                        //Int32.TryParse(tbarray[boxrow - 1, boxcol - 1].Text, out int a);
                        Int32.TryParse(tbarray[boxrow - 1, boxcol].Text, out int b);
                        Int32.TryParse(tbarray[boxrow - 1, boxcol + 1].Text, out int c);
                        //Int32.TryParse(tbarray[boxrow, boxcol - 1].Text, out int d);
                        //Int32.TryParse(tbarray[boxrow + 1, boxcol - 1].Text, out int ee);
                        //Int32.TryParse(tbarray[boxrow + 1, boxcol].Text, out int f);
                        //Int32.TryParse(tbarray[boxrow + 1, boxcol + 1].Text, out int g);
                        Int32.TryParse(tbarray[boxrow, boxcol + 1].Text, out int h);
                        if (b != inp - 1 && c != inp - 1 && h != inp - 1)
                        {
                            MessageBox.Show("Out of sequence", "Error");
                            tbarray[boxrow, boxcol].Text = "";
                        }


                    }
                }
                else
                {
                    MessageBox.Show("Number already used", "Error");
                    tbarray[boxrow, boxcol].Text = "";
                }
            }
            else
            {
                MessageBox.Show("Not a number in [" + boxrow.ToString() + "," + boxcol.ToString() + "]" + tbarray[boxrow - 1, boxcol - 1].Text, "Error");
                tbarray[boxrow, boxcol].Text = "";
            }
        }

        private void ChkCnr44(int boxrow, int boxcol)
        {
            int inp;
            if ((Int32.TryParse(tbarray[boxrow, boxcol].Text, out inp) == true && String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == false) || (Int32.TryParse(tbarray[boxrow, boxcol].Text, out inp) == false && String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == true))
            {
                if (Inarray(inp, boxrow, boxcol) != true)
                {
                    if (String.IsNullOrEmpty(tbarray[boxrow, boxcol].Text) == false)
                    {
                        Int32.TryParse(tbarray[boxrow - 1, boxcol - 1].Text, out int a);
                        Int32.TryParse(tbarray[boxrow - 1, boxcol].Text, out int b);
                        //Int32.TryParse(tbarray[boxrow - 1, boxcol + 1].Text, out int c);
                        Int32.TryParse(tbarray[boxrow, boxcol - 1].Text, out int d);
                        //Int32.TryParse(tbarray[boxrow + 1, boxcol - 1].Text, out int ee);
                        //Int32.TryParse(tbarray[boxrow + 1, boxcol].Text, out int f);
                        //Int32.TryParse(tbarray[boxrow + 1, boxcol + 1].Text, out int g);
                        //Int32.TryParse(tbarray[boxrow, boxcol + 1].Text, out int h);
                        if (b != inp - 1 && a != inp - 1 && d != inp - 1)
                        {
                            MessageBox.Show("Out of sequence", "Error");
                            tbarray[boxrow, boxcol].Text = "";
                        }


                    }
                }
                else
                {
                    MessageBox.Show("Number already used", "Error");
                    tbarray[boxrow, boxcol].Text = "";
                }
            }
            else
            {
                MessageBox.Show("Not a number in [" + boxrow.ToString() + "," + boxcol.ToString() + "]" + tbarray[boxrow - 1, boxcol - 1].Text, "Error");
                tbarray[boxrow, boxcol].Text = "";
            }
        }

        private void TextBox11_TextChanged(object sender, EventArgs e)
        {
            Wincheck();
            
        }

        private void TextBox12_TextChanged(object sender, EventArgs e)
        {
            Wincheck();
            
        }

        private void TextBox13_TextChanged(object sender, EventArgs e)
        {
            Wincheck();
            
        }

        private void TextBox21_TextChanged(object sender, EventArgs e)
        {
            Wincheck();
            
        }

        private void TextBox22_TextChanged(object sender, EventArgs e)
        {
            Wincheck();
            
        }

        private void TextBox23_TextChanged(object sender, EventArgs e)
        {
            Wincheck();
            
        }

        private void TextBox31_TextChanged(object sender, EventArgs e)
        {
            Wincheck();
            
        }

        private void TextBox32_TextChanged(object sender, EventArgs e)
        {
            Wincheck();
            
        }

        private void TextBox33_TextChanged(object sender, EventArgs e)
        {
            Wincheck();
            
        }


        private void textBox41_TextChanged(object sender, EventArgs e)
        {
            Wincheck();
            
        }

        private void textBox42_TextChanged(object sender, EventArgs e)
        {
            Wincheck();
            
        }

        private void textBox43_TextChanged(object sender, EventArgs e)
        {
            Wincheck();
            
        }

        private void textBox01_TextChanged(object sender, EventArgs e)
        {
            Wincheck();
            
        }

        private void textBox02_TextChanged(object sender, EventArgs e)
        {
            Wincheck();
            
        }

        private void textBox03_TextChanged(object sender, EventArgs e)
        {
            Wincheck();
            
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            Wincheck();
            
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            Wincheck();
            
        }

        private void textBox34_TextChanged(object sender, EventArgs e)
        {
            Wincheck();
            
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            Wincheck();
            
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            
            Wincheck();
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            
            Wincheck();
        }

        private void textBox00_TextChanged(object sender, EventArgs e)
        {

             
            Wincheck();
        }

        private void textBox04_TextChanged(object sender, EventArgs e)
        {
            Wincheck();
            
        }

        private void textBox40_TextChanged(object sender, EventArgs e)
        {
            Wincheck();
            
        }

        private void textBox44_TextChanged(object sender, EventArgs e)
        {
            Wincheck();
            
        }

        private void textBox00_Leave(object sender, EventArgs e)
        {
            int boxrow = 0;
            int boxcol = 0;
            ChkCnr00(boxrow, boxcol);
        }

        private void textBox01_Leave(object sender, EventArgs e)
        {
            int boxrow = 0;
            int boxcol = 1;
            CheckDn5(boxrow, boxcol);
        }

        private void textBox02_Leave(object sender, EventArgs e)
        {
            int boxrow = 0;
            int boxcol = 2;
            CheckDn5(boxrow, boxcol);
        }

        private void textBox03_Leave(object sender, EventArgs e)
        {
            int boxrow = 0;
            int boxcol = 3;
            CheckDn5(boxrow, boxcol);
        }

        private void textBox04_Leave(object sender, EventArgs e)
        {
            int boxrow = 0;
            int boxcol = 4;
            ChkCnr04(boxrow, boxcol);
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            int boxrow = 1;
            int boxcol = 0;
            CheckRt5(boxrow, boxcol);
        }

        private void TextBox11_Leave(object sender, EventArgs e)
        {
            int boxrow = 1;
            int boxcol = 1;
            Check8(boxrow, boxcol);
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            int boxrow = 1;
            int boxcol = 2;
            Check8(boxrow, boxcol);
        }

        private void textBox13_Leave(object sender, EventArgs e)
        {
            int boxrow = 1;
            int boxcol = 3;
            Check8(boxrow, boxcol);
        }

        private void textBox14_Leave(object sender, EventArgs e)
        {
            int boxrow = 1;
            int boxcol = 4;
            CheckLft5(boxrow, boxcol);
        }

        private void textBox20_Leave(object sender, EventArgs e)
        {
            int boxrow = 2;
            int boxcol = 0;
            CheckRt5(boxrow, boxcol);
        }

        private void textBox21_Leave(object sender, EventArgs e)
        {
            int boxrow = 2;
            int boxcol = 1;
            Check8(boxrow, boxcol);
        }

        private void textBox22_Leave(object sender, EventArgs e)
        {
            int boxrow = 2;
            int boxcol = 2;
            Check8(boxrow, boxcol);
        }

        private void textBox23_Leave(object sender, EventArgs e)
        {
            int boxrow = 2;
            int boxcol = 3;
            Check8(boxrow, boxcol);
        }

        private void textBox24_Leave(object sender, EventArgs e)
        {
            int boxrow = 2;
            int boxcol = 4;
            CheckLft5(boxrow, boxcol);
        }

        private void textBox30_Leave(object sender, EventArgs e)
        {
            int boxrow = 3;
            int boxcol = 0;
            CheckRt5(boxrow, boxcol);
        }

        private void textBox31_Leave(object sender, EventArgs e)
        {
            int boxrow = 3;
            int boxcol = 1;
            Check8(boxrow, boxcol);
        }

        private void textBox32_Leave(object sender, EventArgs e)
        {
            int boxrow = 3;
            int boxcol = 2;
            Check8(boxrow, boxcol);
        }

        private void textBox33_Leave(object sender, EventArgs e)
        {
            int boxrow = 3;
            int boxcol = 3;
            Check8(boxrow, boxcol);
        }

        private void textBox34_Leave(object sender, EventArgs e)
        {
            int boxrow = 3;
            int boxcol = 4;
            CheckLft5(boxrow, boxcol);
        }

        private void textBox40_Leave(object sender, EventArgs e)
        {
            int boxrow = 4;
            int boxcol = 0;
            ChkCnr40(boxrow, boxcol);
        }

        private void textBox41_Leave(object sender, EventArgs e)
        {
            int boxrow = 4;
            int boxcol = 1;
            CheckUp5(boxrow, boxcol);
        }

        private void textBox42_Leave(object sender, EventArgs e)
        {
            int boxrow = 4;
            int boxcol = 2;
            CheckUp5(boxrow, boxcol);
        }

        private void textBox43_Leave(object sender, EventArgs e)
        {
            int boxrow = 4;
            int boxcol = 3;
            CheckUp5(boxrow, boxcol);
        }

        private void textBox44_Leave(object sender, EventArgs e)
        {
            int boxrow = 4;
            int boxcol = 4;
            ChkCnr44(boxrow, boxcol);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gameenddatetime = DateTime.Now;
            Sendit(textBox27.Text, gamestartdatetime, textBox1.Text,"Loss", gameenddatetime);
            Cleararray();
            Red1();
            textBox27.Select();
            textBox1.Text = "";
            aTimer.Tick -= new EventHandler(aTimer_Tick);
            solvedbyprogram = false;
            gamestart = false;
            secselapsed = 0;
            aTimer.Stop();          
        }

        private void button4_Click(object sender, EventArgs e)
        {            
            aTimer.Stop();
            Cleararray();
            Solvefor(r1ow,c1ol);
        }

        private void textBox00_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void textBox01_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void textBox02_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void textBox03_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void textBox04_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void textBox10_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void textBox11_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void textBox12_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void textBox13_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void textBox14_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void textBox20_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void textBox21_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void textBox22_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void textBox23_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void textBox24_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void textBox30_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void textBox31_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void textBox32_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void textBox33_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void textBox34_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void textBox40_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void textBox41_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void textBox42_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void textBox43_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void textBox44_Enter(object sender, EventArgs e)
        {
            Isnewopause();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            gamepaused = true;
            aTimer.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string message = "New Game? (No = Quit)";
            string title = "Another?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            gameenddatetime = DateTime.Now;
            aTimer.Stop();
            Sendit(textBox27.Text, gamestartdatetime, textBox1.Text,"Loss", gameenddatetime);
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Cleararray();
                Red1();
                textBox27.Select();
                textBox1.Text = "";
                aTimer.Tick -= new EventHandler(aTimer_Tick);
                gamestart = false;
                secselapsed = 0;
                
            }
            if(result == DialogResult.No)
            {
                Application.Exit();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            gameenddatetime = DateTime.Now;
            Sendit(textBox27.Text, gamestartdatetime, textBox1.Text,"Loss",gameenddatetime);
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Form story = new History();
            story.ShowDialog();
        }
    }
}


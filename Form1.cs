using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Day15
{
    public partial class Form1 : Form
    {
        public int moves;
        public int[] a;
        public int res;
        public Form1()
        {
            InitializeComponent();
            moves = 1;
            a = new int[9];
            for (int i = 0; i < 9; i++)
                a[i] = 0;
            res = -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void buttonsclicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int ind;
            string name = btn.Name;
            if (moves < 10 && res == -1)
            {
                if (moves % 2 == 1)
                {
                    if (btn.BackColor != Color.Black)
                    {
                        MessageBox.Show("Click other button as its occupied");
                    }
                    else
                    {
                        btn.BackColor = Color.Yellow;
                        ind = int.Parse(name.Substring(3));
                        a[ind] = 1;
                        moves++;
                    }
                }
                else
                {
                    if (btn.BackColor != Color.Black)
                    {
                        MessageBox.Show("Click other button as its occupied");
                    }
                    else
                    {
                        btn.BackColor = Color.Red;
                        ind = int.Parse(name.Substring(3));
                        a[ind] = 2;
                        moves++;
                    }
                }
                if (moves > 5)
                    res = checkwinner();
                if (res != -1)
                    MessageBox.Show("Congrats to player" + res);
            }
            if (moves == 10 && res == -1)
                MessageBox.Show("Match draw");
        }
            public int checkwinner()
            {
                int[] players = new int[2] { 1, 2 };
            int flag = -1;
            foreach(int p in players)
            {
                if((a[0]==p&&a[1]==p&&a[2]==p)||
                    (a[3] == p && a[4] == p && a[5] == p)||
                        (a[6] == p && a[7] == p && a[8] == p)||
                    (a[0] == p && a[3] == p && a[6] == p)||
                    (a[1] == p && a[4] == p && a[7] == p)||
                    (a[2] == p && a[5] == p && a[8] == p)||
                    (a[0] == p && a[4] == p && a[8] == p)||
                    (a[2] == p && a[4] == p && a[6] == p))
                {
                    flag = 0;
                    return p;
                }
            }
            return flag;
            }
        }
    }


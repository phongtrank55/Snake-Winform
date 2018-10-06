using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snack
{
    public partial class Form1 : Form
    {
        private int score=0, count=0, ds=1;
        Random randfood;
        Snack s = new Snack();
        Food f;
        Graphics paper;
        Boolean left = false, right = true, up = false, down = false;
        public Form1()
        {
            InitializeComponent();
            randfood = new Random();
            f = new Food(randfood);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setcontrol(false);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            f.Drawfood(paper);
            s.DrawSnack(paper);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.S && up == false)
            {
                down = true; up = false; left = false; right = false;
            }
            if (e.KeyData == Keys.W && down == false)
            {
                down = false; up = true; left = false; right = false;
            }
            if (e.KeyData == Keys.A && right == false)
            {
                down = false; up = false; left = true; right = false;
            }
            if (e.KeyData == Keys.D && left == false)
            {
                down = false; up = false; left = false; right = true;
            }
        }
        private void Collition()
        {
            int i;
            //Khi ăn
            for (i = 0; i < s.Snackrec.Length; i++)
                if (s.Snackrec[i].IntersectsWith(f.Foodrec))
                {
                    score += f.sumscore(ds);
                    lblscore.Text = score.ToString("0000");
                    s.growsnack();
                    count++;
                    if (count == 5)
                    {
                        f = new Food(randfood, 30,30);
                        count = 0;
                        timer_bigfood.Enabled = true;
                    }
                    else
                    {
                        timer_bigfood.Enabled = false;
                        f = new Food(randfood);
                    }
                    return;
                }
            //khi va tường hoặc tự tử
            if (s.Snackrec[0].X < 0)
            {
                s.Snackrec[0].X = 470; return;
            }
            if (s.Snackrec[0].X > 470)
            {
                s.Snackrec[0].X = 0; return;
            }
            if (s.Snackrec[0].Y < 0)
            { 
                s.Snackrec[0].Y = 340; return; 
            }
            if (s.Snackrec[0].Y > 340)
            {
                s.Snackrec[0].Y = 0; return;
            }
            //{
            //    btnpause.Enabled = false;
            //    timer1.Enabled = false;
            //    DialogResult result =  MessageBox.Show("Đâm tường cmnr\nSố điểm của bạn là "+score.ToString()+".\nBạn muốn chơi lại không?","Chơi lại?", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            //    if (result == DialogResult.Yes)
            //        Application.Restart();
            //    return;
            //}
            for (i = 1; i < s.Snackrec.Length; i++)
                if (s.Snackrec[0].IntersectsWith(s.Snackrec[i]))
                {
                    btnpause.Enabled = false;
                    timer1.Enabled = false;
                    DialogResult result = MessageBox.Show("Cắn cổ cmnr\nSố điểm của bạn là " + score.ToString() + ".\nBạn muốn chơi lại không?", "Chơi lại?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                        Application.Restart();
                }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (down)
                s.moveDown();
            else if (left)
                s.moveLeft();
            else if (up)
                s.moveUp();
            else if(right)
                s.moveRight();
            Collition();
            panel1.Invalidate();
        }
        private void setcontrol(bool start)
        {
            groupBox1.Enabled = !start;
            btnexit.Enabled = start;
            btnstart.Enabled = !start;
            panel1.Enabled = start;
            timer1.Enabled = start;
            btnpause.Enabled = start;
        }
        private void btnpause_Click(object sender, EventArgs e)
        {
            setcontrol(false);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
                DialogResult exit = MessageBox.Show("Bạn muốn thoát ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (exit == DialogResult.Yes)
                    Application.Exit();
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            setcontrol(true);
        }
        private void timer_bigfood_Tick(object sender, EventArgs e)
        {
            f.zoomout(2);
            if (f.Foodrec.Width <= 0)
            {
                f = new Food(randfood);
                timer_bigfood.Enabled = false;
            }
            panel1.Invalidate();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ds = 1;
            timer1.Interval = 100;
            timer_bigfood.Interval = 900;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ds = 2;
            timer_bigfood.Interval = 700;
            timer1.Interval = 50;
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ds = 3;
            timer1.Interval = 20;
            timer_bigfood.Interval = 400;
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            ds = 4;
            timer1.Interval = 8;
            timer_bigfood.Interval = 100;
        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            ds = 5;
            timer1.Interval = 2;
            timer_bigfood.Interval = 40;
        }

    }
}

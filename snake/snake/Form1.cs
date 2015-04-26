using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    partial class Form1 : Form
    {
        private Palette p;

        public Palette P
        {
            get { return p; }
            set { p = value; }
        }

        private int level = 5;
        private int map = 0;

        public bool[,] myMapList = new bool[20, 20];
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if(p!=null)
            {
                p.PaintPalette(e.Graphics);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(p.keylock==false)
            {
                return;
            }
            if((e.KeyCode==Keys.W||e.KeyCode==Keys.Up)&&p.Driection!=Driection.Down)
            {
                p.Driection = Driection.Up;
                p.keylock = false;
                return;
            }
            if ((e.KeyCode == Keys.S || e.KeyCode == Keys.Down) && p.Driection != Driection.Up)
            {
                p.Driection = Driection.Down;
                p.keylock = false;
                return;
            }
            if ((e.KeyCode == Keys.A || e.KeyCode == Keys.Left) && p.Driection != Driection.Right)
            {
                p.Driection = Driection.Left;
                p.keylock = false;
                return;
            }
            if ((e.KeyCode == Keys.D || e.KeyCode == Keys.Right) && p.Driection != Driection.Left)
            {
                p.Driection = Driection.Right;
                p.keylock = false;
                return;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            int width = 20;
            int height = 20;
            int size = 15;

            this.pictureBox1.Width = width * size;
            this.pictureBox1.Height = height * size;
            this.Width = this.pictureBox1.Width + 30;
            this.Height = this.pictureBox1.Height + 80;
            
            p = new Palette(width, height, size, this.pictureBox1.BackColor, Graphics.FromHwnd(this.pictureBox1.Handle));
            p.Level = level;
            if (map >= 0) 
            {
                p.Map = map; 
            }
            p.PointLabel(label1);
            p.resetSocerText += delegate(string a) { label1.Text = a; };
            p.Start();
            
            
        }

        private void 帮助ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            p.Pause();
            MessageBox.Show("使用上下左右键或者WASD控制小蛇的方向。", "帮助");
        }


        private void 新游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void StartNewGame()
        {
            switch (toolStripTextBox2.Text)
            {
                case "0":
                    level = 0;
                    break;
                case "1":
                    level = 1;
                    break;
                case "2":
                    level = 2;
                    break;
                case "3":
                    level = 3;
                    break;
                case "4":
                    level = 4;
                    break;
                case "5":
                    level = 5;
                    break;
                case "6":
                    level = 6;
                    break;
                case "7":
                    level = 7;
                    break;
                case "8":
                    level = 8;
                    break;
                case "9":
                    level = 9;
                    break;
                default:
                    level = 9;
                    break;
            }
            StartGame();
            
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            p.Continue();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            p.Pause();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p.Pause();
            MessageBox.Show("贪吃蛇snake，用于学习测试v0.1.5by Li XiaYu aasll@126.com", "关于");
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 确定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewGame();
            if(map==-1)
            {
                p.CreateWall(myMapList);
            }
        }

        private void 无迷宫ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            map = 0;
            StartNewGame();

        }

        private void 口字迷宫ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            map = 1;
            StartNewGame();

        }

        private void 道路迷宫ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map = 2;
            StartNewGame();
        }

        private void 风车迷宫ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map = 3;
            StartNewGame();

        }

        private void 春字迷宫ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map = 4;
            StartNewGame();
        }

        private void uPC迷宫ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map = 5;
            StartNewGame();
        }
        private void 重新开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void 设置自定义迷宫ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            snake.myMap myMapForm = new myMap();
            this.Hide();

            myMapForm.setMap = delegate() { this.map = -1; };
            myMapForm.setMyMapList = delegate() { this.myMapList = myMapForm.Map; };
            myMapForm.setShow = delegate() { this.Show(); };
            myMapForm.setCreateWall = delegate() { this.p.CreateWall(this.myMapList); };
            myMapForm.setStartNewGame = delegate() { this.StartNewGame(); };

            myMapForm.Show();

            
        }

        private void 使用自定义迷宫ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map = -1;
            StartNewGame();
            p.CreateWall(myMapList);
        }

        

        
    }
}

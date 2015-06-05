using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    partial class myMap : Form
    {
        Label[,] mapBlock = new Label[20, 20];

        public string mapStr = "";


        public delegate void SetValueDelegate(string m);
        public SetValueDelegate setMap;
        public SetValueDelegate start;


        public myMap()
        {
            InitializeComponent();
        }

        private void myMap_Load(object sender, EventArgs e)
        {
            
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    mapBlock[i, j] = new Label();
                    mapBlock[i, j].Text = "";
                    mapBlock[i, j].Width = 20;
                    mapBlock[i, j].Height = 20;
                    mapBlock[i, j].Location = new Point(j * 20, i * 20);
                    mapBlock[i, j].BackColor = Color.White;
                    mapBlock[i, j].Click += mapBlock_Click;

                    this.Controls.Add(mapBlock[i, j]);
                    mapBlock[i, j].Show();
                }
            }

            this.Width = 20 * 20 + 80;
            this.Height = 20 * 20 + 100;
        }

        private void mapBlock_Click(object sender, EventArgs e)
        {
            if(((Label)sender).BackColor == Color.Blue)
            {
                ((Label)sender).BackColor = Color.White;
            }
            else if(((Label)sender).BackColor == Color.White)
            {
                ((Label)sender).BackColor = Color.Blue;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuildMap();

            this.setMap(this.mapStr);
            
            this.Hide();

            
            
            this.Close();
            
        }

        private void BuildMap()
        {
            this.mapStr = "";

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (mapBlock[i, j].BackColor == Color.Blue)
                    {
                        this.mapStr += "1";
                    }
                    else if (mapBlock[i, j].BackColor == Color.White)
                    {
                        this.mapStr += "0";
                    }
                }
            }
        }

        private void myMap_FormClosing(object sender, FormClosingEventArgs e)
        {
            BuildMap();

            this.setMap(this.mapStr);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BuildMap();

            this.textBox1.Text = this.mapStr;
        }


        
    }
}

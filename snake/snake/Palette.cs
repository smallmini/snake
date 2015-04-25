using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace snake
{
    class Palette
    {
        private int _width = 20;
        private int _height = 20;
        private Color _bgColor;
        private Graphics _gpPalette;
        private ArrayList _blocks;//蛇身array数组。
        private Driection _driection;//蛇的运动方向，蛇头的运动方向。

        private ArrayList _walls;//墙壁array数组。
        
        private System.Timers.Timer timerBlock;
        private Block _food;
        private int _size = 20;
        private int _level = 1;

            public int Level
            {
                /*get { return _level; }*/
                set { _level = value; }
            }
        private int _map = 0;

            public int Map
            {
                /*get { return _map; }*/
                set { _map = value; }
            }
        private bool _isGameOver = false;
        private int[] _speed = new int[] { 500, 450, 400, 350, 300, 250, 200, 150, 100, 50 };

        public bool keylock = false;
        public int score = 0;
        private Label lblScore;
      
        public delegate void AppendStringDelegate(string str);//
        public AppendStringDelegate resetSocerText;//socer显示 用 委托

        public delegate void SetWallDelegate();//
        public ArrayList wallDelegateArray;//迷宫墙壁 设置 委托 组

        public Palette(int width,int height,int size,Color bgColor,Graphics g)
        {
            _width = width;
            _height = height;
            _size = size;
            _bgColor = bgColor;
            _gpPalette = g;
            _blocks = new ArrayList();
            _blocks.Insert(0, new Block(Color.LightPink, this._size, new Point(this._width / 2, this._height / 2)));
            _blocks.Insert(1, new Block(Color.Red, this._size, new Point(this._width / 2 - 1, this._height / 2)));
            _blocks.Insert(2, new Block(Color.Red, this._size, new Point(this._width / 2 - 2, this._height / 2)));

            RegisterWall();

            
            
            _driection = Driection.Right;
        }

        private void RegisterWall()
        {
            wallDelegateArray = new ArrayList();

            wallDelegateArray.Add((SetWallDelegate)(Wall_无));
            wallDelegateArray.Add((SetWallDelegate)(Wall_口字));
            wallDelegateArray.Add((SetWallDelegate)(Wall_道路));
            wallDelegateArray.Add((SetWallDelegate)(Wall_风车));
            wallDelegateArray.Add((SetWallDelegate)(Wall_春字));
        }

        private void Wall_无()
        {
            ArrayList wall = new ArrayList();

            wall.Insert(0, new Block(Color.LightPink, this._size, new Point(-1, -1)));

            this._walls = wall;
        }

        private void Wall_口字()
        {
            ArrayList wall = new ArrayList();

            for (int i = 0; i < this._width; i++)
            {
                wall.Insert(i, new Block(Color.Blue, this._size, new Point(i, 0)));
            }
            for (int i = this._width; i < this._width+(this._height-2)*2; i++)
            {
                if (i % 2 == 0)
                {
                    wall.Insert(i, new Block(Color.Blue, this._size, new Point(0, (i - this._width) / 2 + 1)));
                }
                else
                {
                    wall.Insert(i, new Block(Color.Blue, this._size, new Point(this._width-1, (i - this._width-1) / 2 + 1)));
                }
            }
            for (int i = this._width + (this._height - 2) * 2; i < (this._width + (this._height - 2)) * 2; i++)
            {
                wall.Insert(i, new Block(Color.Blue, this._size, new Point(i - this._width - (this._height - 2) * 2, this._height - 1)));
            }

            this._walls = wall;
        }

        private void Wall_道路()
        {
            ArrayList wall = new ArrayList();

            for(int i=this._width/10+1;i<this._width-this._width/10-1;i++)
            {
                wall.Add(new Block(Color.Blue, this._size, new Point(i, this._height / 3)));
                wall.Add(new Block(Color.Blue, this._size, new Point(i, this._height / 3 * 2)));

            }


            this._walls = wall;
        }

        private void Wall_风车()
        {
            ArrayList wall = new ArrayList();

            for (int i = 0; i < this._height / 2; i++)
            {
                wall.Add(new Block(Color.Blue, this._size, new Point(this._width / 4, i)));
            }
            for (int i = 0; i < this._width / 2; i++)
            {
                wall.Add(new Block(Color.Blue, this._size, new Point(i, 3 * this._height / 4)));
            }
            for (int i = this._height / 2; i < this._height; i++)
            {
                wall.Add(new Block(Color.Blue, this._size, new Point(3 * this._width / 4, i)));
            }
            for (int i = this._width / 2; i < this._width; i++)
            {
                wall.Add(new Block(Color.Blue, this._size, new Point(i, this._height / 4)));
            }

            this._walls = wall;
        }

        private void Wall_春字()
        {
            ArrayList wall = new ArrayList();

            for (int i = 0; i < 20;i++ )
            {
                for(int j=0;j<20;j++)
                {
                    if ((i >= 1 && i <= 2) || (i >= 4 && i <= 5) || (i >= 7 && i <= 8))
                    {
                        if (j >= 9 && j <= 10)
                        {
                            wall.Add(new Block(Color.Blue, this._size, new Point(j, i)));
                        }
                    }
                    if (i == 3)
                    {
                        if (j >= 4 && j <= 15)
                        {
                            wall.Add(new Block(Color.Blue, this._size, new Point(j, i)));
                        }
                    }
                    if (i == 6)
                    {
                        if (j >= 6 && j <= 13)
                        {
                            wall.Add(new Block(Color.Blue, this._size, new Point(j, i)));
                        }
                    }
                    if (i == 9)
                    {
                        if (j >= 3 && j <= 16)
                        {
                            wall.Add(new Block(Color.Blue, this._size, new Point(j, i)));
                        }
                    }
                    if (i == 11)
                    {
                        if (j >= 8 && j <= 12)
                        {
                            wall.Add(new Block(Color.Blue, this._size, new Point(j, i)));
                        }
                    }
                    if (i == 12)
                    {
                        if ((j >= 5 && j <= 8) || (j >= 13 && j <= 14))
                        {
                            wall.Add(new Block(Color.Blue, this._size, new Point(j, i)));
                        }
                    }
                    if (i == 13)
                    {
                        if ((j == 5 )|| (j == 8) || (j >= 13 && j <= 15))
                        {
                            wall.Add(new Block(Color.Blue, this._size, new Point(j, i)));
                        }
                    }
                    if (i == 14)
                    {
                        if ((j >= 3 && j <= 5) || (j >= 10 && j <= 13) || (j == 16))
                        {
                            wall.Add(new Block(Color.Blue, this._size, new Point(j, i)));
                        }
                    }
                    if (i == 15)
                    {
                        if ((j == 13) || (j >= 16 && j <= 17))
                        {
                            wall.Add(new Block(Color.Blue, this._size, new Point(j, i)));
                        }
                    }
                    if (i == 16)
                    {
                        if (j == 13)
                        {
                            wall.Add(new Block(Color.Blue, this._size, new Point(j, i)));
                        }
                    }
                    if (i == 17)
                    {
                        if (j == 8 || j == 13)
                        {
                            wall.Add(new Block(Color.Blue, this._size, new Point(j, i)));
                        }
                    }
                    if (i == 18)
                    {
                        if (j >= 8 && j <= 13)
                        {
                            wall.Add(new Block(Color.Blue, this._size, new Point(j, i)));
                        }
                    }
                }
            }

                this._walls = wall;
        }

        public void CreateWall(bool[,] myMap)
        {
            ArrayList wall = new ArrayList();

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if(myMap[i,j]==true)
                    {
                        wall.Add(new Block(Color.Blue, this._size, new Point(j, i)));
                    }
                }
            }

            this._walls = wall;
        }

        public Driection Driection
        {
            get { return _driection; }
            set { _driection = value; }
        }

        public void Start()
        {
            //绘制地图
            ((SetWallDelegate)wallDelegateArray[this._map])();
            //生成食物
            this._food = GetFood();
            //注册计时器事件，开始计时器
            timerBlock = new System.Timers.Timer(_speed[this._level]);
            timerBlock.Elapsed += new ElapsedEventHandler(OnBlockTimedEvent);
            timerBlock.AutoReset = true;
            timerBlock.Start();
        }

        public void Pause()
        {
            if (timerBlock != null && _isGameOver == false)
            {
                timerBlock.Stop();
                keylock = false;
            }
        }
        public void Continue()
        {
            if (timerBlock != null && _isGameOver == false)
            {
                timerBlock.Start();
                keylock = true;
            }
            
        }

        private void OnBlockTimedEvent(object source,ElapsedEventArgs e)
        {
            //移动
            this.Move();

            //绘图
            this.PaintPalette(this._gpPalette);
            //键盘锁
            this.keylock = true;

            //分数计算，显示
            this.score = ((this._blocks.Count - 3) * this._level);
            string mmm = "Score" + this.score;
            lblScore.Invoke(resetSocerText,mmm);
            
            //死亡判定
            if(this.CheckDead())
            {
                this.timerBlock.Stop();
                MessageBox.Show(mmm, "Game Over!");
            }
        }

        private bool CheckDead()
        {
            Block head = (Block)(this._blocks[0]);

            for(int i=1;i<this._blocks.Count;i++)
            {
                Block b = (Block)(this._blocks[i]);

                if(head.Point.X==b.Point.X&&head.Point.Y==b.Point.Y)
                {
                    this._isGameOver = true;
                    return true;
                }
            }

            for (int j = 0; j < this._walls.Count; j++)
            {
                Block w = (Block)(this._walls[j]);

                if (head.Point.X == w.Point.X && head.Point.Y == w.Point.Y)
                {
                    this._isGameOver = true;
                    return true;
                }
            }

            this._isGameOver = false;
            return false;
        }

        private Block GetFood()
        {
            Block food = null;
            Random r = new Random();
            bool redo = false;

            while(true)
            {
                redo = false;
                int x = r.Next(this._width);
                int y = r.Next(this._height);

                for(int i=0;i<this._blocks.Count;i++)
                {
                    Block b=(Block)(this._blocks[i]);
                    if(x==b.Point.X&&y==b.Point.Y)
                    {
                        redo = true;
                    }
                }
                for (int j = 0; j < this._walls.Count;j++ )
                {
                    Block w = (Block)(this._walls[j]);
                    if(x==w.Point.X&&y==w.Point.Y)
                    {
                        redo = true;
                    }
                }

                if (redo == false)
                {
                    food = new Block(Color.Black, this._size, new Point(x, y));
                    break;
                }
            }

            return food;
        }

        private void Move()
        {
            Point next;
            Block head = (Block)(this._blocks[0]);

            switch(this._driection)
            {
                case Driection.Left:
                    next = new Point(head.Point.X - 1, head.Point.Y);
                    break;
                case Driection.Right:
                    next = new Point(head.Point.X + 1, head.Point.Y);
                    break;
                case Driection.Up:
                    next = new Point(head.Point.X, head.Point.Y - 1);
                    break;
                case Driection.Down:
                    next = new Point(head.Point.X, head.Point.Y + 1);
                    break;
                default:
                    next = new Point(head.Point.X, head.Point.Y);
                    break;
            }


            //穿过屏幕的移动
            if(next.X<0)
            {
                next.X = this._width - 1;
            }
            if(next.X>this._width-1)
            {
                next.X = 0;
            }
            if(next.Y<0)
            {
                next.Y = this._height - 1;
            }
            if (next.Y > this._height - 1)
            {
                next.Y = 0;
            }


            Block nextBlock = new Block(Color.Red, this._size, next);

            if(next!=this._food.Point)
            {
                this._blocks.RemoveAt(this._blocks.Count - 1);
            }
            else
            {
                this._food = this.GetFood();
            }

            this._blocks.Insert(0, nextBlock);


            //蛇上色
            _blocks[0] = new Block(Color.LightPink, this._size, ((Block)(_blocks[0])).Point);
            for(int i=1;i<this._blocks.Count;i++)
            {
                _blocks[i] = new Block(Color.Red, this._size, ((Block)(_blocks[i])).Point);
            }

            
            
        }

        public void PaintPalette(Graphics gp)
        {
            gp.Clear(this._bgColor);
            this._food.Paint(gp);
            foreach(Block b in this._blocks)
            {
                b.Paint(gp);
            }
            foreach(Block w in this._walls)
            {
                w.Paint(gp);
            }
        }

        
        public void PointLabel(Label lbl)
        {

            lblScore = lbl;
        }

        
        private void WriteWallArray()
        {
            BinaryFormatter formater = new BinaryFormatter();

            FileStream fs = new FileStream("WallArray.ini", FileMode.Create, FileAccess.Write, FileShare.None);

            formater.Serialize(fs, this.wallDelegateArray);

            fs.Close();
        }

        private void ReadWallArray()
        {
            BinaryFormatter formater = new BinaryFormatter();

            FileStream fs = new FileStream("WallArray.ini", FileMode.Open, FileAccess.Read, FileShare.Read);

            this.wallDelegateArray = (ArrayList)formater.Deserialize(fs);

            fs.Close();

        }
    }

    public enum Driection
    {
        Left,
        Right,
        Up,
        Down
    }
}

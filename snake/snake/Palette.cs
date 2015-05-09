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
using System.Xml;

namespace snake
{
    class Palette
    {
        private int _width = 20;
        private int _height = 20;
        private Color _bgColor;
        private Graphics _gpPalette;
        /// <summary>
        /// 蛇身array数组
        /// </summary>
        private ArrayList _blocks;
        /// <summary>
        /// 蛇的运动方向，蛇头的运动方向
        /// </summary>
        private Driection _driection;
        /// <summary>
        /// 墙壁array数组
        /// </summary>
        private ArrayList _walls;
        
        private System.Timers.Timer timerBlock;
        private Block _food;
        private int _size = 20;
        private int _level = 1;
            public int Level
            {
                /*get { return _level; }*/
                set { _level = value; }
            }
        public Map map;

        private bool _isGameOver = false;
        private int[] _speed = new int[] { 500, 450, 400, 350, 300, 250, 200, 150, 100, 50 };

        public bool keylock = false;
        public int score = 0;
        private Label lblScore;
        /// <summary>
        /// socer显示 用 委托
        /// </summary>
        /// <param name="str">显示用 字符串</param>
        public delegate void AppendStringDelegate(string str);
        /// <summary>
        /// socer显示 用 委托
        /// </summary>
        public AppendStringDelegate resetSocerText;


        private XmlDocument mapRes=new XmlDocument();
        private XmlNode mapListNode;
        private XmlNodeList mapNodes;

        public List<Map> maps = new List<Map>();

        /// <summary>
        /// 生成 游戏引擎
        /// </summary>
        /// <param name="width">地图块宽度</param>
        /// <param name="height">地图块高度</param>
        /// <param name="size">地图大小，正方体边长</param>
        /// <param name="bgColor">背景色</param>
        /// <param name="g">绘图目标 元素</param>
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

            

            this.ReadXML();

            this.map = this.maps[0];
           
            
            _driection = Driection.Right;
        }
       

        public Driection Driection
        {
            get { return _driection; }
            set { _driection = value; }
        }

        public void Start()
        {
            //绘制地图
            this._walls = this.map.BuildWall();
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

        
        private void WriteXML()
        {
            
        }
        /// <summary>
        /// 从资源文件中读取地图xml信息并添加进List中
        /// </summary>
        private void ReadXML()
        {
            try
            {
                mapRes.Load(@"map.xml");
            }
            catch (Exception)
            {
                this.mapRes.LoadXml(snake.Resource.map);
            }
            
            
            this.mapListNode = this.mapRes.SelectSingleNode("MapList");
            this.mapNodes = this.mapListNode.ChildNodes;

            foreach(XmlNode node in this.mapNodes)
            {
                
                XmlElement element = (XmlElement)(node);

                Map myMap = new Map(element.GetAttribute("name"), element.GetAttribute("walls"));

                this.maps.Add(myMap);
            }

        }
    }
    /// <summary>
    /// 表示蛇头运动的方向
    /// </summary>
    public enum Driection
    {
        Left,
        Right,
        Up,
        Down
    }

    
}

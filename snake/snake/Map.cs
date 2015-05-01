using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    /// <summary>
    /// 地图 类 储存了名称和迷宫信息
    /// </summary>
    public class Map
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { }
        }

        private string walls;
        public string Walls
        {
            get { return walls; }
            set { }
        }
        /// <summary>
        /// 构造一个地图
        /// </summary>
        /// <param name="_name">地图的名称</param>
        /// <param name="_walls">地图的迷宫</param>
        public Map(string _name, string _walls)
        {
            this.name = _name;
            this.walls = _walls;
        }
        /// <summary>
        /// 生成迷宫墙壁
        /// </summary>
        /// <returns>迷宫墙壁</returns>
        public ArrayList BuildWall()
        {
            ArrayList wall = new ArrayList();

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (this.walls[i * 20 + j] == '1')
                    {
                        wall.Add(new Block(Color.Blue, 20, new Point(j, i)));
                    }
                }
            }

            return wall;
        }
    }
}

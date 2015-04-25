using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class Block
    {
        //
        //          基本的方块，蛇身、食物等的类型。
        //
        private Color _color;
        private int _size;
        private Point _point;

        public Block(Color color,int size,Point point)
        {
            _color = color;
            _size = size;
            _point = point;
        }

        public Point Point
        {
            get { return this._point; }
        }

        public virtual void Paint(Graphics g)
        {
            SolidBrush sb = new SolidBrush(_color);
            try
            {
                g.FillRectangle(sb, this.Point.X * this._size, this.Point.Y * this._size, this._size - 1, this._size - 1);
            }
            catch
            { }
        }
    }
}

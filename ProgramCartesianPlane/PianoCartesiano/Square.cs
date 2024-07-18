using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PianoCartesiano
{
    public class square
    {
        private int _side;
        private Point _vertexTopLeft;
        
        private Point _vertexTopRight;
        private Point _vertexDownRight; 
        private Point _vertexDownLeft;

        public int Side
        {   
            get { return _side; }  
        }

        public Point VertexTopLeft
        {
            get { return _vertexTopLeft; }
        }

        public Point VertexTopRight
        {
            get{ return _vertexTopRight; }
        }

        public Point VertexDownRight
        {
            get{ return _vertexDownRight; }
        }

        public Point VertexDownLeft
        {
            get{ return _vertexDownLeft; }
        }

        public square(int side, Point vertex)
        {
            _side = side;
            _vertexTopLeft = vertex;
            _vertexTopRight = new Point(_vertexTopLeft.X+_side,_vertexTopLeft.Y);
            _vertexDownRight = new Point(_vertexTopRight.X,_vertexTopRight.Y-Side);
            _vertexDownLeft = new Point(_vertexDownRight.X-Side,_vertexDownRight.Y);
        }

        public bool CheckInternalPoint(Point p)
        {
            if((p.X >= _vertexDownLeft.X && p.X <= _vertexDownRight.X) && (p.Y <= _vertexTopRight.Y && p.Y >= _vertexDownRight.Y)) return true;
            return false;
        }

    }
}

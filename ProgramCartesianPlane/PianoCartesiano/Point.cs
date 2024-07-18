using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoCartesiano
{
    public enum Position
        {
            orig,
            quadrant1,
            quadrant2,
            quadrant3,
            quadrant4,
            axesX,
            axesY
        }
    public class Point
    {
        private int _x;
        private int _y;

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public Point(int coordinateX=0, int coordinateY=0)
        {
            X = coordinateX;
            Y = coordinateY;
        }

        //campo calcolato --> proprietà di sola lettura
        public Position Quadrant()
        {      
            Position position;
            if (X > 0 && Y > 0)
            {
                position = (Position)1;
            }
            else if (X <= 0 && Y >= 0)
            {
                position = (Position)2;
            }
            else if (X < 0 && Y < 0)
            {
                position = (Position)3;
            }
            else if (X > 0 && Y < 0)
            {
                position = (Position)4;
            }
            else
            {
                position = (Position)0;
            }

            return position;

            
        }

        public void translateX(int newX)
        {
            X += newX;
        }
        public void translateY(int newY)
        {
            Y += newY;
        }

        //ridefinisco (override) il comportamento del metodo Equals
        public override bool Equals(object? obj)
        {
            Point p = (Point)obj;
            if (X == p.X && Y == p.Y)
                return true;
            return false;

        }

        public override string ToString()
        {
            return $"({X};{Y})";
        }
        
        public string PositionPoint(cartesianPlane c)
        {
            string returned;
            if(X == c.OrigX && Y == 0)
            {
                returned = $"{(Position)5}";
            }else
            {
                if(X == 0 && Y == c.OrigY)
                {
                    returned = $"{(Position)6}";
                }else
                {
                    returned = $"{Quadrant}";
                }
            }

            return returned;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoCartesiano
{
    public class Segment
    {
        private Point _pointStart;
        private Point _pointEnd;

        public Point Start
        {
            get{ return _pointStart; }
        }

        public Point End
        {
            get{ return _pointEnd; }
        }
        
        public Segment(Point point1, Point point2)
        {
            try
            {
                if (point1.Equals(point2) == false)
            {
                if(point1.X < point2.X || (point1.X == point2.X && point1.Y < point2.Y))
                {
                    _pointStart = point1;
                    _pointEnd = point2;
                }
                else
                {
                    _pointStart = point2;
                    _pointEnd = point1;                      
                }
                
            }
            else
            {
                throw new ArgumentException("gli estremi non possono coincidere");
            }
            }catch(ArgumentException argEx)
            {
                throw argEx;
            }
            
        }

        public double CalculateLength()
        {
            double diffX = _pointEnd.X - _pointStart.X;
            double diffY = _pointEnd.Y - _pointStart.Y;

            return Math.Sqrt((diffX * diffX) + (diffY * diffY));
        }

        public bool ChecksPuntBelongsSegment(Point pointC)
        {
            int Xc = pointC.X;
            int Yc = pointC.Y;
            int Xa = _pointStart.X;
            int Ya = _pointStart.Y;
            int Xb = _pointEnd.X;
            int Yb = _pointEnd.Y;

            bool temp = false;
            // se pointC si trova sulla retta y=m-q+c ->
            // di equazione (x - xa)(yb - ya) - (y - ya)(xb - xa) = 0
            if ((Xc - Xa) * (Yb - Ya) - (Yc - Ya) * (Xb - Xa) == 0) 
            {
                if (Xa == Xb && Xb == Xc)
                {
                    if (Ya > Yb)
                    {
                        if (Yc < Ya && Yc > Yb)
                        {
                            temp = true;
                        }

                    }
                    else
                    {
                        if (Ya < Yb)
                        {
                            if (Yc > Ya && Yc < Yb)
                            {
                                temp = true;
                            }
                        }
                    }
                }

                if (Xa < Xb)
                {
                    if (Xc > Xa && Xc < Xb)
                    {
                        temp = true;
                    }
                }
                else
                {
                    if (Xa > Xb)
                    {
                        if (Xc < Xa && Xc > Xb)
                        {
                            temp = true;
                        }
                    }
                }
            }

            return temp;
        }


        public override bool Equals(object? obj)
        {           
            if (obj == null || !(obj is Segment)) return false;
            Segment s = (Segment)obj;
            if (_pointStart.Equals(s._pointStart) && _pointEnd.Equals(s._pointEnd))
                return true;
            return false;

        }

        public override string ToString()
        {
            return $"({_pointStart.ToString()})({_pointEnd.ToString()};)";
        }

        
    }
}





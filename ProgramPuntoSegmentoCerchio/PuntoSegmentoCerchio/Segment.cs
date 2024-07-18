using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuntoSegmentoCerchio
{
    public class Segment
    {
        private Point _pointA;
        private Point _pointB;

        public Segment(Point point1, Point point2)
        {

            if (point1.Equals(point2) == false)
            {
                _pointA = point1;
                _pointB = point2;
            }
            else
            {
                throw new ArgumentException("gli estremi non possono coincidere");
            }
        }

        public double CalculateLength()
        {
            double diffX = _pointB.X - _pointA.X;
            double diffY = _pointB.Y - _pointA.Y;

            return Math.Sqrt((diffX * diffX) + (diffY * diffY));
        }

        public bool checksPuntBelongsSegment (Point pointC)
        {
            int Xc = pointC.X;
            int Yc = pointC.Y;
            int Xa = _pointA.X;
            int Ya = _pointA.Y;
            int Xb = _pointB.X;
            int Yb = _pointB.Y;

            bool temp = false;

            if((Xc-Xa)*(Yb-Ya)-(Yc-Ya)*(Xb-Xa)==0) // se pointC si trova sullaretta y=m-q+c -> di equazione (x - xa)(yb - ya) - (y - ya)(xb - xa) = 0
            {
                if(Xa==Xb && Xb==Xc)
                {
                    if(Ya > Yb)
                    {
                        if(Yc < Ya && Yc > Yb)
                        {
                            temp = true;
                        }
                        
                    }
                    else
                    {
                        if(Ya < Yb)
                        {
                            if(Yc > Ya && Yc < Yb)
                            {
                                temp = true;
                            }
                        }
                    }
                }
                
                if(Xa < Xb)
                {
                    if(Xc > Xa && Xc < Xb)
                    {
                        temp = true;
                    }
                }
                else
                {
                    if(Xa > Xb)
                    {
                        if(Xc < Xa && Xc > Xb)
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
            Segment s = (Segment)obj;
                if (_pointA.Equals(s._pointA) && _pointB.Equals(s._pointB))
                    return true;
                return false;
            
        }

        public override string ToString()
        {
            return $"({_pointA.ToString()})({_pointB.ToString()};)"; 
        }
    }
}





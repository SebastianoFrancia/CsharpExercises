using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuntoSegmentoCerchio
{
    public class Circle
    {
        private Point _centre;
        private double _radius;

        public double Radius
        {
            get{return _radius;}
        }
        public Point Center
        {
            get{return _centre;}
        }
        public Circle(Point centre, double radius)
        {
            _centre = centre;
            _radius = radius;
        }
        public double CalculateCircumference()
        {
            return _radius * 2 * Math.PI;
        }
        public double CalculateArea()
        {
            return _radius * _radius * Math.PI;
        }

        public override bool Equals(object? obj)
        {
            Circle c = (Circle)obj;
                if (_radius == c.Radius && _centre.Equals(c.Center)==true)
                    return true;
                return false;
        }

        public override string ToString()
        {
            return $"r={_radius}; center={_centre.ToString()}"; 
        }
    }
}


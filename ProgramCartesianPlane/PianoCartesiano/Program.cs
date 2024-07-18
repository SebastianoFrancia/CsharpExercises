using System;
namespace PianoCartesiano
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Drawer d = new Drawer();
            cartesianPlane c = new cartesianPlane(101, 51);

            //Console.SetWindowSize(c.WindowsWidht, c.WindowsWidht);


            Point p = new Point(5,8);
            d.DrowingPoint(c,p);

            square sq = new square(5,p);
            d.DrawingSquare(c,sq);
            /*
            p.translateX(1);
            Console.Clear();
            d.DrowingPoint(c,p);
            
            p.translateY(1);
            Console.Clear();
            d.DrowingPoint(c,p);


            Point pA = new Point(25, 3);
            Point pB = new Point(32, 10);
            Segment s = new Segment(pA,pB);
            Console.Clear();
            d.DrowingSegment(c,s);
            


            Point a1 = new Point(15,3);
            Point a2 = new Point(25,3);
            Segment s1 = new Segment(a1,a2);
            d.DrowingSegment(c,s1);

            

            Point b1 = new Point(15, 3);
            Point b2 = new Point(8, 10);
            Segment s2 = new Segment(b1,b2);
            d.DrowingSegment(c,s2);

            Point c1 = new Point(10, 12);
            Point c2 = new Point(12, 12);
            Segment s3 = new Segment(c1, c2);
            d.DrowingSegment(c, s3);

            Point d1 = new Point(30, 12);
            Point d2 = new Point(28, 12);
            Segment s4 = new Segment(d1, d2);
            d.DrowingSegment(c, s4);
            */

            d.WriteAxes(c);

        }
    }
}
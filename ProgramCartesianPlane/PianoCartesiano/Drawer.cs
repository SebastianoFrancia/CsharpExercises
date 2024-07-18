using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PianoCartesiano
{
    public class Drawer
    {
        public void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        public void WriteAxes(cartesianPlane c)
        {
            for (int i = 0; i < c.WindowsWidht; i++)
            {
                if (i == c.OrigX)
                {
                    WriteAt("┼", c.OrigX, c.OrigY);
                }
                else
                {
                    WriteAt("─", i, c.OrigY);
                }
            }
            for (int i = 0; i < c.WindowsHeight; i++)
            {
                if (i != c.OrigY)
                {
                    WriteAt("│", c.OrigX, i);
                }
            }
        }

        public void DrowingPoint(cartesianPlane c, Point p)
        {
            if (p.Quadrant() == (Position)1 || p.Quadrant() == (Position)2 || p.Quadrant() == (Position)3 || p.Quadrant() == (Position)4 )
            {
                WriteAt("■", c.OrigX + p.X, c.OrigY - p.Y);
            }
            else
            {
                WriteAt("■", c.OrigX, c.OrigY);
            }
            //WriteAt($"{p}", c.OrigY + p.X+1, c.OrigX - p.Y+1);

        }

        public void DrowingSegment(cartesianPlane c, Segment s)
        {
            DrowingPoint(c, s.Start);
            DrowingPoint(c, s.End);

            //se il segmento è parallel all'asse y
            if (s.Start.X == s.End.X)
            {
                Point temp = new Point(s.Start.X, s.Start.Y);
                while (temp.Y != s.End.Y)
                {
                    temp.Y++;
                    DrowingPoint(c, temp);
                }
            }
            else
            {

                //se il segmento è parallelo all'asse delle x
                if (s.Start.Y == s.End.Y)
                {
                    Point temp = new Point(s.Start.X, s.Start.Y);
                    while (temp.X != s.End.X)
                    {
                        temp.X++;
                        DrowingPoint(c, temp);
                    }
                }
                else
                {

                    //il segmento è obliquo
                    double m = (double)(s.End.Y - s.Start.Y) / (s.End.X - s.Start.X);
                    double q = s.Start.Y - (m * s.Start.X);
                    Point temp;
                    //calcolo tutt i punti sul segmento
                    for (int x = s.Start.X+1; x < s.End.X; x++)
                    {
                        int y = Convert.ToInt32((m * x) + q);
                        temp = new Point(x, y);
                        DrowingPoint(c, temp);
                    }
                }
            }
        }

        public void DrawingSquare(cartesianPlane c, square sq)
        {
            
            Segment top = new Segment(sq.VertexTopLeft, sq.VertexTopRight);
            DrowingSegment(c,top);
            Segment down = new Segment(sq.VertexDownLeft,sq.VertexDownRight);
            DrowingSegment(c,down);
            Segment left = new Segment(sq.VertexTopLeft, sq.VertexDownLeft);
            DrowingSegment(c,left);
            Segment right = new Segment(sq.VertexTopRight, sq.VertexDownRight);
            DrowingSegment(c, right);

        }

        public void DrawingCircle(cartesianPlane c, Circle circle)
        {
            Point temp = new Point(circle.Centre.X+(int)circle.Radius, circle.Centre.Y);
            for(indexer i; i>)
        }
        
    }
}

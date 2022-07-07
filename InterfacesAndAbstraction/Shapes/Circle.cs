using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : IDrawable
    {
        public Circle(int radius)
        {
            Radius = radius;
        }

        public int Radius { get; set; }

        public void Draw()
        {
            for (int i = -this.Radius; i <= this.Radius; i++)
            {
                for (int j = -this.Radius; j <= this.Radius; j++)
                {
                    int inside = (int)Math.Sqrt(Math.Pow(i, 2) + Math.Pow(j, 2));
                    if (this.Radius == inside)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }

            //double rin = Radius - 0.4;
            //double rout = Radius + 0.4;
            //for (double i = Radius; i >= -Radius; --i)
            //{
            //for (double y = -Radius; y < rout; y += 0.5)
            //{
            //double value = i * i + y * y;

            //if (value >= rin * rin && value <= rout * rout)
            //{
            //Console.Write("*");
            //}
            //else
            //{
            //Console.Write(" ");
            //}
            //}
            //Console.WriteLine();
            //}
        }
    }
}

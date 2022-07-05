using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }
        public double Width
        {
            get => width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }
        public double Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            double result = 2 * Length * Height + 2 * Length * Width + 2 * Width * Height;
            return result;
        }

        public double LateralSurfaceArea()
        {
            double result = 2 * Length * Height + 2 * Width * Height;
            return result;
        }

        public double Volume()
        {
            double result = Height * Width * Length;
            return result;
        }
    }
}

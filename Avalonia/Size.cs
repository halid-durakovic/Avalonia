﻿namespace Avalonia
{
    using System;

    public struct Size : IFormattable
    {
        public Size(double width, double height)
        {
            if (width < 0 || height < 0)
                throw new ArgumentException("Width and Height must be non-negative.");

            this.width = width;
            this.height = height;
        }

        public bool Equals(Size value)
        {
            return width == value.Width && height == value.Height;
        }

        public override bool Equals(object o)
        {
            if (!(o is Size))
                return false;

            return Equals((Size)o);
        }

        public static bool Equals(Size size1, Size size2)
        {
            return size1.Equals(size2);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static Size Parse(string source)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            if (IsEmpty)
                return "Empty";
            return String.Format("{0},{1}", width, height);
        }

        public string ToString(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        string IFormattable.ToString(string format, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty
        {
            get
            {
                return (width == Double.NegativeInfinity &&
                    height == Double.NegativeInfinity);
            }
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Cannot modify this property on the Empty Size.");

                if (value < 0)
                    throw new ArgumentException("height must be non-negative.");

                height = value;
            }
        }

        public double Width
        {
            get { return width; }
            set
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Cannot modify this property on the Empty Size.");

                if (value < 0)
                    throw new ArgumentException("width must be non-negative.");

                width = value;
            }
        }

        public static Size Empty
        {
            get
            {
                Size s = new Size();
                s.width = s.height = Double.NegativeInfinity;
                return s;
            }
        }

        /* operators */
        public static explicit operator Point(Size size)
        {
            return new Point(size.Width, size.Height);
        }

        public static explicit operator Vector(Size size)
        {
            return new Vector(size.Width, size.Height);
        }

        public static bool operator ==(Size size1, Size size2)
        {
            return size1.Equals(size2);
        }

        public static bool operator !=(Size size1, Size size2)
        {
            return !size1.Equals(size2);
        }

        double width;
        double height;
    }
}
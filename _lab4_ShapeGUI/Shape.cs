using System;
using System.Drawing;

namespace _lab4_ShapeGUI
{
    [Serializable] // attribute
    class Shape
    {
        protected Point LeftTop;
        protected Point RightBottom;

        public Shape(int Left, int Top, int Right, int Bottom)
        {
        }

        public virtual void Show(Graphics g)
        {
        }
    }

    [Serializable] // attribute
    class Rectangle : Shape
    {
        public Rectangle(int Left, int Top, int Right, int Bottom)
            : base(Left, Top, Right, Bottom)
        {
            this.LeftTop = new Point(Left, Top);
            this.RightBottom = new Point(Right, Bottom);
        }

        public override void Show(Graphics g)
        {
            g.FillRectangle(Brushes.SkyBlue,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);

            g.DrawRectangle(Pens.Blue,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);

        }
    }

    [Serializable] // attribute
    class Square : Shape
    {
        public Square(int Left, int Top, int Right, int Bottom)
            : base(Left, Top, Right, Bottom)
        {
            this.LeftTop = new Point(Left, Top);
            this.RightBottom = new Point(Right, Top + (Right - Left));
        }

        public override void Show(Graphics g)
        {
            g.FillRectangle(Brushes.Orange,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);

            g.DrawRectangle(Pens.Red,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);
        }
    }

    [Serializable] // attribute
    class Triangle : Shape
    {
        public Triangle(int Left, int Top, int Right, int Bottom)
            : base(Left, Top, Right, Bottom)
        {
            this.LeftTop = new Point(Left, Top);
            this.RightBottom = new Point(Right, Bottom);
        }

        public override void Show(Graphics g)
        {
            Point[] pts = new Point[] { new Point((LeftTop.X + RightBottom.Y) / 2, LeftTop.X), new Point(LeftTop.X, RightBottom.Y), new Point(RightBottom.Y, RightBottom.X) };
            g.FillPolygon(Brushes.Pink, pts);
            g.DrawPolygon(Pens.Red, pts);
        }
    }

    [Serializable] // attribute
    class Ellipse : Shape
    {
        public Ellipse(int Left, int Top, int Right, int Bottom)
            : base(Left, Top, Right, Bottom)
        {
            this.LeftTop = new Point(Left, Top);
            this.RightBottom = new Point(Right, Bottom);
        }

        public override void Show(Graphics g)
        {
            g.FillEllipse(Brushes.LightGreen,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);

            g.DrawEllipse(Pens.Green,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);

        }
    }
}

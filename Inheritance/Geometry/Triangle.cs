using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometry
{
	abstract class Triangle:Shape
	{
		public Triangle(int startX, int startY, int lineWidth, System.Drawing.Color color) : 
			base(startX, startY, lineWidth, color) { }
		public abstract double GetHeight();
		public override void Info(PaintEventArgs e)
		{
			Console.WriteLine($"Высота треугольника:\t{GetHeight()}");
			base.Info(e);
		}
	}
	class EquilateralTriangle : Triangle
	{
		float side;
		public float Side
		{
			get => side;
			set => side = FilterSize(value);
		}
		public EquilateralTriangle(float side, int startX, int startY, int lineWidth, System.Drawing.Color color) :
			base(startX, startY, lineWidth, color)
		{
			this.Side = side;
		}
		public override double GetHeight() => Math.Sqrt(Math.Pow(Side, 2) - Math.Pow(Side / 2, 1));
		public override double GetArea() => Side * GetHeight() / 2;
		public override double GetPerimeter() => Side * 3;
		public override void Draw(PaintEventArgs e)
		{
			System.Drawing.Pen pen = new System.Drawing.Pen(Color, LineWidth);
			System.Drawing.Point[] points =
			{
				new System.Drawing.Point(StartX, (int)(StartY+GetHeight())),
				new System.Drawing.Point((int)(StartX+Side), (int)(StartY+GetHeight())),
				new System.Drawing.Point((int)(StartX+Side/2), (int)(StartY))
			};
			e.Graphics.DrawPolygon(pen, points);
		}
		public override void Info(PaintEventArgs e)
		{
			Console.WriteLine($"Длина стороны: {Side}");
			base.Info(e);
		}
	}
	class IsoscalesTriangle : Triangle
	{
		float @base;
		float side;
		public float Base
		{
			get => @base;
			set => @base = FilterSize(value);
		}
		public float Side
		{
			get => side;
			set => side = FilterSize(value);
		}
		public IsoscalesTriangle(float @base, float side, int startX, int startY, int lineWidth, System.Drawing.Color color) :
			base(startX, startY, lineWidth, color)
		{
			this.Base = @base;
			this.Side = side;
		}
		public override double GetHeight() => Math.Sqrt(Math.Pow(Side, 2) - Math.Pow(Base / 2, 2));
		public override double GetArea() => Base * GetHeight() / 2;
		public override double GetPerimeter() => Base + Side * 2;
		public override void Draw(PaintEventArgs e)
		{
			System.Drawing.Pen pen = new System.Drawing.Pen(Color, LineWidth);
			System.Drawing.Point[] points =
			{
				new System.Drawing.Point(StartX, (int)(StartY+GetHeight())),
				new System.Drawing.Point((int)(StartX+Base), (int)(StartY+GetHeight())),
				new System.Drawing.Point((int)(StartX+Base/2), StartY)
			};
			e.Graphics.DrawPolygon(pen, points);
		}
	}
}

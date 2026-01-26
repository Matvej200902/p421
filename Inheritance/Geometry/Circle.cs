using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometry
{
	class Circle : Shape, IHaveDiameter
	{
		float radius;
		public float Radius
		{
			get => radius;
			set => radius = FilterSize(value);
		}
		public Circle(float radius, int startX, int startY, int lineWidth, System.Drawing.Color color) :
			base(startX, startY, lineWidth, color)
		{
			this.Radius = radius;
		}
		public double GetDiameter() => 2 * Radius;
		public void DrawDiameter(PaintEventArgs e) =>
			e.Graphics.DrawLine
			(
				new System.Drawing.Pen(Color, 1),
				StartX + Radius, StartY,
				StartX + Radius, StartY + (float)GetDiameter()
			);
		public override double GetArea() => Math.PI * Math.Pow(Radius, 2);
		public override double GetPerimeter() => 2 * Math.PI * Radius;
		public override void Draw(PaintEventArgs e) =>
			e.Graphics.DrawEllipse(new System.Drawing.Pen(Color, LineWidth), StartX, StartY, 2 * Radius, 2 * Radius);
		public override void Info(PaintEventArgs e)
		{
			Console.WriteLine($"Радиус круга:\t{Radius}");
			Console.WriteLine($"Диаметр круга:\t{GetDiameter()}");
			base.Info(e);
			DrawDiameter(e);
		}
	}
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Drawing;
//using System.Windows.Forms;

//namespace Geometry
//{
//	class Square : Shape
//	{
//		float side;	//длина стороны
//		public float Side
//		{
//			get => side;
//			set => side = FilterSize(value);
//		}
//		public Square(float side, int startX, int startY, int lineWidth, Color color) : 
//			base(startX, startY, lineWidth, color)
//		{
//			this.Side = side;
//		}
//		public override double GetArea() => Side* Side;
//		public override double GetPerimeter() => Side * 4;
//		public override void Draw(PaintEventArgs e)
//		{
//			Pen pen = new Pen(Color, LineWidth);
//			e.Graphics.DrawRectangle(pen, StartX, StartY, Side, Side);
//			//for (int i = 0; i < Side; i++)
//			//{
//			//	for (int j = 0; j < Side; j++)
//			//	{
//			//		Console.Write("* ");
//			//	}
//			//	Console.WriteLine();
//			//}
//		}
//		public override void Info(PaintEventArgs e)
//		{
//			Console.WriteLine(this.GetType());
//			Console.WriteLine($"Длина стороны квадрата:{Side}");
//			base.Info(e);
//		}
//	}
//}

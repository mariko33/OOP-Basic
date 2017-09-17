using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_Box
{
	public class Box
	{
		private double length;
		private double width;
		private double height;

		public Box(double length, double width, double height)
		{
			this.length = length;
			this.width = width;
			this.height = height;

		}

		public double SurfaceArea(double length, double width, double height)
		{
			double surfaceArea = 2 * length * width + 2 * length * height + 2 * width * height;
			return surfaceArea;
		}

		public double LateralSurfaceArea(double length, double width, double height)
		{
		     double lateralSurface = 2 * length * height + 2 * width * height;
			return lateralSurface;
		}

		public double Volume(double length, double width, double height)
		{
			double volume = length * width * height;
			return volume;
		}

	}
}

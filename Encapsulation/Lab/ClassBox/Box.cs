using System;


	public class Box
	{
		private double length;
		private double width;
		private double height;

		public Box(double length, double width, double height)
		{
			this.Length = length;
			this.Width = width;
			this.Height = height;

		}

		private double Length
		{
		
			 set
			{
				if (value<=0)
				{
					throw new ArgumentException("Length cannot be zero or negative.");
				}
				this.length = value;
			}
		}

		private double Width
		{
			 set
			{
				if (value<=0)
				{
					throw new ArgumentException("Width cannot be zero or negative.");
				}
				this.width = value;
			}
		}
		private double Height
		{ 
			 set
			{
				if (value<=0)
				{
					throw new ArgumentException("Height cannot be zero or negative.");
				}
				this.height = value;
			}
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


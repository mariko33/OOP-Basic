using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BookShop
{
	public class Book
	{
		private string title;
		private string author;
		private decimal price;

		public Book(string author, string title, decimal price)
		{
			this.Title = title;
			this.Author = author;
			this.Price = price;
		}

		public string Title
		{ get { return this.title; }
			set
			{
				if (value.Length<3)
				{
					throw new ArgumentException($"Title not valid!");
				}
				this.title = value;
			}
		}
		public string Author
		{ get { return this.author; }
			set
			{
				//var authorName = value.Split(' ');
				//Regex.Match(info,@"^\d") Regex.IsMatch(authorName[1], @"^\d")
				//char.IsDigit(authorName[1][0])
				if (value.Any(char.IsDigit))
				{
					throw new ArgumentException($"Author not valid!");
				}
				this.author = value;
			}
		}
		public virtual decimal Price
		{
			get { return this.price; }
			set
			{
				if (value<=0)
				{
					throw new ArgumentException($"Price not valid!");
				}
				this.price = value;
			}
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.Append("Type: ").AppendLine(this.GetType().Name)
				.Append("Title: ").AppendLine(this.Title)
				.Append("Author: ").AppendLine(this.Author)
				.Append("Price: ").Append($"{this.Price:f1}")
				.AppendLine();

			return sb.ToString();
		}

	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRadioDatabase
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var numb = int.Parse(Console.ReadLine());
			List<Song>songs=new List<Song>();
			
				for (int i = 0; i < numb; i++)
				{
					var info = Console.ReadLine().Split(';');
					var timeInfo = info[2].Split(':');
					try
					{
						Song song=new Song(info[0],info[1],int.Parse(timeInfo[0]),int.Parse(timeInfo[1]));
						songs.Add(song);
						Console.WriteLine("Song added.");
				}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
						
					}
					
					
				}

			try
			{
				var songTime = songs.Sum(s => s.SongLenght());
				int hours = songTime / 3600;
				int minutes = (songTime % 3600) / 60;
				int seconds = (songTime % 3600) % 60;
				Console.WriteLine($"Songs added: {songs.Count}");
				Console.WriteLine($"Playlist length: {hours}h {minutes}m {seconds}s");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				
			}

			}
			
			

		}
	}


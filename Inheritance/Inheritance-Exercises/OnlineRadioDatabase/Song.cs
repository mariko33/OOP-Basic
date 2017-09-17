using System;

namespace OnlineRadioDatabase
{
	public class Song
	{
		private string artistName;
		private string songName;
		private int minutes;
		private int seconds;

		public Song(string artistName, string songName, int minutes, int seconds)
		{
			this.ArtistName = artistName;
			this.SongName = songName;
			this.Minutes = minutes;
			this.Seconds = seconds;
		}

		public string ArtistName
		{ get { return this.artistName; }
			set
			{
				if (value.Length<3||value.Length>20)
				{
					throw new InvalidArtistNameException();
				}
				this.artistName = value;
			} }
		public string SongName
		{ get { return this.songName; }
			set
			{
				if (value.Length<3||value.Length>30)
				{
					throw new InvalidSongNameException();
				}
				this.songName = value;
			} }
		public int Minutes
		{ get { return this.minutes; }
			set
			{
				if (value<0||value>14)
				{
					throw new InvalidSongMinutesException();
				}
				this.minutes = value;
			} }

		public int Seconds
		{
			get { return this.seconds; }

			set
			{
				if (value<0||value>59)
				{
					throw new InvalidSongSecondsException();
				}
				this.seconds = value;
			}
		}

		public int SongLenght()
		{
			//var songLenght = new DateTime(00,00,00,00,this.Minutes,this.Seconds);
			//var songLenght=new TimeSpan(00,this.Minutes,this.Seconds);
			//if ((this.Minutes <= 0 || this.Minutes > 14) && (this.Seconds <= 0 || this.Seconds > 59))
			//{
			//	throw new InvalidSongLengthException();
			//}
			int songLenth = this.Minutes * 60 + this.Seconds;
			if (songLenth<=0||songLenth>(14*60+59))
			{
				throw new InvalidSongLengthException();
			}

			return songLenth;


		}
	}
}
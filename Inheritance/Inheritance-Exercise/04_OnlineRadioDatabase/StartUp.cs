using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
    {
        static void Main()
        {
            List<Song>songs=new List<Song>();
            int numberOfSong = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfSong; i++)
            {
                try
                {
                    var input = Console.ReadLine().Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
                    if(input.Length!=3)throw new InvalidSongException();

                    var songTimeInfo = input[2].Split(new[] {":"}, StringSplitOptions.RemoveEmptyEntries);

                    if (int.TryParse(songTimeInfo[0], out var minutes)&&int.TryParse(songTimeInfo[1], out var seconds))
                    {
                        Song song=new Song(input[0],input[1],minutes,seconds);
                        songs.Add(song);
                        Console.WriteLine("Song added.");
                    }
                    else
                    {
                        throw new InvalidSongLengthException();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    
                }
                
            }

            Console.WriteLine($"Songs added: {songs.Count}");
            long songLength = songs.Sum(s => s.Minutes)*60 + songs.Sum(s => s.Seconds);
            long hours = songLength / 3600;
            long minutesF = songLength % 3600/60;
            long secondsF = songLength % 3600 % 60;
            
            
            Console.WriteLine($"Playlist length: {hours}h {minutesF}m {secondsF}s");
        }
    }


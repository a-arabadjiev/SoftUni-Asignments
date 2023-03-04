namespace P04.OnlineRadioDatabase
{
    using P04.OnlineRadioDatabase.Utility;
    using P04.OnlineRadioDatabase.Factory;
    using P04.OnlineRadioDatabase.Models;

    using System.Collections.Generic;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int songsCount = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < songsCount; i++)
            {
                string[] songInput = Console.ReadLine().Split(new[] { ';' } , StringSplitOptions.RemoveEmptyEntries).ToArray();

                try
                {
                    Song song = SongFactory.Create(songInput);
                    songs.Add(song);

                    ConsoleWriter.Write("Song added.");
                }
                catch (Exception ex)
                {
                    ConsoleWriter.Write(ex.Message);
                }
            }

            ConsoleWriter.PrintFinalOutput(songs);
        }
    }
}
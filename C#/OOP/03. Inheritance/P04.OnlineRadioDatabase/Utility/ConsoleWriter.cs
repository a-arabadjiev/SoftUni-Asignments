namespace P04.OnlineRadioDatabase.Utility
{
    using P04.OnlineRadioDatabase.Models;

    using System;

    public static class ConsoleWriter
    {
        public static void Write(string input)
        {
            Console.WriteLine(input);
        }

        public static void PrintFinalOutput(List<Song> songs)
        {
            Console.WriteLine($"Songs added: {songs.Count}");

            OutputParser outputParser = new OutputParser();
            string playlistLength = outputParser.ReturnParsedPlaylistLength(songs);

            Console.WriteLine($"Playlist length: {playlistLength}");
        }
    }
}

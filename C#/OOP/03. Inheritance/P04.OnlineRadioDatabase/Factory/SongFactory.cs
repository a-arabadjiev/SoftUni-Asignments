namespace P04.OnlineRadioDatabase.Factory
{
    using P04.OnlineRadioDatabase.Exceptions;
    using P04.OnlineRadioDatabase.Models;

    public static class SongFactory
    {
        public static Song Create(string[] parameters)
        {
            if (parameters.Length != 3)
            {
                throw new InvalidSongException();
            }

            string artistName = parameters[0];

            Artist artist = new Artist(artistName);

            string songName = parameters[1];
            string songLength = parameters[2];

            string[] songLengthParams = parameters[2].Split(new[] { ':' } , StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (!(int.TryParse(songLengthParams[0], out _)) || !(int.TryParse(songLengthParams[1], out _)))
            {
                throw new InvalidSongLengthException();
            }

            int songMinutes = int.Parse(songLengthParams[0]);
            int songSeconds = int.Parse(songLengthParams[1]);

            Song song = new Song(songName, songLength, songMinutes, songSeconds, artist);

            return song;
        }
    }
}

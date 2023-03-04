namespace P04.OnlineRadioDatabase.Utility
{
    using P04.OnlineRadioDatabase.Models;

    public class OutputParser
    {
        private int totalSeconds = 0;
        private int totalMinutes = 0;
        private int totalHours = 0;

        public string ReturnParsedPlaylistLength(List<Song> songs)
        {
            int totalDuration = 0;
            foreach (var song in songs)
            {
                totalDuration += song.Minutes * 60 + song.Seconds;
            }
            totalHours = totalDuration / 3600;
            totalDuration -= totalHours * 3600;
            totalMinutes = totalDuration / 60;
            totalDuration -= totalMinutes * 60;
            totalSeconds = totalDuration;

            return $"{totalHours}h {totalMinutes}m {totalSeconds}s";
        }
    }
}

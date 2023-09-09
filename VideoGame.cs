using System;


namespace VideoGameLab
{
    public class VideoGame : IComparable<VideoGame>
    {
        public string Title { get; set; }
        public string Platform { get; set; }
        public string Year { get; set; }
        public Genre GameGenre { get; set; }
        public string Publisher { get; set; }
        public string NA_Sales { get; set; }
        public string EU_Sales { get; set; }
        public string JP_Sales { get; set; }
        public string Other_Sales { get; set; }
        public string Global_Sales { get; set; }

        public VideoGame()
        {

        }//end constructor

        public VideoGame(string title, string platform, string year, Genre genre, string publisher, string na, string eu, string jp, string other, string global)
        {
            Title = title;
            Platform = platform;
            Year = year;
            GameGenre = genre;
            Publisher = publisher;
            NA_Sales = na;
            EU_Sales = eu;
            JP_Sales = jp;
            Other_Sales = other;
            Global_Sales = global;

        }//end constructor

        public override string ToString()
        {
            string str = "";
            str += "\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
            str += "\nTitle: " + Title;
            str += "\nPlatform: " + Platform;
            str += "\nYear: " + Year;
            str += "\nGenre: " + GameGenre;
            str += "\nPublisher: " + Publisher;
            str += "\nNA Sales: " + NA_Sales;
            str += "\nJP Sales: " + JP_Sales;
            str += "\nOther Sales: " + Other_Sales;
            str += "\nGlobal Sales: " + Global_Sales;
            str += "\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";

            return str;
        }//end method

        public int CompareTo(VideoGame? other)
        {
            return this.Title.CompareTo(other.Title);
        }
    }
}

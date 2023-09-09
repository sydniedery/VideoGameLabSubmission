/*
 * Author:          Sydnie Dery
 * Date:            9/9/23
 * Purpse:          Read in .csv file of video games. Offer user option to get data on Genres or Publishers. 
 * 
 */
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Numerics;
using System.Globalization;

namespace VideoGameLab
{
    public class Program
    {

        static void Main(string[] args)
        {
            List<VideoGame> allGames = new List<VideoGame>();
          
            string filePath = @"..\..\..\Data\videogames.csv";


      //  @"C:\Users\sydni\OneDrive - East Tennessee State University\Semester 7\Server Side\Labs\VideoGameLab\VideoGameLab\Data\videogames.csv";
            StreamReader reader = null;
            //only do this if the path is right 
            if (File.Exists(filePath))
            {

                reader = new StreamReader(File.OpenRead(filePath));
                var line = reader.ReadLine();
                //read each line of the csv and create a VideoGame object and add it to the list.
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    var values = line.Split(',');
                    Genre inputAsEnum = decideGenre(values[3]);
                    VideoGame game = new VideoGame(values[0], values[1], values[2], inputAsEnum, values[4], values[5], values[6], values[7], values[8], values[9]);
                    allGames.Add(game);               
                }//end while loop 
                bool run = true;
                //menu
                while (run)
                {
                    Console.WriteLine("\nWhat kind of data would you like?\n1: Publisher\n2: Genre\n3: Exit");
                    string response = Console.ReadLine();

                    switch (response)
                    {
                        case "1":
                            PublisherData(allGames);
                            break;
                        case "2":
                            GenreData(allGames);
                            break;
                        default:
                            run = false;
                            break;
                    }//end switch
                }//end while loop
                Console.ReadLine();
            }//end if 
            else
            {
                Console.WriteLine("File doesn't exist");
            }//end else 

        }//end main

        //Method to ask user what genre they want data on and write it
        public static void GenreData(List<VideoGame> allGames)
        {
            int countOfAllGames = allGames.Count();

            Console.WriteLine("What genre do you want data on?");
            Genre genre = decideGenre(Console.ReadLine());

            var sorted = allGames.Where(game => game.GameGenre == genre).OrderBy(game => game.Title).ToList();
            foreach (var game in sorted)
            {
                Console.WriteLine(game.ToString());
            }//end foreach

            decimal percentage = decimal.Divide(sorted.Count(), countOfAllGames);

            Console.WriteLine("Out of " + countOfAllGames + " games, " + sorted.Count() + " are " + genre + ". That is {0:P2}.", percentage);


        }//end method

        //Method to request what publisher the user wants data on and write it
        public static void PublisherData(List<VideoGame> allGames)
        {
            int countOfAllGames = allGames.Count();

            Console.WriteLine("What publisher do you want data from?");
            string publisher = Console.ReadLine();

            //save all games by specified publisher to the var
            var sorted = allGames.Where(game => game.Publisher == publisher).OrderBy(game => game.Title).ToList();

            decimal percentage = decimal.Divide(sorted.Count(), countOfAllGames);

            //output all games by publisher specified
            foreach (var game in sorted)
            {
                Console.WriteLine(game.ToString());
            }//end foreach

            Console.WriteLine("Out of " + countOfAllGames + " games, " + sorted.Count() + " were made by " + publisher + ". That is {0:P2}.", percentage);
        }//end mehtod

            //Method to decide which genre was input and return a Genre Enum object. 
            public static Genre decideGenre(string inputString)
            {
            Genre inputasenum = new Genre();
            switch (inputString)
            {
                case "Action":
                    inputasenum = Genre.Action;
                    break;
                case "Adventure":
                    inputasenum = Genre.Adventure;
                    break;
                case "Fighting":
                    inputasenum = Genre.Fighting;
                    break;
                case "Misc":
                    inputasenum = Genre.Misc;
                    break;
                case "Platform":
                    inputasenum = Genre.Platform;
                    break;
                case "Puzzle":
                    inputasenum = Genre.Puzzle;
                    break;
                case "Racing":
                    inputasenum = Genre.Racing;
                    break;
                case "Role-Playing":
                    inputasenum = Genre.RolePlaying;
                    break;
                case "Shooter":
                    inputasenum = Genre.Action;
                    break;
                case "Simulation":
                    inputasenum = Genre.Simulation;
                    break;
                case "Sports":
                    inputasenum = Genre.Sports;
                    break;
                case "Strategy":
                    inputasenum = Genre.Strategy;
                    break;
            }//end switch 
            return inputasenum;
        }//end method

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HangMan
{
    class Program
    {
        //Declaration of global variables
        static string userName = "";
        static string[] possibleWords = {"apple", "greensleeves", "cider", "vivacious", "hideous", "musicianship", "rebellious", "institution", "indoctrination", "compatability", "invisible", "roundhouse", "allocation", "riveting"};
        static string chosenWord;
        static int guessesLeft = 15;
        static List<string> guessList = new List<string>();

        static void HangMan()
        {
            WelcomeToTheGame();
            ThinkingAnimation();
            Console.Clear();
            CompChooseWord();
            Console.Clear();
            ThinkingAnimation();
            Console.Clear();
            //Gameplay();

        }
        
        /// <summary>
        /// Welcomes user to the game, asks for their name, and gives brief description of gameplay
        /// </summary>
        static void WelcomeToTheGame()
        {
            Console.WriteLine("Hello there! I have a little game I'd like to play with you.");
            Console.WriteLine("But first! May I ask you your name?");

            Console.WriteLine();
            Console.WriteLine("...");
            Console.WriteLine();
            
            //Receive input for user name
            userName = Console.ReadLine().ToString();

            Console.WriteLine();
            ThinkingAnimation();             

            Thread.Sleep(1500);
            Console.Clear();
            
            //Welome & explanation
            Console.WriteLine("Wonderful! Welcome " + userName + ", I'm thrilled to have you.");
            Thread.Sleep(1500);
            Console.WriteLine("Today I'll be picking a word, and you'll be trying to figure out what it is.");
            Thread.Sleep(1500);
            Console.WriteLine("You can either guess the whole word or individual letters.");
            Thread.Sleep(1500);
            Console.WriteLine("If you guess the wrong word or your letter doesn't occur - you'll lose a guess.");
            Thread.Sleep(1500);
            Console.WriteLine("If you guess a letter that's in the word, I'll show you where it occurs.");
            Thread.Sleep(1500);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Chooses random word from array of available choices
        /// </summary>
        static void CompChooseWord()
        {
            //Create new random object constructor
            Random random = new Random();

            //Generate random index of word
            int randomIndex = random.Next(0, possibleWords.Length + 1);

            //Set chosenWord to possibleWords[randomIndex]
            chosenWord = possibleWords[randomIndex];

            //Print that word has been chosen
            Console.WriteLine("The computer has made it's choice:");
            Thread.Sleep(1000);

            //Display chosen word with underscores instead of letters.
            var tempList = new List<string>();
            for (int i = 0; i < chosenWord.Length; i++)
            {
                tempList.Add("_ ");
            }
            for (int i = 0; i < chosenWord.Length; i++)
            { 
                Console.Write(tempList[i]);
                Thread.Sleep(100);
            }

            //Ready to make your first guess?
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Ready to make your first guess? Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// Fun little thinking ... animation
        /// </summary>
        static void ThinkingAnimation()
        {
            for (int i = 0; i < 12; i++)
            {
                Console.Write(". ");
                Thread.Sleep(100);
            }
        }

        //static void Gameplay()
        //{
        //    //Analyze and print any letters in the word that have been guessed
        //    for (int i = 0; i < chosenWord.Length; i++)
        //    { 
        //        string y = chosenWord[i].ToString();
        //        if (guessList.Where(x => x == y).Any())
        //        {
        //            Console.Write(chosenWord[i] + ' ');
        //            Thread.Sleep(100);
        //        }
        //        else
        //        {
        //            Console.Write("_ ");
        //            Thread.Sleep(100);
        //        }
        //    }

        //    //Line break
        //    Console.WriteLine();
        //    Console.WriteLine();

        //    //Show letters guessed and guesses left
        //    Console.Write(

        //}

        static void Main(string[] args)
        {
            HangMan();
            Console.ReadKey();


            //var guessed = new List<string();
            //guessed.Where(x => x == userName || x =="e" || x == "s"); 
            //guessed.Where(x=> x == "a").Any();
        }
    }
}

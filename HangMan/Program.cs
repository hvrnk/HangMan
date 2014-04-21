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
        static string[] possibleWords = { "apple", "greensleeves", "cider", "vivacious", "hideous", "musicianship", "rebellious", "institution", "indoctrination", "compatability", "invisible", "roundhouse", "allocation", "riveting"};
        static string chosenWord;
        static int guessesStart = 10;
        static int guessesLeft = guessesStart;
        static List<string> guessList = new List<string>();
        static string currentGuess;
        static bool iWin = false;
        static List<bool> boolList = new List<bool>();

        static void HangMan()
        {
            WelcomeToTheGame();

            ThinkingAnimation();
            Console.Clear();
            
            CompChooseWord();
            Console.Clear();

            do 
            {
                Gameplay();
            } while (iWin == false && guessesLeft > 0);

            if (iWin)
            {
                YouWin();
            }
            else
            {
                YouLose();
            }


        }
        
        /// <summary>
        /// Welcomes user to the game, asks for their name, and gives brief description of gameplay
        /// </summary>
        static void WelcomeToTheGame()
        {
            //Console.WriteLine("Hello there! I have a little game I'd like to play with you.");
            Printing("Hello there! I have a little game I'd like to play with you.");
            //Console.WriteLine("But first! May I ask you your name?");
            Thread.Sleep(500);
            Printing("But first! May I ask you your name?");
            Thread.Sleep(500);

            Console.WriteLine();
            //Console.WriteLine("...");
            Printing("...");
            Console.WriteLine();
            
            //Receive input for user name
            userName = Console.ReadLine().ToString();

            Console.WriteLine();
            ThinkingAnimation();             

            Thread.Sleep(1500);
            Console.Clear();
            
            //Welome & explanation
            //Console.WriteLine("Wonderful! Welcome " + userName + ", I'm thrilled to have you.");
            Printing("Wonderful! Welcome " + userName + ", I'm thrilled to have you.");
            Thread.Sleep(500);
            Printing("Today I'll be picking a word, and you'll be trying to figure out what it is.");
            Thread.Sleep(500);
            Printing("You can either guess the whole word or individual letters.");
            Thread.Sleep(500);
            Printing("If you guess the wrong word or your letter doesn't occur - you'll lose a guess.");
            Thread.Sleep(500);
            Printing("If you guess a letter that's in the word, I'll show you where it occurs.");
            Thread.Sleep(500);
            Console.WriteLine();
            Printing("Think you can handle it, " + userName + "? Press any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Chooses random word from array of available choices
        /// </summary>
        static void CompChooseWord()
        {
            //Create new random object constructor
            Random random = new Random();

            //Generate random index of word
            int randomIndex = random.Next(0, possibleWords.Length);

            //Set chosenWord to possibleWords[randomIndex]
            chosenWord = possibleWords[randomIndex].ToUpper();

            //Print that word has been chosen
            Printing("I've made my choice:");
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

            ReceiveAndAnalyzeGuess();
        }

        /// <summary>
        /// Fun little thinking ... animation
        /// </summary>
        static void ThinkingAnimation()
        {
            for (int i = 0; i < 39; i++)
            {
                Console.Write(". ");
                Thread.Sleep(30);
            }
            Console.Write(".");
        }

        /// <summary>
        /// Animated printing function
        /// </summary>
        /// <param name="input">Text to be printed</param>
        /// <param name="delay">delay between each letter printed</param>
        static void Printing(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(input[i]);
                Thread.Sleep(1);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Prints guessed letters in appropriate spot or _s for letters not yet guessed
        /// </summary>
        static void PrintGuessedLetters()
        {
            //print any letters in the word that have been guessed
            for (int i = 0; i < chosenWord.Length; i++)
            {
                string y = chosenWord[i].ToString();
                if (guessList.Where(x => x == y).Any())
                {

                    Console.Write(chosenWord[i] + " ");
                    //boolList.Add(true);
                    Thread.Sleep(100);

                }
                else
                {
                    Console.Write("_ ");
                    //boolList.Add(false);
                    Thread.Sleep(100);
                }
            }

        }

        /// <summary>
        /// Looks through each letter of chosenWord and sees if guessList contains every letter in the word
        /// Returns true if guessList does contain them all and false otherwise
        /// </summary>
        /// <returns></returns>
        static bool TestGuessedLetters()
        {
            //clear boolList
            boolList.Clear();
            //loop through letters of chosenWord
            for (int i = 0; i < chosenWord.Length; i++)
            {
                if (guessList.Where(x => x == chosenWord[i].ToString()).Any())
                {
                    boolList.Add(true);
                }
                else
                {
                    boolList.Add(false);
                }
            }

            if (boolList.Where(i => i == false).Any())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static void ReceiveAndAnalyzeGuess()
        {
            //Ask for user's guess
            Printing("Type your guess and press enter to continue.");

            //receive guess 
            currentGuess = Console.ReadLine().ToUpper();

            //formatting
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(1000);
            ThinkingAnimation();
            Thread.Sleep(500);
            Console.Clear();

            //test if guess is more than 1 character
            if (currentGuess.Length > 1)
            {
                //test if guess is equal to chosenWord
                if (currentGuess == chosenWord)
                {
                    //end the gameplay() do-while loop
                    iWin = true;
                }
                //dis wut happens if u guess wrong
                else
                {
                    //subtract from guess counter
                    guessesLeft -= 1;

                    Printing("I'm sorry " + userName + ", that guess was incorrect.");
                    Console.WriteLine();
                    Thread.Sleep(1000);
                    Console.WriteLine();
                    Printing("Got a little ahead of ourselves did we?");
                    Printing("Maybe try just a letter next time, eh?");
                    Console.WriteLine();
                    Thread.Sleep(1000);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    ThinkingAnimation();
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            if (currentGuess.Length == 1)
            {
                guessList.Add(currentGuess);
            }

            //see if currentGuess is in chosenWord and subtract from guessesLeft if it is not
            bool guessIsThere = false;
            for (int i = 0; i < chosenWord.Length; i++)
            {
                char y = chosenWord[i];
                if (currentGuess.Where(x => x == y).Any())
                {
                    guessIsThere = true;
                }
            }

            if (!guessIsThere)
            {
                guessesLeft -= 1;
                Printing("Sorry! That one's not in there.");
            }
            else
            {
                Printing("Good work! That one's in there.");
            }

            //delay so message can be read
            Thread.Sleep(1000);
            Console.Clear();

            if(TestGuessedLetters())
            {
                iWin = true;
            }
        }

        /// <summary>
        /// Completes tasks essential to gameplay
        /// </summary>
        static void Gameplay()
        {
            Printing("Alright " + userName + ", here's what you're workin' with...");
            Console.WriteLine();

            PrintGuessedLetters();
            
            //Line break
            Console.WriteLine();
            Console.WriteLine();

            //Show letters guessed and guesses left
            Console.Write("Letters guessed: ");
            for (int i = 0; i < guessList.Count; i++)
            {
                Console.Write(guessList[i] + ' ');
            } Console.WriteLine();

            Thread.Sleep(300);

            Console.WriteLine("Guesses left: " + guessesLeft);

            Thread.Sleep(300);

            Console.WriteLine();
            Console.WriteLine("________________________________________________");
            Console.WriteLine();

            Thread.Sleep(300);

            ReceiveAndAnalyzeGuess();
        }

        /// <summary>
        /// Prints winning message
        /// </summary>
        static void YouWin()
        {
            Printing("Correctomundo! You've got it " + userName + "!");
            Printing("You made " + (guessesStart - guessesLeft) + " incorrect guesses.");
            Console.WriteLine();
            Thread.Sleep(500);
            
            Printing("The word I was looking for was:");
            Console.WriteLine();

            for (int i = 0; i < chosenWord.Length; i++)
            {
                Console.Write(chosenWord[i].ToString() + ' ');
            }
            Console.WriteLine();
            Console.WriteLine();

            Printing("Thanks for playing!");
            Thread.Sleep(200);
            Printing("I hope to play again soon.");

        }

        /// <summary>
        /// Prints losing message
        /// </summary>
        static void YouLose()
        {
            Printing("You thought!!");
            Thread.Sleep(300);
            Printing("But nah...you're done.");
            Console.WriteLine();
            Printing("The word I was looking for was:");
            Console.WriteLine();

            for (int i = 0; i < chosenWord.Length; i++)
            {
                Console.Write(chosenWord[i].ToString() + ' ');
            }
            Console.WriteLine();
            Printing("I've got lots more words you can guess, so whaddaya say?");
            Printing("Let's try again later!");
        }

       

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

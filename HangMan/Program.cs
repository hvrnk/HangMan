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
        static int guessesStart = 7;
        static int guessesLeft = guessesStart;
        static List<string> guessList = new List<string>();
        static string currentGuess;
        static bool iWin = false;
        static List<bool> boolList = new List<bool>();
        static string playAgain;
        static int cursorStartHangMan;

        static void HangMan()
        {
            WelcomeToTheGame();
            CompChooseWord();

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
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            PrintingSameLine("        ██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╗  "); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╗"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine(" █████"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╗ "); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("███"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╗   "); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╗ "); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██████"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╗ "); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("███"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╗   "); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("███"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╗ "); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("█████"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╗ "); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("███"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╗   "); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; Printing("╗"); Console.ForegroundColor = ConsoleColor.DarkBlue;
            PrintingSameLine("        ██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║  "); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╔══"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╗"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("████"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╗"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("  ██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╔════╝ "); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("████"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╗ "); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("████"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╔══"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╗"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("████"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╗  "); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; Printing("║"); Console.ForegroundColor = ConsoleColor.DarkBlue;
            PrintingSameLine("        ███████"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("███████"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╔"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╗ "); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║  "); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("███"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╗"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╔"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("████"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╔"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("███████"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╔"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╗ "); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; Printing("║"); Console.ForegroundColor = ConsoleColor.DarkBlue;
            PrintingSameLine("        ██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╔══"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╔══"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║╚"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╗"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║   "); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║╚"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╔╝"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╔══"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║╚"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╗"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; Printing("║");Console.ForegroundColor = ConsoleColor.DarkBlue;
            PrintingSameLine("        ██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║  "); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║  "); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║ ╚"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("████"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║╚"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██████"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("╔╝"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║ ╚═╝ "); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║  "); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("██"); Console.ForegroundColor = ConsoleColor.Cyan; PrintingSameLine("║ ╚"); Console.ForegroundColor = ConsoleColor.DarkBlue; PrintingSameLine("████"); Console.ForegroundColor = ConsoleColor.Cyan; Printing("║");
            PrintingSameLine("        ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝"); Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine();
//            Printing(@"
//
//        ██╗  ██╗ █████╗ ███╗   ██╗ ██████╗ ███╗   ███╗ █████╗ ███╗   ██╗
//        ██║  ██║██╔══██╗████╗  ██║██╔════╝ ████╗ ████║██╔══██╗████╗  ██║
//        ███████║███████║██╔██╗ ██║██║  ███╗██╔████╔██║███████║██╔██╗ ██║
//        ██╔══██║██╔══██║██║╚██╗██║██║   ██║██║╚██╔╝██║██╔══██║██║╚██╗██║
//        ██║  ██║██║  ██║██║ ╚████║╚██████╔╝██║ ╚═╝ ██║██║  ██║██║ ╚████║
//        ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝
//
//                        ");
            cursorStartHangMan = Console.CursorTop;

            guessesLeft = 7;
            for (int i = 0; i <= 7; i++)
            {
                Console.SetCursorPosition(0, cursorStartHangMan);
                DrawHangedMan();
                Thread.Sleep(300);
                guessesLeft--;
            }
            guessesLeft = 7;


            PrintingSameLine("        Enter name: ");
            
            //Receive input for user name
            userName = Console.ReadLine();
            Thread.Sleep(200);
            //Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();

            Header();

            Thread.Sleep(250);

            DrawHangedMan();
            Console.ForegroundColor = ConsoleColor.Gray;
             

//            Thread.Sleep(1500);
            
            //Welome & explanation
            //Console.WriteLine("Wonderful! Welcome " + userName + ", I'm thrilled to have you.");
            Printing("        Welcome " + userName + "! Let's play HANGMAN.");
            Thread.Sleep(500);
            Console.WriteLine();
            Printing("        I've selected a word.");
            Thread.Sleep(500);
            Printing("        Guess a letter at a time or the whole word.");
            Thread.Sleep(500);
            Printing("        Guess wrong, and you'll lose a guess. ");
            Thread.Sleep(500);
            Printing("        Guess right, and I'll show you where the letter shows up.");
            Thread.Sleep(500);
            Console.WriteLine();
            Printing("        Think you can handle it, " + userName + "? Press any key to continue...");
            Console.ReadKey();
            ThinkingAnimation();
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
            int randomIndex = random.Next(0, possibleWords.Length);

            //Set chosenWord to possibleWords[randomIndex]
            chosenWord = possibleWords[randomIndex].ToUpper();
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
                //Thread.Sleep(1);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Animated printing function
        /// </summary>
        /// <param name="input">Text to be printed</param>
        /// <param name="delay">delay between each letter printed</param>
        static void PrintingSameLine(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(input[i]);
                Thread.Sleep(1);
            }
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

                    Console.ForegroundColor = ConsoleColor.Red;
                    Printing("I'm sorry " + userName + ", that guess was incorrect.");
                    Console.ForegroundColor = ConsoleColor.White;

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

            //check to see if user input is empty
            if (currentGuess.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Printing("You didn't type anything! Let's try that again...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            //if guess is not there
            else if (!guessIsThere)
            {
                guessesLeft -= 1;
                Console.ForegroundColor = ConsoleColor.Red;
                Printing("Sorry! That one's not in there.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            //else guess is there
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Printing("Good work! That one's in there.");
                Console.ForegroundColor = ConsoleColor.White;
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
            Header();

            DrawHangedMan();

            PrintGuessedLetters();
            
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

            Header();
            DrawHangedMan();
            GreenChosenWord();
        }

        /// <summary>
        /// Prints losing message
        /// </summary>
        static void YouLose()
        {
            RedHeader();

            DrawHangedMan();

            RedChosenWord();
        }

        static void DrawHangedMan()
        {
                    if (guessesLeft == 7)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(@"

                             ____________________
                            | .__________________|
                            | | / /                         
                            | |/ /                    
                            | | /                       
                            | |/                     
                            | |                       
                            | |                       
                            | |                           
                            | |                           
                            | |                            
                            | |                               
                            | |                            
                            | |                          
                            | |                            
                            | |                         
                            | |                         
                            | |                        
                            | |-------|-----------|-|
                            | |-------|-----------|-|
                            | |                   | |
                            | |                   | | 
                            . .                   . .
                            _________________________
         

");
                    }
                    if (guessesLeft == 6)
                    {
                        Console.WriteLine(@"

                             ___________.._______
                            | .__________))______|
                            | | / /      ||
                            | |/ /       ||
                            | | /        ||
                            | |/         ||
                            | |         
                            | |          
                            | |              
                            | |               
                            | |                
                            | |                 
                            | |                  
                            | |          
                            | |          
                            | |          
                            | |         
                            | |         
                            | |-------|-----------|-|
                            | |-------|-----------|-|
                            | |                   | |
                            | |                   | | 
                            . .                   . .
                            _________________________


");

                    }
                    if (guessesLeft == 5)
                    {
                        Console.WriteLine(@"

                             ___________.._______
                            | .__________))______|
                            | | / /      ||
                            | |/ /       ||.-''.      
                            | | /        |/  _  \ 
                            | |/         ||  `/,| 
                            | |           \\`_.' 
                            | |
                            | |              
                            | |               
                            | |                
                            | |                 
                            | |                  
                            | |          
                            | |          
                            | |          
                            | |         
                            | |         
                            | |-------|-----------|-|
                            | |-------|-----------|-|
                            | |                   | |
                            | |                   | | 
                            . .                   . .
                            _________________________


");
                    }
                    if (guessesLeft == 4)
                    {
                        Console.WriteLine(@"

                             ___________.._______
                            | .__________))______|
                            | | / /      ||
                            | |/ /       ||.-''.      
                            | | /        |/  _  \ 
                            | |/         ||  `/,| 
                            | |           \\`_.' 
                            | |              '.
                            | |               Y\
                            | |                \\
                            | |                 \\
                            | |                  (`
                            | |
                            | |          
                            | |          
                            | |          
                            | |         
                            | |         
                            | |-------|-----------|-|
                            | |-------|-----------|-|
                            | |                   | |
                            | |                   | | 
                            . .                   . .
                            _________________________


");
                    }
                    if (guessesLeft == 3)
                    {
                        Console.WriteLine(@"

                             ___________.._______
                            | .__________))______|
                            | | / /      ||
                            | |/ /       ||.-''.      
                            | | /        |/  _  \ 
                            | |/         ||  `/,| 
                            | |          (\\`_.' 
                            | |         .-`--'.
                            | |        /Y     Y\
                            | |       //       \\
                            | |      //         \\
                            | |     ')           (`
                            | |
                            | |          
                            | |          
                            | |          
                            | |         
                            | |         
                            | |-------|-----------|-|
                            | |-------|-----------|-|
                            | |                   | |
                            | |                   | | 
                            . .                   . .
                            _________________________


");
                    }
                    if (guessesLeft == 2)
                    {
                        Console.WriteLine(@"

                             ___________.._______
                            | .__________))______|
                            | | / /      ||
                            | |/ /       ||.-''.      
                            | | /        |/  _  \ 
                            | |/         ||  `/,| 
                            | |          (\\`_.' 
                            | |         .-`--'.
                            | |        /Y . . Y\
                            | |       // |   | \\
                            | |      //  | . |  \\
                            | |     ')   |   |   (`
                            | |
                            | |          
                            | |          
                            | |          
                            | |         
                            | |         
                            | |-------|-----------|-|
                            | |-------|-----------|-|
                            | |                   | |
                            | |                   | | 
                            . .                   . .
                            _________________________


");
                    }
                    if (guessesLeft == 1)
                    {
                        Console.WriteLine(@"

                             ___________.._______
                            | .__________))______|
                            | | / /      ||
                            | |/ /       ||.-''.       
                            | | /        |/  _  \ 
                            | |/         ||  `/,|
                            | |          (\\`_.' 
                            | |         .-`--'. 
                            | |        /Y . . Y\
                            | |       // |   | \\
                            | |      //  | . |  \\
                            | |     ')   |   |   (`
                            | |          ||'||
                            | |          || ||
                            | |          || ||
                            | |          || ||
                            | |         / | | \         
                            | |         `-' `-'
                            | |-------|-----------|-|
                            | |-------|-----------|-|
                            | |                   | |
                            | |                   | | 
                            . .                   . .
                            _________________________


");
                    }
                    if (guessesLeft == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;

                        Console.WriteLine(@"

                             ___________.._______
                            | .__________))______|
                            | | / /      ||             
                            | |/ /       ||             
                            | | /        ||.-''.  
                            | |/         |/  _  \  
                            | |          ||  `/,|   
                            | |          (\\`_.'    
                            | |         .-`--'.   
                            | |        /Y . . Y\   
                            | |       // |   | \\   
                            | |      //  | . |  \\   
                            | |     ')   |   |   (`   
                            | |          ||'||  
                            | |          || ||  
                            | |          || ||  
                            | |          || ||  
                            | |         / | | \  
                            | |-------|_`-' `-' |---|  
                            | |-------\ \       --|-|  
                            | |        \ \        | |  
                            | |         \ \       | |   
                            . .          `'       . .  
                            _________________________  


");
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }

        static void Header()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(@"        ██╗  ██╗ █████╗ ███╗   ██╗ ██████╗ ███╗   ███╗ █████╗ ███╗   ██╗
        ██║  ██║██╔══██╗████╗  ██║██╔════╝ ████╗ ████║██╔══██╗████╗  ██║
        ███████║███████║██╔██╗ ██║██║  ███╗██╔████╔██║███████║██╔██╗ ██║
        ██╔══██║██╔══██║██║╚██╗██║██║   ██║██║╚██╔╝██║██╔══██║██║╚██╗██║
        ██║  ██║██║  ██║██║ ╚████║╚██████╔╝██║ ╚═╝ ██║██║  ██║██║ ╚████║
        ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝");
        }
        
        static void RedHeader()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"        ██╗  ██╗ █████╗ ███╗   ██╗ ██████╗ ███╗   ███╗ █████╗ ███╗   ██╗
        ██║  ██║██╔══██╗████╗  ██║██╔════╝ ████╗ ████║██╔══██╗████╗  ██║
        ███████║███████║██╔██╗ ██║██║  ███╗██╔████╔██║███████║██╔██╗ ██║
        ██╔══██║██╔══██║██║╚██╗██║██║   ██║██║╚██╔╝██║██╔══██║██║╚██╗██║
        ██║  ██║██║  ██║██║ ╚████║╚██████╔╝██║ ╚═╝ ██║██║  ██║██║ ╚████║
        ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝");
        }

        static void RedChosenWord()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < chosenWord.Length; i++)
            {
                Console.Write(chosenWord[i] + " ");
                Thread.Sleep(50);
            }
        }

        static void GreenChosenWord()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < chosenWord.Length; i++)
            {
                Console.Write(chosenWord[i] + " ");
                Thread.Sleep(50);
            }
        }

        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 50);

            HangMan();

            Console.ReadKey();
        }
    }
}

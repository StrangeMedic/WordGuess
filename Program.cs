using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    internal class Program
    {
        public static List<string> words = new List<string>()
            {
                "apple",
                "angry",
                "horse",
                "weird",
                "grand",
                "jolly",
                "cheer",
                "tight",
                "small",
                "hurry",
                "spook",
                "haunt",
            };

        public static void Main(string[] args)
        {
            string solution = "";
            List<string> guesses = new List<string>();
            List<int> guessAcc = new List<int>();

            Random rand = new Random();

            solution = words[rand.Next(words.Count)];

            bool gameOver = false;
            int guessesLeft = 8;
            string userGuess = "";
            string errored = "";

            do
            {
                Console.Clear();
                Console.WriteLine("========[Word guess]========");
                for(int i = 0; i < guesses.Count; i++)
                {
                    for(int j = 0; j < guesses[i].Length; j++)
                    {
                        int k = (i * 5) + j;
                        if (guessAcc[k] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        } else if (guessAcc[k] == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        } else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.Write(guesses[i][j]);
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Guesses left: " + guessesLeft);
                Console.WriteLine(errored);
                Console.Write("==> ");
                userGuess = Console.ReadLine();
                if (userGuess.Length == 5)
                {
                    if (solution.Equals(userGuess.ToLower()))
                    {
                        Console.Clear();
                        Console.WriteLine("You guessed the word!");
                        Thread.Sleep(5000);
                        gameOver = true;
                    } else
                    {
                        for (int i = 0; i < userGuess.Length; i++)
                        {
                            int k = i + (guesses.Count * 5);
                            char c = userGuess.ToLower()[i];
                            int acc = 3;
                            for (int j = 0; j < solution.Length; j++)
                            {
                                char c2 = solution[j];
                                Console.WriteLine("Comparing " + c + " and " +  c2);
                                if (c == c2)
                                {
                                    if (j == i)
                                    {
                                        Console.WriteLine("In the same spot!");
                                        acc = 1;
                                        break;
                                    } else
                                    {
                                        Console.WriteLine("Contains the letter!");
                                        acc = 2;
                                    }
                                }
                            }

                            guessAcc.Add(acc);
                        }
                        guesses.Add(userGuess);

                        guessesLeft--;

                        if (guessesLeft <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("You lose!");
                            Console.WriteLine("Word was " + solution + ".");
                            Thread.Sleep(5000);
                            gameOver = true;
                        }
                    }
                } else
                {
                    errored = "Answer must be a 5 letter word!";
                }

            } while (gameOver == false);

            if(guessesLeft > 0) {
                Console.WriteLine("You win!");
            } else
            {
                Console.WriteLine("You lost...");
                Console.WriteLine("Solution was " + solution);
            }
        }
    }
}

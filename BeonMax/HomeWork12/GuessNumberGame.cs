﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork12
{
    public enum GuessingPlayes
    {
        Human,
        Machine
    }


    public class GuessNumberGame
    {
        private readonly int max;
        private readonly int maxTries;
        private readonly GuessingPlayes guessingPlayers;

        public GuessNumberGame(int max = 100, int maxTries = 5, GuessingPlayes guessingPlayes = GuessingPlayes.Human)
        {
            this.max = max;
            this.maxTries = maxTries;
            this.guessingPlayers = guessingPlayes;
        }

        public void Start()
        {
            if (guessingPlayers == GuessingPlayes.Human)
            {
                HumanGuesses();
            }
            else
            {
                MachineGuesses();
            }
        }

        private void HumanGuesses()
        {
            Random rand = new Random();
            int guessedNumber = rand.Next(0, max);
            int lastGuess = -1;
            int tries = 0;
            while (lastGuess != guessedNumber && tries < maxTries)
            {
                Console.WriteLine("Guess the number!");
                lastGuess = int.Parse(Console.ReadLine());

                if (lastGuess == guessedNumber)
                {
                    Console.WriteLine("Congrats! You guessed the number!");
                    break;
                }
                else
                {
                    if (lastGuess < guessedNumber)
                    {
                        Console.WriteLine("My number is greater");
                    }
                    else
                    {
                        Console.WriteLine("My number is less!");
                    }
                    tries++;

                    if (tries == maxTries)
                    {
                        Console.WriteLine("You lost!");
                    }
                }
 
            }
        }

        private void MachineGuesses()
        {
            Console.WriteLine("Enter a number that's going to be guessed by a computer");

            int guessedNumber = -1;

            while (guessedNumber == -1)
            {
                int parsedNumber = int.Parse(Console.ReadLine());
                if (parsedNumber >= 0 && parsedNumber <= this.max)
                {
                    guessedNumber = parsedNumber;
                }
            }

            int lastGuess = -1;
            int min = 0;
            int max = this.max;
            int tries = 0;

            while (lastGuess != guessedNumber && tries < maxTries)
            {
                lastGuess = (max + min) / 2;
                Console.WriteLine($"Did you guess the number - {lastGuess}");
                Console.WriteLine("If yes, enter 'y', if you is greater - enter 'g', if less - 'l'");

                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    Console.WriteLine("Super! I guessed your number, man!");
                    break;
                }
                else if (answer == "g")
                {
                    min = lastGuess;
                }
                else
                {
                    max = lastGuess;
                }

                if (lastGuess == guessedNumber)
                {
                    Console.WriteLine("Don't cheat, man!");
                }
                tries++;
                if (tries == maxTries)
                {
                    Console.WriteLine("No tries anymore :( I lost!");
                }
            }
        }
    }
}

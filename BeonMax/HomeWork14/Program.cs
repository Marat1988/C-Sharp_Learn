using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Старая добрая игра "Виселица" (с недобрым названием).

Смысл игры
Компьютер загадывает любое слово, взятое из словаря (ссылка на словарь прилагается).
Человек пытается, называя буквы, угадать слово. Если буква есть в слове, компьютер
вскрывает отгаданные буквы. Не отгаданные буквы не вскрываются, а выводятся, например,
прочерки (дефисы). Есть ограниченное кол-во попыток (по умолчанию, максимум 6).
Если попытки исчерпаны - человек проиграл, игра завершается и показывается загаданное
слово и кол-во ошибок допущенных игроком.

Рисовать виселицу в консоли необязательно. Если есть желание - это сделать можно. */

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            HangmanGame game = new HangmanGame();
            string word = game.GenerateWord();
            Console.WriteLine($"The wird consists of {word.Length} letters.");
            Console.WriteLine("Try to guess the word.");

            while (game.GameStatus==GameStatus.InProgredss)
            {
                Console.WriteLine("Pick a letter");
                char c = (char)Console.ReadLine().ToCharArray()[0];

                string curSate = game.GuessLetter(c);

                Console.WriteLine(curSate);

                Console.WriteLine($"Remaining tries = {game.RemainingTries}");
                Console.WriteLine($"Tried letters:{game.TriedLetters}");
            }

            if (game.GameStatus == GameStatus.Lost)
            {
                Console.WriteLine("You are hanged");
                Console.WriteLine($"The word was: {game.Word}");
            }
            else
            {
                if (game.GameStatus == GameStatus.Won)
                {
                    Console.WriteLine("You won!");
                }
            }
            Console.ReadKey();
        }
    }
}

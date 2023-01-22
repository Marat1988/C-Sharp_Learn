using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*Скачать файл по ссылке ниже.
В файле лежат данные в csv формате. Данные предназначены для игры в "верю-не-верю".

Смысл игры
Компьютер задаёт вопросы или даёт некоторые утверждения человеку, а человек отвечает да\нет или верит он или не верит в утверждение.
Компьютер берёт вопросы из файла, правильные ответы и пояснения к ответу тоже. Можете записать свои данные в файл.

Кол-во ошибок ограничено и по умолчанию равно 2. Компьютер задаёт вопросы из файла и если человек ответил на все вопросы, не допустив
более максимально разрешённого количества ошибок, то игрок победил, в противном случае проиграл.

Если игрок ошибся при ответе, компьютер выводит пояснение к ответу.

Диалог реализуйте в виде, который сочтёте наиболее приемлемым. */

namespace HomeWork17
{

    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(@"Questions.csv");
            game.EndOfGame += (sender, e) =>
            {
                Console.WriteLine($"Questions asked:{e.questionPassed}. Mistakes made: {e.mistakesMade} ");
                Console.WriteLine(e.isWin ? "You won!" : "You lost!");
            };

            while (game.GameStatus == GameStatus.GameInProgress)
            {
                Question q = game.GetNextQuestion();
                Console.WriteLine("Dou you believe in the next statement or question? Enter 'y' or 'n'");
                Console.WriteLine(q.text);

                string answer = Console.ReadLine();
                bool boolAnswer = answer == "y";
                if (q.correctAnswer == boolAnswer)
                {
                    Console.WriteLine("Good job. You're right!");
                }
                else
                {
                    Console.WriteLine("Oooops, actually you're mistaken. Here is the commentaty:");
                    Console.WriteLine(q.explanation);
                }

                game.GiveAnswer(boolAnswer);
            }
            Console.ReadLine();
        }
    }
}

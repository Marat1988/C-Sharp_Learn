using HomeWork15.Stick;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*Вы попробуете разработать игру.

Предлагаю древнюю китайскую игру в палочки.
Играют два игрока. Есть 10 палочек (по умолчанию). Игроки по очереди берут от одной до трёх палочек. Играют до тех пор пока не закончатся палочки.
Тот кто взял последним - тот проиграл.

Реализуйте игру таким образом, чтобы против человек играл компьютер. Изначально есть 10 палочек. На каждом ходу выводите на консоль текущее количество
оставшихся палочек и просите ввести количество палочек, которое хочет взять игрок (который делает ход. машина делает ход автоматически при своей очереди,
её просить не надо :)). Не забывайте менять очерёдность игроков и сокращать кол-во палочек. В конце надо вывести кто победил - человек или машина.

Нюансы реализации могут отличаться. Кто-то может захотеть реализовать не с 10-ю палочками, а с тем количеством, которое введёт пользователь
(может он хочет играть с 20-ю палочками?).


Разбор решения в следующем видео-уроке*/


namespace HomeWork15
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new StickGame(10,Player.Human);
            game.MachinePlayer += Game_MachinePlayer;
            game.HumanTurnToMakeMove += Game_HumanTurnToMakeMove;
            game.ENdOfGame += Game_ENdOfGame;

            game.Start();
        }

        private static void Game_ENdOfGame(Player player)
        {
            Console.WriteLine($"Winner: {player}");
        }

        private static void Game_HumanTurnToMakeMove(object sender, int remainingSticks)
        {
            Console.WriteLine($"Remaining sticks: {remainingSticks}");
            Console.WriteLine("Take some sticks");

            bool takenCorrectly = false;
            while (!takenCorrectly)
            {
                if (int.TryParse(Console.ReadLine(),out int takeSticks))
                {
                    var game = (StickGame)sender;

                    try
                    {
                        game.HumanTakes(takeSticks);
                        takenCorrectly = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private static void Game_MachinePlayer(int sticksTaken)
        {
            Console.WriteLine($"Machine took:{sticksTaken}");
        }
    }
}

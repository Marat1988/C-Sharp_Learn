using System;
using System.Text;

/*Практическое задание "Крестики-Нолики"
 
А вот и новое домашнее задание. Непростое. Но вполне реализуемое.

Вы попробуете реализовать игру в крестики-нолики размером 3х3 - самые что ни на есть обыкновенные.

Сделайте метод, который выводит на каждом ходу текущее положение с линейками, крестиками и ноликами
(используйте буквы X и O в качестве крестиков и ноликов) - так игрокам будет удобнее ориентироваться.

Также вам понадобится реализовать способ проверки наличия выигрышной комбинации. Подсказка: договоримся,
что клетки поля будут пронумерованы от 0 до 8 и пользователи будут вводить индекс поля, чтобы поставить там крестик или нолик.

Для упрощения - тот кто ходит первым - ставит крестик.
 */

namespace HomeWork13
{
    class Program
    {
        private static TicTacToeGame g = new TicTacToeGame();

        static void Main(string[] args)
        {
            Console.WriteLine(GetPrintableState());
            while (g.GetWinner() == Winner.GameIsUnfinished)
            {
                int index = int.Parse(Console.ReadLine());
                g.MakeMove(index);

                Console.WriteLine();
                Console.WriteLine(GetPrintableState());
            }
            Console.WriteLine($"Reult: {g.GetWinner()}");
            Console.ReadLine();
        }

        static string GetPrintableState()
        {
            var sb = new StringBuilder();
            for (int i = 1; i <= 7; i += 3)
            {
                sb.AppendLine("     |     |      |")
                    .AppendLine($"  {GetPrintableChar(i)}  |  {GetPrintableChar(i + 1)}  |  {GetPrintableChar(i + 2)}   |")
                    .AppendLine("_____|_____|______|");
            }
            return sb.ToString();
        }

        static string GetPrintableChar(int index)
        {
            State state = g.GetState(index);
            if (state == State.Unset)
            {
                return index.ToString();
            }
            else
            {
                return state == State.Cross ? "X" : "O";
            }
        }
    }
}

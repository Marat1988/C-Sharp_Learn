using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork16
{
    /*Используя файл с ТОП100 шахматных игроков, найти всех игроков из России и отсортировать их по году рождения по возрастанию.*/
    class Program
    {
        static void Main(string[] args)
        {
            var players = File.ReadAllLines(@"Top100ChessPlayers.csv")
                              .Skip(1)
                              .Select(ChessPlayer.ParseFideCsv)
                              .Where(player => player.Country == "RUS")
                              .OrderBy(player => player.BirthYear)
                              .ToList();
            foreach (var player in players)
            {
                Console.WriteLine(player);
            }
            Console.ReadLine();
        }
    }
}

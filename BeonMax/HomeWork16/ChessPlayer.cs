using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork16
{
    public class ChessPlayer
    {
        public string Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public int Rating { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return $"Full Name: {FirstName + " " + LastName}, Rating = {Rating}, from {Country}," +
                $"born in {BirthYear}";
        }

        public static ChessPlayer ParseFideCsv(string line)
        {
            string[] parts = line.Split(';');

            int BirthYear = int.Parse(parts[6]);
            return new ChessPlayer()
            {
                Id = int.Parse(parts[0]),
                LastName = parts[1].Split('\t')[0].Trim(),
                FirstName = parts[1].Split('\t')[1].Trim(),
                Country = parts[3],
                Rating = int.Parse(parts[4]),
                BirthYear = int.Parse(parts[6])
            };
        }
    }
}

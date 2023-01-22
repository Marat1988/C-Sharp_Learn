using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork17
{


    public class Game
    {
        private readonly List<Question> questions;
        public readonly int AllowedMisTakes;
        private int counter;
        private int mistakes;
        public event EventHandler<GameResultEvemtArgs> EndOfGame;


        public GameStatus GameStatus { get; private set; }

        public Game(string filePath, int allowedMisTakes = 2)
        {
            if (filePath == null)
                throw new ArgumentNullException("filePath");
            if (filePath == "")
                throw new ArgumentException("filePath should not be empty");
            if (allowedMisTakes < 2)
                throw new ArgumentException("allowedMistakes should be >= 2");

            List<Question> questions = File.ReadAllLines(filePath)
                                                  .Select(x =>
                                                  {
                                                      string[] parts = x.Split(';');
                                                      string text = parts[0];
                                                      bool correctAnswer = parts[1] == "Yes";
                                                      string explanation = parts[2];
                                                      return new Question(text, correctAnswer, explanation);
                                                  })
                                                  .ToList();
            this.questions = questions;
            AllowedMisTakes = allowedMisTakes;
            GameStatus = GameStatus.GameInProgress;
        }

        public Question GetNextQuestion()
        {
            return questions[counter];
        }

        public void GiveAnswer(bool answer)
        {
            if (questions[counter].correctAnswer != answer)
            {
                mistakes++;
            }

            if (counter==questions.Count-1 || mistakes > AllowedMisTakes)
            {
                GameStatus = GameStatus.GameIsOver;
                if (EndOfGame != null)
                {
                    EndOfGame(this, new GameResultEvemtArgs(counter, mistakes, mistakes < AllowedMisTakes));
                }
            }

            counter++;
        }


    }
}

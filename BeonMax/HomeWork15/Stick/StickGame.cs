using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork15.Stick
{


    public class StickGame
    {
        private readonly Random randomizer;

        public int InitialStickNumber { get; }

        public Player Turn { get; private set; }

        public int RemainingSticks { get; private set; }

        public GameStatus GameStatus { get; private set; }

        public event Action<int> MachinePlayer;

        public event EventHandler<int> HumanTurnToMakeMove;

        public event Action<Player> ENdOfGame;

        public StickGame(int initialSticksNumber, Player whoMakesFirstMove)
        {
            if (initialSticksNumber<7 || initialSticksNumber > 30)
            {
                throw new ArgumentException("Initial number of sticks should be >=7 AND <=30");
            }
            randomizer = new Random();
            GameStatus = GameStatus.NotStarted;
            InitialStickNumber = initialSticksNumber;
            RemainingSticks = InitialStickNumber;
            Turn = whoMakesFirstMove;
        }

        public void HumanTakes(int sticks)
        {
            if (sticks < 1 || sticks > 3)
            {
                throw new ArgumentException("You can take from 1 to 3 sticks in a single move");
            }

            if (sticks > RemainingSticks)
            {
                throw new ArgumentException($"You can't take more than remaining. Remains:{RemainingSticks}");
            }

            TakeSticks(sticks);
        }

        public void Start()
        {
            if (GameStatus == GameStatus.GameIsOver)
                RemainingSticks = InitialStickNumber;

            if (GameStatus == GameStatus.InProgress)
            {
                throw new InvalidOperationException("Can't call start when game is already in progress");
            }

            GameStatus = GameStatus.InProgress;
            while (GameStatus == GameStatus.InProgress)
            {
                if (Turn == Player.Computer)
                {
                    CompMakesMove();
                }
                else
                {
                    HumanMakesMove();
                }

                FireEndOfGameIfRequired();

                Turn = Turn == Player.Computer ? Player.Human : Player.Computer;

            }
        }

        private void FireEndOfGameIfRequired()
        {
            if (RemainingSticks == 0)
            {
                GameStatus = GameStatus.GameIsOver;
                if (ENdOfGame != null)
                {
                    ENdOfGame(Turn == Player.Computer ? Player.Human : Player.Computer);
                }
            }
        }

        private void HumanMakesMove()
        {
            if (HumanTurnToMakeMove != null)
                HumanTurnToMakeMove(this, RemainingSticks);
        }

        private void CompMakesMove()
        {
            int maxNumber = RemainingSticks >= 3 ? 3 : RemainingSticks;
            int sticks = randomizer.Next(1, maxNumber);
            TakeSticks(sticks);

            if (MachinePlayer != null)
            {
                MachinePlayer(sticks);
            }
        }

        private void TakeSticks(int sticks)
        {
            RemainingSticks -= sticks;
        }
    }
}

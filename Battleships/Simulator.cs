using Battleships.Constants;
using Battleships.Interfaces;

namespace Battleships
{
    public class Simulator : ISimulator
    {
        private readonly IBoard _board;
        private readonly IPlayer _player;
        public Simulator(IBoard board, IPlayer player)
        {
            _board = board;
            _player = player;
        }

        public void Run()
        {
            _player.CreateWarships();
            _player.PlaceWarshipsToBoard(_board);
            while(_player.ShipsRemaining > 0)
            {
                var result = AttackWarships(_board, _player);
                Console.WriteLine($"{result}!");
            }
            Console.WriteLine($"All ships sunk. {AttackResult.GameOver}!");
        }

        private static AttackResult AttackWarships(IBoard board, IPlayer player)
        {
            var random = new Random();
            var validTargetTiles = board.BoardTiles.Count;
            var index = random.Next(0, validTargetTiles);
            var coordinate = board.BoardTiles.ElementAt(index);
            var attackResult = player.ReportAttack(board, coordinate);
            //attack tile only once
            board.BoardTiles.RemoveAt(index);

            return attackResult;
        }
    }
}

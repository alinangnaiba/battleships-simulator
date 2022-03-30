using Battleships.Constants;
using Battleships.Interfaces;
using Battleships.Models;

namespace Battleships
{
    public class Player : IPlayer
    {
        public Player()
        {
            Warships = new List<Warship>();
        }

        public int ShipsRemaining { get; set; }
        public List<Warship> Warships { get; set; }

        public void PlaceWarshipsToBoard(IBoard board)
        {
            var random = new Random();
            foreach (var warship in Warships)
            {
                var randomNum = random.Next(1, 10);
                warship.Alignment = randomNum % 2 == 0 ? Alignment.Vertical : Alignment.Horizontal;
                if (!TryAddWarshipToBoard(board, warship))
                    throw new Exception("Adding ships to board failed.");
            }
        }

        public void CreateWarships()
        {
            var factory = new WarshipFactory();
            foreach (ShipType type in Enum.GetValues(typeof(ShipType)))
            {
                var ship = factory.Create(type);
                Warships.Add(ship);
            }
            Warships = Warships.OrderByDescending(x => x.Size).ToList();
            ShipsRemaining = Warships.Count;
        }

        public AttackResult ReportAttack(IBoard board, Coordinate attackCoordinate)
        {
            if (board.WarshipPosition.ContainsKey(attackCoordinate))
            {
                var warshipType = board.WarshipPosition[attackCoordinate];
                var targetShip = Warships.FirstOrDefault(x => x.Type == warshipType);
                if (targetShip is null) return AttackResult.Miss;
                targetShip.Hit();
                if (targetShip.Status == ShipStatus.Sunk)
                {
                    ShipsRemaining -= 1;
                }
                return AttackResult.Hit;
            }
            return AttackResult.Miss;
        }

        private bool TryAddWarshipToBoard(IBoard board, Warship warship)
        {
            var startCoordinate = GetStartCoordinate(warship);
            while (!board.IsValidPosition(startCoordinate, warship))
            {
                startCoordinate = GetStartCoordinate(warship);
            }
            warship.Location = GetLocation(warship, startCoordinate);
            var success = board.TryAddWarship(warship);
            return success;
        }

        private Coordinate GetStartCoordinate(Warship warship)
        {
            var random = new Random();
            var col = random.Next(0, 9);
            var row = random.Next(0, 9);
            while (row + warship.Size > Constant.MaxBoardSize)
            {
                row = random.Next(0, 9);
            }
            var startCoordinate = new Coordinate(row, col);
            return startCoordinate;
        }

        private static Location GetLocation(Warship warship, Coordinate startCoordinate)
        {
            var coordinates = new List<Coordinate>();
            coordinates.Add(startCoordinate);
            for(int i = 1; i <= warship.Size - 1; i++)
            {
                var newCoordinate = warship.Alignment == Alignment.Horizontal ? 
                    new Coordinate(startCoordinate.X + i, startCoordinate.Y) : new Coordinate(startCoordinate.X, startCoordinate.Y + i);
                coordinates.Add(newCoordinate);
            }
            return new Location(coordinates);
        }
    }
}

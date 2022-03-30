using Battleships.Constants;
using Battleships.Interfaces;
using Battleships.Models;

namespace Battleships
{
    public class Board : IBoard
    {
        private readonly List<Coordinate> _tiles;
        private readonly Dictionary<Coordinate, string> _warshipPosition;
        
        public Board()
        {
            _tiles = new List<Coordinate>();
            _warshipPosition = new Dictionary<Coordinate, string>();
            GenerateBoard();
        }

        public List<Coordinate> BoardTiles => _tiles;
        public Dictionary<Coordinate, string> WarshipPosition => _warshipPosition;

        public bool TryAddWarship(Warship warship)
        {
            try
            {
                foreach (var coordinate in warship.Location.Coordinates)
                {
                    _warshipPosition.Add(coordinate, warship.Type);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool IsValidPosition(Coordinate coordinate, Warship warship)
        {
            if (!ValidateCoordinate(coordinate))
                return false;
            if (warship.Alignment == Alignment.Horizontal)
            {
                if (coordinate.X + warship.Size - 1 > Constant.MaxBoardSize - 1)
                    return false;
                for (int i = 1; i <= warship.Size - 1; i++)
                {
                    var newCoordinate = new Coordinate(coordinate.X + i, coordinate.Y);
                    if (ValidateCoordinate(newCoordinate))
                        continue;
                    return false;
                }
            }
            else
            {
                if (coordinate.Y + warship.Size - 1 > Constant.MaxBoardSize - 1)
                    return false;
                for (int i = 1; i <= warship.Size - 1; i++)
                {
                    var newCoordinate = new Coordinate(coordinate.X, coordinate.Y + i);
                    if (ValidateCoordinate(newCoordinate))
                        continue;
                    return false;
                }
            }
            return true;
        }

        private bool ValidateCoordinate(Coordinate coordinate)
        {
            return !_warshipPosition.ContainsKey(coordinate);
        }

        private void GenerateBoard()
        {
            for(int i = 0; i < Constant.MaxBoardSize; i++)
            {
                for(int j = 0; j < Constant.MaxBoardSize; j++)
                {
                    //Adding coordinates that are valid for attack
                    _tiles.Add(new Coordinate(i, j));
                }
            }
        }
    }
}

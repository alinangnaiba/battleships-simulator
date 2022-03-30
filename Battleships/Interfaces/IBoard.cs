using Battleships.Models;

namespace Battleships.Interfaces
{
    public interface IBoard
    {
        List<Coordinate> BoardTiles { get; }
        Dictionary<Coordinate, string> WarshipPosition { get; }
        bool TryAddWarship(Warship warship);
        bool IsValidPosition(Coordinate coordinate, Warship warship);
    }
}

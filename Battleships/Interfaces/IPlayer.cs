using Battleships.Constants;
using Battleships.Models;

namespace Battleships.Interfaces
{
    public interface IPlayer
    {
        int ShipsRemaining { get; set; }
        List<Warship> Warships { get; set; }
        void CreateWarships();
        void PlaceWarshipsToBoard(IBoard board);
        AttackResult ReportAttack(IBoard board, Coordinate attackCoordinate);
    }
}

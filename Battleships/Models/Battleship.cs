using Battleships.Constants;

namespace Battleships.Models
{
    public class Battleship : Warship
    {
        public Battleship()
            : base(nameof(ShipType.Battleship), MaxLife.Battleship)
        {
        }
    }
}

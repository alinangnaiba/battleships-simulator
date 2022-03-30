using Battleships.Constants;

namespace Battleships.Models
{
    public class Submarine : Warship
    {
        public Submarine()
            : base(nameof(ShipType.Submarine), MaxLife.Submarine)
        {
        }
    }
}

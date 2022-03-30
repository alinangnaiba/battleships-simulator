using Battleships.Constants;

namespace Battleships.Models
{
    public class PatrolBoat : Warship
    {
        public PatrolBoat()
            : base(nameof(ShipType.PatrolBoat), MaxLife.PatrolBoat)
        {
        }
    }
}

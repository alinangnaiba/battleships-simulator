using Battleships.Constants;

namespace Battleships.Models
{
    public class Destroyer : Warship
    {
        public Destroyer()
            :base(nameof(ShipType.Destroyer), MaxLife.Destroyer)
        {
        }
    }
}

using Battleships.Constants;

namespace Battleships.Models
{
    public class Carrier : Warship
    {
        public Carrier() 
            : base(nameof(ShipType.Carrier), MaxLife.Carrier)
        {
        }
    }
}

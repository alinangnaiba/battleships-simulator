using Battleships.Constants;
using Battleships.Interfaces;
using Battleships.Models;

namespace Battleships
{
    public class WarshipFactory : IWarshipFactory
    {
        private static readonly Dictionary<string, Warship> _factory = new()
        {
            { nameof(ShipType.Carrier), new Carrier() },
            { nameof(ShipType.Battleship), new Battleship() },
            { nameof(ShipType.Destroyer), new Destroyer() },
            { nameof(ShipType.Submarine), new Submarine() },
            { nameof(ShipType.PatrolBoat), new PatrolBoat() }
        };

        public Warship Create(ShipType type)
        {
            
            if (!_factory.TryGetValue($"{ type}", out Warship warship))
            {
                throw new ArgumentException($"Failed creating warship. No ship for type: {type}");
            }
            return warship;
        }
    }
}

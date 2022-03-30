using Battleships.Constants;
using Battleships.Models;

namespace Battleships.Interfaces
{
    public interface IWarshipFactory
    {
        Warship Create(ShipType type);
    }
}

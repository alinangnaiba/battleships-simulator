using Battleships.Constants;

namespace Battleships.Models
{
    public abstract class Warship
    {
        private int _remainingLife;
        public Warship(string type, int size)
        {
            Type = type;
            Size = size;
            _remainingLife = size;
        }

        public Alignment Alignment { get; set; }
        public int Size {get; }
        public string Type { get; }
        public Location Location { get; set; }

        public ShipStatus Status => GetStatus();

        public void Hit()
        {
            _remainingLife--;
        }
        private ShipStatus GetStatus() => _remainingLife > 0 ? ShipStatus.Floating : ShipStatus.Sunk;

    }
}

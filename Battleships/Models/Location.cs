namespace Battleships.Models
{
    public class Location
    {
        public Location(IEnumerable<Coordinate> coordinates)
        {
            Coordinates = coordinates;
        }

        public IEnumerable<Coordinate> Coordinates { get; }
    }
}

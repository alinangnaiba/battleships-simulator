using Battleships;
using Battleships.Constants;
using Battleships.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace BattleshipTests
{
    public class BoardTests
    {
        [Test]
        public void AddingWarshipToBoard_ShouldReturnTrue()
        {
            var board = new Board();
            var warship = new Carrier();
            var coordinates = new List<Coordinate>();
            
            for (var i = 0; i < warship.Size; i++)
            {
                var coordinate = new Coordinate(5, i);
                coordinates.Add(coordinate);
            }
            var location = new Location(coordinates);
            warship.Location = location;

            var result = board.TryAddWarship(warship);

            Assert.True(result);
        }

        [Test]
        public void AddingWarshipToBoard_ThrowsAndCatchException_ShouldReturnFalse()
        {
            var warship = new Carrier();
            var board = new Board();

            var result = board.TryAddWarship(warship);

            Assert.IsFalse(result);
        }

        [Test]
        public void AddingWarship_ShouldAddCoordinatesToWarshipPosition()
        {
            var board = new Board();
            var warship = new Carrier();
            var coordinates = new List<Coordinate>();

            for (var i = 0; i < warship.Size; i++)
            {
                var coordinate = new Coordinate(5, i);
                coordinates.Add(coordinate);
            }
            var location = new Location(coordinates);
            warship.Location = location;

            board.TryAddWarship(warship);
            
            Assert.IsTrue(board.WarshipPosition.Count > 0);
        }

        [Test]
        public void CreatingInstanceOfBoard_ShouldGenerate100Tiles()
        {
            var board = new Board();

            var tileCount = board.BoardTiles.Count;

            Assert.AreEqual(100, tileCount);
        }

        [Test]
        public void IsValidPosition_ShouldReturnTrue_WhenShipPositionDoesNotOverlap()
        {
            var board = new Board();
            var battleship = new Battleship();
            var battleshipCoordinate = new Coordinate(4, 6);
            var battleshipCoordinates = new List<Coordinate>();
            battleshipCoordinates.Add(battleshipCoordinate);
            for (var i = 1; i <= battleship.Size - 1; i++)
            {
                var newCoordinate = new Coordinate(battleshipCoordinate.X + i, battleshipCoordinate.Y);
                battleshipCoordinates.Add(newCoordinate);
            }
            battleship.Alignment = Alignment.Horizontal;
            battleship.Location = new Location(battleshipCoordinates);
            board.TryAddWarship(battleship);
            var destroyer = new Destroyer();
            var destroyerCoordinate = new Coordinate(6, 3);
            destroyer.Alignment = Alignment.Vertical;

            var result = board.IsValidPosition(destroyerCoordinate, destroyer);

            Assert.IsTrue(result);
        }
        [Test]
        public void IsValidPosition_ShouldReturnFalse_WhenShipPositionOverlaps()
        {
            var board = new Board();
            var battleship = new Battleship();
            var battleshipCoordinate = new Coordinate(4, 6);
            var battleshipCoordinates = new List<Coordinate>();
            battleshipCoordinates.Add(battleshipCoordinate);
            for(var i = 1; i <= battleship.Size - 1; i++)
            {
                var newCoordinate = new Coordinate(battleshipCoordinate.X + i, battleshipCoordinate.Y);
                battleshipCoordinates.Add(newCoordinate);
            }
            battleship.Alignment = Alignment.Horizontal;
            battleship.Location = new Location(battleshipCoordinates);
            board.TryAddWarship(battleship);
            var destroyer = new Destroyer();
            var destroyerCoordinate = new Coordinate(5, 5);
            destroyer.Alignment = Alignment.Vertical;

            var result = board.IsValidPosition(destroyerCoordinate, destroyer);

            Assert.IsFalse(result);
        }
    }
}
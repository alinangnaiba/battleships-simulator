using Battleships;
using Battleships.Constants;
using Battleships.Interfaces;
using Battleships.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BattleshipTests
{
    public class PlayerTest
    {
        [Test]
        public void CreateWarships_ShouldCreateFiveWarships()
        {
            var player = new Player();
            player.CreateWarships();

            var warshipsCount = player.Warships.Count;

            Assert.AreEqual(warshipsCount, 5);
        }

        [Test]
        public void CreateWarships_ShouldCreateFiveWarshipsWitLocationNull()
        {
            var player = new Player();
            player.CreateWarships();

            var count = player.Warships.Where(x => x.Location is null).ToList().Count;

            Assert.AreEqual(count, 5);
        }

        [Test]
        public void PlaceWarshipsToBoard_ShouldAddWarshipCoordinatesToBoard()
        {
            var board = new Board();
            var player = new Player();
            player.CreateWarships();
            player.PlaceWarshipsToBoard(board);
            

            Assert.IsTrue(board.WarshipPosition.Count > 0);
        }

        [Test]
        public void PlaceWarshipsToBoard_ShouldUpdateShipsLocation()
        {
            var board = new Board();
            var player = new Player();
            player.CreateWarships();
            player.PlaceWarshipsToBoard(board);

            var count = player.Warships.Where(x => x.Location is not null && x.Location.Coordinates.Any()).ToList().Count;

            Assert.AreEqual(count, 5);
        }

        [Test]
        public void ReportAttack_ShouldReportHit()
        {
            var warshipPosition = new Dictionary<Coordinate, string>
            {
                { new Coordinate(5,5), "Battleship" }
            };
            Mock<IBoard> mockBoard = new Mock<IBoard>(MockBehavior.Strict);
            mockBoard.SetupGet(x => x.WarshipPosition).Returns(warshipPosition);
            var player = new Player();
            player.CreateWarships();
            var attackCoordinate = new Coordinate(5,5);
            var result = player.ReportAttack(mockBoard.Object, attackCoordinate);

            Assert.AreEqual(result, AttackResult.Hit);
        }

        [Test]
        public void ReportAttack_ShouldReportMiss()
        {
            var warshipPosition = new Dictionary<Coordinate, string>
            {
                { new Coordinate(5,5), "Battleship" }
            };
            Mock<IBoard> mockBoard = new Mock<IBoard>(MockBehavior.Strict);
            mockBoard.SetupGet(x => x.WarshipPosition).Returns(warshipPosition);
            var player = new Player();
            player.CreateWarships();
            var attackCoordinate = new Coordinate(3, 5);
            var result = player.ReportAttack(mockBoard.Object, attackCoordinate);

            Assert.AreEqual(result, AttackResult.Miss);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPV.Utils;

namespace SPV.Tests
{

    [TestClass]
    public class GeoLocationTests
    {

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public void DistanceTo_VrneMedDvemaLokacijoma_Kilometers()
        {
            // Arrange
            var baseCoordinates = new Coordinates(46.418461, 15.874029);
            var targetCoordinates = new Coordinates(46.421550, 15.877491);
            var expectedDistance = 0.22;

            // Act
            var actualDistance = CoordinatesDistance.DistanceTo(baseCoordinates,targetCoordinates,UnitOfLength.Kilometers);

            // Assert
            Assert.AreEqual(expectedDistance, actualDistance, 0.1);
        }

        [TestMethod]
        public void DistanceTo_VrneMedDvemaLokacijoma_Miles()
        {
            // Arrange
            var baseCoordinates = new Coordinates(46.418461, 15.874029);
            var targetCoordinates = new Coordinates(46.421550, 15.877491);
            var expectedDistance = 0.16;

            // Act
            var actualDistance = baseCoordinates.DistanceTo(targetCoordinates, UnitOfLength.Miles);

            // Assert
            Assert.AreEqual(expectedDistance, actualDistance, 0.1);
        }
    }
}

using InverntOn.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InventOn.UnitTests
{
    [TestClass]
    public class ReservationTests
    {
        [TestMethod]
        public void CanBeCancelledBy_ClientIsNull_ReturnFalse()
        {
            Reservation reservation = new Reservation();

            bool result = reservation.CanBeCancelledBy(null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_ClientIsOwner_ReturnTrue()
        {
            Reservation reservation = new Reservation();
            Client client = new Client() {FirstName = "test1", LastName = "test2"};
            reservation.Owner = client;

            bool result = reservation.CanBeCancelledBy(client);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_ClientIsNotOwner_ReturnFalse()
        {
            Reservation reservation = new Reservation();
            Client client = new Client() { FirstName = "test1", LastName = "test2" };
            reservation.Owner = client;

            bool result = reservation.CanBeCancelledBy(new Client());

            Assert.IsFalse(result);
        }
    }
}

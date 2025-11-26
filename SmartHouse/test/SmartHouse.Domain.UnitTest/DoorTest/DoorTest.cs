using SmartHouse.Domain.Illumination;
using SmartHouse.Domain.Doors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.UnitTest.DoorTest
{
    public class DoorTest
    {
        [Fact]
        public void When_TheNameOfTheDoorIsEmpty_TheIsNotValid()
        {
            Assert.Throws<ArgumentException>(() => new Door(string.Empty));
        }

        [Fact]
        public void When_TheDoorIsClosed_CanOpenIt()
        {
            Door newDoor = new Door("Giovanni");

            newDoor.OpenDoor();

            Assert.Equal(DoorStatus.Open, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsOpen_CanCloseIt()
        {
            Door newDoor = new Door("Giovanni");

            newDoor.OpenDoor();
            newDoor.CloseDoor();

            Assert.Equal(DoorStatus.Closed, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsOpen_CannotLockIt()
        {
            Door newDoor = new Door("Giovanni");

            newDoor.OpenDoor();
            newDoor.LockDoor();

            Assert.Equal(DoorStatus.Open, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsClosed_CanLockIt()
        {
            Door newDoor = new Door("Giovanni");

            newDoor.LockDoor();

            Assert.Equal(DoorStatus.Locked, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsOpen_CannotUnlockIt()
        {
            Door newDoor = new Door("Giovanni");

            newDoor.OpenDoor();
            newDoor.UnlockDoor();

            Assert.Equal(DoorStatus.Open, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsLocked_CanUnlockIt()
        {
            Door newDoor = new Door("Giovanni");

            newDoor.LockDoor();
            newDoor.UnlockDoor();

            Assert.Equal(DoorStatus.Closed, newDoor.Status);
        }
    }
}

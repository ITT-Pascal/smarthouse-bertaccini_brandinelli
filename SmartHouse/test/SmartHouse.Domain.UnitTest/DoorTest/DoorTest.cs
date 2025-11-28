using SmartHouse.Domain.Doors;
using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.Illumination;
using SmartHouse.Domain.ThermostastDevice;
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

        public void When_GivenANullStringAsAName_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Door(null, 1234));
        }

        [Fact]
        public void When_TheNameOfTheDoorIsEmpty_TheNameIsNotValid()
        {
            Assert.Throws<ArgumentException>(() => new Door(string.Empty, 1234));
        }

        [Fact]

        public void When_GivenANameThatIsOnlySpaces_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Door("    ", 1234));
        }

        [Fact]
        public void When_ThePINOfTheDoorIsUnder4Digits_ThePINIsNotValid()
        {
            Assert.Throws<ArgumentException>(() => new Door("Giovanni", 00));
        }

        [Fact]
        public void When_TheDoorIsClosed_CanOpenIt()
        {
            Door newDoor = new Door("Giovanni", 1234);

            newDoor.OpenDoor();

            Assert.Equal(DoorStatus.Open, newDoor.DoorStatus);
            Assert.Equal(DeviceStatus.Unknown, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsLocked_CannotOpenIt()
        {
            Door newDoor = new Door("Giovanni", 1234);

            newDoor.LockDoor();

            Assert.Throws<ArgumentException>(() => newDoor.OpenDoor());
            Assert.Equal(DoorStatus.Locked, newDoor.DoorStatus);
            Assert.Equal(DeviceStatus.Unknown, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsOpen_CanCloseIt()
        {
            Door newDoor = new Door("Giovanni", 1234);

            newDoor.OpenDoor();
            newDoor.CloseDoor();

            Assert.Equal(DoorStatus.Closed, newDoor.DoorStatus);
            Assert.Equal(DeviceStatus.Unknown, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsOpen_CannotLockIt()
        {
            Door newDoor = new Door("Giovanni", 1234);

            newDoor.OpenDoor();

            Assert.Throws<ArgumentException>(() => newDoor.LockDoor());
            Assert.Equal(DoorStatus.Open, newDoor.DoorStatus);
            Assert.Equal(DeviceStatus.Unknown, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsClosed_CanLockIt()
        {
            Door newDoor = new Door("Giovanni", 1234);

            newDoor.LockDoor();

            Assert.Equal(DoorStatus.Locked, newDoor.DoorStatus);
            Assert.Equal(DeviceStatus.Unknown, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsOpen_CannotUnlockIt()
        {
            Door newDoor = new Door("Giovanni", 1234);

            newDoor.OpenDoor();

            Assert.Throws<ArgumentException>(() => newDoor.UnlockDoor(1234));
            Assert.Equal(DoorStatus.Open, newDoor.DoorStatus);
            Assert.Equal(DeviceStatus.Unknown, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsLockedAndThePINIsWrong_CannotUnlockIt()
        {
            Door newDoor = new Door("Giovanni", 1234);

            newDoor.LockDoor();

            Assert.Throws<ArgumentException>(() => newDoor.UnlockDoor(1230));
            Assert.Equal(DoorStatus.Locked, newDoor.DoorStatus);
            Assert.Equal(DeviceStatus.Unknown, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsLockedAndYhePINIsCorrect_CanUnlockIt()
        {
            Door newDoor = new Door("Giovanni", 1234);

            newDoor.LockDoor();
            newDoor.UnlockDoor(1234);

            Assert.Equal(DoorStatus.Closed, newDoor.DoorStatus);
            Assert.Equal(DeviceStatus.Unknown, newDoor.Status);
        }
    }
}

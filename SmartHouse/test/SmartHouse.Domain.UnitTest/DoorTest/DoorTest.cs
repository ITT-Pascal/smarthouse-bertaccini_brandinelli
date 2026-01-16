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

            newDoor.Unlock(1234);
            newDoor.Open();

            Assert.True(newDoor.IsOpen);
            Assert.Equal(DeviceStatus.Unknown, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsLocked_CannotOpenIt()
        {
            Door newDoor = new Door("Giovanni", 1234);

            newDoor.Unlock(1234);
            newDoor.Lock();

            Assert.Throws<ArgumentException>(() => newDoor.Open());
            Assert.False(newDoor.IsOpen);
            Assert.True(newDoor.IsLocked);
            Assert.Equal(DeviceStatus.Unknown, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsOpen_CanCloseIt()
        {
            Door newDoor = new Door("Giovanni", 1234);

            newDoor.Unlock(1234);
            newDoor.Open();
            newDoor.Close();

            Assert.False(newDoor.IsOpen);
            Assert.Equal(DeviceStatus.Unknown, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsOpen_CannotLockIt()
        {
            Door newDoor = new Door("Giovanni", 1234);

            newDoor.Unlock(1234);
            newDoor.Open();

            Assert.Throws<ArgumentException>(() => newDoor.Lock());
            Assert.True(newDoor.IsOpen);
            Assert.Equal(DeviceStatus.Unknown, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsClosed_CanLockIt()
        {
            Door newDoor = new Door("Giovanni", 1234);

            newDoor.Unlock(1234);
            newDoor.Lock();

            Assert.False(newDoor.IsOpen);
            Assert.True(newDoor.IsLocked);
            Assert.Equal(DeviceStatus.Unknown, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsOpen_CannotUnlockIt()
        {
            Door newDoor = new Door("Giovanni", 1234);

            newDoor.Unlock(1234);
            newDoor.Open();

            Assert.Throws<ArgumentException>(() => newDoor.Unlock(1234));
            Assert.True(newDoor.IsOpen);
            Assert.Equal(DeviceStatus.Unknown, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsLockedAndThePINIsWrong_CannotUnlockIt()
        {
            Door newDoor = new Door("Giovanni", 1234);

            Assert.Throws<ArgumentException>(() => newDoor.Unlock(1230));
            Assert.True(newDoor.IsLocked);
            Assert.Equal(DeviceStatus.Unknown, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsLockedAndThePINIsCorrect_CanUnlockIt()
        {
            Door newDoor = new Door("Giovanni", 1234);

            newDoor.Unlock(1234);

            Assert.False(newDoor.IsOpen);
            Assert.Equal(DeviceStatus.Unknown, newDoor.Status);
        }
    }
}

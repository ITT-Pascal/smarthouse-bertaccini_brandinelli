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
        private Pin PIN = new Pin(1234);
        private Pin PIN2 = new Pin(00);
        private Pin PIN3 = new Pin(1230);

        [Fact]

        public void When_GivenANullStringAsAName_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Door(null, PIN));
        }

        [Fact]
        public void When_TheNameOfTheDoorIsEmpty_TheNameIsNotValid()
        {
            Assert.Throws<ArgumentException>(() => new Door(string.Empty, PIN));
        }

        [Fact]

        public void When_GivenANameThatIsOnlySpaces_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Door("    ", PIN));
        }

        [Fact]
        public void When_ThePINOfTheDoorIsUnder4Digits_ThePINIsNotValid()
        {
            Assert.Throws<ArgumentException>(() => new Door("Giovanni", PIN2));
        }

        [Fact]
        public void When_TheDoorIsClosed_CanOpenIt()
        {
            Door newDoor = new Door("Giovanni", PIN);

            newDoor.Unlock(PIN);
            newDoor.Open();

            Assert.True(newDoor.IsOpen);
            Assert.Equal(DeviceStatus.Unknown, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsLocked_CannotOpenIt()
        {
            Door newDoor = new Door("Giovanni", PIN);

            newDoor.Unlock(PIN);
            newDoor.Lock();

            Assert.Throws<ArgumentException>(() => newDoor.Open());
            Assert.False(newDoor.IsOpen);
            Assert.True(newDoor.IsLocked);
            Assert.Equal(DeviceStatus.Unknown, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsOpen_CanCloseIt()
        {
            Door newDoor = new Door("Giovanni", PIN);

            newDoor.Unlock(PIN);
            newDoor.Open();
            newDoor.Close();

            Assert.False(newDoor.IsOpen);
            Assert.Equal(DeviceStatus.Unknown, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsOpen_CannotLockIt()
        {
            Door newDoor = new Door("Giovanni", PIN);

            newDoor.Unlock(PIN);
            newDoor.Open();

            Assert.Throws<ArgumentException>(() => newDoor.Lock());
            Assert.True(newDoor.IsOpen);
            Assert.Equal(DeviceStatus.Unknown, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsClosed_CanLockIt()
        {
            Door newDoor = new Door("Giovanni", PIN);

            newDoor.Unlock(PIN);
            newDoor.Lock();

            Assert.False(newDoor.IsOpen);
            Assert.True(newDoor.IsLocked);
            Assert.Equal(DeviceStatus.Unknown, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsOpen_CannotUnlockIt()
        {
            Door newDoor = new Door("Giovanni", PIN);

            newDoor.Unlock(PIN);
            newDoor.Open();

            Assert.Throws<ArgumentException>(() => newDoor.Unlock(PIN));
            Assert.True(newDoor.IsOpen);
            Assert.Equal(DeviceStatus.Unknown, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsLockedAndThePINIsWrong_CannotUnlockIt()
        {
            Door newDoor = new Door("Giovanni", PIN);

            Assert.Throws<ArgumentException>(() => newDoor.Unlock(PIN3));
            Assert.True(newDoor.IsLocked);
            Assert.Equal(DeviceStatus.Unknown, newDoor.Status);
        }

        [Fact]
        public void When_TheDoorIsLockedAndThePINIsCorrect_CanUnlockIt()
        {
            Door newDoor = new Door("Giovanni", PIN);

            newDoor.Unlock(PIN);

            Assert.False(newDoor.IsOpen);
            Assert.Equal(DeviceStatus.Unknown, newDoor.Status);
        }
    }
}

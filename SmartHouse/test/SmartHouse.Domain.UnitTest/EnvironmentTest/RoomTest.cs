using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.CCTVDevice;
using SmartHouse.Domain.Doors;
using SmartHouse.Domain.Environment;
using SmartHouse.Domain.Illumination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.UnitTest.EnvironmentTest
{
    public class RoomTest
    {
        [Fact]
        public void When_WantToAddANewDeviceIntoTheRoom_CanDoIt()
        {
            Room newRoom = new Room("Totti");
            CCTV CCTV = new CCTV("Salvatore");

            newRoom.AddDevice(CCTV);

            Assert.Equal(CCTV, newRoom.Devices[0]);
            Assert.Equal(1, newRoom.Devices.Count);
        }

        [Fact]
        public void When_WantToAddANewDeviceIntoTheRoomButItIsNull_CannotDoIt()
        {
            Room newRoom = new Room("Totti");

            Assert.Throws<ArgumentException>(() => newRoom.AddDevice(null));
            Assert.Equal(0, newRoom.Devices.Count);
        }

        [Fact]
        public void When_WantToAddNewDeviceInADeterminedPosition_CanDoIt()
        {
            Room newRoom = new Room("Totti");
            CCTV CCTV = new CCTV("Salvatore");
            Door Door = new Door("Giovanni", 1234);

            newRoom.AddDevice(CCTV);
            newRoom.AddDevice(Door);
            newRoom.AddDeviceInPosition(CCTV, 1);

            Assert.Equal(CCTV, newRoom.Devices[1]);
        }

        [Fact]
        public void When_WantToRemoveADeviceIntoTheRoom_CanDoIt()
        {
            Room newRoom = new Room("Totti");
            CCTV CCTV = new CCTV("Salvatore");

            newRoom.AddDevice(CCTV);
            newRoom.RemoveDevice(CCTV);

            Assert.Equal(0, newRoom.Devices.Count);
        }

        [Fact]
        public void When_WantToRemoveADeviceIntoTheRoomButItIsNull_CannotDoIt()
        {
            Room newRoom = new Room("Totti");
            
            Assert.Throws<ArgumentException>(() => newRoom.RemoveDevice((AbstractDevice)null));
            Assert.Equal(0, newRoom.Devices.Count);
        }

        [Fact]
        public void When_WantToRemoveADeviceIntoTheRoomWithItsName_CanDoIt()
        {
            Room newRoom = new Room("Totti");
            CCTV CCTV = new CCTV("Salvatore");

            newRoom.AddDevice(CCTV);
            newRoom.RemoveDevice(CCTV.Name);

            Assert.Equal(0, newRoom.Devices.Count);
        }

        [Fact]
        public void When_WantToRemoveADeviceIntoTheRoomWithItsId_CanDoIt()
        {
            Room newRoom = new Room("Totti");
            CCTV CCTV = new CCTV("Salvatore");

            newRoom.AddDevice(CCTV);
            newRoom.RemoveDevice(CCTV.Id);

            Assert.Equal(0, newRoom.Devices.Count);
        }

        [Fact]
        public void When_WantToRemoveADeviceIntoTheRoomWithItsPosition_CanDoIt()
        {
            Room newRoom = new Room("Totti");
            CCTV CCTV = new CCTV("Salvatore");

            newRoom.AddDevice(CCTV);
            newRoom.RemoveDeviceInPosition(0);

            Assert.Equal(0, newRoom.Devices.Count);
        }

        [Fact]
        public void When_WantToTurnOnASpecificDevice_CanDoIt()
        {
            Room newRoom = new Room("Totti");
            CCTV CCTV = new CCTV("Salvatore");

            newRoom.AddDevice(CCTV);
            newRoom.SwitchOn(CCTV);

            Assert.Equal(DeviceStatus.On, newRoom.Devices[0].Status);
        }

        [Fact]
        public void When_WantToTurnOnASpecificDevices_CanDoIt()
        {
            Room newRoom = new Room("Totti");
            CCTV CCTV = new CCTV("Salvatore");
            Lamp Lamp = new Lamp("Stefano");

            newRoom.AddDevice(CCTV);
            newRoom.AddDevice(Lamp);
            newRoom.AddDevice(CCTV);
            newRoom.SwitchOn(CCTV);

            Assert.Equal(DeviceStatus.On, newRoom.Devices[0].Status);
            Assert.Equal(DeviceStatus.Off, newRoom.Devices[1].Status);
            Assert.Equal(DeviceStatus.On, newRoom.Devices[2].Status);
        }

        [Fact]
        public void When_WantToTurnOnASpecificDeviceWithItsName_CanDoIt()
        {
            Room newRoom = new Room("Totti");
            CCTV CCTV = new CCTV("Salvatore");

            newRoom.AddDevice(CCTV);
            newRoom.SwitchOn(CCTV.Name);

            Assert.Equal(DeviceStatus.On, newRoom.Devices[0].Status);
        }

        [Fact]
        public void When_WantToTurnOnASpecificDevicesWithItsName_CanDoIt()
        {
            Room newRoom = new Room("Totti");
            CCTV CCTV = new CCTV("Salvatore");
            Lamp Lamp = new Lamp("Stefano");

            newRoom.AddDevice(CCTV);
            newRoom.AddDevice(Lamp);
            newRoom.AddDevice(CCTV);
            newRoom.SwitchOn(CCTV.Name);

            Assert.Equal(DeviceStatus.On, newRoom.Devices[0].Status);
            Assert.Equal(DeviceStatus.Off, newRoom.Devices[1].Status);
            Assert.Equal(DeviceStatus.On, newRoom.Devices[2].Status);
        }

        [Fact]
        public void When_WantToTurnOnASpecificDeviceWithItsId_CanDoIt()
        {
            Room newRoom = new Room("Totti");
            CCTV CCTV = new CCTV("Salvatore");

            newRoom.AddDevice(CCTV);
            newRoom.SwitchOn(CCTV.Id);

            Assert.Equal(DeviceStatus.On, newRoom.Devices[0].Status);
        }

        [Fact]
        public void When_WantToTurnOnASpecificDevicesWithItsId_CanDoIt()
        {
            Room newRoom = new Room("Totti");
            CCTV CCTV = new CCTV("Salvatore");
            Lamp Lamp = new Lamp("Stefano");

            newRoom.AddDevice(CCTV);
            newRoom.AddDevice(Lamp);
            newRoom.AddDevice(CCTV);
            newRoom.SwitchOn(CCTV.Id);

            Assert.Equal(DeviceStatus.On, newRoom.Devices[0].Status);
            Assert.Equal(DeviceStatus.Off, newRoom.Devices[1].Status);
            Assert.Equal(DeviceStatus.On, newRoom.Devices[2].Status);
        }

        [Fact]
        public void When_WantToTurnOffASpecificDevice_CanDoIt()
        {
            Room newRoom = new Room("Totti");
            CCTV CCTV = new CCTV("Salvatore");

            newRoom.AddDevice(CCTV);
            newRoom.SwitchOn(CCTV);
            newRoom.SwitchOff(CCTV);

            Assert.Equal(DeviceStatus.Off, newRoom.Devices[0].Status);
        }

        [Fact]
        public void When_WantToTurnOffASpecificDevices_CanDoIt()
        {
            Room newRoom = new Room("Totti");
            CCTV CCTV = new CCTV("Salvatore");
            Lamp Lamp = new Lamp("Stefano");

            newRoom.AddDevice(CCTV);
            newRoom.AddDevice(Lamp);
            newRoom.AddDevice(CCTV);
            newRoom.SwitchOn(CCTV);
            newRoom.SwitchOff(CCTV);

            Assert.Equal(DeviceStatus.Off, newRoom.Devices[0].Status);
            Assert.Equal(DeviceStatus.Off, newRoom.Devices[1].Status);
            Assert.Equal(DeviceStatus.Off, newRoom.Devices[2].Status);
        }

        [Fact]
        public void When_WantToTurnOffASpecificDeviceWithItsName_CanDoIt()
        {
            Room newRoom = new Room("Totti");
            CCTV CCTV = new CCTV("Salvatore");

            newRoom.AddDevice(CCTV);
            newRoom.SwitchOn(CCTV.Name);
            newRoom.SwitchOff(CCTV.Name);

            Assert.Equal(DeviceStatus.Off, newRoom.Devices[0].Status);
        }

        [Fact]
        public void When_WantToTurnOffASpecificDevicesWithItsName_CanDoIt()
        {
            Room newRoom = new Room("Totti");
            CCTV CCTV = new CCTV("Salvatore");
            Lamp Lamp = new Lamp("Stefano");

            newRoom.AddDevice(CCTV);
            newRoom.AddDevice(Lamp);
            newRoom.AddDevice(CCTV);
            newRoom.SwitchOn(CCTV.Name);
            newRoom.SwitchOff(CCTV.Name);

            Assert.Equal(DeviceStatus.Off, newRoom.Devices[0].Status);
            Assert.Equal(DeviceStatus.Off, newRoom.Devices[1].Status);
            Assert.Equal(DeviceStatus.Off, newRoom.Devices[2].Status);
        }

        [Fact]
        public void When_WantToTurnOffASpecificDeviceWithItsId_CanDoIt()
        {
            Room newRoom = new Room("Totti");
            CCTV CCTV = new CCTV("Salvatore");

            newRoom.AddDevice(CCTV);
            newRoom.SwitchOn(CCTV.Id);
            newRoom.SwitchOff(CCTV.Id);

            Assert.Equal(DeviceStatus.Off, newRoom.Devices[0].Status);
        }

        [Fact]
        public void When_WantToTurnOffASpecificDevicesWithItsId_CanDoIt()
        {
            Room newRoom = new Room("Totti");
            CCTV CCTV = new CCTV("Salvatore");
            Lamp Lamp = new Lamp("Stefano");

            newRoom.AddDevice(CCTV);
            newRoom.AddDevice(Lamp);
            newRoom.AddDevice(CCTV);
            newRoom.SwitchOn(CCTV.Id);
            newRoom.SwitchOff(CCTV.Id);

            Assert.Equal(DeviceStatus.Off, newRoom.Devices[0].Status);
            Assert.Equal(DeviceStatus.Off, newRoom.Devices[1].Status);
            Assert.Equal(DeviceStatus.Off, newRoom.Devices[2].Status);
        }

        [Fact]
        public void When_WantToTurnAllDevicesOff_CanDoIt()
        {
            Room newRoom = new Room("Totti");
            CCTV CCTV = new CCTV("Salvatore");
            Lamp Lamp = new Lamp("Stefano");

            newRoom.AddDevice(CCTV);
            newRoom.AddDevice(Lamp);
            newRoom.AddDevice(CCTV);
            newRoom.AllSwitchOn();

            Assert.Equal(DeviceStatus.On, newRoom.Devices[0].Status);
            Assert.Equal(DeviceStatus.On, newRoom.Devices[1].Status);
            Assert.Equal(DeviceStatus.On, newRoom.Devices[2].Status);
        }

        [Fact]
        public void When_WantToTurnAllDevicesOn_CanDoIt()
        {
            Room newRoom = new Room("Totti");
            CCTV CCTV = new CCTV("Salvatore");
            Lamp Lamp = new Lamp("Stefano");

            newRoom.AddDevice(CCTV);
            newRoom.AddDevice(Lamp);
            newRoom.AddDevice(CCTV);
            newRoom.AllSwitchOn();
            newRoom.AllSwitchOff();

            Assert.Equal(DeviceStatus.Off, newRoom.Devices[0].Status);
            Assert.Equal(DeviceStatus.Off, newRoom.Devices[1].Status);
            Assert.Equal(DeviceStatus.Off, newRoom.Devices[2].Status);
        }
    }
}

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

namespace SmartHouse.Domain.UnitTest
{
    public class RoomTest
    {
        [Fact]
        public void When_WantToAddANewDeviceIntoTheRoom_CanDoIt()
        {
            Room newRoom = new Room("Totti");
            CCTV CCTV = new CCTV("Salvatore");

            newRoom.AddDevice(CCTV);

            Assert.Equal(CCTV, newRoom.Devices.ToArray()[0]);
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
        public void When_WantToTurnOffASpecificDevicesWithThisId_CanDoIt()
        {
            Room newRoom = new Room("Totti");
            CCTV CCTV = new CCTV("Salvatore");
            CCTV CCTV1 = new CCTV("Salvatore");
            Lamp Lamp = new Lamp("Stefano");

            newRoom.AddDevice(CCTV);
            newRoom.AddDevice(Lamp);
            newRoom.AddDevice(CCTV1);
            newRoom.SwitchOn(CCTV);
            newRoom.SwitchOff(CCTV);

            Assert.Equal(DeviceStatus.Off, newRoom.Devices[0].Status);
            Assert.Equal(DeviceStatus.Off, newRoom.Devices[1].Status);
            Assert.Equal(DeviceStatus.Off, newRoom.Devices[2].Status);
        }
    }
}

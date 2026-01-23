using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.CCTVDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.UnitTest.CCTVTest
{
    public class CCTVTest
    {
        public Pin PIN = Pin.Create(1234);

        [Fact]
        public void When_TheNameOfCCTVIsEmpty_TheNameIsNotValid()
        {
            Assert.Throws<ArgumentException>(() => new CCTV(string.Empty));
        }

        [Fact]
        public void When_WantToSetDefaultVisionButItHasAlreadyBeenSet_CannotSetDefaultVision()
        {
            CCTV newCCTV = new CCTV("Salvatore");

            Assert.Throws<ArgumentException>(() => newCCTV.SetVision(CCTVVisionType.DefaultVision));
        }

        [Fact]
        public void When_WantToSetDefaultVisionAndItIsAlreadySetToNightVision_CanSetDefaultVision()
        {
            CCTV newCCTV = new CCTV("Salvatore");

            newCCTV.SetVision(CCTVVisionType.NightVision);
            newCCTV.SetVision(CCTVVisionType.DefaultVision);

            Assert.Equal(CCTVVisionType.DefaultVision, newCCTV.VisionType);

        }

        [Fact]
        public void When_WantToSetNightVisionButItHasAlreadyBeenSet_CannotSetNightVision()
        {
            CCTV newCCTV = new CCTV("Salvatore");

            newCCTV.SetVision(CCTVVisionType.NightVision);

            Assert.Throws<ArgumentException>(() => newCCTV.SetVision(CCTVVisionType.NightVision));
        }

        [Fact]
        public void When_WantToSetNightVisionAndItIsAlreadySetToDefaultVision_CanSetNightVision()
        {
            CCTV newCCTV = new CCTV("Salvatore");

            newCCTV.SetVision(CCTVVisionType.NightVision);

            Assert.Equal(CCTVVisionType.NightVision, newCCTV.VisionType);

        }

        [Fact]
        public void When_WantToSetThermalVisionButItHasAlreadyBeenSet_CannotSetThermalVision()
        {
            CCTV newCCTV = new CCTV("Salvatore");

            newCCTV.SetVision(CCTVVisionType.ThermalVision);

            Assert.Throws<ArgumentException>(() => newCCTV.SetVision(CCTVVisionType.ThermalVision));
        }

        [Fact]
        public void When_WantToSetThermalVisionAndItIsAlreadySetToDefaultVision_CanSetThermalVision()
        {
            CCTV newCCTV = new CCTV("Salvatore");

            newCCTV.SetVision(CCTVVisionType.ThermalVision);

            Assert.Equal(CCTVVisionType.ThermalVision, newCCTV.VisionType);

        }

        [Fact]
        public void When_WantToSetDefaultZoomButItHasAlreadyBeenSet_CannotSetDefaultZoom()
        {
            CCTV newCCTV = new CCTV("Salvatore");

            Assert.Throws<ArgumentException>(() => newCCTV.SetDefaultZoom());
        }

        [Fact]
        public void When_WantToSetDefaultZoomAndItIsAlreadySetToMaxZoom_CanSetDefaultZoom()
        {
            CCTV newCCTV = new CCTV("Salvatore");

            newCCTV.SetMaxZoom();
            newCCTV.SetDefaultZoom();

            Assert.Equal(Zoom.Create(1.0), newCCTV.Zoom);

        }

        [Fact]
        public void When_WantToSetMinZoomButItHasAlreadyBeenSet_CannotSetMinZoom()
        {
            CCTV newCCTV = new CCTV("Salvatore");

            newCCTV.SetMinZoom();

            Assert.Throws<ArgumentException>(() => newCCTV.SetMinZoom());
        }

        [Fact]
        public void When_WantToSetMinZoomAndItIsAlreadySetToDefaultZoom_CanSetMinZoom()
        {
            CCTV newCCTV = new CCTV("Salvatore");

            newCCTV.SetMinZoom();

            Assert.Equal(Zoom.Create(0.5), newCCTV.Zoom);

        }

        [Fact]
        public void When_WantToSetMaxZoomButItHasAlreadyBeenSet_CannotSetMaxZoom()
        {
            CCTV newCCTV = new CCTV("Salvatore");

            newCCTV.SetMaxZoom();

            Assert.Throws<ArgumentException>(() => newCCTV.SetMaxZoom());
        }

        [Fact]
        public void When_WantToSetMaxZoomAndItIsAlreadySetToDefaultZoom_CanSetMaxZoom()
        {
            CCTV newCCTV = new CCTV("Salvatore");

            newCCTV.SetMaxZoom();

            Assert.Equal(Zoom.Create(10.0), newCCTV.Zoom);
        }

        [Fact]
        public void When_WantToIncreaseZoom_CanDoIt()
        {
            CCTV newCCTV = new CCTV("Salvatore");

            newCCTV.IncreaseZoom();

            Assert.Equal(Zoom.Create(1.1), newCCTV.Zoom);
        }

        [Fact]
        public void When_WantToDecreaseZoom_CanDoIt()
        {
            CCTV newCCTV = new CCTV("Salvatore");

            newCCTV.DecreaseZoom();

            Assert.Equal(Zoom.Create(0.9), newCCTV.Zoom);
        }

        [Fact]
        public void When_TheNameOfCCTVPINIsEmpty_TheNameIsNotValid()
        {
            Assert.Throws<ArgumentException>(() => new CCTV(string.Empty, 1234));
        }

        [Fact]
        public void When_WantToSetDefaultVisionAndCCTVIsUnlockedButItHasAlreadyBeenSet_CannotSetDefaultVision()
        {
            CCTV newCCTV = new CCTV("Salvatore", 1234);

            newCCTV.Unlock(PIN);

            Assert.Throws<ArgumentException>(() => newCCTV.SetVision(CCTVVisionType.DefaultVision));
        }

        [Fact]
        public void When_WantToSetDefaultVisionAndCCTVIsUnlockedAndItIsAlreadySetToNightVision_CanSetDefaultVision()
        {
            CCTV newCCTV = new CCTV("Salvatore", 1234);

            newCCTV.Unlock(PIN);
            newCCTV.SetVision(CCTVVisionType.NightVision);
            newCCTV.SetVision(CCTVVisionType.DefaultVision);

            Assert.Equal(CCTVVisionType.DefaultVision, newCCTV.VisionType);

        }

        [Fact]
        public void When_WantToSetNightVisionAndCCTVIsUnlockedButItHasAlreadyBeenSet_CannotSetNightVision()
        {
            CCTV newCCTV = new CCTV("Salvatore", 1234);

            newCCTV.Unlock(PIN);
            newCCTV.SetVision(CCTVVisionType.NightVision);

            Assert.Throws<ArgumentException>(() => newCCTV.SetVision(CCTVVisionType.NightVision));
        }

        [Fact]
        public void When_WantToSetNightVisionAndCCTVIsUnlockedAndItIsAlreadySetToDefaultVision_CanSetNightVision()
        {
            CCTV newCCTV = new CCTV("Salvatore", 1234);

            newCCTV.Unlock(PIN);
            newCCTV.SetVision(CCTVVisionType.NightVision);

            Assert.Equal(CCTVVisionType.NightVision, newCCTV.VisionType);

        }

        [Fact]
        public void When_WantToSetThermalVisionAndCCTVIsUnlockedButItHasAlreadyBeenSet_CannotSetThermalVision()
        {
            CCTV newCCTV = new CCTV("Salvatore", 1234);

            newCCTV.Unlock(PIN);
            newCCTV.SetVision(CCTVVisionType.ThermalVision);

            Assert.Throws<ArgumentException>(() => newCCTV.SetVision(CCTVVisionType.ThermalVision));
        }

        [Fact]
        public void When_WantToSetThermalVisionAndCCTVIsUnlockedAndItIsAlreadySetToDefaultVision_CanSetThermalVision()
        {
            CCTV newCCTV = new CCTV("Salvatore", 1234);

            newCCTV.Unlock(PIN);
            newCCTV.SetVision(CCTVVisionType.ThermalVision);

            Assert.Equal(CCTVVisionType.ThermalVision, newCCTV.VisionType);

        }

        [Fact]
        public void When_WantToSetDefaultZoomAndCCTVIsUNlockedButItHasAlreadyBeenSet_CannotSetDefaultZoom()
        {
            CCTV newCCTV = new CCTV("Salvatore", 1234);

            newCCTV.Unlock(PIN);

            Assert.Throws<ArgumentException>(() => newCCTV.SetDefaultZoom());
        }

        [Fact]
        public void When_WantToSetDefaultZoomAndCCTVIsUnlockedAndItIsAlreadySetToMaxZoom_CanSetDefaultZoom()
        {
            CCTV newCCTV = new CCTV("Salvatore", 1234);

            newCCTV.Unlock(PIN);
            newCCTV.SetMaxZoom();
            newCCTV.SetDefaultZoom();

            Assert.Equal(Zoom.Create(1.0), newCCTV.Zoom);

        }

        [Fact]
        public void When_WantToSetMinZoomAndCCTVIsUnlockedButItHasAlreadyBeenSet_CannotSetMinZoom()
        {
            CCTV newCCTV = new CCTV("Salvatore", 1234);

            newCCTV.Unlock(PIN);
            newCCTV.SetMinZoom();

            Assert.Throws<ArgumentException>(() => newCCTV.SetMinZoom());
        }

        [Fact]
        public void When_WantToSetMinZoomAndCCTVIsUnlockedAndItIsAlreadySetToDefaultZoom_CanSetMinZoom()
        {
            CCTV newCCTV = new CCTV("Salvatore", 1234);

            newCCTV.Unlock(PIN);
            newCCTV.SetMinZoom();

            Assert.Equal(Zoom.Create(0.5), newCCTV.Zoom);

        }

        [Fact]
        public void When_WantToSetMaxZoomAndCCTVIsUnlockedButItHasAlreadyBeenSet_CannotSetMaxZoom()
        {
            CCTV newCCTV = new CCTV("Salvatore", 1234);

            newCCTV.Unlock(PIN);
            newCCTV.SetMaxZoom();

            Assert.Throws<ArgumentException>(() => newCCTV.SetMaxZoom());
        }

        [Fact]
        public void When_WantToSetMaxZoomAndCCTVIsUnlockedAndItIsAlreadySetToDefaultZoom_CanSetMaxZoom()
        {
            CCTV newCCTV = new CCTV("Salvatore", 1234);

            newCCTV.Unlock(PIN);
            newCCTV.SetMaxZoom();

            Assert.Equal(Zoom.Create(10.0), newCCTV.Zoom);
        }

        [Fact]
        public void When_WantToIncreaseZoomAndCCTVIsUnlocked_CanDoIt()
        {
            CCTV newCCTV = new CCTV("Salvatore", 1234);

            newCCTV.Unlock(PIN);
            newCCTV.IncreaseZoom();

            Assert.Equal(Zoom.Create(1.1), newCCTV.Zoom);
        }

        [Fact]
        public void When_WantToDecreaseZoomAndCCTVIsUnlocked_CanDoIt()
        {
            CCTV newCCTV = new CCTV("Salvatore", 1234);

            newCCTV.Unlock(PIN);
            newCCTV.DecreaseZoom();

            Assert.Equal(Zoom.Create(0.9), newCCTV.Zoom);
        }
    }
}

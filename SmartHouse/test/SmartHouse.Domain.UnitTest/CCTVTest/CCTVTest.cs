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
        [Fact]
        public void When_TheNameOfCCTVIsEmpty_TheNameIsNotValid()
        {
            Assert.Throws<ArgumentException>(() => new CCTV(new Name(string.Empty)));
        }

        [Fact]
        public void When_WantToSetDefaultVisionButItHasAlreadyBeenSet_CannotSetDefaultVision()
        {
            CCTV newCCTV = new CCTV(new Name("Salvatore"));

            Assert.Throws<ArgumentException>(() => newCCTV.SetVision(CCTVVisionType.DefaultVision));
        }

        [Fact]
        public void When_WantToSetDefaultVisionAndItIsAlreadySetToNightVision_CanSetDefaultVision()
        {
            CCTV newCCTV = new CCTV(new Name("Salvatore"));

            newCCTV.SetVision(CCTVVisionType.NightVision);
            newCCTV.SetVision(CCTVVisionType.DefaultVision);

            Assert.Equal(CCTVVisionType.DefaultVision, newCCTV.VisionType);

        }

        [Fact]
        public void When_WantToSetNightVisionButItHasAlreadyBeenSet_CannotSetNightVision()
        {
            CCTV newCCTV = new CCTV(new Name("Salvatore"));

            newCCTV.SetVision(CCTVVisionType.NightVision);

            Assert.Throws<ArgumentException>(() => newCCTV.SetVision(CCTVVisionType.NightVision));
        }

        [Fact]
        public void When_WantToSetNightVisionAndItIsAlreadySetToDefaultVision_CanSetNightVision()
        {
            CCTV newCCTV = new CCTV(new Name("Salvatore"));

            newCCTV.SetVision(CCTVVisionType.NightVision);

            Assert.Equal(CCTVVisionType.NightVision, newCCTV.VisionType);

        }

        [Fact]
        public void When_WantToSetThermalVisionButItHasAlreadyBeenSet_CannotSetThermalVision()
        {
            CCTV newCCTV = new CCTV(new Name("Salvatore"));

            newCCTV.SetVision(CCTVVisionType.ThermalVision);

            Assert.Throws<ArgumentException>(() => newCCTV.SetVision(CCTVVisionType.ThermalVision));
        }

        [Fact]
        public void When_WantToSetThermalVisionAndItIsAlreadySetToDefaultVision_CanSetThermalVision()
        {
            CCTV newCCTV = new CCTV(new Name("Salvatore"));

            newCCTV.SetVision(CCTVVisionType.ThermalVision);

            Assert.Equal(CCTVVisionType.ThermalVision, newCCTV.VisionType);

        }

        [Fact]
        public void When_WantToSetDefaultZoomButItHasAlreadyBeenSet_CannotSetDefaultZoom()
        {
            CCTV newCCTV = new CCTV(new Name("Salvatore"));

            Assert.Throws<ArgumentException>(() => newCCTV.SetDefaultZoom());
        }

        [Fact]
        public void When_WantToSetDefaultZoomAndItIsAlreadySetToMaxZoom_CanSetDefaultZoom()
        {
            CCTV newCCTV = new CCTV(new Name("Salvatore"));

            newCCTV.SetMaxZoom();
            newCCTV.SetDefaultZoom();

            Assert.Equal(1.0, newCCTV.Zoom);

        }

        [Fact]
        public void When_WantToSetMinZoomButItHasAlreadyBeenSet_CannotSetMinZoom()
        {
            CCTV newCCTV = new CCTV(new Name("Salvatore"));

            newCCTV.SetMinZoom();

            Assert.Throws<ArgumentException>(() => newCCTV.SetMinZoom());
        }

        [Fact]
        public void When_WantToSetMinZoomAndItIsAlreadySetToDefaultZoom_CanSetMinZoom()
        {
            CCTV newCCTV = new CCTV(new Name("Salvatore"));

            newCCTV.SetMinZoom();

            Assert.Equal(0.5, newCCTV.Zoom);

        }

        [Fact]
        public void When_WantToSetMaxZoomButItHasAlreadyBeenSet_CannotSetMaxZoom()
        {
            CCTV newCCTV = new CCTV(new Name("Salvatore"));

            newCCTV.SetMaxZoom();

            Assert.Throws<ArgumentException>(() => newCCTV.SetMaxZoom());
        }

        [Fact]
        public void When_WantToSetMaxZoomAndItIsAlreadySetToDefaultZoom_CanSetMaxZoom()
        {
            CCTV newCCTV = new CCTV(new Name("Salvatore"));

            newCCTV.SetMaxZoom();

            Assert.Equal(10.0, newCCTV.Zoom);
        }

        [Fact]
        public void When_WantToIncreaseZoom_CanDoIt()
        {
            CCTV newCCTV = new CCTV(new Name("Salvatore"));

            newCCTV.IncreaseZoom();

            Assert.Equal(1.1, newCCTV.Zoom);
        }

        [Fact]
        public void When_WantToIncreaseZoomButItIsAlreadySetAtMaximum_CannotDoIt()
        {
            CCTV newCCTV = new CCTV(new Name("Salvatore"));

            newCCTV.SetMaxZoom();

            Assert.Throws<ArgumentException>(() => newCCTV.IncreaseZoom());
        }

        [Fact]
        public void When_WantToDecreaseZoom_CanDoIt()
        {
            CCTV newCCTV = new CCTV(new Name("Salvatore"));

            newCCTV.DecreaseZoom();

            Assert.Equal(0.9, newCCTV.Zoom);
        }

        [Fact]
        public void When_WantToDecreaseZoomButItIsAlreadySetAtMinimum_CannotDoIt()
        {
            CCTV newCCTV = new CCTV(new Name("Salvatore"));

            newCCTV.SetMinZoom();

            Assert.Throws<ArgumentException>(() => newCCTV.DecreaseZoom());
        }
    }
}

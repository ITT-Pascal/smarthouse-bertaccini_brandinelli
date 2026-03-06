using SmartHouse.Application.Devices.Abstraction.Mapper;
using SmartHouse.Application.Devices.CCTVDevice;
using SmartHouse.Application.Devices.CCTVDevice.Dto;
using SmartHouse.Domain;
using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.CCTVDevice;
using SmartHouse.Domain.Doors;
using SmartHouse.Domain.Illumination;
using SmartHouse.Domain.IlluminationDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.CCTVDevice.Mapper
{
    public class CCTVMapper
    {
        

        public static Dto.CCTVDto ToDto(Domain.CCTVDevice.CCTV cctv)
        {
            return new Dto.CCTVDto
            {
                Id = cctv.Id,
                Name = cctv.Name._name,
                Status = DeviceStatusMapper.ToDto(cctv.Status),
                CreationTime = cctv.CreationTime,
                LastUpdateTime = cctv.LastUpdateTime,
                Pin = cctv.PIN.PIN,
                IsLocked = cctv.IsLocked,
                VisionType = VisionTypeMapper.ToDto(cctv.VisionType),
                Zoom = cctv.Zoom._zoom,
            };
        }

        public static Domain.CCTVDevice.CCTV ToDomain(Dto.CCTVDto dto)
        {
            return new Domain.CCTVDevice.CCTV(
                dto.Id,
                dto.Name,
                DeviceStatusMapper.ToDomain(dto.Status),
                dto.Pin,
                VisionTypeMapper.ToDomain(dto.VisionType),
                dto.Zoom,
                dto.IsLocked,
                dto.CreationTime,
                dto.LastUpdateTime
                );                             
        }
    }
}

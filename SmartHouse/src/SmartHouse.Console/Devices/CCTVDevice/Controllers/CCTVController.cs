using SmartHouse.Application.Devices.CCTVDevice.Commands;
using SmartHouse.Application.Devices.CCTVDevice.Mapper;
using SmartHouse.Application.Devices.CCTVDevice.Queries;
using SmartHouse.Domain.CCTVDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CCTVController
{
    private readonly ICCTVRepository _repository;
        
    public CCTVController(ICCTVRepository repos)
    {
        _repository = repos;
    }
    public void ShowCCTVS()
    {
        var cctvs = new CCTVGetAllQuery(_repository).Execute();
            
        Console.WriteLine("CCTVS:");
        Console.WriteLine("------------------------------");

        if (cctvs.Count == 0)
        {
            Console.WriteLine("No lamps available");
            return;
        }

        for (int i = 0; i < cctvs.Count; i++)
        {
            var l = cctvs[i];
            Console.WriteLine($"{i + 1}. {l.Name}\n{l}");
        }
    }

    public void AddCCTV()
    {
        Console.Write("CCTV name: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid name");
            return;
        }

        new AddCCTVCommand(_repository).Execute(name);
        Console.WriteLine("CCTV added!");
    }

    public void RemoveLamp()
    {
        Console.Write("CCTV Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new RemoveCCTVCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("CCTV removed!");
    }

    public void ChangePin()
    {
        Console.Write("CCTV Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        Console.Write("Current pin: ");
        string currentpin = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(currentpin))
        {
            Console.WriteLine("Invalid Pin");
            return;
        }

        Console.Write("New pin: ");
        string newpin = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(newpin))
        {
            Console.WriteLine("Invalid Pin");
            return;
        }

        new ChangePinCCTVCommand(_repository).Execute(new Guid(id), int.Parse(currentpin), int.Parse(newpin));
        Console.WriteLine("CCTV removed!");
    }

    public void DecreaseZoom()
    {
        Console.Write("CCTV Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new DecreaseCCTVZoomCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("CCTV zoom decreased");
    }

    public void IncreaseZoom()
    {
        Console.Write("CCTV Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new IncreaseCCTVZoomCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("CCTV zoom increased");
    }

    public void Lock()
    {
        Console.Write("CCTV Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new LockCCTVCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("Locked CCTV");
    }

    public void Unlock()
    {
        Console.Write("CCTV Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        Console.Write("Current Pin: ");
        string currentpin = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(currentpin))
        {
            Console.WriteLine("Invalid Pin");
            return;
        }

        new UnlockCCTVCommand(_repository).Execute(new Guid(id), int.Parse(currentpin));
        Console.WriteLine("Unlocked CCTV");
    }

    public void SetDefaultZoom()
    {
        Console.Write("CCTV Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new SetCCTVDefaultZoomCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("Setted CCTV to default zoom");
    }

    public void SetMaxZoom()
    {
        Console.Write("CCTV Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new SetCCTVMaxZoomCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("Setted CCTV to max zoom");
    }

    public void SetMinZoom()
    {
        Console.Write("CCTV Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new SetCCTVMinZoomCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("Setted CCTV to min zoom");
    }

    public void SwitchOn()
    {
        Console.Write("CCTV Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new SwitchCCTVOnCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("Turned CCTV on");
    }

    public void SetVision()
    {
        Console.Write("CCTV Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        Console.Write("Vision Type: ");
        string visiontype = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(visiontype))
        {
            Console.WriteLine("Invalid vision type");
            return;
        }

        new SetCCTVVisionCommand(_repository).Execute(new Guid(id), VisionTypeMapper.ToDomain(visiontype));
        Console.WriteLine("Setted CCTV default zoom");
    }
}

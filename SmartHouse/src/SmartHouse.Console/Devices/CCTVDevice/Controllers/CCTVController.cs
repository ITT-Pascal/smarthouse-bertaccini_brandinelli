using SmartHouse.Application.Devices.CCTVDevice.Commands;
using SmartHouse.Application.Devices.CCTVDevice.Mapper;
using SmartHouse.Application.Devices.CCTVDevice.Queries;
using SmartHouse.Domain.CCTVDevice.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    public void RemoveCCTV()
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
        Console.WriteLine("Pin changed");
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

    private void ShowCCTVS()
    {
        var cctvs = new CCTVGetAllQuery(_repository).Execute();

        Console.WriteLine("CCTVS:");
        Console.WriteLine("------------------------------");

        if (cctvs.Count == 0)
        {
            Console.WriteLine("No CCTVs available");
            return;
        }

        for (int i = 0; i < cctvs.Count; i++)
        {
            var c = cctvs[i];
            Console.WriteLine($"{i + 1}. {c.Name}\n{c}");
        }
    }

    private void ShowChoices()
    {
        Console.WriteLine("1 - Add CCTV \n" +
                          "2 - Remove CCTV \n" +
                          "3 - Change pin \n" +
                          "4 - Lock \n" +
                          "5 - Unlock \n" +
                          "6 - Increase zoom \n" +
                          "7 - Decrease zoom \n" + 
                          "8 - Set default zoom \n" + 
                          "9 - Set max zoom \n" +
                          "10 - Set min zoom \n" +
                          "11 - Switch on \n" + 
                          "12 - Set vision ");
    }

    public void ShowMenu(CCTVController controller)
    {

        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.Write("\x1b[3J");
            controller.ShowCCTVS();
            controller.ShowChoices();

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    controller.AddCCTV();
                    break;
                case "2":
                    controller.RemoveCCTV();
                    break;
                case "3":
                    controller.ChangePin();
                    break;
                case "4":
                    controller.Lock();
                    break;
                case "5":
                    controller.Unlock();
                    break;
                case "6":
                    controller.IncreaseZoom();
                    break;
                case "7":
                    controller.DecreaseZoom();
                    break;
                case "8":
                    controller.SetDefaultZoom();
                    break;
                case "9":
                    controller.SetMaxZoom();
                    break;
                case "10":
                    controller.SetMinZoom();
                    break;
                case "11":
                    controller.SwitchOn();
                    break;
                case "12":
                    controller.SetVision();
                    break;
            }

            Console.WriteLine("Press Enter To go back to the menu");
            Console.ReadLine();
        }
    }

    private string SelectCCTV()
    {
        var cctvs = new CCTVGetAllQuery(_repository).Execute();

        if (cctvs.Count == 0)
        {
            Console.WriteLine("No cctvs available");
            return null;
        }

        Console.Write("CCTV number: ");
        if (!int.TryParse(Console.ReadLine(), out int num))
        {
            Console.WriteLine("Invalid number");
            return null;
        }

        if (num < 1 || num > cctvs.Count)
        {
            Console.WriteLine("There is no corresponding CCTV");
            return null;
        }

        try
        {
            return cctvs[num - 1].Id.ToString();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
            return null;
        }
    }
}

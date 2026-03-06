using SmartHouse.Application.Devices.CCTVDevice.Commands;
using SmartHouse.Application.Devices.CCTVDevice.Mapper;
using SmartHouse.Application.Devices.CCTVDevice.Queries;
using SmartHouse.Application.Devices.Illumination.Lamps.Queries;
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

    public void AddCCTV()
    {
        Console.Write("CCTV name: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid name");
            return;
        }

        Console.Write("CCTV Pin: ");
        if(!int.TryParse(Console.ReadLine(), out int pin))
        {
            Console.WriteLine("Invalid Pin");
            return;
        }

        new AddCCTVCommand(_repository).Execute(name,pin);
        Console.WriteLine("CCTV added!");
    }

    public void RemoveCCTV()
    {
        Guid id = new Guid(SelectCCTV());

        if (id == null)
        {
            Console.WriteLine("Cannot find selected cctv");
            return;
        }

        try
        {
            new RemoveCCTVCommand(_repository).Execute(id);
            Console.WriteLine("CCTV removed!");
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
       
    }

    public void ChangePin()
    {
        Guid id = new Guid(SelectCCTV());

        if (id == null)
        {
            Console.WriteLine("Cannot find selected cctv");
            return;
        }

        if (new CCTVCheckIsLockedQuery(_repository).Execute(id))
        {
            Console.WriteLine("CCTV must be unlocked!");
            return;
        }

        Console.Write("Current pin: ");
        if(!int.TryParse(Console.ReadLine(), out int currentpin))
        {
            Console.WriteLine("Invalid Pin");
            return;
        }      

        Console.Write("New pin: ");
        if (!int.TryParse(Console.ReadLine(), out int newpin))
        {
            Console.WriteLine("Invalid Pin");
            return;
        }

        try
        {
                new ChangePinCCTVCommand(_repository).Execute(id, currentpin, newpin);
                Console.WriteLine("Pin changed");
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void DecreaseZoom()
    {
        Guid id = new Guid(SelectCCTV());

        if (id == null)
        {
            Console.WriteLine("Cannot find selected cctv");
            return;
        }

        try
        {
            if (new CCTVCheckIsLockedQuery(_repository).Execute(id))
                Console.WriteLine("CCTV must be unlocked and turned on!");
            else if (!new CCTVCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("CCTV must be turned on!");
            else
            {
                new DecreaseCCTVZoomCommand(_repository).Execute(id);
                Console.WriteLine("CCTV zoom decreased");
            }
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void IncreaseZoom()
    {
        Guid id = new Guid(SelectCCTV());

        if (id == null)
        {
            Console.WriteLine("Cannot find selected cctv");
            return;
        }

        try
        {
            if (new CCTVCheckIsLockedQuery(_repository).Execute(id))
                Console.WriteLine("CCTV must be unlocked and turned on!");
            else if (!new CCTVCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("CCTV must be turned on!");
            else
            {
                new IncreaseCCTVZoomCommand(_repository).Execute(id);
                Console.WriteLine("CCTV zoom increased");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void Lock()
    {
        Guid id = new Guid(SelectCCTV());

        if (id == null)
        {
            Console.WriteLine("Cannot find selected cctv");
            return;
        }

        try
        {
            if (new CCTVCheckIsLockedQuery(_repository).Execute(id))
                Console.WriteLine("CCTV is alredy locked!");
            else if (new CCTVCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("CCTV must be turned off before locking!");
            else
            {
                new LockCCTVCommand(_repository).Execute(id);
                Console.WriteLine("Locked CCTV");
            }
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void Unlock()
    {
        Guid id = new Guid(SelectCCTV());

        if (id == null)
        {
            Console.WriteLine("Cannot find selected cctv");
            return;
        }

        if (!new CCTVCheckIsLockedQuery(_repository).Execute(id))
        {
            Console.WriteLine("CCTV is alredy unlocked!");
            return;
        }

        Console.Write("Current Pin: ");
        if(!int.TryParse(Console.ReadLine(), out int currentpin))
        {
            Console.WriteLine("Invalid Pin");
            return;
        }

        try
        {            
                new UnlockCCTVCommand(_repository).Execute(id, currentpin);
                Console.WriteLine("Unlocked CCTV");
            
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void SetDefaultZoom()
    {
        Guid id = new Guid(SelectCCTV());

        if (id == null)
        {
            Console.WriteLine("Cannot find selected cctv");
            return;
        }

        try
        {
            if (new CCTVCheckIsLockedQuery(_repository).Execute(id))
                Console.WriteLine("CCTV must be unlocked and turned on!");
            else if (!new CCTVCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("CCTV must be turned on!");
            else if (new CCTVCheckZoomIsDefaultQuery(_repository).Execute(id))
                Console.WriteLine("Zoom is alredy at it's default value");
            else
            {
                new SetCCTVDefaultZoomCommand(_repository).Execute(id);
                Console.WriteLine("Set Zoom to it's default value");
            }
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void SetMaxZoom()
    {
        Guid id = new Guid(SelectCCTV());

        if (id == null)
        {
            Console.WriteLine("Cannot find selected cctv");
            return;
        }

        try
        {
            if (new CCTVCheckIsLockedQuery(_repository).Execute(id))
                Console.WriteLine("CCTV must be unlocked and turned on!");
            else if (!new CCTVCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("CCTV must be turned on!");
            else if (new CCTVCheckZoomIsMaxQuery(_repository).Execute(id))
                Console.WriteLine("Zoom is alredy at it's maximum value");
            else
            {
                new SetCCTVMaxZoomCommand(_repository).Execute(id);
                Console.WriteLine("Set Zoom to it's max value");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void SetMinZoom()
    {
        Guid id = new Guid(SelectCCTV());

        if (id == null)
        {
            Console.WriteLine("Cannot find selected cctv");
            return;
        }

        try
        {
            if (new CCTVCheckIsLockedQuery(_repository).Execute(id))
                Console.WriteLine("CCTV must be unlocked and turned on!");
            else if (!new CCTVCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("CCTV must be turned on!");
            else if (new CCTVCheckZoomIsMinQuery(_repository).Execute(id))
                Console.WriteLine("Zoom is alredy at it's minimum value");
            else
            {
                new SetCCTVMinZoomCommand(_repository).Execute(id);
                Console.WriteLine("Set Zoom to it's minimum value");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void SwitchOn()
    {
        Guid id = new Guid(SelectCCTV());

        if (id == null)
        {
            Console.WriteLine("Cannot find selected cctv");
            return;
        }

        try
        {
            if (new CCTVCheckIsLockedQuery(_repository).Execute(id))
                Console.WriteLine("CCTV must be unlocked!");
            else if (new CCTVCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("CCTV is alredy on!");
            else
            {
                new SwitchCCTVOnCommand(_repository).Execute(id);
                Console.WriteLine("Turned CCTV on");
            }
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void SwitchOff()
    {
        Guid id = new Guid(SelectCCTV());

        if (id == null)
        {
            Console.WriteLine("Cannot find selected cctv");
            return;
        }

        try
        {
            if (new CCTVCheckIsLockedQuery(_repository).Execute(id))
                Console.WriteLine("CCTV is alredy off and locked!");
            else if (!new CCTVCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("CCTV is alredy off!");
            else
            {
                new SwitchCCTVOffCommand(_repository).Execute(id);
                Console.WriteLine("Turned CCTV off");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void SetVision()
    {
        Guid id = new Guid(SelectCCTV());

        if (id == null)
        {
            Console.WriteLine("Cannot find selected cctv");
            return;
        }

        Console.Write("Select: \n" +
            "1 - Default vision \n" +
            "2 - Night vision \n" +
            "3 - Thermal vision \n");
        string choice = Console.ReadLine();

        try
        {
            if (new CCTVCheckIsLockedQuery(_repository).Execute(id))
                Console.WriteLine("CCTV must be unlocked and turned on!");
            else if (!new CCTVCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("CCTV must be turned on!");
            else
            {
                if (new SetCCTVVisionCommand(_repository).Execute(id, choice))
                    Console.WriteLine("Set selected vision type!");
                else
                    Console.WriteLine();
            }
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
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
                          "6 - Switch On \n" +
                          "7 - Switch Off \n" + 
                          "8 - Set default zoom \n" + 
                          "9 - Set max zoom \n" +
                          "10 - Set min zoom \n" +
                          "11 - Increase zoom \n" + 
                          "12 - Decrease zoom \n" +
                          "13 - Set vision \n" +
                          "14 - Go back to device selection menu");
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
                    controller.SwitchOn();
                    break;
                case "7":
                    controller.SwitchOff();
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
                    controller.IncreaseZoom();
                    break;
                case "12":
                    controller.DecreaseZoom();
                    break;
                case "13":
                    controller.SetVision();
                    break;
                case "14":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
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
            Console.WriteLine("There is no corresponding cctv");
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

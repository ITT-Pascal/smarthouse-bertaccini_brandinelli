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
            Thread.Sleep(1500);
            return;
        }

        Console.Write("CCTV Pin: ");
        if(!int.TryParse(Console.ReadLine(), out int pin))
        {
            Console.WriteLine("Invalid Pin");
            Thread.Sleep(1500);
            return;
        }

        new AddCCTVCommand(_repository).Execute(name,pin);
        Console.WriteLine("CCTV added!");
        Thread.Sleep(1500);
    }

    public void RemoveCCTV()
    {
        string selectedId = SelectCCTV();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try
        {
            new RemoveCCTVCommand(_repository).Execute(id);
            Console.WriteLine("CCTV removed!");
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        Thread.Sleep(1500);
    }

    public void ChangePin()
    {
        string selectedId = SelectCCTV();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        if (new CCTVCheckIsLockedQuery(_repository).Execute(id))
        {
            Console.WriteLine("CCTV must be unlocked!");
            Thread.Sleep(1500);
            return;
        }

        Console.Write("Current pin: ");
        if(!int.TryParse(Console.ReadLine(), out int currentpin))
        {
            Console.WriteLine("Invalid Pin");
            Thread.Sleep(1500);
            return;
        }else if (currentpin != new GetCCTVByIdQuery(_repository).Execute(id).Pin)
        {
            Console.WriteLine("Wrong Pin");
            Thread.Sleep(1500);
            return;
        }

        Console.Write("New pin: ");
        if (!int.TryParse(Console.ReadLine(), out int newpin))
        {
            Console.WriteLine("Invalid Pin");
            Thread.Sleep(1500);
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
        Thread.Sleep(1500);
    }

    public void DecreaseZoom()
    {
        string selectedId = SelectCCTV();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

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
        Thread.Sleep(1500);
    }

    public void IncreaseZoom()
    {
        string selectedId = SelectCCTV();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

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
        Thread.Sleep(1500);
    }

    public void Lock()
    {
        string selectedId = SelectCCTV();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

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
        Thread.Sleep(1500);
    }

    public void Unlock()
    {
        string selectedId = SelectCCTV();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        if (!new CCTVCheckIsLockedQuery(_repository).Execute(id))
        {
            Console.WriteLine("CCTV is alredy unlocked!");
            Thread.Sleep(1500);
            return;
        }

        Console.Write("Current Pin: ");
        if(!int.TryParse(Console.ReadLine(), out int currentpin))
        {
            Console.WriteLine("Invalid Pin");
            Thread.Sleep(1500);
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
        Thread.Sleep(1500);
    }

    public void SetDefaultZoom()
    {
        string selectedId = SelectCCTV();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

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
        Thread.Sleep(1500);
    }

    public void SetMaxZoom()
    {
        string selectedId = SelectCCTV();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

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
        Thread.Sleep(1500);
    }

    public void SetMinZoom()
    {
        string selectedId = SelectCCTV();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

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
        Thread.Sleep(1500);
    }

    public void SwitchOn()
    {
        string selectedId = SelectCCTV();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

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
        Thread.Sleep(1500);
    }

    public void SwitchOff()
    {
        string selectedId = SelectCCTV();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

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
        Thread.Sleep(1500);
    }

    public void SetVision()
    {
        string selectedId = SelectCCTV();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        Console.Write("Choices: \n" +
            "1 - Default vision \n" +
            "2 - Night vision \n" +
            "3 - Thermal vision \n" +
            "Select: ");
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
        Thread.Sleep(1500);
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

    public void ShowMenu(CCTVController controller)
    {

        bool exit = false;

        string[] options = { "0 - Go back to device selection menu", "1 - Add CCTV", "2 - Remove CCTV", "3 - Change pin", "4 - Lock", "5 - Unlock", "6 - Switch On", "7 - Switch Off", "8 - Set default zoom", "9 - Set max zoom", "10 - Set min zoom", "11 - Increase zoom", "12 - Decrease zoom", "13 - Set vision" };
        int selected = 0;

        Console.CursorVisible = false;

        while (!exit)
        {
            bool choiceDone = false;

            while (!choiceDone)
            {
                Console.Clear();
                Console.Write("\x1b[3J");
                controller.ShowCCTVS();

                Console.WriteLine("---- SELECT AN OPTION ----");
                Console.WriteLine("(Use the arrows keys to move, Enter to select)\n");

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write($"> {options[i]} ");
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine($"  {options[i]} ");
                    }
                }

                Console.WriteLine("--------------------------");

                ConsoleKey info = Console.ReadKey(true).Key;

                switch (info)
                {
                    case ConsoleKey.UpArrow:
                        selected = (selected == 0) ? options.Length - 1 : selected - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        selected = (selected == options.Length - 1) ? 0 : selected + 1;
                        break;
                    case ConsoleKey.Enter:
                        choiceDone = true;
                        break;
                }
            }

            switch (selected)
            {
                case 0:
                    exit = true;
                    break;
                case 1:
                    controller.AddCCTV();
                    break;
                case 2:
                    controller.RemoveCCTV();
                    break;
                case 3:
                    controller.ChangePin();
                    break;
                case 4:
                    controller.Lock();
                    break;
                case 5:
                    controller.Unlock();
                    break;
                case 6:
                    controller.SwitchOn();
                    break;
                case 7:
                    controller.SwitchOff();
                    break;
                case 8:
                    controller.SetDefaultZoom();
                    break;
                case 9:
                    controller.SetMaxZoom();
                    break;
                case 10:
                    controller.SetMinZoom();
                    break;
                case 11:
                    controller.IncreaseZoom();
                    break;
                case 12:
                    controller.DecreaseZoom();
                    break;
                case 13:
                    controller.SetVision();
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    private string SelectCCTV()
    {
        var cctvs = new CCTVGetAllQuery(_repository).Execute();

        if (cctvs.Count == 0)
        {
            Console.WriteLine("No cctvs available");
            Thread.Sleep(1500);
            return null;
        }

        Console.Write("CCTV number: ");
        if (!int.TryParse(Console.ReadLine(), out int num))
        {
            Console.WriteLine("Invalid number");
            Thread.Sleep(1500);
            return null;
        }

        if (num < 1 || num > cctvs.Count)
        {
            Console.WriteLine("There is no corresponding cctv");
            Thread.Sleep(1500);
            return null;
        }

        try
        {
            return cctvs[num - 1].Id.ToString();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
            Thread.Sleep(1500);
            return null;
        }
    }

    //private bool TurnChoice(Guid id)
    //{
    //    Console.WriteLine("Do you want to unlock the cctv?");
    //    Console.Write("Select (Y/N): ");
    //    string choice = Console.ReadLine().ToLower();
    //    switch (choice)
    //    {
    //        case "y":
    //            Console.Write("Enter Current PIN to unlock: ");
    //            if (int.TryParse(Console.ReadLine(), out int pin))
    //            {
    //                return SmartUnlockCCTV(id, pin);
    //            }
    //            else
    //            {
    //                Console.WriteLine("Invalid PIN format.");
    //                return false;
    //            }
    //            break;
    //        case "n":
    //            return false;
    //            break;
    //        default:
    //            Console.WriteLine("Invalid choice");
    //            return false;
    //            break;
    //    }
    //}

    //private bool SmartUnlockCCTV(Guid id, int currentpin)
    //{
        
    //    try
    //    {
    //        new UnlockCCTVCommand(_repository).Execute(id, currentpin);
    //        Console.WriteLine("Unlocked CCTV");
    //        return true;
    //    }
    //    catch (ArgumentException ex)
    //    {
    //        Console.WriteLine($"ERROR: {ex.Message}");
    //        return false;
    //    }
    //}
}

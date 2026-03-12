using SmartHouse.Application.Devices.Abstraction.Mapper;
using SmartHouse.Application.Devices.Illumination.Lamps.Commands;
using SmartHouse.Application.Devices.Illumination.Lamps.Mapper;
using SmartHouse.Application.Devices.Illumination.Lamps.Queries;
using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.AirConditionerDevice.Repositories;
using SmartHouse.Domain.CCTVDevice.Repositories;
using SmartHouse.Domain.DoorsDevice.Repositories;
using SmartHouse.Domain.Illumination;
using SmartHouse.Domain.IlluminationDevice.Repositories;
using SmartHouse.Domain.TemperatureDevice.Repositories;
using System.ComponentModel.Design;

public class LampController
{
    private readonly ILampRepository _repository;

    public LampController(ILampRepository repos)
    {
        _repository = repos;
    }

    public void AddLamp()
    {
        Console.Write("Lamp name: ");
        string name = Console.ReadLine();

        if(string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid name");
            return;
        }

        new AddLampCommand(_repository).Execute(name);
        Console.WriteLine("Lamp added!");
        Thread.Sleep(1500);
    }

    public void RemoveLamp()
    {
        string selectedId = SelectLamp();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try
        {
            new RemoveLampCommand(_repository).Execute(id);
            Console.WriteLine("Lamp removed!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        Thread.Sleep(1500);
    }

    public void Brighten()
    {
        string selectedId = SelectLamp();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try
        {
            if (!new LampCheckIsOnQuery(_repository).Execute(id))
            {
                Console.WriteLine("Lamp must be turned on!");
                if (TurnChoice(id))
                {
                    new BrightenLampCommand(_repository).Execute(id);
                    Console.WriteLine("Increased lamp brightness!");
                }
            }
            else if (new LampCheckBrightnessIsMaxQuery(_repository).Execute(id))
                Console.WriteLine("Brightness is alredy at it's maximum");
            else
            {
                new BrightenLampCommand(_repository).Execute(id);
                Console.WriteLine("Increased lamp brightness!");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        Thread.Sleep(1500);
    }

    public void ChangeBrightness()
    {
        string selectedId = SelectLamp();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        if (! new LampCheckIsOnQuery(_repository).Execute(id))
        {
            Console.WriteLine("Lamp must be turned on!");
            if (TurnChoice(id))
            {
                Console.Write("New brightness (0-100): ");
                if (!int.TryParse(Console.ReadLine(), out int newBrightness))
                {
                    Console.WriteLine("Invalid brightness");
                    Thread.Sleep(1500);
                    return;
                }

                try
                {
                    new ChangeBrightnessLampCommand(_repository).Execute(id, newBrightness);
                    Console.WriteLine("Changed lamp brightness!");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }
            Thread.Sleep(1500);
            return;
        }

        Console.Write("New brightness (0-100): ");
        if (!int.TryParse(Console.ReadLine(), out int newbrightness))
        {
            Console.WriteLine("Invalid brightness");
            Thread.Sleep(1500);
            return;
        }

        try
        {
            new ChangeBrightnessLampCommand(_repository).Execute(id, newbrightness);
            Console.WriteLine("Changed lamp brightness!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        Thread.Sleep(1500);
    }

    public void Dimmer()
    {
        string selectedId = SelectLamp();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try
        {
            if (!new LampCheckIsOnQuery(_repository).Execute(id))
            {
                Console.WriteLine("Lamp must be turned on!");
                if (TurnChoice(id))
                {
                    new DimmerLampCommand(_repository).Execute(id);
                    Console.WriteLine("Decreased lamp brightness!");
                }               
            }
            else if (new LampCheckBrightnessIsMinQuery(_repository).Execute(id))
                Console.WriteLine("Brightness is alredy at it's maximum");
            else
            {
                new DimmerLampCommand(_repository).Execute(id);
                Console.WriteLine("Decreased lamp brightness!");
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
        string selectedId = SelectLamp();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try
        {           
            if (new LampCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("Lamp is alredy on!");
            else
            {
                new SwitchLampOnCommand(_repository).Execute(id);
                Console.WriteLine("Turned lamp on!");
            }            
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        Thread.Sleep(1500);
    }

    public void SwitchOff()
    {
        string selectedId = SelectLamp();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try
        {
            if (! new LampCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("Lamp is alredy off!");
            else
            {
                new SwitchLampOffCommand(_repository).Execute(id);
                Console.WriteLine("Turned lamp off!");
            }      
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        Thread.Sleep(1500);
    }

    private void ShowLamps()
    {
        var lamps = new GetAllLampsQuery(_repository).Execute();

        Console.WriteLine("LAMPS:");
        Console.WriteLine("------------------------------");

        if(lamps.Count == 0)
        {
            Console.WriteLine("No lamps available");
            return;
        }

        for(int i = 0; i < lamps.Count;i++)
        {
            var l = lamps[i];
            Console.WriteLine($"{i + 1}. {l.Name}\n{l}");
        }
    }

    public void ShowMenu(LampController controller)
    {
        bool exit = false;

        string[] options = { "0 - Go back to device selection menu", "1 - Add lamp", "2 - Remove lamp", "3 - Switch On", "4 - Switch Off", "5 - Brighten", "6 - Dimmer", "7 - Change brightness" };
        int selected = 0;

        Console.CursorVisible = false;

        while (!exit)
        {
            bool choiceDone = false;

            while (!choiceDone)
            {
                Console.Clear();
                Console.Write("\x1b[3J");
                controller.ShowLamps();

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
                    controller.AddLamp();
                    break;
                case 2:
                    controller.RemoveLamp();
                    break;
                case 3:
                    controller.SwitchOn();
                    break;
                case 4:
                    controller.SwitchOff();
                    break;
                case 5:
                    controller.Brighten();
                    break;
                case 6:
                    controller.Dimmer();
                    break;
                case 7:
                    controller.ChangeBrightness();
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    private string SelectLamp()
    {
        var lamps = new GetAllLampsQuery(_repository).Execute();

        if (lamps.Count == 0)
        {
            Console.WriteLine("No lamps available");
            Thread.Sleep(1500);
            return null;
        }

        Console.Write("Lamp number: ");
        if(!int.TryParse(Console.ReadLine(), out int num))
        {
            Console.WriteLine("Invalid number");
            Thread.Sleep(1500);
            return null;
        }

        if(num<1 || num > lamps.Count)
        {
            Console.WriteLine("There is no corresponding lamp");
            Thread.Sleep(1500);
            return null;
        }    

        try
        {
            return lamps[num-1].Id.ToString();
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
            Thread.Sleep(1500);
            return null;
        }
    }

    private bool TurnChoice(Guid id)
    {
        Console.WriteLine("Do you want to turn the lamp on");
        Console.Write("Select (Y/N): ");
        string choice = Console.ReadLine().ToLower();
        switch (choice)
        {
            case "y":
                SmartSwitchOn(id);
                return true;
                break;
            case "n":
                return false;
                break;
            default:
                Console.WriteLine("Invalid choice");
                return false;
                break;
        }
    }

    private void SmartSwitchOn(Guid id)
    {
        try
        {
            new SwitchLampOnCommand(_repository).Execute(id);
            Console.WriteLine("Turned lamp on!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }
}

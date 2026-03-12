using SmartHouse.Application.Devices.Abstraction.Mapper;
using SmartHouse.Application.Devices.DoorDevice.Commands;
using SmartHouse.Application.Devices.DoorDevice.Queries;
using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.DoorsDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DoorController
{
    private readonly IDoorRepository _repository;

    public DoorController(IDoorRepository repos)
    {
        _repository = repos;
    }

    public void AddDoor()
    {
        Console.Write("Door name: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid name");
            return;
        }

        Console.Write("New Pin: ");
        if(!int.TryParse(Console.ReadLine(), out int pin))
        {
            Console.WriteLine("Invalid Pin");
        }

        new AddDoorCommand(_repository).Execute(name, pin);
        Console.WriteLine("Door added!");
    }

    public void RemoveDoor()
    {
        string selectedId = SelectDoor();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try
        {
            new RemoveDoorCommand(_repository).Execute(id);
            Console.WriteLine("Door removed!");
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void SwitchOn()
    {
        string selectedId = SelectDoor();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try
        {
            if (new DoorCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("Door is alredy on!");
            else
            {
                new DoorSwitchOnCommand(_repository).Execute(id);
                Console.WriteLine("Door turned on!");
            }
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void SwitchOff()
    {
        string selectedId = SelectDoor();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try
        {
            if (!new DoorCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("Door is alredy off!");
            else
            {
                new DoorSwitchOffCommand(_repository).Execute(id);
                Console.WriteLine("Door turned off!");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void ChangePin()
    {
        string selectedId = SelectDoor();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        if (!new DoorCheckIsOnQuery(_repository).Execute(id))
        {
            Console.WriteLine("Door must be on and unlocked!");
            return;
        }
        else if (new DoorCheckIsLockedQuery(_repository).Execute(id))
        {
            Console.WriteLine("Door must be unlocked!");
            return;
        }

        Console.Write("Current pin: ");
        if(!int.TryParse(Console.ReadLine(), out int currentpin))
        {
            Console.WriteLine("Invalid Pin");
            return;
        }

        Console.Write("New pin: ");
        if(!int.TryParse(Console.ReadLine(),out int newpin))
        {
            Console.WriteLine("Invalid Pin");
            return;
        }

        try
        {
                new ChangePinDoorCommand(_repository).Execute(id, currentpin, newpin);
                Console.WriteLine("Pin changed!");
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void Lock()
    {
        string selectedId = SelectDoor();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try
        {
            if (!new DoorCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("Door must be on!");
            else if (new DoorCheckIsOpenQuery(_repository).Execute(id))
                Console.WriteLine("Door must be closed!");
            else if (new DoorCheckIsLockedQuery(_repository).Execute(id))
                Console.WriteLine("Door is alredy locked!");
            else
            {
                new LockDoorCommand(_repository).Execute(id);
                Console.WriteLine("Door locked!");
            }
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void Unlock()
    {
        string selectedId = SelectDoor();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        if (!new DoorCheckIsOnQuery(_repository).Execute(id))
        {
            Console.WriteLine("Door must be on!");
            return;
        }
        else if (!new DoorCheckIsLockedQuery(_repository).Execute(id))
        {
            Console.WriteLine("Door is alredy unlocked!");
            return;
        }

        Console.Write("Current Pin: ");
        if(!int.TryParse(Console.ReadLine(),out int currentpin))
        {
            Console.WriteLine("Invalid Pin");
        }

        try
        {
                new UnlockDoorCommand(_repository).Execute(id, currentpin);
                Console.WriteLine("Door unlocked!");
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void Open()
    {
        string selectedId = SelectDoor();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try
        {
            if (!new DoorCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("Door must be on!");
            else if (new DoorCheckIsLockedQuery(_repository).Execute(id))
                Console.WriteLine("Door must be unlocked!");
            else if (new DoorCheckIsOpenQuery(_repository).Execute(id))
                Console.WriteLine("Door is alredy open");
            else
            {
                new OpenDoorCommand(_repository).Execute(id);
                Console.WriteLine("Opened door");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void Close()
    {
        string selectedId = SelectDoor();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try 
        {
            if (!new DoorCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("Door must be on!");
            else if (!new DoorCheckIsOpenQuery(_repository).Execute(id))
                Console.WriteLine("Door is alredy closed");
            else
            {
                new CloseDoorCommand(_repository).Execute(id);
                Console.WriteLine("Closed door");
            }
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    private void ShowDoors()
    {
        var doors = new DoorGetAllQuery(_repository).Execute();

        Console.WriteLine("Doors:");
        Console.WriteLine("------------------------------");

        if (doors.Count == 0)
        {
            Console.WriteLine("No doors available");
            return;
        }

        for (int i = 0; i < doors.Count; i++)
        {
            var d = doors[i];
            Console.WriteLine($"{i + 1}. {d.Name}\n{d}");
        }
    }

    public void ShowMenu(DoorController controller)
    {

        bool exit = false;

        string[] options = { "0 - Go back to device selection menu", "1 - Add door", "2 - Remove door", "3 - Switch On", "4 - Switch Off", "5 - Change pin", "6 - Lock", "7 - Unlock", "8 - Open", "9 - Close" };
        int selected = 0;

        Console.CursorVisible = false;

        while (!exit)
        {
            bool choiceDone = false;

            while (!choiceDone)
            {
                Console.Clear();
                Console.Write("\x1b[3J");
                controller.ShowDoors();

                Console.WriteLine("--- SMART HOUSE SYSTEM ---");
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
                    controller.AddDoor();
                    break;
                case 2:
                    controller.RemoveDoor();
                    break;
                case 3:
                    controller.SwitchOn();
                    break;
                case 4:
                    controller.SwitchOff();
                    break;
                case 5:
                    controller.ChangePin();
                    break;
                case 6:
                    controller.Lock();
                    break;
                case 7:
                    controller.Unlock();
                    break;
                case 8:
                    controller.Open();
                    break;
                case 9:
                    controller.Close();
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    private string SelectDoor()
    {
        var doors = new DoorGetAllQuery(_repository).Execute();

        if (doors.Count == 0)
        {
            Console.WriteLine("No doors available");
            return null;
        }

        Console.Write("Door number: ");
        if (!int.TryParse(Console.ReadLine(), out int num))
        {
            Console.WriteLine("Invalid number");
            return null;
        }

        if (num < 1 || num > doors.Count)
        {
            Console.WriteLine("There is no corresponding door");
            return null;
        }

        try
        {
            return doors[num - 1].Id.ToString();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
            return null;
        }
    }
}

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

    private void ShowChoices()
    {
        Console.WriteLine("0 - Go back to device selection menu \n" +
                          "1 - Add door \n" +
                          "2 - Remove door \n" +
                          "3 - Switch On \n" +
                          "4 - Switch Off \n" +
                          "5 - Change pin \n" +
                          "6 - Lock \n" +
                          "7 - Unlock \n" +
                          "8 - Open \n" +
                          "9 - Close \n");
    }

    public void ShowMenu(DoorController controller)
    {

        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.Write("\x1b[3J");
            controller.ShowDoors();
            controller.ShowChoices();

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "0":
                    exit = true;
                    break;
                case "1":
                    controller.AddDoor();
                    break;
                case "2":
                    controller.RemoveDoor();
                    break;
                case "3":
                    controller.SwitchOn();
                    break;
                case "4":
                    controller.SwitchOff();
                    break;
                case "5":
                    controller.ChangePin();
                    break;
                case "6":
                    controller.Lock();
                    break;
                case "7":
                    controller.Unlock();
                    break;
                case "8":
                    controller.Open();
                    break;
                case "9":
                    controller.Close();
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

            Console.WriteLine("Press Enter To go back to the menu");
            Console.ReadLine();
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

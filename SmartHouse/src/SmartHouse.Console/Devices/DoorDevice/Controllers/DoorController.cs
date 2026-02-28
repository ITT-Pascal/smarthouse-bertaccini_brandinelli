using SmartHouse.Application.Devices.DoorDevice.Commands;
using SmartHouse.Application.Devices.DoorDevice.Queries;
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

    public void ShowDoors()
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
        string newpin = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(newpin))
        {
            Console.WriteLine("Invalid new pin");
            return;
        }

        new AddDoorCommand(_repository).Execute(name, int.Parse(newpin));
        Console.WriteLine("Door added!");
    }

    public void RemoveLamp()
    {
        Console.Write("Door Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new RemoveDoorCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("Door removed!");
    }

    public void ChangePin()
    {
        Console.Write("Door Id: ");
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

        new ChangePinDoorCommand(_repository).Execute(new Guid(id), int.Parse(currentpin), int.Parse(newpin));
        Console.WriteLine("Door removed!");
    }

    public void Lock()
    {
        Console.Write("Door Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new LockDoorCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("Locked Door");
    }

    public void Unlock()
    {
        Console.Write("Door Id: ");
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

        new UnlockDoorCommand(_repository).Execute(new Guid(id), int.Parse(currentpin));
        Console.WriteLine("Unlocked Door");
    }

    public void Open()
    {
        Console.Write("Door Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new OpenDoorCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("Opened Door");
    }

    public void Close()
    {
        Console.Write("Door Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new CloseDoorCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("Closed Door");
    }
}

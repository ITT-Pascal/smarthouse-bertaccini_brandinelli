using SmartHouse.Application.Devices.AirConditionerDevice.Commands;
using SmartHouse.Application.Devices.AirConditionerDevice.Queries;
using SmartHouse.Domain.AirConditionerDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AirConditionerController
{
    private readonly IAirConditionerRepository _repository;

    public AirConditionerController(IAirConditionerRepository repos)
    {
        _repository = repos;
    }

    public void ShowAirConditioners()
    {
        var airconditioners = new AirConditionerGetAllQuery(_repository).Execute();

        Console.WriteLine("AirConditioners:");
        Console.WriteLine("------------------------------");

        if (airconditioners.Count == 0)
        {
            Console.WriteLine("No airconditioners available");
            return;
        }

        for (int i = 0; i < airconditioners.Count; i++)
        {
            var a = airconditioners[i];
            Console.WriteLine($"{i + 1}. {a.Name}\n{a}");
        }
    }

    public void AddDoor()
    {
        Console.Write("AirConditioner name: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid name");
            return;
        }

        new AddAirConditionerCommand(_repository).Execute(name);
        Console.WriteLine("AirConditioner added!");
    }

    public void RemoveLamp()
    {
        Console.Write("AirConditioner Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new RemoveAirConditionerCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("AirConditioner removed!");
    }

    public void IncreaseFanSpeed()
    {
        Console.Write("AirConditioner Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new AirConditionerIncreaseFanSpeedCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("Increased airConditioner fan speed");
    }

    public void DecreaseFanSpeed()
    {
        Console.Write("AirConditioner Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new AirConditionerDecreaseFanSpeedCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("Decreased airConditioner fan speed");
    }

    public void SetFanSpeedHigh()
    {
        Console.Write("AirConditioner Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new AirConditionerSetFanSpeedHigh(_repository).Execute(new Guid(id));
        Console.WriteLine("Setted airConditioner fan speed in high");
    }

    public void SetFanSpeedMedium()
    {
        Console.Write("AirConditioner Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new AirConditionerSetFanSpeedMedium(_repository).Execute(new Guid(id));
        Console.WriteLine("Setted airConditioner fan speed in medium");
    }

    public void SetFanSpeedLow()
    {
        Console.Write("AirConditioner Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new AirConditionerSetFanSpeedLow(_repository).Execute(new Guid(id));
        Console.WriteLine("Setted airConditioner fan speed in low");
    }
}

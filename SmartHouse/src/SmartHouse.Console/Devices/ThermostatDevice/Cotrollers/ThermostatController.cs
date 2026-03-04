using SmartHouse.Application.Devices.Illumination.Lamps.Commands;
using SmartHouse.Application.Devices.Illumination.Lamps.Queries;
using SmartHouse.Application.Devices.ThermostatDevice.Command;
using SmartHouse.Application.Devices.ThermostatDevice.Queries;
using SmartHouse.Domain.TemperatureDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ThermostatController
{
    private readonly IThermostatRepository _repository;

    public ThermostatController(IThermostatRepository repos)
    {
        _repository = repos;
    }

    public void AddThermostat()
    {
        Console.Write("Thermostat name: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name isn't valid");
            return;
        }

        new AddThermostatCommand(_repository).Execute(name);
        Console.WriteLine("Thermostat Added!");
    }

    public void RemoveThermostat()
    {
        Console.Write("Thermostat Id: ");
        string id = Console.ReadLine();

        if(string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("Invalid id");
            return;
        }

        new RemoveThermostatCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("Thermostat Removed!");
    }

    public void SetTemperature()
    {
        Console.Write("Thermostat Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("Invalid id");
            return;
        }

        Console.Write("New temperature : ");
        string temp = Console.ReadLine();

        try
        {
            new ThermostatSetTemperatureCommand(_repository).Execute(new Guid(id), double.Parse(temp));
            Console.WriteLine("Temperature Set!");
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void DecreaseTemperature()
    {
        Console.Write("Thermostat Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("Invalid id");
            return;
        }

        try
        {
            new ThermostatDecreaseTemperatureCommand(_repository).Execute(new Guid(id));
            Console.WriteLine("Temperature Decreased!");
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void IncreaseTemperature()
    {
        Console.Write("Thermostat id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("Invalid id");
            return;
        }

        try
        {
            new ThermostatIncreaseTemperatureCommand(_repository).Execute(new Guid(id));
            Console.WriteLine("Temperature Increased!");
        }catch(ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void ShowThermostats()
    {
        var thermostats = new ThermostatGetAllQuery(_repository).Execute();

        Console.WriteLine("THERMOSTATS:");
        Console.WriteLine("------------------------------");

        if (thermostats.Count == 0)
        {
            Console.WriteLine("No thermostats available");
            return;
        }

        for (int i = 0; i < thermostats.Count; i++)
        {
            var l = thermostats[i];
            Console.WriteLine($"{i + 1}. {l.Name}\n{l}");
        }
    }
}

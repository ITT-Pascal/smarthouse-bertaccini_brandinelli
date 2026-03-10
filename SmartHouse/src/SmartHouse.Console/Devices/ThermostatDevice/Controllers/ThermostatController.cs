using SmartHouse.Application.Devices.Abstraction.Mapper;
using SmartHouse.Application.Devices.ThermostatDevice.Command;
using SmartHouse.Application.Devices.ThermostatDevice.Mapper;
using SmartHouse.Application.Devices.ThermostatDevice.Queries;
using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.TemperatureDevice;
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
        string selectedId = SelectThermostat();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try
        {
            new RemoveThermostatCommand(_repository).Execute(id);
            Console.WriteLine("Thermostat Removed!");
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }
    public void SwitchOn()
    {
        string selectedId = SelectThermostat();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try
        {
            if (new ThermostatCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("Thermostat is alredy on!");
            else
            {
                new ThermostatSwitchOnCommand(_repository).Execute(id);
                Console.WriteLine("Turned thermostat on!");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void SwitchOff()
    {
        string selectedId = SelectThermostat();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try
        {
            if (!new ThermostatCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("Thermostat is alredy off!");
            else
            {
                new ThermostatSwitchOffCommand(_repository).Execute(id);
                Console.WriteLine("Turned thermostat off!");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void SetTemperature()
    {
        string selectedId = SelectThermostat();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        if (!new ThermostatCheckIsOnQuery(_repository).Execute(id))
        {
            Console.WriteLine("Thermostat must be turned on!");
            return;
        }

        Console.Write("New temperature : ");
        if(!double.TryParse(Console.ReadLine(), out double temp))
        {
            Console.WriteLine("Invalid temperature!");
            return;
        }

        try
        {
            new ThermostatSetTemperatureCommand(_repository).Execute(id, temp);
            Console.WriteLine("Temperature Set!");
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void DecreaseTemperature()
    {
        string selectedId = SelectThermostat();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try
        {
            if (!new ThermostatCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("Thermostat must be turned on!");
            else if (new ThermostatCheckTemperatureIsMinQuery(_repository).Execute(id))
                Console.WriteLine("Temperature is alredy at it's minimum");
            else
            {
                new ThermostatDecreaseTemperatureCommand(_repository).Execute(id);
                Console.WriteLine("Temperature Decreased!");
            }          
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void IncreaseTemperature()
    {
        string selectedId = SelectThermostat();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try
        {
            if (!new ThermostatCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("Thermostat must be turned on!");
            else if (new ThermostatCheckTemperatureIsMaxQuery(_repository).Execute(id))
                Console.WriteLine("Temperature is alredy at it's maximum");
            else
            {
                new ThermostatIncreaseTemperatureCommand(_repository).Execute(id);
                Console.WriteLine("Temperature Increased!");
            }          
        }catch(ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    private void ShowThermostats()
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
            var t = thermostats[i];
            Console.WriteLine($"{i + 1}. {t.Name}\n{t}");
        }
    }

    private void ShowChoices()
    {
        Console.WriteLine("1 - Add thermostat \n" +
                          "2 - Remove thermostat \n" +
                          "3 - Switch On \n" +
                          "4 - Switch Off \n" +
                          "5 - Increase temperature \n" +
                          "6 - Decrease temperature \n" +
                          "7 - Set temperature \n" +
                          "8 - Go back to device selection menu");
    }

    public void ShowMenu(ThermostatController controller)
    {

        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.Write("\x1b[3J");
            controller.ShowThermostats();
            controller.ShowChoices();

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    controller.AddThermostat();
                    break;
                case "2":
                    controller.RemoveThermostat();
                    break;
                case "3":
                    controller.SwitchOn();
                    break;
                case "4":
                    controller.SwitchOff();
                    break;
                case "5":
                    controller.IncreaseTemperature();
                    break;
                case "6":
                    controller.DecreaseTemperature();
                    break;
                case "7":
                    controller.SetTemperature();
                    break;
                case "8":
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

    private string SelectThermostat()
    {
        var thermostats = new ThermostatGetAllQuery(_repository).Execute();

        if (thermostats.Count == 0)
        {
            Console.WriteLine("No thermostats available");
            return null;
        }

        Console.Write("Thermostat number: ");
        if (!int.TryParse(Console.ReadLine(), out int num))
        {
            Console.WriteLine("Invalid number");
            return null;
        }

        if (num < 1 || num > thermostats.Count)
        {
            Console.WriteLine("There is no corresponding thermostat");
            return null;
        }

        try
        {
            return thermostats[num - 1].Id.ToString();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
            return null;
        }
    }
}

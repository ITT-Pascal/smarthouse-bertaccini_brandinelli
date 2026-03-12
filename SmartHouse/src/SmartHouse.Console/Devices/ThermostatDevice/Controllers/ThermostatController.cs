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
            Thread.Sleep(1500);
            return;
        }

        new AddThermostatCommand(_repository).Execute(name);
        Console.WriteLine("Thermostat Added!");
        Thread.Sleep(1500);
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
        Thread.Sleep(1500);
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
        Thread.Sleep(1500);
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
        Thread.Sleep(1500);
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
            if (TurnChoice(id))
            {
                Console.Write("New temperature (15-30): ");
                if (!double.TryParse(Console.ReadLine(), out double t))
                {
                    Console.WriteLine("Invalid temperature!");
                    Thread.Sleep(1500);
                    return;
                }

                try
                {
                    new ThermostatSetTemperatureCommand(_repository).Execute(id, t);
                    Console.WriteLine("Temperature Set!");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }
            Thread.Sleep(1500);
            return;
        }

        Console.Write("New temperature (15-30): ");
        if (!double.TryParse(Console.ReadLine(), out double temp))
        {
            Console.WriteLine("Invalid temperature!");
            Thread.Sleep(1500);
            return;
        }

        try
        {
            new ThermostatSetTemperatureCommand(_repository).Execute(id, temp);
            Console.WriteLine("Temperature Set!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        Thread.Sleep(1500);
    }

    public void DecreaseTemperature()
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
            if(TurnChoice(id))
            {
                try
                {
                    if (new ThermostatCheckTemperatureIsMaxQuery(_repository).Execute(id))
                        Console.WriteLine("Temperature is alredy at it's maximum");
                    else
                    {
                        new ThermostatIncreaseTemperatureCommand(_repository).Execute(id);
                        Console.WriteLine("Temperature Increased!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }
            Thread.Sleep(1500);
            return;
        }

        try
        {
            if (new ThermostatCheckTemperatureIsMaxQuery(_repository).Execute(id))
                Console.WriteLine("Temperature is alredy at it's maximum");
            else
            {
                new ThermostatIncreaseTemperatureCommand(_repository).Execute(id);
                Console.WriteLine("Temperature Increased!");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        Thread.Sleep(1500);
    }

    public void IncreaseTemperature()
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
            if(TurnChoice(id))
            {
                try
                {
                    if (new ThermostatCheckTemperatureIsMaxQuery(_repository).Execute(id))
                        Console.WriteLine("Temperature is alredy at it's maximum");
                    else
                    {
                        new ThermostatIncreaseTemperatureCommand(_repository).Execute(id);
                        Console.WriteLine("Temperature Increased!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }
            Thread.Sleep(1500);
            return;
        }

        try
        {
            if (new ThermostatCheckTemperatureIsMaxQuery(_repository).Execute(id))
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
        Thread.Sleep(1500);
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

    public void ShowMenu(ThermostatController controller)
    {

        bool exit = false;

        string[] options = { "0 - Go back to device selection menu", "1 - Add thermostat", "2 - Remove thermostat", "3 - Switch On", "4 - Switch Off", "5 - Increase temperature", "6 - Decrease temperature", "7 - Set temperature" };
        int selected = 0;

        Console.CursorVisible = false;

        while (!exit)
        {
            bool choiceDone = false;

            while (!choiceDone)
            {
                Console.Clear();
                Console.Write("\x1b[3J");
                controller.ShowThermostats();

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
                    controller.AddThermostat();
                    break;
                case 2:
                    controller.RemoveThermostat();
                    break;
                case 3:
                    controller.SwitchOn();
                    break;
                case 4:
                    controller.SwitchOff();
                    break;
                case 5:
                    controller.IncreaseTemperature();
                    break;
                case 6:
                    controller.DecreaseTemperature();
                    break;
                case 7:
                    controller.SetTemperature();
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    private string SelectThermostat()
    {
        var thermostats = new ThermostatGetAllQuery(_repository).Execute();

        if (thermostats.Count == 0)
        {
            Console.WriteLine("No thermostats available");
            Thread.Sleep(1500);
            return null;
        }

        Console.Write("Thermostat number: ");
        if (!int.TryParse(Console.ReadLine(), out int num))
        {
            Console.WriteLine("Invalid number");
            Thread.Sleep(1500);
            return null;
        }

        if (num < 1 || num > thermostats.Count)
        {
            Console.WriteLine("There is no corresponding thermostat");
            Thread.Sleep(1500);
            return null;
        }

        try
        {
            return thermostats[num - 1].Id.ToString();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
            Thread.Sleep(1500);
            return null;
        }
    }

    private bool TurnChoice(Guid id)
    {
        Console.WriteLine("Do you want to turn the thermostat on?");
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
            new ThermostatSwitchOnCommand(_repository).Execute(id);
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }
}

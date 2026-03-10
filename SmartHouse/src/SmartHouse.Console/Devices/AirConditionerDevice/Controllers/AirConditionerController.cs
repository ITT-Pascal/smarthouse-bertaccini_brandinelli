using SmartHouse.Application.Devices.AirConditionerDevice.Commands;
using SmartHouse.Application.Devices.AirConditionerDevice.Queries;
using SmartHouse.Application.Devices.CCTVDevice.Queries;
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

    public void AddAirConditioner()
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

    public void RemoveAirConditioner()
    {
        string selectedId = SelectAirConditioner();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try
        {
            new RemoveAirConditionerCommand(_repository).Execute(id);
            Console.WriteLine("AirConditioner removed!");
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void SwitchOn()
    {
        string selectedId = SelectAirConditioner();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try
        {
            if (new AirConditionerCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("Air conditioner is alredy on!");
            else
            {
                new AirConditionerSwitchOnCommand(_repository).Execute(id);
                Console.WriteLine("Air conditioner turned on!");
            }
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void SwitchOff()
    {
        string selectedId = SelectAirConditioner();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try
        {
            if (!new AirConditionerCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("Air conditioner is alredy off!");
            else
            {
                new AirConditionerSwitchOnCommand(_repository).Execute(id);
                Console.WriteLine("Air conditioner turned off!");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void IncreaseFanSpeed()
    {
        string selectedId = SelectAirConditioner();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try
        {
            if (!new AirConditionerCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("Air conditioner must be turned on!");
            else if (new AirConditionerCheckFanSpeedHighQuery(_repository).Execute(id))
                Console.WriteLine("Fan speed is alredy at it's maximum");
            else
            {
                new AirConditionerIncreaseFanSpeedCommand(_repository).Execute(id);
                Console.WriteLine("Increased air conditioner fan speed");
            }
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void DecreaseFanSpeed()
    {
        string selectedId = SelectAirConditioner();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try
        {
            if (!new AirConditionerCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("Air conditioner must be turned on!");
            else if (new AirConditionerCheckFanSpeedLowQuery(_repository).Execute(id))
                Console.WriteLine("Fan speed is alredy at it's minimum");
            else
            {
                new AirConditionerDecreaseFanSpeedCommand(_repository).Execute(id);
                Console.WriteLine("Decreased air conditioner fan speed");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void SetFanSpeedHigh()
    {
        string selectedId = SelectAirConditioner();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try
        {
            if (!new AirConditionerCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("Air conditioner must be turned on!");
            else if (new AirConditionerCheckFanSpeedHighQuery(_repository).Execute(id))
                Console.WriteLine("Fan speed is alredy set to high!");
            else
            {
                new AirConditionerSetFanSpeedHigh(_repository).Execute(id);
                Console.WriteLine("Set air conditioner fan speed to high");
            }
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void SetFanSpeedMedium()
    {
        string selectedId = SelectAirConditioner();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try
        {
            if (!new AirConditionerCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("Air conditioner must be turned on!");
            else if (new AirConditionerCheckFanSpeedMediumQuery(_repository).Execute(id))
                Console.WriteLine("Fan speed is alredy set to medium!");
            else
            {
                new AirConditionerSetFanSpeedMedium(_repository).Execute(id);
                Console.WriteLine("Set air conditioner fan speed to medium");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void SetFanSpeedLow()
    {
        string selectedId = SelectAirConditioner();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        try
        {
            if (!new AirConditionerCheckIsOnQuery(_repository).Execute(id))
                Console.WriteLine("Air conditioner must be turned on!");
            else if (new AirConditionerCheckFanSpeedLowQuery(_repository).Execute(id))
                Console.WriteLine("Fan speed is alredy set to low!");
            else
            {
                new AirConditionerSetFanSpeedLow(_repository).Execute(id);
                Console.WriteLine("Set air conditioner fan speed to low");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    private void ShowAirConditioners()
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

    private void ShowChoices()
    {
        Console.WriteLine("1 - Add air conditioner \n" +
                          "2 - Remove air conditioner \n" +
                          "3 - Switch On \n" +
                          "4 - Switch Off \n" +
                          "5 - Increase fan speed \n" +
                          "6 - Decrease fan speed \n" +
                          "7 - Set fan speed high \n" +
                          "8 - Set fan speed medium \n" +
                          "9 - Set fan speed low \n" +
                          "10 - Go back to device selection menu");
    }

    public void ShowMenu(AirConditionerController controller)
    {

        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.Write("\x1b[3J");
            controller.ShowAirConditioners();
            controller.ShowChoices();

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    controller.AddAirConditioner();
                    break;
                case "2":
                    controller.RemoveAirConditioner();
                    break;
                case "3":
                    controller.SwitchOn();
                    break;
                case "4":
                    controller.SwitchOff();
                    break;
                case "5":
                    controller.IncreaseFanSpeed();
                    break;
                case "6":
                    controller.DecreaseFanSpeed();
                    break;
                case "7":
                    controller.SetFanSpeedHigh();
                    break;
                case "8":
                    controller.SetFanSpeedMedium();
                    break;
                case "9":
                    controller.SetFanSpeedLow();
                    break;
                case "10":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

            Console.WriteLine("Press Enter To go back to the menu");
            Console.ReadLine();
        }
    }

    private string SelectAirConditioner()
    {
        var airConditioners = new AirConditionerGetAllQuery(_repository).Execute();

        if (airConditioners.Count == 0)
        {
            Console.WriteLine("No air conditioners available");
            return null;
        }

        Console.Write("Air conditioner number: ");
        if (!int.TryParse(Console.ReadLine(), out int num))
        {
            Console.WriteLine("Invalid number");
            return null;
        }

        if (num < 1 || num > airConditioners.Count)
        {
            Console.WriteLine("There is no corresponding air conditioner");
            return null;
        }

        try
        {
            return airConditioners[num - 1].Id.ToString();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
            return null;
        }
    }
}

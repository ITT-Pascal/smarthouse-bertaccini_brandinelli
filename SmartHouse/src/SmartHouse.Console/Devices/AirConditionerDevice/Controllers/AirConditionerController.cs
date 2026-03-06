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
                          "3 - Increase fan speed \n" +
                          "4 - Decrease fan speed \n" +
                          "5 - Set fan speed high \n" +
                          "6 - Set fan speed medium \n" +
                          "7 - Set fan speed low ");
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
                    controller.IncreaseFanSpeed();
                    break;
                case "4":
                    controller.DecreaseFanSpeed();
                    break;
                case "5":
                    controller.SetFanSpeedHigh();
                    break;
                case "6":
                    controller.SetFanSpeedMedium();
                    break;
                case "7":
                    controller.SetFanSpeedMedium();
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

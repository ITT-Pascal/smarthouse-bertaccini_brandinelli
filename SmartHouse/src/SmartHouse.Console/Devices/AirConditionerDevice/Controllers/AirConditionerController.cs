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
            Thread.Sleep(1500);
            return;
        }

        new AddAirConditionerCommand(_repository).Execute(name);
        Console.WriteLine("AirConditioner added!");
        Thread.Sleep(1500);
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
        Thread.Sleep(1500);
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
        Thread.Sleep(1500);
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
        Thread.Sleep(1500);
    }

    public void IncreaseFanSpeed()
    {
        string selectedId = SelectAirConditioner();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        if(!new AirConditionerCheckIsOnQuery(_repository).Execute(id))
        {
            Console.WriteLine("Air conditioner must be turned on!");
            if(TurnChoice(id))
            {
                try
                {
                    if (new AirConditionerCheckFanSpeedHighQuery(_repository).Execute(id))
                        Console.WriteLine("Fan speed is alredy at it's maximum");
                    else
                    {
                        new AirConditionerIncreaseFanSpeedCommand(_repository).Execute(id);
                        Console.WriteLine("Increased air conditioner fan speed");
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
            if (new AirConditionerCheckFanSpeedHighQuery(_repository).Execute(id))
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
        Thread.Sleep(1500);
    }

    public void DecreaseFanSpeed()
    {
        string selectedId = SelectAirConditioner();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        if (!new AirConditionerCheckIsOnQuery(_repository).Execute(id)) 
        {
            Console.WriteLine("Air conditioner must be turned on!");
            if(TurnChoice(id))
            {
                try
                {
                    if (new AirConditionerCheckFanSpeedLowQuery(_repository).Execute(id))
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
            Thread.Sleep(1500);
            return;
        }

        try
        {
            if (new AirConditionerCheckFanSpeedLowQuery(_repository).Execute(id))
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
        Thread.Sleep(1500);
    }

    public void SetFanSpeedHigh()
    {
        string selectedId = SelectAirConditioner();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        if (!new AirConditionerCheckIsOnQuery(_repository).Execute(id))
        {
            Console.WriteLine("Air conditioner must be turned on!");
            if(TurnChoice(id))
            {
                try
                {
                    if (new AirConditionerCheckFanSpeedHighQuery(_repository).Execute(id))
                        Console.WriteLine("Fan speed is alredy set to high!");
                    else
                    {
                        new AirConditionerSetFanSpeedHigh(_repository).Execute(id);
                        Console.WriteLine("Set air conditioner fan speed to high");
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
            if (new AirConditionerCheckFanSpeedHighQuery(_repository).Execute(id))
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
        Thread.Sleep(1500);
    }

    public void SetFanSpeedMedium()
    {
        string selectedId = SelectAirConditioner();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        if (!new AirConditionerCheckIsOnQuery(_repository).Execute(id))
        {
            Console.WriteLine("Air conditioner must be turned on!");
            if(TurnChoice(id))
            {
                try
                {
                    if (new AirConditionerCheckFanSpeedMediumQuery(_repository).Execute(id))
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
            Thread.Sleep(1500);
            return;
        }

        try
        {
            if (new AirConditionerCheckFanSpeedMediumQuery(_repository).Execute(id))
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
        Thread.Sleep(1500);
    }

    public void SetFanSpeedLow()
    {
        string selectedId = SelectAirConditioner();

        if (string.IsNullOrWhiteSpace(selectedId))
        {
            return;
        }

        Guid id = new Guid(selectedId);

        if (!new AirConditionerCheckIsOnQuery(_repository).Execute(id))
        {
            Console.WriteLine("Air conditioner must be turned on!");
            if(TurnChoice(id))
            {
                try
                {
                    if (new AirConditionerCheckFanSpeedLowQuery(_repository).Execute(id))
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
            Thread.Sleep(1500);
            return;
        }

        try
        {
            if (new AirConditionerCheckFanSpeedLowQuery(_repository).Execute(id))
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
        Thread.Sleep(1500);
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

    public void ShowMenu(AirConditionerController controller)
    {

        bool exit = false;

        string[] options = { "0 - Go back to device selection menu", "1 - Add air conditioner", "2 - Remove air conditioner", "3 - Switch On", "4 - Switch Off", "5 - Increase fan speed", "6 - Decrease fan speed", "7 - Set fan speed high", "8 - Set fan speed medium", "9 - Set fan speed low" };
        int selected = 0;

        Console.CursorVisible = false;

        while (!exit)
        {
            bool choiceDone = false;

            while (!choiceDone)
            {
                Console.Clear();
                Console.Write("\x1b[3J");
                controller.ShowAirConditioners();

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
                    controller.AddAirConditioner();
                    break;
                case 2:
                    controller.RemoveAirConditioner();
                    break;
                case 3:
                    controller.SwitchOn();
                    break;
                case 4:
                    controller.SwitchOff();
                    break;
                case 5:
                    controller.IncreaseFanSpeed();
                    break;
                case 6:
                    controller.DecreaseFanSpeed();
                    break;
                case 7:
                    controller.SetFanSpeedHigh();
                    break;
                case 8:
                    controller.SetFanSpeedMedium();
                    break;
                case 9:
                    controller.SetFanSpeedLow();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    private string SelectAirConditioner()
    {
        var airConditioners = new AirConditionerGetAllQuery(_repository).Execute();

        if (airConditioners.Count == 0)
        {
            Console.WriteLine("No air conditioners available");
            Thread.Sleep(1500);
            return null;
        }

        Console.Write("Air conditioner number: ");
        if (!int.TryParse(Console.ReadLine(), out int num))
        {
            Console.WriteLine("Invalid number");
            Thread.Sleep(1500);
            return null;
        }

        if (num < 1 || num > airConditioners.Count)
        {
            Console.WriteLine("There is no corresponding air conditioner");
            Thread.Sleep(1500);
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
        Thread.Sleep(1500);
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
            new AirConditionerSwitchOnCommand(_repository).Execute(id);
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }
}

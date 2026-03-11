using SmartHouse.Domain.AirConditionerDevice.Repositories;
using SmartHouse.Domain.CCTVDevice.Repositories;
using SmartHouse.Domain.DoorsDevice.Repositories;
using SmartHouse.Domain.IlluminationDevice.Repositories;
using SmartHouse.Domain.TemperatureDevice.Repositories;
using SmartHouse.Infrastructure.Repositories.Devices.AirConditionerDevice.InMemory;
using SmartHouse.Infrastructure.Repositories.Devices.CCTVDevice.InMemory;
using SmartHouse.Infrastructure.Repositories.Devices.DoorDevice.InMemory;
using SmartHouse.Infrastructure.Repositories.Devices.Illumination.Lamps.InMemory;
using SmartHouse.Infrastructure.Repositories.Devices.ThermostatDevice.InMemory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        bool exit = false;

        string[] options = { "0 - Exit", "1 - Lamps", "2 - CCTVS", "3 - Air Conditioner", "4 - Thermostat", "5 - Door" };
        int selected = 0;

        Console.CursorVisible = false;

        while (!exit)
        {
            bool choiceDone = false;

            while (!choiceDone)
            {
                Console.Clear();
                Console.Write("\x1b[3J");

                Console.WriteLine("--- SMART HOUSE SYSTEM ---");
                Console.WriteLine("(Use the arrows keys to move, Enter to select)\n");

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"> {options[i]} ");
                        Console.ResetColor();
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
                    ILampRepository lampRepository = new InMemoryLampRepository();
                    LampController lampController = new LampController(lampRepository);
                    lampController.ShowMenu(lampController);
                    break;
                case 2:
                    ICCTVRepository cctvRepository = new InMemoryCCTVRepository();
                    CCTVController cctvController = new CCTVController(cctvRepository);
                    cctvController.ShowMenu(cctvController);
                    break;
                case 3:
                    IAirConditionerRepository airConditionerRepository = new InMemoryAirConditionerRepository();
                    AirConditionerController airConditionerController = new AirConditionerController(airConditionerRepository);
                    airConditionerController.ShowMenu(airConditionerController);
                    break;
                case 4:
                    IThermostatRepository thermostatRepository = new InMemoryThermostatRepository();
                    ThermostatController thermostatController = new ThermostatController(thermostatRepository);
                    thermostatController.ShowMenu(thermostatController);
                    break;
                case 5:
                    IDoorRepository doorRepository = new InMemoryDoorRepository();
                    DoorController doorController = new DoorController(doorRepository);
                    doorController.ShowMenu(doorController);
                    break;
            }
        }

        Console.Clear();
        Console.Write("\x1b[3J");
        Console.WriteLine("See you next time!");
        Console.Write("\nPress enter to close the menu....");
        Console.ReadLine();
    }
}
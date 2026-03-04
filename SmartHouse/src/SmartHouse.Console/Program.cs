using SmartHouse.Domain.IlluminationDevice.Repositories;
using SmartHouse.Infrastructure.Repositories.Devices.Illumination.Lamps.InMemory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        ILampRepository repository = new InMemoryLampRepository();
        LampController controller = new LampController(repository);

        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            controller.ShowLamps();

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    controller.AddLamp();
                    break;
                case "2":
                    controller.RemoveLamp();
                    break;
                case "3":
                    controller.SwitchOn();
                    break;
                case "4":
                    controller.SwitchOff();
                    break;
                case "5":
                    controller.Brighten();
                    break;
                case "6":
                    controller.Dimmer();
                    break;
                case "7":
                    controller.ChangeBrightness();
                    break;
            }

            Console.WriteLine("Press Enter To go back to the menu");
            Console.ReadLine();
        }
    }
}
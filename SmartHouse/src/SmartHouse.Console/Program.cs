using SmartHouse.Domain.CCTVDevice.Repositories;
using SmartHouse.Domain.IlluminationDevice.Repositories;
using SmartHouse.Infrastructure.Repositories.Devices.CCTVDevice.InMemory;
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

        bool exit = false;

        while (!exit)
        {
            Console.Clear();

            Console.WriteLine("1 - Lamps \n" +
                          "2 - CCTVS \n" +
                          "3 - Air Conditioner \n" +
                          "4 - Thermostat \n" +
                          "5 - Door \n" );

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ILampRepository lampRepository = new InMemoryLampRepository();
                    LampController lampController = new LampController(lampRepository);
                    lampController.ShowMenu(lampController);
                    break;
                case "2":
                    ICCTVRepository cctvRepository = new InMemoryCCTVRepository();
                    CCTVController cctvController = new CCTVController(cctvRepository);
                    break;
            }
        }
    }
}
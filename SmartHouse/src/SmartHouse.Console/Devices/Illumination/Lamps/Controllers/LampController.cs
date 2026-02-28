using SmartHouse.Application.Devices.Illumination.Lamps.Commands;
using SmartHouse.Application.Devices.Illumination.Lamps.Queries;
using SmartHouse.Domain.IlluminationDevice.Repositories;

public class LampController
{
    private readonly ILampRepository _repository;

    public LampController(ILampRepository repos)
    {
        _repository = repos;
    }

    public void AddLamp()
    {
        Console.Write("Lamp name: ");
        string name = Console.ReadLine();

        if(string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid name");
            return;
        }

        new AddLampCommand(_repository).Execute(name);
        Console.WriteLine("Lamp added!");
    }

    public void RemoveLamp()
    {
        Console.Write("Lamp Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new RemoveLampCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("Lamp removed!");
    }

    public void Brighten()
    {
        Console.Write("Lamp Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new BrightenLampCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("Increased lamp brightness!");
    }

    public void ChangeBrightness()
    {
        Console.Write("Lamp Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        Console.Write("New brightness: ");
        string newbrightness = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(newbrightness))
        {
            Console.WriteLine("Invalid brightness");
            return;
        }

        new ChangeBrightnessLampCommand(_repository).Execute(new Guid(id), int.Parse(newbrightness));
        Console.WriteLine("Changed lamp brightness!");
    }

    public void Dimmer()
    {
        Console.Write("Lamp Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new DimmerLampCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("Decreased lamp brightness!");
    }

    public void SwitchOn()
    {
        Console.Write("Lamp Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new SwitchLampOnCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("Turned lamp on!");
    }

    public void SwitchOff()
    {
        Console.Write("Lamp Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new SwitchLampOffCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("Turned lamp off!");
    }

    public void ShowLamps()
    {
        var lamps = new GetAllLampsQuery(_repository).Execute();

        Console.WriteLine("LAMPS:");
        Console.WriteLine("------------------------------");

        if(lamps.Count == 0)
        {
            Console.WriteLine("No lamps available");
            return;
        }

        for(int i = 0; i < lamps.Count;i++)
        {
            var l = lamps[i];
            Console.WriteLine($"{i + 1}. {l.Name}\n{l}");
        }
    }
}

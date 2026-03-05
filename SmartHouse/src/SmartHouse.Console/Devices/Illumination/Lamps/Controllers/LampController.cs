using SmartHouse.Application.Devices.Abstraction.Mapper;
using SmartHouse.Application.Devices.Illumination.Lamps.Commands;
using SmartHouse.Application.Devices.Illumination.Lamps.Mapper;
using SmartHouse.Application.Devices.Illumination.Lamps.Queries;
using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.Illumination;
using SmartHouse.Domain.IlluminationDevice.Repositories;
using System.ComponentModel.Design;

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
        string id = SelectLamp();
        
        if(string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Cannot Find Selected Lamp");
            return;
        }

        try
        {
            new RemoveLampCommand(_repository).Execute(new Guid(id));
            Console.WriteLine("Lamp removed!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void Brighten()
    {
        string id = SelectLamp();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Cannot Find Selected Lamp");
            return;
        }

        try
        {
            if (DeviceStatusMapper.ToDomain(new GetLampByIdQuery(_repository).Execute(new Guid(id)).Status) == DeviceStatus.Off)
                Console.WriteLine("Lamp must be turned on!");
            else if (LampMapper.ToDomain(new GetLampByIdQuery(_repository).Execute(new Guid(id))).Brightness == new Lamp("Check").MaxBrightness)
                Console.WriteLine("Brightness is alredy at it's maximum");
            else
            {
                new BrightenLampCommand(_repository).Execute(new Guid(id));
                Console.WriteLine("Increased lamp brightness!");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void ChangeBrightness()
    {
        string id = SelectLamp();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Cannot Find Selected Lamp");
            return;
        }

        if (DeviceStatusMapper.ToDomain(new GetLampByIdQuery(_repository).Execute(new Guid(id)).Status) == DeviceStatus.Off)
        {
            Console.WriteLine("Lamp must be turned on!");
            return;
        }

        Console.Write("New brightness: ");
        if (!int.TryParse(Console.ReadLine(), out int newbrightness))
        {
            Console.WriteLine("Invalid brightness");
            return;
        }

        try
        {
            new ChangeBrightnessLampCommand(_repository).Execute(new Guid(id), newbrightness);
            Console.WriteLine("Changed lamp brightness!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void Dimmer()
    {
        string id = SelectLamp();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Cannot Find Selected Lamp");
            return;
        }

        try
        {
            if (DeviceStatusMapper.ToDomain(new GetLampByIdQuery(_repository).Execute(new Guid(id)).Status) == DeviceStatus.Off)
                Console.WriteLine("Lamp must be turned on!");
            else if (LampMapper.ToDomain(new GetLampByIdQuery(_repository).Execute(new Guid(id))).Brightness == new Lamp("Check").MinBrightness)
                Console.WriteLine("Brightness is alredy at it's minimum value");
            else
            {
                new DimmerLampCommand(_repository).Execute(new Guid(id));
                Console.WriteLine("Decreased lamp brightness!");
            }         
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void SwitchOn()
    {
        string id = SelectLamp();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Cannot Find Selected Lamp");
            return;
        }

        try
        {           
            if (DeviceStatusMapper.ToDomain(new GetLampByIdQuery(_repository).Execute(new Guid(id)).Status) == DeviceStatus.On)
                Console.WriteLine("Lamp is alredy on!");
            else
            {
                new SwitchLampOnCommand(_repository).Execute(new Guid(id));
                Console.WriteLine("Turned lamp on!");
            }            
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void SwitchOff()
    {
        string id = SelectLamp();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Cannot Find Selected Lamp");
            return;
        }

        try
        {
            if (DeviceStatusMapper.ToDomain(new GetLampByIdQuery(_repository).Execute(new Guid(id)).Status) == DeviceStatus.Off)
                Console.WriteLine("Lamp is alredy off!");
            else
            {
                new SwitchLampOffCommand(_repository).Execute(new Guid(id));
                Console.WriteLine("Turned lamp off!");
            }      
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
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
    public void ShowMenu()
    {
        Console.WriteLine("1 - Add lamp \n" +
                          "2 - Remove lamp \n" +
                          "3 - Switch On \n" +
                          "4 - Switch Off \n" +
                          "5 - Brighten \n" +
                          "6 - Dimmer \n" +
                          "7 - Change brightness ");
    }

    private string SelectLamp()
    {
        var lamps = new GetAllLampsQuery(_repository).Execute();

        if (lamps.Count == 0)
        {
            Console.WriteLine("No lamps available");
            return null;
        }

        Console.Write("Lamp number: ");
        if(!int.TryParse(Console.ReadLine(), out int num))
        {
            Console.WriteLine("Invalid number");
            return null;
        }

        if(num<1 || num > lamps.Count)
        {
            Console.WriteLine("There is no corresponding lamp");
            return null;
        }    

        try
        {
            return lamps[num-1].Id.ToString();
        }catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
            return null;
        }
    }
}

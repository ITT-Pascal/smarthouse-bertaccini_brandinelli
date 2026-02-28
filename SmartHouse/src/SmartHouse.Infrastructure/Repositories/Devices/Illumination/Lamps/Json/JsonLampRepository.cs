using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Domain.Illumination;
using SmartHouse.Domain.IlluminationDevice.Repositories;

namespace SmartHouse.Infrastructure.Repositories.Devices.Illumination.Lamps.Json
{
    public class JsonLampRepository : ILampRepository
    {
        private readonly string _storagepath;

        public JsonLampRepository(string storagepath = "smarthouse-bertaccini_brandinelli\\SmartHouse\\data")
        {
            _storagepath = storagepath;
        }
        public void Add(Lamp lamp)
        {
            var json = JsonSerializer.Serialize(lamp);
            File.WriteAllTextAsync($"{_storagepath}/{lamp.Id}.json", json);
        }

        public void Update(Lamp lamp)
        {
            var json = JsonSerializer.Serialize(lamp);
            File.WriteAllTextAsync($"{_storagepath}/{lamp.Id}.json", json);
        }

        public void Delete(Guid id)
        {
            var filepath = $"{_storagepath}/{id}.json";
            if(File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }

        public Lamp GetById(Guid id)
        {
            var filepath = $"{_storagepath}/{id}.json";
            if (!File.Exists(filepath)) return null;

            var json = File.ReadAllText(filepath);
            return JsonSerializer.Deserialize<Lamp>(json);
        }

        public List<Lamp> GetAll()
        {
            var lamps = new List<Lamp>();

            var files = Directory.GetFiles(_storagepath, "*.json");

            foreach(var file in files)
            {
                var json = File.ReadAllText(file);
                var lamp = JsonSerializer.Deserialize<Lamp>(json);
                if (lamp != null)
                {
                    lamps.Add(lamp);
                }
            }
            return lamps;
        }
    }
}

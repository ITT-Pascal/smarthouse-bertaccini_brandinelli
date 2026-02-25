using SmartHouse.Domain.Illumination;
using SmartHouse.Domain.IlluminationDevice.Repositories;

namespace SmartHouse.Infrastructure.Repositories.Devices.Illumination.Lamps.InMemory
{
    public class InMemoryLampRepository : ILampRepository
    {
        private readonly List<Lamp> _lamps;

        public InMemoryLampRepository()
        {
            _lamps = new List<Lamp>
            {
                new Lamp("Stefano"),
                new Lamp("Pasquale"),
                new Lamp("Giovanni")
            };
        }

        public List<Lamp> GetAll()
        {
            return _lamps;
        }

        public Lamp? GetById(Guid id)
        {
            Lamp? result = null;

            foreach (Lamp l in _lamps)
                if (l.Id == id)
                    result = l;

            return result;                 
        }

        public void Add(Lamp lamp)
        {
            if (lamp != null)
                _lamps.Add(lamp);
            else
                throw new ArgumentException("lamp cannot be null");
        }

        public void Delete(Guid id)
        {
            var lamp = GetById(id);

            if (lamp != null)
                _lamps.Remove(lamp);
        }

        public void Update(Lamp lamp)
        {
            //To do
        }
    }
}

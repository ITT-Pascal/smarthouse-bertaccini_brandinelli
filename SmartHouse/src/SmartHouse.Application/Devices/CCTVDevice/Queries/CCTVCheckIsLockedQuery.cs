using SmartHouse.Domain.CCTVDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.CCTVDevice.Queries
{
    public class CCTVCheckIsLockedQuery
    {
        private readonly ICCTVRepository _repository;

        public CCTVCheckIsLockedQuery(ICCTVRepository repos) { _repository = repos; }

        public bool Execute(Guid id)
        {
            bool islocked = new GetCCTVByIdQuery(_repository).Execute(id).IsLocked;
            if (islocked)
                return true;
            return false;
        }
    }
}

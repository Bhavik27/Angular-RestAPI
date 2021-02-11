using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Infrastructure.Models;

namespace WebAPI.Application.Interfaces
{
    public interface IRoleMasterService
    {
        public List<RoleMaster> GetRoles();
    }
}

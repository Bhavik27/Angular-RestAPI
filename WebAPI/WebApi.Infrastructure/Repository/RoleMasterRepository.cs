using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAPI.Infrastructure.context;
using WebAPI.Infrastructure.Interfaces;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Infrastructure.Repository
{
    public class RoleMasterRepository : IRoleMasterRepository
    {
        private WebDbContext _context;
        private readonly IActivityLogRepository _logRepository;
        public RoleMasterRepository(WebDbContext context, IActivityLogRepository logRepository)
        {
            _context = context;
            _logRepository = logRepository;
        }
        public List<VMRoleMaster> GetRoles(PageModel pageModel)
        {
            List<VMRoleMaster> data = new List<VMRoleMaster>();

            var data2 = _context.RoleMasters.ToList();
            int totalRecords = data.Count;

            data = (from d in data2
                    select new VMRoleMaster
                    {
                        RoleId = d.RoleId,
                        RoleName = d.RoleName,
                        TotalRecords = totalRecords
                    }).ToList();
            if(pageModel.SortOrder == "desc")
            {
                data = PagingUtils.OrderDesc<VMRoleMaster>(data.AsQueryable<VMRoleMaster>(), pageModel).ToList();
            }
            else
            {
                data = PagingUtils.OrderAsc<VMRoleMaster>(data.AsQueryable<VMRoleMaster>(), pageModel).ToList();
            }
            return data;
        }

        public int SaveRoles(VMRoleMaster roleMaster)
        {
            if (_context.RoleMasters.Where(u => u.RoleId == roleMaster.RoleId).FirstOrDefault() == null)
            {
                RoleMaster role = new RoleMaster();
                role.RoleName = roleMaster.RoleName;
                role.CreatedBy = 1;
                role.CreatedTime = DateTime.Now;
                role.UpdatedBy = null;
                role.UpdatedTime = null;
                _context.RoleMasters.Add(role);
                _context.SaveChanges();

                ActivityLog activity = new ActivityLog();
                activity.Activity = "New Role Created - " + roleMaster.RoleName;
                activity.ActivityType = "CREATE";
                _logRepository.SetActivityLog(activity);
            }
            else
            {
                var data = _context.RoleMasters.FirstOrDefault(u => u.RoleId == roleMaster.RoleId);
                data.RoleName = roleMaster.RoleName;
                data.UpdatedTime = DateTime.Now;
                data.UpdatedBy = 1;
                _context.RoleMasters.Update(data);
                _context.SaveChanges();

                ActivityLog activity = new ActivityLog();
                activity.Activity = "Role Updated - " + roleMaster.RoleName;
                activity.ActivityType = "UPDATE";
                _logRepository.SetActivityLog(activity);
            }
            return 1;
        }

        public List<VMRoleAccess> GeteRoleRights(int RoleID)
        {
            var data2 = (from RA in _context.RoleAccessMasters
                         join MM in _context.ModuleMasters on RA.ModuleName equals MM.ModuleName
                         where RA.RoleId == RoleID
                         select new VMRoleAccess
                         {
                             RoleAccessId = RA.RoleAccessId,
                             RoleId = RA.RoleId,
                             ModuleName = MM.ModuleName,
                             ViewAccess = RA.ViewAccess,
                             CreateAccess = RA.CreateAccess,
                             UpdateAccess = RA.UpdateAccess,
                             DeleteAccess = RA.DeleteAccess,
                             IsView = MM.IsView,
                             IsCreate = MM.IsCreate,
                             IsUpdate = MM.IsUpdate,
                             IsDelete = MM.IsDelete,
                         }).ToList();
            return data2;
        }

        public int SetRoleRights(List<VMRoleAccess> vMRoles, int RoleID)
        {
            foreach (var item in vMRoles)
            {
                RoleAccessMaster roleAccess = _context.RoleAccessMasters.Where(x => x.RoleId == item.RoleId && x.RoleAccessId == item.RoleAccessId).FirstOrDefault();
                roleAccess.ViewAccess = item.ViewAccess;
                roleAccess.CreateAccess = item.CreateAccess;
                roleAccess.UpdateAccess = item.UpdateAccess;
                roleAccess.DeleteAccess = item.DeleteAccess;
                roleAccess.UpdatedBy = 1;
                roleAccess.UpdatedTime = DateTime.Now;
                _context.RoleAccessMasters.Update(roleAccess);
                _context.SaveChanges();
            }
            return 0;
        }
    }
}

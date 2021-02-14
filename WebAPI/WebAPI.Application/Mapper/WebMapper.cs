using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Application.Mapper
{
    public class WebMapper:Profile
    {
        public WebMapper()
        {
            CreateMap<UserMaster, VMUserMaster>();
            CreateMap<RoleMaster, VMRoleMaster>();
            //CreateMap<VMUserMaster, UserMaster>();
        }
    }
}

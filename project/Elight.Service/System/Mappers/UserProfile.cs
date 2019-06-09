using AutoMapper;
using Elight.Entity;
using Elight.Service.System.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elight.Service.System.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Sys_User, UserGetListOutput>();
            CreateMap<UserUpdateInput, Sys_User>();
        }
    }
}

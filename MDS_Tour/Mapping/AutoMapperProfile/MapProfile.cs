﻿using AutoMapper;
using DTOLayer.DataTrabsferObjects.AnnouncementDTOs;
using DTOLayer.DataTrabsferObjects.AppUserDTOs;
using EntityLayer.Concrete;

namespace MDS_Tour.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDto, Announcement>();
            CreateMap<Announcement, AnnouncementAddDto>();

            CreateMap<AppUserRegisterDTO, AppUser>();
            CreateMap<AppUser,AppUserRegisterDTO>();

            CreateMap<AppUserLogInDTO, AppUser>();
            CreateMap<AppUser, AppUserLogInDTO>();
        }
    }
}

﻿using AutoMapper;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebApi.mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room, RoomAddDto>();

            CreateMap<RoomUpdateDto, Room>().ReverseMap();
        }
    }
}

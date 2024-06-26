﻿using AutoMapper;
using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ResultAuthorDto, UpdateAuthorDto>().ReverseMap();
            CreateMap<ResultBookDetailsDto, UpdateBookDto>().ReverseMap();
        }
    }
}

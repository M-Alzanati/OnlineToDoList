using System;
using System.Collections.Generic;
using AutoMapper;
using OnlineUserToDoList.Models;

namespace OnlineUserToDoList.App_Start
{
    public static class AutoMapping
    {
        private static MapperConfiguration _mapperConfiguration;
        private static IMapper _mapper;

        public static void CreateMapping()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ToDoBindingModel, ToDoModel>()
                    .ForPath(destination => destination.ToDoStatus.Id,
                        opt => opt.MapFrom(source => source.Status))
                    .ForPath(destination => destination.DueDate,
                        opt => opt.MapFrom(source => DateTime.Parse(source.DueDate)));

                cfg.CreateMap<ToDoModel, ToDoBindingModel>()
                    .ForPath(destination => destination.Status,
                        opt => opt.MapFrom(source => source.ToDoStatus.Id))
                    .ForPath(destination => destination.DueDate,
                        opt => opt.MapFrom(source => source.DueDate.ToShortDateString()));
            });
            _mapper = _mapperConfiguration.CreateMapper();
        }

        public static IMapper Mapper => _mapper;
    }
}
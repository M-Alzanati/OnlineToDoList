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
                    .ForMember(destination => destination.Id, opt => opt.MapFrom(source => source.Id))
                    .ForMember(destination => destination.Title, opt => opt.MapFrom(source => source.Title))
                    .ForMember(destination => destination.DueDate, opt => opt.MapFrom(source => source.DueDate));
            });
            _mapper = _mapperConfiguration.CreateMapper();
        }

        public static IMapper Mapper => _mapper;
    }
}
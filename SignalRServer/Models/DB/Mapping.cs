using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace SignalRServer.Models.DB
{
    public static class ConfigureServicesMapping
    {   
        public static void ConfigureServices(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dto => dto.Role, x => x.MapFrom(x => x.Role))
                .ForMember(dto => dto.Tasks, x => x.MapFrom(x => x.Tasks));
            
            CreateMap<RoleEmployee, RoleDTO>();
            CreateMap<TaskEmployee, TaskDTO>();

            CreateMap<TaskDTO, TaskEmployee>()
                .ForMember(task => task.Name, x=> x.MapFrom(x => x.Name))
                .ForMember(task => task.IdEmployee, x => x.MapFrom(x => x.IdEmployee));
        }
    }
}

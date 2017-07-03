using System;
using AutoMapper;
using Invoice.Core.Domain;
using Invoice.Infrastructure.DTO;

namespace Invoice.Infrastructure.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Customer, CustomerDto>();
            })
            .CreateMapper();
    }
}
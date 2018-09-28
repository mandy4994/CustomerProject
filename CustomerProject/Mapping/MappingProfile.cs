using AutoMapper;
using CustomerProject.Data;
using CustomerProject.Models;

namespace CustomerProject.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}

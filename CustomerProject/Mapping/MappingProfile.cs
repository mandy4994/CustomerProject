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
            CreateMap<CustomerViewModel, Customer>()
                .ForMember(
                dest => dest.CustCode, opt => opt.MapFrom(
                    vm => (vm.FirstName + vm.LastName + vm.DateOfBirth.ToString("yyyyMMdd")).ToLower()
                    )
                    );
        }
    }
}

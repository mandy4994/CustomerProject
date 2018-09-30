using AutoMapper;
using CustomerProject.Data;
using CustomerProject.Models;

namespace CustomerProject.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerListViewModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(c => c.FirstName + " " + c.LastName));
            CreateMap<CustomerViewModel, Customer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(
                            dest => dest.CustCode, opt => opt.ResolveUsing(vm =>
                            {
                                return (vm.DateOfBirth.HasValue) ?
                                (vm.FirstName + vm.LastName + vm.DateOfBirth.Value.ToString("yyyyMMdd")).ToLower() :
                                (vm.FirstName + vm.LastName).ToLower();
                            })
                    );
        }
    }
}

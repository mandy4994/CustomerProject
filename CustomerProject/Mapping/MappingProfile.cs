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

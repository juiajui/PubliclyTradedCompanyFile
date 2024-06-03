using AutoMapper;
using Gov_ListedCompany_API.BusinessModel;
using Gov_ListedCompany_API.DataModel;
using Gov_ListedCompany_API.ViewModel;

namespace Gov_ListedCompany_API.MapperProfile
{
    public class CompanyMapperProfile : Profile
    {
        public CompanyMapperProfile()
        {
            CreateMap<OperatingIncomeDo, OperatingIncomeBo>();
            CreateMap<OperatingIncomeBo, OperatingIncomeVo>();
            CreateMap<OperatingIncomeBo, OperatingIncomeDo>();
            CreateMap<OperatingIncomeVo, OperatingIncomeBo>();
        }
    }
}

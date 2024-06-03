using Gov_ListedCompany_API.BusinessModel;

namespace Gov_ListedCompany_API.Service.Interface
{
    public interface ICompanyService
    {
        public List<OperatingIncomeBo> GetCompanyData(string coNo);
        public bool AddCompanyData(OperatingIncomeBo data);

    }
}

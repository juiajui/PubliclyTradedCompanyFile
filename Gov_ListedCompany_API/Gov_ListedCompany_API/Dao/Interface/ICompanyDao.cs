using Gov_ListedCompany_API.DataModel;
using Gov_ListedCompany_API.ViewModel;

namespace Gov_ListedCompany_API.Dao.Interface
{
    public interface ICompanyDao
    {
        public List<OperatingIncomeDo> GetCompanyData(string coNo);
        public bool AddCompanyData(OperatingIncomeDo data);
    }
}

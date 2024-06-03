using AutoMapper;
using Gov_ListedCompany_API.BusinessModel;
using Gov_ListedCompany_API.Dao.Interface;
using Gov_ListedCompany_API.DataModel;
using Gov_ListedCompany_API.Service.Interface;

namespace Gov_ListedCompany_API.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyDao _companyDao;
        private readonly IMapper _mapper;


        public CompanyService(ICompanyDao companyDao, IMapper mapper)
        {
            _companyDao = companyDao;
            _mapper = mapper;
        }

        public List<OperatingIncomeBo> GetCompanyData(string coNo)
        {

            List<OperatingIncomeBo> operatingIncomeBo = _mapper.Map<List<OperatingIncomeBo>>(_companyDao.GetCompanyData(coNo));

            return operatingIncomeBo;
        }
        public bool AddCompanyData(OperatingIncomeBo data)
        {

            bool result = _companyDao.AddCompanyData(_mapper.Map<OperatingIncomeDo>(data));

            return result;
        }
    }
}

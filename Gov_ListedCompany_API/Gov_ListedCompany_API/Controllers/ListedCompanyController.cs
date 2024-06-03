using AutoMapper;
using Gov_ListedCompany_API.BusinessModel;
using Gov_ListedCompany_API.Service;
using Gov_ListedCompany_API.Service.Interface;
using Gov_ListedCompany_API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gov_ListedCompany_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListedCompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        private readonly ILogger<ListedCompanyController> _logger;

        public ListedCompanyController(ICompanyService companyService, IMapper mapper, ILogger<ListedCompanyController> logger)
        {
            _companyService = companyService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// 取得公司每月營業收入資料
        /// </summary>
        /// <param name="coNo">公司代號</param>
        /// <returns></returns>
        [HttpPost("GetListedCompanyRevenue")]
        public List<OperatingIncomeVo> GetListedCompanyRevenue(string? coNo)
        {
            List<OperatingIncomeVo> result = new List<OperatingIncomeVo>();

            try
            {
                result = _mapper.Map<List<OperatingIncomeVo>>(_companyService.GetCompanyData(string.Empty));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetListedCompanyRevenue");
            }
            return result;
        }

        [HttpPost("AddListedCompanyRevenue")]
        public bool AddListedCompanyRevenue(OperatingIncomeVo data)
        {
            bool result = false;

            try
            {
                result = _companyService.AddCompanyData(_mapper.Map<OperatingIncomeBo>(data));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AddListedCompanyRevenue");
            }

            return result;
        }
    }
}

using DataManager.Model;
using DataManger;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Xml.Linq;

namespace APITechTest.Controllers
{
    /* 
     *  Would suggest:
     *  1 using an API key or API token to authenticate usage 
     *  2 logging all responses 
     *  3 Updating response status code 
     *  4 data is returned by default in json format in dotnet core 6
     */

    [ApiController]
    [Route("[controller]/[action]")]
    public class MarkelController : ControllerBase
    {

        IDataRepository _dataRepository;
        ILogger _logger;

        public MarkelController(ILogger<MarkelController> logger, IDataRepository dataRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
        }

        [HttpGet()]
        public Company GetCompanyData(string Name)
        {
            return _dataRepository.CompanyData(Name);
        }

        [HttpGet()]
        public IEnumerable<string> GetCompanyClaims(int CompanyId)
        {
            return _dataRepository.CompanyClaims(CompanyId);
        }


        [HttpGet()]
        public Claim GetCompanyClaimsDetails(string UCR)
        {
            return _dataRepository.CompanyClaimsDetails(UCR);
        }

        [HttpPost()]
        public bool UpdateCompanyClaimsDetails([FromBody] Claim claim)
        {
            return _dataRepository.UpdateCompanyClaimsDetails(claim);

        }

    }
}
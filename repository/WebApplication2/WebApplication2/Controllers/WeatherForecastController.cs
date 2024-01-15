using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        public WeatherForecastController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        [HttpGet]
        public IEnumerable<string> Get() 
        {
            //var domicAccount = _repoWrapper.Account.FindByCondition(x => x.AccountType.Equals("Domics"));
            var owner = _repoWrapper.Owner.FindAll();
            return new string[] { "value1", "value2" };
        }
    }
}
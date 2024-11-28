using DbOperationWithEfCode.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationWithEfCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public CurrencyController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
            //constructor injecting of teh dependency (AppDbContext)
        }
        [HttpGet("")]
        //saying that we are perfroming the Get Operation

        public async Task<IActionResult>  GetAllCurrencies()
        {
            //var res = await _appDbContext.CurrencyTypes.ToListAsync();

            //every linq query can be written in 2 forms

            var res =await  (from CurrencyType in _appDbContext.CurrencyTypes
                       select CurrencyType).ToListAsync();
            return Ok(res);
        }
        //here we will perform database operations
    }
}

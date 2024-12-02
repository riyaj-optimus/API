using System.ComponentModel;
using System.Formats.Asn1;
using DbOperationWithEfCode.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationWithEfCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController(AppDbContext appDbContext) : ControllerBase
    {
        //primary constructor
        private readonly AppDbContext _appDbContext=appDbContext;
       
        [HttpGet("")]
        //saying that we are perfroming the Get Operation

        public async Task<IActionResult> GetAllCurrencies()
        {
            //var res = await _appDbContext.CurrencyTypes.ToListAsync();

            //every linq query can be written in 2 forms

            var res = await (from CurrencyType in _appDbContext.CurrencyTypes
                             select CurrencyType).ToListAsync();
            return Ok(res);
        }
        //here we will perform database operations

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurrencyTypeById([FromRoute] int id)
        {
            var resi = await _appDbContext.CurrencyTypes.SingleOrDefaultAsync(c => c.Id == id);
            return Ok(resi);
        }
        //we need limited columns : specific no.

        [HttpPost("specific_cols")]
        public async Task<IActionResult> GetSpecificCols()
        {
            var res = await _appDbContext.CurrencyTypes.Select(x=>new CurrencyType()
            {
                Id = x.Id
            }).ToListAsync();
            return Ok(res);

            //or
        }
        //adding single record at a time
        [HttpPost("Adding/data")]
        public async Task<IActionResult> AddingCurrencyTypes([FromBody] CurrencyType ct)
        {
            _appDbContext.CurrencyTypes.Add(ct);
            await _appDbContext.SaveChangesAsync();//used to maek the changes in the DB
            return Ok(ct);    

        }

        //Adding multiple records at once
        [HttpPost("multi/rec/insertion")]
        public async Task<IActionResult> PuttingAllTheRec([FromBody] List<CurrencyType> lili)
        {
            _appDbContext.CurrencyTypes.AddRange(lili);
            await _appDbContext.SaveChangesAsync();
            return Ok(lili);
        }
        
    }
}

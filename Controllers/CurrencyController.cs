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

        //updating the record

        [HttpPut("{bkId}")]
        public async Task<IActionResult> UpdatingCurrencyTypes([FromRoute] int bkId, [FromQuery] CurrencyType ct)
        {
            var currData = _appDbContext.CurrencyTypes.FirstOrDefault(x => x.Id == bkId);
            if(currData == null)
            {
                return NotFound();

            }
            currData.Currency= ct.Currency;

            await _appDbContext.SaveChangesAsync();
            return Ok(ct);


        }

        //updating a recors in 1 hit
        [HttpPut("")]
        public async Task<IActionResult> UpdatingCurrencyTypesWithSingleQuery([FromBody] CurrencyType ct)
        {
            _appDbContext.CurrencyTypes.Update(ct);
            await _appDbContext.SaveChangesAsync();
            return Ok(ct);
        }

        //updating a recors in 1 hit c
        [HttpPut("detials")]
        public async Task<IActionResult> UpdatingCurrencyTypesWithSingleQueryMeth([FromBody] CurrencyType ct)
        {
            _appDbContext.Entry(ct).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return Ok(ct);
        }

        //updating multiple records in a table in 1 go
        [HttpPut("bulk/Updating")]
        public async Task<IActionResult> UpdatingInBulk()
        {
            var curr = _appDbContext.CurrencyTypes.ToList();
            foreach(var i in curr)
            {
                i.Currency = "Updated";
                //the drawback of this method is : this will hit the DB n no. of times

            }
            await _appDbContext.SaveChangesAsync();
            return Ok(curr);
        }

        //updating multiple  records in 1 go without iterating 


    }
}

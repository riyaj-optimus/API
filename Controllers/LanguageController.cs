using DbOperationWithEfCode.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationWithEfCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public LanguageController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        [HttpGet("")]

        public async Task<IActionResult> GetAllLanguage()
        {
            var lang= await _appDbContext.Languages.FirstAsync();
            await _appDbContext.Entry(lang).Collection(x=>x.Books).Query().LoadAsync();
            //var res = await _appDbContext.Languages.ToListAsync();
           
            return Ok(lang);
        }
        [HttpGet("uhm")]
        public async Task<IActionResult> GetAllLanguages()
        {
            var domainList = await _appDbContext.Languages.Include(x => x.Books).ThenInclude(x => x.Author).ToListAsync();
            //var res = await _appDbContext.Languages.ToListAsync();

            return Ok(domainList);
        }

        //updating records in bulk : hitting the DB in once
        [HttpPut("Bulk")]
        public async Task<IActionResult> UpdateRec()
        {
            await _appDbContext.Languages
                .Where(x => x.Id % 2 == 0)
                .ExecuteUpdateAsync(y =>
                y.SetProperty(p=>p.Title,p => p.Title + " Updated")
                .SetProperty(p=>p.Description,p => p.Description + " some new"));

            return Ok();

        }
        //deleting  a record
        [HttpDelete("{langId}")]
        public async Task<IActionResult> DeleteRec([FromRoute] int langId)
        {
            var lang = await _appDbContext.Languages.FirstOrDefaultAsync(x=>x.Id==langId);
            if (lang == null)
            {
                return NotFound();
            }

            _appDbContext.Languages.Remove(lang);
            await _appDbContext.SaveChangesAsync();
            return Ok();
        }
        //another way of deleting
        [HttpDelete("{bid}/Deleted")]
        public async Task<IActionResult> deletedFromLanguages([FromRoute] int bid)
        {
            var lala = new Language { Id = bid };
            _appDbContext.Entry(lala).State = EntityState.Deleted;
            await _appDbContext.SaveChangesAsync();
            return Ok();
        }
        //deleting multiple records
        [HttpDelete("deletion/Bulk")]
        public async Task<IActionResult> bulkDeletion()
        {
            var laa = _appDbContext.Languages.Where(i => i.Id == 3).ExecuteDeleteAsync();
            return Ok();
         
        }
        //deleting multiple records
        [HttpDelete("deletion/Bulk/a")]
        public async Task<IActionResult> bulkDeletiona()
        {
            var laa = _appDbContext.Languages.Where(i => i.Id == 3);
            _appDbContext.Languages.RemoveRange(laa);
            await _appDbContext.SaveChangesAsync();
            return Ok();


        }



    }
}

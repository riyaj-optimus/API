using DbOperationWithEfCode.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationWithEfCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookPriceController : ControllerBase
    {
        private readonly AppDbContext _appdbcontext;

        public BookPriceController(AppDbContext appdbcontext)
        {
            this._appdbcontext = appdbcontext;
        }

        [HttpGet("")]

        public async Task<IActionResult> GetAllBookPrice()
        {
            var result = await _appdbcontext.BookPrices.ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetBookPriceByID([FromRoute] int id)
        {
            var res = await _appdbcontext.BookPrices.FindAsync(id);
            return Ok(res);
        }
    }
}

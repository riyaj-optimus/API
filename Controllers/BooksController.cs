using DbOperationWithEfCode.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationWithEfCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public BooksController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var res = await _appDbContext.Books.ToListAsync();
            return Ok(res);
        }
    }
}

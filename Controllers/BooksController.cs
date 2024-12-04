using DbOperationWithEfCode.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationWithEfCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(AppDbContext appDbContext) : ControllerBase
    {
        private readonly AppDbContext _appDbContext=appDbContext;
        
        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var res = await _appDbContext.Books.ToListAsync();
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        //to access a single element
        public async Task<IActionResult> GetBookByIdAsync([FromRoute] int id)
        {
            var res = await _appDbContext.Books.FindAsync(id);
            return Ok(res);
        }

        //accesing without the pk
        [HttpGet("{name}/name")]
        //to access a single element
        public async Task<IActionResult> GetBookByAsync([FromRoute] string name)
        {
            var res = await _appDbContext.Books.FindAsync(name);
            return Ok(res);
        }

        //accessing single record using more than 1 value
        [HttpGet("{name}")]
        public async Task<IActionResult> GetBookByNameAsync([FromRoute] string name, [FromQuery] string ? desc )
        {
            var res = await _appDbContext.Books
                .FirstOrDefaultAsync(x => x.Title == name && x.Description == desc);//we need to handle the null scenario here as well
            return Ok(res);
        }

        //accessing multiple records at once
        [HttpGet("similar/{details}")]
        public async Task<IActionResult> GetSimilar([FromRoute] string details)
        {
            var res = await _appDbContext.Books.Where(x => x.Title == details).ToListAsync();
                return Ok(res);
        }

        //accessing record using a list (multiple values at once
        List<int> ids = new List<int>() { 1,5,2,3,7};
        [HttpGet("all")]//hardcoding

        public async Task<IActionResult> GetdetailsUsingId()
        {
            var res = await _appDbContext.Books.Where(x => ids.Contains(x.Id)).ToListAsync();
            return Ok(res);
        }

        //doing the exact samething as above using HTTPPost
        [HttpPost("Details /all")]
        public async Task<IActionResult> GetAllList([FromBody] List<int> ids)
        {
            var re = await _appDbContext.Books.Where(x=>ids.Contains(x.Id)).ToListAsync();
            return Ok(re);
        }

        //inserting records in multiple tables at once.
        [HttpPost("Deleting/The/records")]
       public async Task<IActionResult> InsertingRecs([FromBody] Book model)
        {

            var data = new Author() { 
                Name="Harsh",
                Email="pooo@gmail.com"
            };
            model.Author = data;
            _appDbContext.Books.Add(model);
            await _appDbContext.SaveChangesAsync();
            return Ok(model);
        }
       

    }
}

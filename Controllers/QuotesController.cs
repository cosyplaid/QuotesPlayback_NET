using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace QuotesPlayback_NET.Controllers
{
    [ApiController]
    [Route("quotes")]
    public class QuotesController : ControllerBase
    {
        private readonly QuoteContext _context;

        public QuotesController(QuoteContext context)
        {
            _context = context;
        }

        [HttpGet("GetRandomQuote")]
        public async Task<ActionResult<Quote>> GetRandomQuote()
        {
            var count = await _context.Quotes.CountAsync();
            if (count == 0)
                return NotFound();

            var index = new Random().Next(0, count);
            var quote = await _context.Quotes.Skip(index).FirstOrDefaultAsync();

            return Ok(quote);
        }

        //private List<Quote> _quotes =
        //[
        //    new Quote {Id = 1, QuoteText = "Sample text", QuoteImage ="url"},
        //    new Quote {Id = 2, QuoteText = "Sample text 2", QuoteImage ="url"},
        //    new Quote {Id = 3, QuoteText = "Sample text 3", QuoteImage ="url"},
        //    new Quote {Id = 4, QuoteText = "Sample text 4", QuoteImage ="url"}
        //];

        //[HttpGet("GetQuoteByID")]
        //public IActionResult GetQuoteByID([FromQuery] int orderId)
        //{
        //    var quote = _quotes.FirstOrDefault(x => x.Id == orderId);

        //    return Ok(quote);
        //}
    }
}



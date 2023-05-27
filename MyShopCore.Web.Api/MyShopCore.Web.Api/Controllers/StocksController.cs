using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShopCore.Web.Api.Models.Products;
using MyShopCore.Web.Api.Models.Stocks;
using MyShopCore.Web.Api.Services.Foundations.Products;
using MyShopCore.Web.Api.Services.Foundations.Stocks;

namespace MyShopCore.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {

        private readonly IStockService stockService;
        public StocksController(IStockService stockService)
        {
            this.stockService = stockService;
        }

        [HttpGet]
        public IActionResult GetActionResult()
        {
            var stocks = this.stockService.RetrieveAllStocks().ToList();
            return Ok(stocks);
        }

        [HttpGet("{id}", Name = "GetSingleStock")]
        public async ValueTask<IActionResult> GetStockAsync(Guid id)
        {
            var stocks = await this.stockService.RetrieveStockByIdAsync(id);

            if (stocks is null)
            {
                return NotFound();
            }
            return Ok(stocks);
        }
        [HttpPost]
        public async ValueTask<IActionResult> PostStock([FromBody] Stock stock)
        {
            var newStock = await this.stockService.AddStockAsync(stock);

            return Created("GetSingleStock", newStock);
        }
        [HttpPut]

        public async ValueTask<IActionResult> PutStock([FromBody] Stock stock)
        {
            var currentStock = await this.stockService.RetrieveStockByIdAsync(stock.Id);

            if (currentStock is null)
            {
                return NotFound();
            }

            var updatedStock = await this.stockService.ModifyStockAsync(stock);
            return Ok(updatedStock);
        }
        [HttpDelete]

        public async ValueTask<IActionResult> DeleteProduct(Guid id)
        {
            var currentStock = await this.stockService.RetrieveStockByIdAsync(id);

            if (currentStock is null)
            {
                return NotFound();
            }
            var deletedStock = await this.stockService.RemoveStockAsync(currentStock);

            return NoContent();
        }
    }
}

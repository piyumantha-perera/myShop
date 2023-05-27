using Microsoft.EntityFrameworkCore;
using MyShopCore.Web.Api.Models.Products;
using MyShopCore.Web.Api.Models.Stocks;

namespace MyShopCore.Web.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Stock> Stocks { get; set; }


        public async ValueTask<Stock> InsertStockAsync(Stock stock)
        {

            this.Entry(stock).State = EntityState.Added;
            await this.SaveChangesAsync();

            return stock;
        }
        public IQueryable<Stock> SelectAllStocks()
        {
            return this.Stocks.AsQueryable();
        }
        public async ValueTask<Stock> SelectStockByIdAsync(Guid stockId)
        {
            return await this.Stocks.FindAsync(stockId);
        }
        public async ValueTask<Stock> UpdateStockAsync(Stock stock)
        {
            this.Entry(stock).State = EntityState.Modified;
            await this.SaveChangesAsync();

            return stock;
        }
        public async ValueTask<Stock> DeleteStockAsync(Stock stock)
        {
            this.Entry(stock).State = EntityState.Deleted;
            await this.SaveChangesAsync();

            return stock;
        }
    }
}

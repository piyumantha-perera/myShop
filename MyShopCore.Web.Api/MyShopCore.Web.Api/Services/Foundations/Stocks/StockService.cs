using MyShopCore.Web.Api.Brokers.DateTimes;
using MyShopCore.Web.Api.Brokers.Loggings;
using MyShopCore.Web.Api.Brokers.Storages;
using MyShopCore.Web.Api.Models.Products;
using MyShopCore.Web.Api.Models.Stocks;

namespace MyShopCore.Web.Api.Services.Foundations.Stocks
{
    public class StockService : IStockService
    {

        private readonly IStorageBroker storagerBrokker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        public StockService(IStorageBroker storagerBrokker, ILoggingBroker loggingBroker
            , IDateTimeBroker dateTimeBroker)
        {
            this.storagerBrokker = storagerBrokker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public async ValueTask<Stock> AddStockAsync(Stock stock)
        {
            this.loggingBroker.LogInformation($"{stock.Id} added");

            stock.Id = Guid.NewGuid();
            stock.Created = this.dateTimeBroker.getCurrentDateTime();
            stock.CreatedBy = Guid.NewGuid();

            return await this.storagerBrokker.InsertStockAsync(stock);
        }

        public async ValueTask<Stock> ModifyStockAsync(Stock stock)
        {
            this.loggingBroker.LogInformation($"{stock.Id} modified");

            stock.Updated = this.dateTimeBroker.getCurrentDateTime();
            stock.UpdatedBy = Guid.NewGuid();

            return await this.storagerBrokker.UpdateStockAsync(stock);
        }

        public async ValueTask<Stock> RemoveStockAsync(Stock stock)
        {
            this.loggingBroker.LogInformation($"{stock.Id} removed");
            return await this.storagerBrokker.DeleteStockAsync(stock);
        }

        public IQueryable<Stock> RetrieveAllStocks()
        {
            return this.storagerBrokker.SelectAllStocks();
        }

        public async ValueTask<Stock> RetrieveStockByIdAsync(Guid stockId)
        {
            return await this.storagerBrokker.SelectStockByIdAsync(stockId);
        }
    }
}

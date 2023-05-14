using MyShopCore.Web.Api.Brokers.DateTimes;
using MyShopCore.Web.Api.Brokers.Loggings;
using MyShopCore.Web.Api.Brokers.Storages;
using MyShopCore.Web.Api.Models.Products;

namespace MyShopCore.Web.Api.Services.Foundations.Products
{
    public class ProductService : IProductService
    {
        private readonly IStorageBroker storagerBrokker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        public ProductService(IStorageBroker storagerBrokker, ILoggingBroker loggingBroker
            , IDateTimeBroker dateTimeBroker)
        {
            this.storagerBrokker = storagerBrokker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

       
        public async ValueTask<Product> AddProductAsync(Product product)
        {
            this.loggingBroker.LogInformation($"{product.Title} added");

            product.Created =this.dateTimeBroker.getCurrentDateTime();
            product.CreatedBy = Guid.NewGuid();

            return await this.storagerBrokker.InsertProductAsync( product );
        }

        public async ValueTask<Product> ModifyProductAsync(Product product)
        {
            this.loggingBroker.LogInformation($"{product.Title} modified");

            product.Updated = this.dateTimeBroker.getCurrentDateTime();
            product.UpdatedBy = Guid.NewGuid();

            return await this.storagerBrokker.UpdateProductAsync(product);
        }

        public async ValueTask<Product> RemoveProductAsync(Product product)
        {
            this.loggingBroker.LogInformation($"{product.Title} removed");
            return await this.storagerBrokker.DeleteProductAsync(product);
        }

        public IQueryable<Product> RetrieveAllProducts()
        {
            return this.storagerBrokker.SelectAllProducts();
        }

        public async ValueTask<Product> RetrieveProductByIdAsync(Guid productId)
        {
          return await this.storagerBrokker.SelectProductByIdAsync(productId);
        }
    }
}

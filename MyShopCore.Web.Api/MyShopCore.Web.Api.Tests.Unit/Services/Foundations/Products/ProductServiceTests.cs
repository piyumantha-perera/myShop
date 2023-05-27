using FluentAssertions;
using Moq;
using MyShopCore.Web.Api.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyShopCore.Web.Api.Tests.Unit.Services.Foundations.Products
{
    public partial class ProductServiceTests
    {
        [Fact]
        public async ValueTask ShouldAddProductAsync()
        {

            //given
            

            DateTimeOffset randomDateTime = DateTimeOffset.Now;
            DateTimeOffset dateTime = randomDateTime;

            Product randomProduct = new Product();

            randomProduct.Id = Guid.NewGuid();
            randomProduct.CostPrice = 100;
            randomProduct.SellingPrice = 120;
            randomProduct.Title = "Unit Test Product";
            randomProduct.Description = "Description";
            randomProduct.Created = dateTime;
            randomProduct.CreatedBy = Guid.NewGuid();
            randomProduct.OrderAfter = 20;

            Product inputProduct = randomProduct;
            Product storageProduct = inputProduct;
            Product expectedProduct = storageProduct;

            // this method create mock db and test without accessing actual DB
            this.dateTimeBrokerMock.Setup(broker =>broker.getCurrentDateTime()).Returns(dateTime);

            this.storageBrokerMock.Setup(broker => broker.InsertProductAsync
            (inputProduct)).ReturnsAsync(storageProduct);

            //when

            Product actualProduct = await this.productService.AddProductAsync(inputProduct);

            //then

            actualProduct.Should().BeEquivalentTo(expectedProduct);

        }
    }
}

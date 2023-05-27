namespace MyShopCore.Web.Api.Models.Stocks
{
    public class Stock : Audit

    {

        public Guid Id { get; set; }
        public string ProductId { get; set; }
        public string CurrentStock { get; set; }


    }
}

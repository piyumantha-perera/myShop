namespace MyShopCore.Web.Api.Models.Products.Exceptions
{
    public class InvalidProductIdException :Exception
    {
        public InvalidProductIdException() :  base(message:"Product Id is null") 
        {
            
        }
    }
}

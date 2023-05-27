namespace MyShopCore.Web.Api.Models.Products.Exceptions
{

    //Added exception to direive class
    public class NullProductException : Exception
    {
        //ctor
        //parameter passing when order is unkowing
        public NullProductException()   
            :base(message:"Product is null") 
        {
            
        }
    }
}

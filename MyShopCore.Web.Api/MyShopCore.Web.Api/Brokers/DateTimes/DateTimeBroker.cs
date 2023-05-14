namespace MyShopCore.Web.Api.Brokers.DateTimes
{
    public class DateTimeBroker : IDateTimeBroker
    {
        public DateTimeOffset getCurrentDateTime() => DateTime.UtcNow;
        
    }
}

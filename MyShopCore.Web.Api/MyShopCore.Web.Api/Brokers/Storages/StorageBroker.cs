using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MyShopCore.Web.Api.Brokers.Storages
{
    public partial class StorageBroker : DbContext,IStorageBroker
    {
        private readonly IConfiguration configuration;

        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
          
        }

        //connect to the db
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = this.configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}

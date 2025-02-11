using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;
using ProductApi.Data;

namespace ProductApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<IConfiguration>(Configuration);
            services.AddDbContext<ProductDbContext>(options =>
                options.UseSqlServer());  ////Configuration.GetConnectionString("DefaultConnection")
            services.AddControllers();
        }
    }
}

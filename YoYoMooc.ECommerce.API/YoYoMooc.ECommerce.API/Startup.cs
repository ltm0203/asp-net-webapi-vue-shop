namespace YoYoMooc.ECommerce.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }
    }
}

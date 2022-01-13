namespace vuedemo
{
    public class Startup
    {
        private IWebHostEnvironment _env;
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            this._env = env;
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();


        }
        public void Configure(IApplicationBuilder app)
        {
            //如果环境是Development serve Developer Exception Page
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }

    }
}

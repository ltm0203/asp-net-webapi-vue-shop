
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

using System.Reflection;

using YoYoMooc.ECommerce.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 builder.Services.AddControllers();

// 注册Swagger生成器，定义一个或多个Swagger文档
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "YoYoMooc.ECommerce.API", Version = "v1",
        
        Description = "一个基于ASP.NET Core WebAPI的电商案例项目",
        TermsOfService = new Uri("https://www.yoyomooc.com"),
        Contact = new OpenApiContact
        {
            Name = "YoYoMooc.ECommerce项目联系方式",
            Url = new Uri("https://www.yoyomooc.com")
        },
        License = new OpenApiLicense
        {
            Name = "YoYoMooc.ECommerce.API 许可证信息",
            Url = new Uri("https://www.yoyomooc.com")
        }

    });

    c.SwaggerDoc("v2", new OpenApiInfo { Title = "YoYoMooc.ECommerce API - V2", Version = "v2" });

    // 会使用 System.Reflection; 命名空间，进行反射获取项目文件
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

});


builder.Services.AddSingleton<IProductRepository, MockProductRepository>();

var app = builder.Build();
// Configure the HTTP request pipeline.
 app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    // 启用中间件Swagger
    app.UseSwagger();
    //启用中间件Swagger -ui服务，它需要与Swagger配置在一起
    app.UseSwaggerUI(c =>
    {
        c.InjectStylesheet("/swagger-ui/custom.css");
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "API V2");
    });
}
 
//启用路由服务
app.UseRouting();
//配置路由规则
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();
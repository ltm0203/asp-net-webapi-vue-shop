
using Microsoft.OpenApi.Models;

using YoYoMooc.ECommerce.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 builder.Services.AddControllers();

// 注册Swagger生成器，定义一个或多个Swagger文档
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "YoYoMooc.ECommerce.API", Version = "v1" });
});


builder.Services.AddSingleton<IProductRepository, MockProductRepository>();

var app = builder.Build();
// Configure the HTTP request pipeline.

// 启用中间件Swagger
app.UseSwagger();
//启用中间件Swagger -ui服务，它需要与Swagger配置在一起
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
});



////添加身份认证中间件
//app.UseAuthentication();
app.UseRouting();
////添加授权中间件
//app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

//app.MapControllers();
app.Run();
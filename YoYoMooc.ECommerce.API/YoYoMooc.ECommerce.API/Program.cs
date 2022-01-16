
using Microsoft.OpenApi.Models;

using YoYoMooc.ECommerce.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 builder.Services.AddControllers();

// ע��Swagger������������һ������Swagger�ĵ�
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "YoYoMooc.ECommerce.API", Version = "v1" });
});


builder.Services.AddSingleton<IProductRepository, MockProductRepository>();

var app = builder.Build();
// Configure the HTTP request pipeline.

// �����м��Swagger
app.UseSwagger();
//�����м��Swagger -ui��������Ҫ��Swagger������һ��
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
});



////��������֤�м��
//app.UseAuthentication();
app.UseRouting();
////�����Ȩ�м��
//app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

//app.MapControllers();
app.Run();
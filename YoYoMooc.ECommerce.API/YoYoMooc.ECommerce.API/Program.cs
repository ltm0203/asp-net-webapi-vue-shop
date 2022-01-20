
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

using System.Reflection;

using YoYoMooc.ECommerce.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 builder.Services.AddControllers();

// ע��Swagger������������һ������Swagger�ĵ�
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "YoYoMooc.ECommerce.API", Version = "v1",
        
        Description = "һ������ASP.NET Core WebAPI�ĵ��̰�����Ŀ",
        TermsOfService = new Uri("https://www.yoyomooc.com"),
        Contact = new OpenApiContact
        {
            Name = "YoYoMooc.ECommerce��Ŀ��ϵ��ʽ",
            Url = new Uri("https://www.yoyomooc.com")
        },
        License = new OpenApiLicense
        {
            Name = "YoYoMooc.ECommerce.API ���֤��Ϣ",
            Url = new Uri("https://www.yoyomooc.com")
        }

    });

    c.SwaggerDoc("v2", new OpenApiInfo { Title = "YoYoMooc.ECommerce API - V2", Version = "v2" });

    // ��ʹ�� System.Reflection; �����ռ䣬���з����ȡ��Ŀ�ļ�
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

});


builder.Services.AddSingleton<IProductRepository, MockProductRepository>();

var app = builder.Build();
// Configure the HTTP request pipeline.
 app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    // �����м��Swagger
    app.UseSwagger();
    //�����м��Swagger -ui��������Ҫ��Swagger������һ��
    app.UseSwaggerUI(c =>
    {
        c.InjectStylesheet("/swagger-ui/custom.css");
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "API V2");
    });
}
 
//����·�ɷ���
app.UseRouting();
//����·�ɹ���
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();
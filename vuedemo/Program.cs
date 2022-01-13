var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

   
});

app.Run();

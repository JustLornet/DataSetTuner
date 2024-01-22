var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(o =>
{
    var basePath = AppContext.BaseDirectory;
    var xmlPath = Path.Combine(basePath, "ApiGateway.xml");
    o.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseSwagger().UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}");

app.Run();

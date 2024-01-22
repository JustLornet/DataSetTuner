using ImageResizeService.Rabbit;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var consumer = new RabbitMqConsumer();

app.Run();
using System.Net.WebSockets;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");



app.Use(async (context, next) =>
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        WebSocket ws = await context.WebSockets.AcceptWebSocketAsync();
        Console.WriteLine("Connected");
    }
    else
    {
        await next();
    }
});


app.UseWebSockets();
app.Run();

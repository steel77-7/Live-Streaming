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


async Task Listner(WebSocket ws)
{

    while (true)
    {

        if (ws.State == WebSocketState.Closed) break;
        //either use a singelton of the sockethelper or another way to use the socket 
    }

}

app.UseWebSockets();
app.Run();

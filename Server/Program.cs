using System.Net.WebSockets;
using Server.Api.SocketHelper;
using System.Net;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<SocketHelper>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:5173") 
               .AllowAnyMethod() 
               .AllowAnyHeader() 
               .AllowCredentials();
    });
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

SocketHelper webSoc = new SocketHelper();



var webSocketOptions = new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromMinutes(2)
};
app.UseWebSockets(webSocketOptions);
/* app.Use(async (context, next) =>
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        WebSocket ws = await context.WebSockets.AcceptWebSocketAsync();
        Console.WriteLine("Connected");
        await SocketListener(ws);
    }
    else
    {
        await next();
    }
}); */


/* app.Map("/ws",async (context)=> 
{
    if( context.WebSockets.IsWebSocketRequest){ 
        using var ws = await context.WebSockets.AcceptWebSocketAsync();
        Console.WriteLine("Connected");
        await SocketListener(ws);
    }
    else{ 
          context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }
}); */

app.Map("/ws", async (context) =>
{
    //var buffer = new byte[1024 * 4];
    if (context.WebSockets.IsWebSocketRequest)
    {
       // Console.WriteLine("Connected");
        using var ws = await context.WebSockets.AcceptWebSocketAsync();

      //  string userId = context.Request.Query["userId"];
      //  string roomId = context.Request.Query["roomId"];

       /*  if (userId == null) { 
            Console.Write("empty");
            return; } */

        //rooms.Add(ws);
        // SocketHelper Ws = new SocketHelper();
        // await Ws.HandleSocketConnection(ws);\
        //pushing the new user to room 
        await SocketListener(ws);
    }
    else
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }
});

async Task SocketListener(WebSocket ws)
{
    while (true)
    {
        if (ws.State == WebSocketState.Closed) break;
        await webSoc.RecieveMessageAsync(ws);
        //either use a singelton of the sockethelper or another way to use the socket
    }
   await  webSoc.CloseConnection(ws);
}

app.UseCors("MyCorsPolicy");
//app.UseWebSockets();
app.Run();

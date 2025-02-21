using System.Net.WebSockets;
using System.Text;
using Server.Api.Utils;
using Server.Api.Dtos;

namespace Server.Api.SocketHelper;

public class SocketHelper
{
    private byte[] buffer = new byte[1024 * 4];
    public async Task RecieveMessageAsync(WebSocket ws)
    {
        if (ws.State != WebSocketState.Open) return;
        var res = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        if (res.MessageType != WebSocketMessageType.Text) return;

        //converting the result to ta string
        var mess = Encoding.UTF8.GetString(buffer, 0, res.Count);
        Console.WriteLine("Message is : " + mess);
        //now pass the messsage the message to the JSON deserializer 
        var rawData = new Deserializer(mess);
        var data = rawData.Decode();
        await HandleMessageAsync(ws, data);

    }
    public async Task HandleMessageAsync(WebSocket ws, Message mess)
    {
        if (ws.State != WebSocketState.Open) return;
        switch (mess.Type)
        { //dunno what to do with these rn ......
            case "message": //stream to the rtmp ??.....but this is 
                Console.WriteLine("Message");
                break;
            case "stream":
                Console.WriteLine("Stream");
                break;
        }
    }

     public async Task CloseConnection(WebSocket ws)
    {

        Console.WriteLine("Connection closed");
        await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
        ws.Dispose();
    }


}

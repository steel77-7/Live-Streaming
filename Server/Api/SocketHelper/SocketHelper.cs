using System.Net.WebSockets;
using System.Text;
using System.Diagnostics;
using Server.Api.Utils;
using Server.Api.Dtos;

namespace Server.Api.SocketHelper;

public class SocketHelper
{
    private byte[] buffer = new byte[1024 * 4];

    public Process ffmpegProcess;
    public Stream ffmpegInputStream;
    public async Task RecieveMessageAsync(WebSocket ws)
    {
        if (ws.State != WebSocketState.Open) return;
        var res = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        if (res.MessageType == WebSocketMessageType.Text)
        {
            //converting the result to ta string
            var mess = Encoding.UTF8.GetString(buffer, 0, res.Count);
            Console.WriteLine("Message is : " + mess);
            //now pass the messsage the message to the JSON deserializer 
            var rawData = new Deserializer(mess);
            var data = rawData.Decode();
            await HandleMessageAsync(ws, data);
        }
        else if (res.MessageType == WebSocketMessageType.Binary)
        {
           // Console.WriteLine("binary recieved");
            await ffmpegInputStream.WriteAsync(buffer, 0, res.Count);
            await ffmpegInputStream.FlushAsync();
        }

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
                //send the stream to the nginx for now....
                Console.WriteLine("Stream data ::" + mess.Payload.Stream);

                break;
        }
    }


    public void StartFFmpeg()
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = "ffmpeg",
            Arguments = "-f webm -i pipe:0 -c:v libx264 -preset ultrafast -f flv rtmp://localhost/live/stream",
            RedirectStandardInput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        ffmpegProcess = new Process { StartInfo = startInfo };
        ffmpegProcess.Start();
        ffmpegInputStream = ffmpegProcess.StandardInput.BaseStream;
    }

    public async Task CloseConnection(WebSocket ws)
    {

        Console.WriteLine("Connection closed");
        await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
        ws.Dispose();
    }


}

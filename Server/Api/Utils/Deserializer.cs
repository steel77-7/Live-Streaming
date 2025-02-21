using System.Text.Json;
using Server.Api.Dtos;
namespace Server.Api.Utils;

public class Deserializer
{
    private string encodedData;

    public Deserializer(string data)
    {
        encodedData = data;
    }
    public Message Decode()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            AllowTrailingCommas = true
        };
        try
        {
            var decodedData = JsonSerializer.Deserialize<Message>(encodedData, options);
            if (decodedData == null)
            {
                throw new Exception("Json data was not serialized in Message.cs");
            }
            return decodedData;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception occured : " + ex);
            return new Message();
        }
    }
}

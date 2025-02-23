namespace Server.Api.Dtos;

public class Message
{
    public string Type { get; set; }
    public PayloadData Payload { get; set; }
}

public class PayloadData
{

    public string? Stream { get; set; }

    public string? IceCandidate { get; set; }
    public string? RoomId { get; set; }

    public string? UserId { get; set; }



}
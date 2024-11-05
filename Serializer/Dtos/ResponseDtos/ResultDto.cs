namespace Serializer.Dtos;

public class ResultDto
{
    public ResultDto(string message)
    {
        this.message = message;
    }

    public ResultDto(bool success, string message)
    {
        this.message = message;
        this.success = success;
    }
    public ResultDto(int statusCode, bool success, string message)
    {
        this.statusCode = statusCode;
        this.success = success;
        this.message = message;
    }
    public ResultDto(int statusCode, string message)
    {
        this.statusCode = statusCode;
        this.message = message;
    }
    public string message { get; set; } = "Successfully";
    public int statusCode { get; set; } = 200;
    public bool success { get; set; } = true;
}



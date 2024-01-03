namespace HttpClientDemo.Common.Dtos;

public class TodoResponse
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public bool IsComplete { get; set; }
}
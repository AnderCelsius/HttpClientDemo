using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HttpClientDemo.Api.Entities;

public class Todo
{
  private Todo(string name)
  {
    Name = name;
    IsComplete = false;
  }

  public static Todo CreateInstance(string name)
  {
    ArgumentException.ThrowIfNullOrEmpty(name);
    return new Todo(name);
  }

  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }
  public string? Name { get; set; }
  public bool IsComplete { get; set; }
}